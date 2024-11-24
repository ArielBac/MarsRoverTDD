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

            if (command == "f" && startDirection == "S")
            {
                return $"{startDirection},{startPoint.X},{startPoint.Y - 1}";
            }

            if (command == "f" && startDirection == "E")
            {
                return $"{startDirection},{startPoint.X + 1},{startPoint.Y}";
            }

            if (command == "f" && startDirection == "N")
            {
                if (startPointStr == "0,10")
                    return "N,0,0";

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
            var startCordinateArray = coordinate.Split(",");

            return new Point()
            {
                X = int.Parse(startCordinateArray[0]),
                Y = int.Parse(startCordinateArray[1])
            };
        }
    }

}
