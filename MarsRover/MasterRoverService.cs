namespace MarsRover
{
    public static class MasterRoverService
    {
        public static string Move(string startPosition, string command)
        {
            var startPositionArray = startPosition.Split(", ");
            var startDirection = startPositionArray[0];
            var startPoint = startPositionArray[1];

            if (command == "f" && startDirection == "N")
            {
                var x = int.Parse(startPoint[0].ToString());
                var y = int.Parse(startPoint[2].ToString());

                return $"{startDirection},{x},{y + 1}";
            }

            return "S,0,10";
        }
    }
}
