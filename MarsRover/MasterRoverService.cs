namespace MarsRover
{
    public static class MasterRoverService
    {
        private static bool IsForward(string command) => command == "f";
        private static bool IsBackward(string command) => command == "b";
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

            if (IsNorth(startDirection) && command == "lf")
                return $"W,{startPoint.X - 1},{startPoint.Y}";

            if (IsSouth(startDirection) && command == "lf")
                return $"E,{startPoint.X + 1},{startPoint.Y}";

            if (IsBackward(command))
            {
                return MoveBackward(startPoint, startDirection);
            }

            if (IsForward(command))
            {
                return MoveForward(startPoint, startDirection);
            }

            return "S,0,10";
        }

        private static string MoveForward(Point startPoint, string startDirection)
        {
            if (IsWest(startDirection))
            {
                if (startPoint.X == 0)
                    return $"{startDirection},20,{startPoint.Y}";

                return $"{startDirection},{startPoint.X - 1},{startPoint.Y}";
            }

            if (IsSouth(startDirection))
            {
                if (startPoint.Y == 0)
                    return $"{startDirection},{startPoint.X},10";

                return $"{startDirection},{startPoint.X},{startPoint.Y - 1}";
            }

            if (IsEast(startDirection))
            {
                if (startPoint.X == 20)
                    return $"{startDirection},0,{startPoint.Y}";

                return $"{startDirection},{startPoint.X + 1},{startPoint.Y}";
            }

            if (IsNorth(startDirection))
            {
                if (startPoint.Y == 10)
                    return $"{startDirection},{startPoint.X},0";

                return $"{startDirection},{startPoint.X},{startPoint.Y + 1}";
            }

            return string.Empty;
        }

        private static string MoveBackward(Point startPoint, string startDirection)
        {
            if (IsWest(startDirection))
            {
                if (startPoint.X == 20)
                    return $"{startDirection},0,{startPoint.Y}";

                return $"{startDirection},{startPoint.X + 1},{startPoint.Y}";
            }

            if (IsEast(startDirection))
            {
                if (startPoint.X == 0)
                    return $"{startDirection},20,{startPoint.Y}";

                return $"{startDirection},{startPoint.X - 1},{startPoint.Y}";
            }

            if (IsSouth(startDirection))
            {
                if (startPoint.Y == 10)
                    return $"{startDirection},{startPoint.X},0";

                return $"{startDirection},{startPoint.X},{startPoint.Y + 1}";
            }

            if (IsNorth(startDirection))
            {
                if (startPoint.Y == 0)
                    return $"{startDirection},{startPoint.X},10";

                return $"{startDirection},{startPoint.X},{startPoint.Y - 1}";
            }

            return string.Empty;
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
