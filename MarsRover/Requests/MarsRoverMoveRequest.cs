namespace MarsRover.Requests
{
    public class MarsRoverMoveRequest(string startPosition, string command)
    {
        public string StartPosition { get; set; } = startPosition.ToUpper();
        public string Command { get; set; } = command.ToLower();
    }
}
