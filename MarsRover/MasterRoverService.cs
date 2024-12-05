namespace MarsRover
{
    public static class MasterRoverService
    {
        public static string Move(string startPosition, string command)
        {
            var startPositionArray = startPosition.Split(", ");
            var startDirection = startPositionArray[0];
            var startPointStr = startPositionArray[1];
            var startPoint = Point.Parse(startPointStr);

            if (command == "f" && startDirection == "W")
            {
                return $"{startDirection},{startPoint.X - 1},{startPoint.Y}";
            }

            if (command == "f" && startDirection == "S")
            {
                if (startPoint.Y == 0)
                    return $"{startDirection},{startPoint.X},10";

                return $"{startDirection},{startPoint.X},{startPoint.Y - 1}";
            }

            if (command == "f" && startDirection == "E")
            {
                if (startPointStr == "20,0")
                    return $"E,0,0";
            }

            if (command == "f" && startDirection == "N")
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
