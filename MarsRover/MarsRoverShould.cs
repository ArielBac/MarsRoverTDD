namespace MarsRover
{
    public class MarsRoverShould
    {
        [Theory]
        [InlineData("N,0,0", "f", "N,0,1")]
        public void ReturnNewPsotion(string startPosition, string command, string expectedNewPosition)
        {
            var result = MasterRoverService.Move(startPosition, command);
        }
    }
}