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
                
                if (validationObject is Location)
                {
                    List<Location> _locations = _list.Cast<Location>().ToList();
                    Location location = (Location)validationObject;
                    LocationName(location.Name, checkers, _locations);
                    CityNameChecker(location.City, checkers);
                }
                if (validationObject is Team)
                {
                    List<Team> _teams = _list.Cast<Team>().ToList();
                    Team team = (Team)validationObject;
                    TeamName(team.Name, checkers, _teams);
                    CoachNameChecker(team.CoachName, checkers);
                }
            }
        }

        public static void LocationName(string name, Checkers checkers, List<Location> _locations)
        {
            
            if(name != null && name.Length < 255 && name!="string")
            {

                checkers.NameChecker = true;
                LocationNameExistChecker(name, checkers, _locations);
            }
            else
            {
                checkers.NameChecker = false;
            }
        }

        public static void TeamName(string name, Checkers checkers, List<Team> _teams)
        {
            if (name != null && name.Length < 255 && name != "string")
            {
                checkers.NameChecker = true;
                TeamNameExistChecker(name, checkers, _teams);
            }
            else
            {
                checkers.NameChecker = false;
            }
        }

        public static void TeamNameExistChecker(string name, Checkers checkers, List<Team> _teams)
        {
            bool exist = false;
            exist =_teams.Exists(x => x.Name == name);
            if (exist==false)
            {
                checkers.ItemExister = false;
            }
            else
            {
                checkers.ItemExister = true;
            }
        }
        public static void LocationNameExistChecker(string name, Checkers checkers, List<Location> _locations)
        {
            bool exist = false;
            exist = _locations.Exists(x => x.Name == name);
            if (exist == false)
            {
                checkers.ItemExister = false;
            }
            else
            {
                checkers.ItemExister = true;
            }
        }


        public static void CityNameChecker(string city, Checkers checkers)
        {
            if (city != null && city.Length < 55 && city != "string")
            {
                checkers.CityChecker = true;
            }
            else
            {
                checkers.CityChecker = false;
            }
        }

        public static void CoachNameChecker(string coachName, Checkers checkers)
        {
            if (coachName == null && coachName.Length < 55 && coachName != "string")
            {
                checkers.CoachChecker = true;
            }
            else
            {
                checkers.CoachChecker = false;
            }
        }

    }

}
