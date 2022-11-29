using MatchDataManager.Api.Models;
using System.Xml.Linq;

namespace MatchDataManager.Api.Validations
{
    public class Validation: Checkers
    {
        public Checkers checkers = new Checkers();
        public Validation(object validationObject, List<object> _list)
        {

            if(validationObject != null)
            {
                
                if (validationObject is Library)
                {
                    List<Library> _libraries = _list.Cast<Library>().ToList();
                    Library library = (Library)validationObject;
                    LocationName(library.BookName, checkers, _libraries);
                    AuthorNameChecker(library.Author, checkers);
                }
               
            }
        }

        public static void LocationName(string name, Checkers checkers, List<Library> _libraies)
        {
            
            if(name != null && name.Length < 255 && name!="string")
            {

                checkers.BookNameChecker = true;
                BookNameExistChecker(name, checkers, _libraies);
            }
            else
            {
                checkers.BookNameChecker = false;
            }
        }

        
        public static void BookNameExistChecker(string name, Checkers checkers, List<Library> _libraies)
        {
            bool exist = false;
            exist = _libraies.Exists(x => x.BookName == name);
            if (exist == false)
            {
                checkers.ItemExister = false;
            }
            else
            {
                checkers.ItemExister = true;
            }
        }


        public static void AuthorNameChecker(string name, Checkers checkers)
        {
            if (name != null && name.Length < 55 && name != "string")
            {
                checkers.AuthorChecker = true;
            }
            else
            {
                checkers.AuthorChecker = false;
            }
        }

        public static void CoachNameChecker(string year, Checkers checkers)
        {
            if (year == null && year.Length < 55 && year != "string")
            {
                checkers.YearOFPublishChecker = true;
            }
            else
            {
                checkers.YearOFPublishChecker = false;
            }
        }

    }

}
