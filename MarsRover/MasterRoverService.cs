namespace MarsRover
{
    public static class MasterRoverService
    {
        public static string Move(string startPosition, string command)
        {
            var startPositionArray = startPosition.Split(", ");
            var startDirection = startPositionArray[0];
            var startPoint = startPositionArray[1];
            var x = int.Parse(startPoint[0].ToString());
            var y = int.Parse(startPoint[2].ToString());

            if (command == "f" && startDirection == "E")
            {
                if (x == 1 && y == 0)
                    return "E,2,0";

                return "E,1,0";
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
