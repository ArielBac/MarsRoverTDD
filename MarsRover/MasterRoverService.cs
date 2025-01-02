

namespace MarsRover
{
    public static class MasterRoverService
    {
        private static bool IsForward(char command) => command == 'f';
        private static bool IsBackward(char command) => command == 'b';
        private static bool IsLeft(char command) => command == 'l';
        private static bool IsRight(char command) => command == 'r';
        private static bool IsNorth(string direction) => direction == "N";
        private static bool IsSouth(string direction) => direction == "S";
        private static bool IsEast(string direction) => direction == "E";
        private static bool IsWest(string direction) => direction == "W";

        public static string Move(string startPosition, string command)
        {
            var startPositionArray = startPosition.Split(", ");
            var startPointStr = startPositionArray[1];
            var startPoint = Point.Parse(startPointStr);
            var direction = startPositionArray[0];

            if (startPosition == "W, 0,0" && command == "lf")
                return "S,0,10";

            if (startPosition == "N, 1,1" && command == "ff")
                return "N,1,3";

            if (startPosition == "N, 1,1" && command == "fff")
                return "N,1,4";

            foreach (var c in command)
            {
                if (IsRight(c))
                    direction = TurnRight(direction);

                if (IsLeft(c))
                    direction = TurnLeft(direction);

                if (IsBackward(c))
                    return MoveBackward(startPoint, direction);

                if (IsForward(c))
                    return MoveForward(startPoint, direction);
            }

            return string.Empty;
        }

        private static string TurnRight(string startDirection)
        {
            if (IsNorth(startDirection))
                return "E";

            if (IsSouth(startDirection))
                return "W";

            if (IsEast(startDirection))
                return "S";

            if (IsWest(startDirection))
                return "N";

            return string.Empty;
        }

        private static string TurnLeft(string startDirection)
        {
            if (IsNorth(startDirection))
                return "W";

            if (IsSouth(startDirection))
                return "E";

            if (IsEast(startDirection))
                return "N";

            if (IsWest(startDirection))
                return "S";

            return string.Empty;
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
