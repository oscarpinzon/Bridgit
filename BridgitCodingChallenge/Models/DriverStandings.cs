using static BridgitCodingChallenge.Models.SharedClasses;

namespace BridgitCodingChallenge.Models
{
    public class DriverStanding
    {
        public string position { get; set; }
        public string positionText { get; set; }
        public string points { get; set; }
        public string wins { get; set; }
        public Driver Driver { get; set; }
        public List<Constructor> Constructors { get; set; }
    }

    public class Root
    {
        public List<DriverStanding> DriverStandings { get; set; }
    }
}