using BridgitCodingChallenge.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BridgitCodingChallengeTests
{
    public class F1ControllerTests
    {
        private readonly F1Controller _controller;
        ILogger<F1Controller> logger = Mock.Of<ILogger<F1Controller>>();

        public F1ControllerTests()
        {
            _controller = new F1Controller(logger);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsBadRequest()
        {
            //Act
            var badRequestResult = _controller.Get();
            //Assert
            Assert.IsType<BadRequestObjectResult>(badRequestResult);
        }

        [Fact]
        public void GetStandings_WhenCalled_ReturnsBadRequest()
        {
            //Act
            var badYear = 2020;
            var actionResult = _controller.GetStandings(badYear);

            //Assert
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public void GetStandings_WhenCalled_ReturnsStandings()
        {
            //Act
            var acceptableYear = 2021;
            var actionResult = _controller.GetStandings(acceptableYear);

            //Assert
            var result = actionResult.Value;
            Assert.NotNull(result);
        }

        [Fact]
        public void GetRaceResults_WhenCalled_ReturnsBadRequest()
        {
            //Act
            var badRequestResult = _controller.GetRaceResults(123, 123);

            //Assert
            Assert.IsType<BadRequestObjectResult>(badRequestResult.Result);
        }

        [Fact]
        public void GetRaceResults_WhenCalled_ReturnsRaceResults()
        {
            //Act
            var acceptableYear = 2021;
            var acceptableRound = 5;
            var actionResult = _controller.GetRaceResults(acceptableYear, acceptableRound);

            //Assert
            var result = actionResult.Value;
            Assert.NotNull(result);
        }

        // Could get deeper into testing using [Theory]
    }
}