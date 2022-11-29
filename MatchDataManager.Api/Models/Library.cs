namespace MatchDataManager.Api.Models { };

public class Library : Entity
{
    public string BookName { get; set; }

    public string Author { get; set; }

    public string YearOFPublish { get; set; }

    public string CityOfPublish { get; set; }

}