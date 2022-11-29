using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MatchDataManager.Api.Controllers { };

[ApiController]
[Route("[controller]")]
public class LibraryController: ControllerBase
{
    [HttpPost]
    public IActionResult AddBook(Library book)
    {
        LibraryRepository.AddBook(book);
        return CreatedAtAction(nameof(GetById), new {id = book.Id}, book);
    }

    [HttpDelete]
    public IActionResult DeleteBook(Guid bookId)
    {
        LibraryRepository.DeleteBook(bookId);
        return NoContent();
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(LibraryRepository.GetAllBooks());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var book = LibraryRepository.GetBookById(id);
        if (book is null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    [HttpPut]
    public IActionResult UpdateBook(Library book)
    {
        LibraryRepository.UpdateLibrary(book);
        return Ok(book);
    }
}