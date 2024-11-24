namespace MarsRover
{
    public static class MasterRoverService
    {
        public static string Move(string startPosition, string command)
        {
            var startPositionArray = startPosition.Split(", ");
            var startDirection = startPositionArray[0];
            var startPoint = startPositionArray[1];
            var startPointArray = startPoint.Split(",");
            var x = int.Parse(startPointArray[0]);
            var y = int.Parse(startPointArray[1]);

            if (command == "f" && startDirection == "S")
            {
                return $"{startDirection},{x},{y - 1}";
            }

            if (command == "f" && startDirection == "E")
            {
                return $"{startDirection},{x + 1},{y}";
            }

            if (command == "f" && startDirection == "N")
            {
                if (startPoint == "0,10")
                    return "N,0,0";

                return $"{startDirection},{x},{y + 1}";
            }

            return "S,0,10";
        }
    }
}
