namespace MarsRover.Responses
{
    public class MarsRoverMoveResponse(string newPosition)
    {
        public string? NewPosition { get; set; } = newPosition;
    }
}
