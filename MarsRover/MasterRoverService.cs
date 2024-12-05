namespace MarsRover
{
    public static class MasterRoverService
    {
        private static bool IsForward(string command) => command == "f";
        private static bool IsNorth(string direction) => direction == "N";
        private static bool IsSouth(string direction) => direction == "S";
        private static bool IsEast(string direction) => direction == "E";
        private static bool IsWest(string direction) => direction == "W";

        public static string Move(string startPosition, string command)
        {
            var startPositionArray = startPosition.Split(", ");
            var startDirection = startPositionArray[0];
            var startPointStr = startPositionArray[1];
            var startPoint = Point.Parse(startPointStr);

            if (IsForward(command) && IsWest(startDirection))
            {
                if (startPoint.X == 0)
                    return $"{startDirection},20,{startPoint.Y}";

                return $"{startDirection},{startPoint.X - 1},{startPoint.Y}";
            }

            if (IsForward(command) && IsSouth(startDirection))
            {
                if (startPoint.Y == 0)
                    return $"{startDirection},{startPoint.X},10";

                return $"{startDirection},{startPoint.X},{startPoint.Y - 1}";
            }

            if (IsForward(command) && IsEast(startDirection))
            {
                if (startPoint.X == 20)
                    return $"{startDirection},0,{startPoint.Y}";

                return $"{startDirection},{startPoint.X + 1},{startPoint.Y}";
            }

            if (IsForward(command) && IsNorth(startDirection))
            {
                if (startPoint.Y == 10)
                    return $"{startDirection},{startPoint.X},0";

                return $"{startDirection},{startPoint.X},{startPoint.Y + 1}";
            }

            return "S,0,10";
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Point Parse(string coordinate)
        {
            var startCoordinateArray = coordinate.Split(",");

            return new Point()
            {
                X = int.Parse(startCoordinateArray[0]),
                Y = int.Parse(startCoordinateArray[1])
            };
        }
    }

}
