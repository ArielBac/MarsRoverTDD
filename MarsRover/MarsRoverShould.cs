using FluentAssertions;

namespace MarsRover
{
    public class MarsRoverShould
    {
        [Theory]
        [InlineData("N, 0,0", "f", "N,0,1")]
        [InlineData("N, 0,1", "f", "N,0,2")]
        [InlineData("N, 0,2", "f", "N,0,3")]
        //
        [InlineData("S, 0,10", "f", "S,0,9")]
        [InlineData("S, 0,9", "f", "S,0,8")]
        [InlineData("S, 0,8", "f", "S,0,7")]
        //
        [InlineData("E, 0,0", "f", "E,1,0")]
        [InlineData("E, 1,0", "f", "E,2,0")]
        [InlineData("E, 2,0", "f", "E,3,0")]
        //
        [InlineData("W, 20,0", "f", "W,19,0")]
        [InlineData("W, 19,0", "f", "W,18,0")]
        [InlineData("W, 18,0", "f", "W,17,0")]
        // ========= //
        [InlineData("N, 0,10", "b", "N,0,9")]

        public void ReturnNewPosition(string startPosition, string command, string expectedNewPosition)
        {
            var result = MasterRoverService.Move(startPosition, command);

            result.Should().Be(expectedNewPosition);
        }

        [Theory]
        //
        [InlineData("N, 0,10", "f", "N,0,0")]
        [InlineData("N, 1,10", "f", "N,1,0")]
        [InlineData("N, 5,10", "f", "N,5,0")]
        //
        [InlineData("S, 0,0", "f", "S,0,10")]
        [InlineData("S, 5,0", "f", "S,5,10")]
        [InlineData("S, 10,0", "f", "S,10,10")]
        //
        [InlineData("E, 20,0", "f", "E,0,0")]
        [InlineData("E, 20,5", "f", "E,0,5")]
        [InlineData("E, 20,10", "f", "E,0,10")]
        //
        [InlineData("W, 0,0", "f", "W,20,0")]
        [InlineData("W, 0,5", "f", "W,20,5")]
        [InlineData("W, 0,10", "f", "W,20,10")]
        //
        [InlineData("W, 0,0", "lf", "S,0,10")]
        public void ReturnNewPositionWhenEdge(string startPosition, string command, string expectedNewPosition)
        {
            var result = MasterRoverService.Move(startPosition, command);

            result.Should().Be(expectedNewPosition);
        }
    }
}