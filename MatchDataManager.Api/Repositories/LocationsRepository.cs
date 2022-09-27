using MatchDataManager.Api.Data;
using MatchDataManager.Api.Database;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Validations;
using System.IO;

namespace MatchDataManager.Api.Repositories;

public static class LocationsRepository
{
    private static List<Location> _locations;

    public static void AddLocation(Location location)
    {
        ReadDatabase();
        var listLocations = _locations.Cast<object>().ToList();
        Validation validation = new Validation(location, listLocations);
    
        if(validation.checkers.NameChecker==true && validation.checkers.CityChecker ==true && validation.checkers.ItemExister == false)
        {
            location.Id = Guid.NewGuid();
            var _locations = new AuthDbContext();
            _locations.Add(new Location { Name = location.Name, City = location.City, Id = location.Id });
            _locations.SaveChanges();
        }
        else if (validation.checkers.ItemExister == true)
        {
            throw new ArgumentException("Puted location exist!", nameof(location));
        }
        else
        {
            throw new ArgumentException("Data doesn't match proper pattern!", nameof(location));
        }
        
    }

    public static void DeleteLocation(Guid locationId)
    {
        ReadDatabase();
        var _locations = new AuthDbContext();
        var _location = _locations.LocationTable.Where(b => b.Id == locationId);
        if (_location is not null)
        {
            _locations.Remove(_location.FirstOrDefault());
            _locations.SaveChanges();
        }
    }

    public static IEnumerable<Location> GetAllLocations()
    {
        ReadDatabase();
        return _locations;
    }

    public static Location GetLocationById(Guid id)
    {
        ReadDatabase();
        return _locations.FirstOrDefault(x => x.Id == id);
    }

    public static void UpdateLocation(Location location)
    {
        ReadDatabase();
        var listLocations = _locations.Cast<object>().ToList();
        Validation validation = new Validation(location, listLocations);

        var _locations_db = new AuthDbContext();
        var _location = _locations_db.LocationTable.FirstOrDefault(b => b.Id == location.Id);

        if (_locations is null || location is null)
        {
            throw new ArgumentException("Location doesn't exist.", nameof(location));
        }
        if(validation.checkers.ItemExister == true)
        {
            throw new ArgumentException("Location name exist.", nameof(location));
        }

        _location.City = location.City;
        _location.Name = location.Name;
        _locations_db.SaveChanges();
    }

    public static void ReadDatabase()
    {
        _locations = new AuthDbContext().LocationTable.ToList();
    }

}