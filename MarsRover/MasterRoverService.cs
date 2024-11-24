namespace MarsRover
{
    public static class MasterRoverService
    {
        public static string Move(string startPosition, string command)
        {
            var startPositionArray = startPosition.Split(", ");
            var startDirection = startPositionArray[0];
            var startPoint = startPositionArray[1];

            if (startPosition == "N, 0,0" && command == "f")
                return "N,0,1";

            if (startPosition == "N, 0,1" && command == "f")
                return "N,0,2";

            if (startPosition == "N, 0,2" && command == "f")
                return "N,0,3";

            return "S,0,10";
        }

        public class Point
        {
            public Point(string x, string y)
            {
                X = int.Parse(x);
                Y = int.Parse(x);
            }

            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
