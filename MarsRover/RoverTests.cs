using FluentAssertions;
using NUnit.Framework;

namespace MarsRover
{
    [TestFixture( Author ="Muhsin Meydan")]
    public class RoverTests
    {
        Rover _rover;
        [SetUp]
        public void Setup()
        {
            _rover = new Rover(new Point(0,0), "N");
        }

        [TestCase("R", ExpectedResult ="0:0:E")]
        [TestCase("RR", ExpectedResult = "0:0:S")]
        [TestCase("RRR", ExpectedResult = "0:0:W")]
        [TestCase("RRRR", ExpectedResult = "0:0:N")]
        public string MoveRight(string command)
        {
            var actualResult = _rover.Execute(command); 
            return actualResult;
        }

        [TestCase("L", ExpectedResult = "0:0:W")]
        [TestCase("LL", ExpectedResult = "0:0:S")]
        [TestCase("LLL", ExpectedResult = "0:0:E")]
        [TestCase("LLLL", ExpectedResult = "0:0:N")]
        public string MoveLeft(string command)
        {
            var actualResult = _rover.Execute(command);
            return actualResult;
        }

        [TestCase("M", ExpectedResult = "0:1:N")]
        [TestCase("MMM", ExpectedResult = "0:3:N")]
        [TestCase("MMMMMMMMMM", ExpectedResult = "0:0:N")]
        [TestCase("MMMMMMMMMMMMMMM", ExpectedResult = "0:5:N")]
        public string Move(string command)
        {
            var actualResult = _rover.Execute(command);
            return actualResult;
        }

        [TestCase("RM", ExpectedResult = "1:0:E")]
        [TestCase("RMMMMM", ExpectedResult = "5:0:E")]
        [TestCase("LM", ExpectedResult = "9:0:W")]
        [TestCase("LLMMMMM", ExpectedResult = "0:5:S")]
        public string MixMove(string command)
        {
            var actualResult = _rover.Execute(command);
            return actualResult;
        }

        [TestCase("MMMM", new int[] { 0, 4 }, ExpectedResult = "0:0:3:N")]
        [TestCase("RMMMMMM", new int[] { 2, 0 }, ExpectedResult = "0:1:0:E")]
        public string ObstcleMove(string command, int[] obstclePoint)
        {
            _rover.SetObstcle(new Point(obstclePoint[0], obstclePoint[1]));
            var actualResult = _rover.Execute(command);
            return actualResult;
        }
    }
}