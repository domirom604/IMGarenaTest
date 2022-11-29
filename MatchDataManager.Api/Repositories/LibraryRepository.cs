using MatchDataManager.Api.Data;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Validations;
using System.IO;

namespace MatchDataManager.Api.Repositories { };

public  class LibraryRepository
{
    private static List<Library> _books;

    public static void AddBook(Library library)
    {
        ReadDatabase();
        var listOfBooks = _books.Cast<object>().ToList();
        Validation validation = new Validation(library, listOfBooks);
    
        if(validation.checkers.BookNameChecker==true && validation.checkers.AuthorChecker ==true && validation.checkers.ItemExister == false)
        {
            library.Id = Guid.NewGuid();
            var _books = new AuthDbContext();
            _books.Add(new Library { BookName = library.BookName, Author = library.Author, Id = library.Id, CityOfPublish= library.CityOfPublish, YearOFPublish= library.YearOFPublish });
            _books.SaveChanges();
        }
        else if (validation.checkers.ItemExister == true)
        {
            throw new ArgumentException("Puted book exist!", nameof(library));
        }
        else
        {
            throw new ArgumentException("Data doesn't match proper pattern!", nameof(library));
        }
        
    }

    public static void DeleteBook(Guid bookId)
    {
        ReadDatabase();
        var _books = new AuthDbContext();
        var _book = _books.BookTable.Where(b => b.Id == bookId);
        if (_book is not null)
        {
            _books.Remove(_book.FirstOrDefault());
            _books.SaveChanges();
        }
    }

    public static IEnumerable<Library> GetAllBooks()
    {
        ReadDatabase();
        return _books;
    }

    public static Library GetBookById(Guid id)
    {
        ReadDatabase();
        return _books.FirstOrDefault(x => x.Id == id);
    }

    public static void UpdateLibrary(Library library)
    {
        ReadDatabase();
        var listBooks = _books.Cast<object>().ToList();
        Validation validation = new Validation(library, listBooks);

        var _books_db = new AuthDbContext();
        var _book = _books_db.BookTable.FirstOrDefault(b => b.Id == library.Id);

        if (_books is null || library is null)
        {
            throw new ArgumentException("Book doesn't exist.", nameof(library));
        }
        if(validation.checkers.ItemExister == true)
        {
            throw new ArgumentException("Book name exist.", nameof(library));
        }

        _book.Author = library.Author;
        _book.BookName = library.BookName;
        _books_db.SaveChanges();
    }

    public static void ReadDatabase()
    {
        _books = new AuthDbContext().BookTable.ToList();
    }

}