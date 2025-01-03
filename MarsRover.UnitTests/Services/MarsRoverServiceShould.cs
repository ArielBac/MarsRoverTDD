using FluentAssertions;
using MarsRover.Services;

namespace MarsRover.UnitTests.Services
{
    public class MarsRoverServiceShould
    {
        // ------------ Forward ----------- //
        [Theory]
        [InlineData("N, 0,0", "f", "N, 0,1")]
        [InlineData("N, 0,1", "f", "N, 0,2")]
        [InlineData("N, 0,2", "f", "N, 0,3")]
        [InlineData("S, 0,10", "f", "S, 0,9")]
        [InlineData("S, 0,9", "f", "S, 0,8")]
        [InlineData("S, 0,8", "f", "S, 0,7")]
        [InlineData("E, 0,0", "f", "E, 1,0")]
        [InlineData("E, 1,0", "f", "E, 2,0")]
        [InlineData("E, 2,0", "f", "E, 3,0")]
        [InlineData("W, 20,0", "f", "W, 19,0")]
        [InlineData("W, 19,0", "f", "W, 18,0")]
        [InlineData("W, 18,0", "f", "W, 17,0")]
        // ------------ Backward ----------- //
        [InlineData("N, 0,10", "b", "N, 0,9")]
        [InlineData("N, 0,5", "b", "N, 0,4")]
        [InlineData("N, 0,1", "b", "N, 0,0")]
        [InlineData("S, 0,0", "b", "S, 0,1")]
        [InlineData("S, 0,5", "b", "S, 0,6")]
        [InlineData("S, 0,9", "b", "S, 0,10")]
        [InlineData("E, 20,0", "b", "E, 19,0")]
        [InlineData("E, 10,1", "b", "E, 9,1")]
        [InlineData("E, 1,2", "b", "E, 0,2")]
        [InlineData("W, 0,0", "b", "W, 1,0")]
        [InlineData("W, 5,1", "b", "W, 6,1")]
        [InlineData("W, 19,2", "b", "W, 20,2")]
        // ------------ Left - Forward ----------- //
        [InlineData("N, 1,0", "lf", "W, 0,0")]
        [InlineData("N, 2,1", "lf", "W, 1,1")]
        [InlineData("N, 5,2", "lf", "W, 4,2")]
        [InlineData("S, 1,0", "lf", "E, 2,0")]
        [InlineData("S, 2,1", "lf", "E, 3,1")]
        [InlineData("S, 5,2", "lf", "E, 6,2")]
        [InlineData("E, 1,0", "lf", "N, 1,1")]
        [InlineData("E, 2,1", "lf", "N, 2,2")]
        [InlineData("E, 5,2", "lf", "N, 5,3")]
        [InlineData("W, 0,1", "lf", "S, 0,0")]
        [InlineData("W, 2,1", "lf", "S, 2,0")]
        [InlineData("W, 5,2", "lf", "S, 5,1")]
        // ------------ Left - Backward ----------- //
        [InlineData("N, 1,0", "lb", "W, 2,0")]
        [InlineData("N, 2,1", "lb", "W, 3,1")]
        [InlineData("N, 5,2", "lb", "W, 6,2")]
        [InlineData("S, 1,0", "lb", "E, 0,0")]
        [InlineData("S, 2,1", "lb", "E, 1,1")]
        [InlineData("S, 5,2", "lb", "E, 4,2")]
        [InlineData("E, 1,1", "lb", "N, 1,0")]
        [InlineData("E, 2,2", "lb", "N, 2,1")]
        [InlineData("E, 5,3", "lb", "N, 5,2")]
        [InlineData("W, 0,1", "lb", "S, 0,2")]
        [InlineData("W, 2,1", "lb", "S, 2,2")]
        [InlineData("W, 5,2", "lb", "S, 5,3")]
        // ------------ Right - Forward ----------- //
        [InlineData("N, 0,0", "rf", "E, 1,0")]
        [InlineData("N, 2,3", "rf", "E, 3,3")]
        [InlineData("N, 6,4", "rf", "E, 7,4")]
        [InlineData("S, 1,0", "rf", "W, 0,0")]
        [InlineData("S, 2,1", "rf", "W, 1,1")]
        [InlineData("S, 5,2", "rf", "W, 4,2")]
        [InlineData("E, 1,1", "rf", "S, 1,0")]
        [InlineData("E, 2,1", "rf", "S, 2,0")]
        [InlineData("E, 5,2", "rf", "S, 5,1")]
        [InlineData("W, 0,1", "rf", "N, 0,2")]
        [InlineData("W, 2,1", "rf", "N, 2,2")]
        [InlineData("W, 5,2", "rf", "N, 5,3")]
        // ------------ Right - Backward ----------- //
        [InlineData("N, 1,1", "rb", "E, 0,1")]
        [InlineData("N, 2,3", "rb", "E, 1,3")]
        [InlineData("N, 6,4", "rb", "E, 5,4")]
        [InlineData("S, 1,0", "rb", "W, 2,0")]
        [InlineData("S, 2,1", "rb", "W, 3,1")]
        [InlineData("S, 5,2", "rb", "W, 6,2")]
        [InlineData("E, 1,1", "rb", "S, 1,2")]
        [InlineData("E, 2,1", "rb", "S, 2,2")]
        [InlineData("E, 5,2", "rb", "S, 5,3")]
        [InlineData("W, 0,1", "rb", "N, 0,0")]
        [InlineData("W, 2,1", "rb", "N, 2,0")]
        [InlineData("W, 5,2", "rb", "N, 5,1")]
        public void ReturnNewPosition(string startPosition, string command, string expectedNewPosition)
        {
            var result = MarsRoverService.Move(startPosition, command);

            result.Should().Be(expectedNewPosition);
        }

        [Theory]
        // ------------ Forward ----------- //
        [InlineData("N, 1,1", "ff", "N, 1,3")]
        [InlineData("N, 1,1", "fff", "N, 1,4")]
        [InlineData("N, 1,3", "ffff", "N, 1,7")]
        [InlineData("S, 0,10", "ff", "S, 0,8")]
        [InlineData("S, 0,9", "fff", "S, 0,6")]
        [InlineData("E, 0,0", "ff", "E, 2,0")]
        [InlineData("E, 1,0", "fff", "E, 4,0")]
        [InlineData("W, 20,0", "ff", "W, 18,0")]
        [InlineData("W, 19,0", "fff", "W, 16,0")]
        // ------------ Backward ----------- //
        [InlineData("N, 0,10", "bb", "N, 0,8")]
        [InlineData("N, 0,5", "bbb", "N, 0,2")]
        [InlineData("S, 0,0", "bb", "S, 0,2")]
        [InlineData("S, 0,5", "bbb", "S, 0,8")]
        [InlineData("E, 20,0", "bb", "E, 18,0")]
        [InlineData("E, 10,1", "bbb", "E, 7,1")]
        [InlineData("W, 0,0", "bb", "W, 2,0")]
        [InlineData("W, 5,1", "bbb", "W, 8,1")]
        // ------------ Left - Forward ----------- //
        [InlineData("N, 1,5", "llff", "S, 1,3")]
        [InlineData("N, 1,5", "llllfff", "N, 1,8")]
        [InlineData("S, 0,0", "llfff", "N, 0,3")]
        [InlineData("E, 5,0", "llfff", "W, 2,0")]
        [InlineData("W, 5,0", "lllfff", "N, 5,3")]
        // ------------ Left - Backward ----------- //
        [InlineData("N, 1,5", "llbb", "S, 1,7")]
        [InlineData("N, 1,5", "llllbbbb", "N, 1,1")]
        [InlineData("S, 0,3", "llbbb", "N, 0,0")]
        [InlineData("E, 5,0", "llbbb", "W, 8,0")]
        [InlineData("W, 5,3", "lllbbb", "N, 5,0")]
        // ------------ Right - Forward ----------- //
        [InlineData("N, 5,5", "rrff", "S, 5,3")]
        [InlineData("S, 5,5", "rrrfff", "E, 8,5")]
        [InlineData("E, 5,5", "rrfff", "W, 2,5")]
        [InlineData("W, 5,5", "rrrff", "S, 5,3")]
        // ------------ Right - Backward ----------- //
        [InlineData("N, 5,5", "rrbb", "S, 5,7")]
        [InlineData("S, 5,5", "rrrbbb", "E, 2,5")]
        [InlineData("E, 5,5", "rrbbb", "W, 8,5")]
        [InlineData("W, 5,5", "rrrbb", "S, 5,7")]
        // Random
        [InlineData("N, 5,3", "llfrbblff", "S, 7,0")]
        [InlineData("S, 10,10", "rfrflfrrbb", "E, 6,0")]
        [InlineData("E, 0,0", "blbbbrrffff", "S, 20,4")]
        [InlineData("W, 5,3", "lfrrbblf", "W, 4,0")]
        public void ReturnNewPositionWhenMultipleCommands(string startPosition, string command, string expectedNewPosition)
        {
            var result = MarsRoverService.Move(startPosition, command);

            result.Should().Be(expectedNewPosition);
        }

        // ------------ Forward ----------- //
        [Theory]
        [InlineData("N, 0,10", "f", "N, 0,0")]
        [InlineData("N, 1,10", "f", "N, 1,0")]
        [InlineData("N, 5,10", "f", "N, 5,0")]
        [InlineData("S, 0,0", "f", "S, 0,10")]
        [InlineData("S, 5,0", "f", "S, 5,10")]
        [InlineData("S, 10,0", "f", "S, 10,10")]
        [InlineData("E, 20,0", "f", "E, 0,0")]
        [InlineData("E, 20,5", "f", "E, 0,5")]
        [InlineData("E, 20,10", "f", "E, 0,10")]
        [InlineData("W, 0,0", "f", "W, 20,0")]
        [InlineData("W, 0,5", "f", "W, 20,5")]
        [InlineData("W, 0,10", "f", "W, 20,10")]
        // ------------ Backward ----------- //
        [InlineData("N, 0,0", "b", "N, 0,10")]
        [InlineData("N, 1,0", "b", "N, 1,10")]
        [InlineData("N, 5,0", "b", "N, 5,10")]
        [InlineData("S, 0,10", "b", "S, 0,0")]
        [InlineData("S, 5,10", "b", "S, 5,0")]
        [InlineData("S, 20,10", "b", "S, 20,0")]
        [InlineData("E, 0,0", "b", "E, 20,0")]
        [InlineData("E, 0,5", "b", "E, 20,5")]
        [InlineData("E, 0,10", "b", "E, 20,10")]
        [InlineData("W, 20,0", "b", "W, 0,0")]
        [InlineData("W, 20,5", "b", "W, 0,5")]
        [InlineData("W, 20,10", "b", "W, 0,10")]
        // -------------------------------- //
        [InlineData("N, 0,0", "rb", "E, 20,0")]
        [InlineData("S, 0,0", "frf", "W, 20,10")]
        [InlineData("E, 20,10", "ffrbb", "S, 1,1")]
        [InlineData("W, 0,0", "lf", "S, 0,10")]
        public void ReturnNewPositionWhenEdge(string startPosition, string command, string expectedNewPosition)
        {
            var result = MarsRoverService.Move(startPosition, command);

            result.Should().Be(expectedNewPosition);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ThrowExceptionWhenNullOrEmptyStartPosition(string startPosition)
        {
            var result = () => MarsRoverService.Move(startPosition, "f");

            result.Should()
                .Throw<ArgumentException>()
                .WithMessage("Start position cannot be null or empty.");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ThrowExceptionWhenNullOrEmptyCommand(string command)
        {
            var result = () => MarsRoverService.Move("N, 0,0", command);

            result.Should()
                .Throw<ArgumentException>()
                .WithMessage("Command cannot be null or empty.");
        }
    }
}