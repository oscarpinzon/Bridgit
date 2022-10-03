using BridgitCodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BridgitCodingChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class F1Controller : ControllerBase
    {
        private readonly ILogger<F1Controller> _logger;

        public F1Controller(ILogger<F1Controller> logger)
        {
            //logger not used, but will be useful in real projects
            _logger = logger;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            return BadRequest(new { message = "Please use routes 'api/f1/{year}/standings' or 'api/f1/{year}/{round}/results'", status = StatusCodes.Status400BadRequest });
        }


        [HttpGet("{year}/standings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<DriverStanding>> GetStandings(int year)
        {
            if (year != 2021)
                return BadRequest(new { message = "Only year allowed is 2021", status = StatusCodes.Status400BadRequest });

            Root root = JsonFileReader.Read<Root>("Data/driverStandings.json");
            return root.DriverStandings;
        }

        [HttpGet("{year}/{round}/results")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Race>> GetRaceResults(int year, int round)
        {
            if (year != 2021)
                return BadRequest(new { message = "Only year allowed is 2021", status = StatusCodes.Status400BadRequest });

            if (round < Constants.Constants.MIN_ROUND || round > Constants.Constants.MAX_ROUND)
                return BadRequest(new { message = "Only rounds between 1 and 22 are allowed", status = StatusCodes.Status400BadRequest });


            RaceResults raceResults = JsonFileReader.Read<RaceResults>($"Data/RaceResults/raceResultRound{round}.json");
            return raceResults.Races;
        }
    }

    public static class JsonFileReader
    {
        public static T Read<T>(string filePath)
        {
            string text = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(text);
        }
    }
}