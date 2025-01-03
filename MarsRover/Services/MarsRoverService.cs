namespace MarsRover.Services
{
    public static class MarsRoverService
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
            var pointStr = startPositionArray[1];
            var direction = startPositionArray[0];

            foreach (var c in command)
            {
                var point = Point.Parse(pointStr);

                if (IsRight(c))
                    direction = TurnRight(direction);

                if (IsLeft(c))
                    direction = TurnLeft(direction);

                if (IsBackward(c))
                    pointStr = MoveBackward(point, direction);

                if (IsForward(c))
                    pointStr = MoveForward(point, direction);
            }

            return $"{direction}, {pointStr}";
        }

        private static string TurnRight(string direction)
        {
            if (IsNorth(direction))
                return "E";

            if (IsSouth(direction))
                return "W";

            if (IsEast(direction))
                return "S";

            if (IsWest(direction))
                return "N";

            return string.Empty;
        }

        private static string TurnLeft(string direction)
        {
            if (IsNorth(direction))
                return "W";

            if (IsSouth(direction))
                return "E";

            if (IsEast(direction))
                return "N";

            if (IsWest(direction))
                return "S";

            return string.Empty;
        }

        private static string MoveForward(Point point, string direction)
        {
            if (IsWest(direction))
            {
                if (point.X == 0)
                    return $"20,{point.Y}";

                return $"{point.X - 1},{point.Y}";
            }

            if (IsSouth(direction))
            {
                if (point.Y == 0)
                    return $"{point.X},10";

                return $"{point.X},{point.Y - 1}";
            }

            if (IsEast(direction))
            {
                if (point.X == 20)
                    return $"0,{point.Y}";

                return $"{point.X + 1},{point.Y}";
            }

            if (IsNorth(direction))
            {
                if (point.Y == 10)
                    return $"{point.X},0";

                return $"{point.X},{point.Y + 1}";
            }

            return string.Empty;
        }

        private static string MoveBackward(Point point, string direction)
        {
            if (IsWest(direction))
            {
                if (point.X == 20)
                    return $"0,{point.Y}";

                return $"{point.X + 1},{point.Y}";
            }

            if (IsEast(direction))
            {
                if (point.X == 0)
                    return $"20,{point.Y}";

                return $"{point.X - 1},{point.Y}";
            }

            if (IsSouth(direction))
            {
                if (point.Y == 10)
                    return $"{point.X},0";

                return $"{point.X},{point.Y + 1}";
            }

            if (IsNorth(direction))
            {
                if (point.Y == 0)
                    return $"{point.X},10";

                return $"{point.X},{point.Y - 1}";
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
            var coordinateArray = coordinate.Split(",");

            return new Point()
            {
                X = int.Parse(coordinateArray[0]),
                Y = int.Parse(coordinateArray[1])
            };
        }
    }

}
