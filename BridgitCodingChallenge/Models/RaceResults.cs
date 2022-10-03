using static BridgitCodingChallenge.Models.SharedClasses;

namespace BridgitCodingChallenge.Models
{
    public class AverageSpeed
    {
        public string units { get; set; }
        public string speed { get; set; }
    }

    public class Circuit
    {
        public string circuitId { get; set; }
        public string url { get; set; }
        public string circuitName { get; set; }
        public Location Location { get; set; }
    }

    public class FastestLap
    {
        public string rank { get; set; }
        public string lap { get; set; }
        public Time Time { get; set; }
        public AverageSpeed AverageSpeed { get; set; }
    }

    public class Location
    {
        public string lat { get; set; }
        public string @long { get; set; }
        public string locality { get; set; }
        public string country { get; set; }
    }

    public class Race
    {
        public string season { get; set; }
        public string round { get; set; }
        public string url { get; set; }
        public string raceName { get; set; }
        public Circuit Circuit { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        public string number { get; set; }
        public string position { get; set; }
        public string positionText { get; set; }
        public string points { get; set; }
        public Driver Driver { get; set; }
        public Constructor Constructor { get; set; }
        public string grid { get; set; }
        public string laps { get; set; }
        public string status { get; set; }
        public Time Time { get; set; }
        public FastestLap FastestLap { get; set; }
    }

    public class RaceResults
    {
        public List<Race> Races { get; set; }
    }

    public class Time
    {
        public string millis { get; set; }
        public string time { get; set; }
    }
}
