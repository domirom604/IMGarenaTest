using MatchDataManager.Api.Data;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Validations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace MatchDataManager.Api.Repositories;

public class TeamsRepository
{
    private static List<Team> _teams;
    
    public static void AddTeam(Team team)
    {
        ReadDatabase();
        var listTeam= _teams.Cast<object>().ToList();
        Validation validation = new Validation(team, listTeam);
       
        if (validation.checkers.NameChecker == true  && validation.checkers.ItemExister == false)
        {
            team.Id = Guid.NewGuid();
            var _teams  = new AuthDbContext();
            _teams.Add(new Team { Name = team.Name, CoachName = team.CoachName, Id=team.Id });
            _teams.SaveChanges();

        }
        else if (validation.checkers.ItemExister == true)
        {
            throw new ArgumentException("Puted team exist!", nameof(team));
        }
        else
        {
            throw new ArgumentException("Data doesn't match proper pattern!", nameof(team));
        }
    }

    public static void DeleteTeam(Guid teamId)
    {
        ReadDatabase();
        var _teams = new AuthDbContext();
        var _team = _teams.TeamTable.Where(b => b.Id== teamId);
        if (_team is not null)
        {
            _teams.Remove(_team.FirstOrDefault());
            _teams.SaveChanges();
        }
    }

    public static IEnumerable<Team> GetAllTeams()
    {
        ReadDatabase();
        return _teams;
    }

    public static Team GetTeamById(Guid id)
    {
        ReadDatabase();
        return _teams.FirstOrDefault(x => x.Id == id);
    }

    public static void UpdateTeam(Team team)
    {
        ReadDatabase();
        var _teams = new AuthDbContext();
        var _team = _teams.TeamTable.FirstOrDefault(b => b.Id == team.Id);
        if (_teams is null || team is null)
        {
            throw new ArgumentException("Team doesn't exist.", nameof(team));
        }

        _team.CoachName = team.CoachName;
        _team.Name = team.Name;
        _teams.SaveChanges();

    }
    public static void ReadDatabase()
    {
        _teams = new AuthDbContext().TeamTable.ToList();
    }


}