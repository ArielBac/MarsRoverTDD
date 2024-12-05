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

        public void ReturnNewPosition(string startPosition, string command, string expectedNewPosition)
        {
            var result = MasterRoverService.Move(startPosition, command);

            result.Should().Be(expectedNewPosition);
        }

        [Theory]
        [InlineData("N, 0,10", "f", "N,0,0")]
        [InlineData("N, 1,10", "f", "N,1,0")]
        [InlineData("W, 0,0", "lf", "S,0,10")]
        public void ReturnNewPositionWhenEdge(string startPosition, string command, string expectedNewPosition)
        {
            var result = MasterRoverService.Move(startPosition, command);

            result.Should().Be(expectedNewPosition);
        }
    }
}