using FluentAssertions;

namespace MarsRover
{
    public class MarsRoverShould
    {
        [Theory]
        [InlineData("N, 0,0", "f", "N,0,1")]
        [InlineData("N, 0,1", "f", "N,0,2")]
        [InlineData("N, 0,2", "f", "N,0,3")]

        public void ReturnNewPosition(string startPosition, string command, string expectedNewPosition)
        {
            var result = MasterRoverService.Move(startPosition, command);

            result.Should().Be(expectedNewPosition);
        }

        [Theory]
        [InlineData("N, 0,10", "f", "N,0,0")]
        [InlineData("W, 0,0", "lf", "S,0,10")]
        public void ReturnNewPositionWhenEdge(string startPosition, string command, string expectedNewPosition)
        {
            var result = MasterRoverService.Move(startPosition, command);

            result.Should().Be(expectedNewPosition);
        }
    }
}