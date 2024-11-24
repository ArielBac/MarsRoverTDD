using FluentAssertions;

namespace MarsRover
{
    public class MarsRoverShould
    {
        [Theory]
        [InlineData("N,0,0", "f", "N,0,1")]
        public void ReturnNewPosition(string startPosition, string command, string expectedNewPosition)
        {
            var result = MasterRoverService.Move(startPosition, command);

            result.Should().Be(expectedNewPosition);
        }
    }
}