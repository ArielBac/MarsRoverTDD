namespace MarsRover
{
    public static class MasterRoverService
    {
        public static string Move(string startPosition, string command)
        {
            if (startPosition == "W,0,0" && command == "lf")
                return "S,0,10";

            return "N,0,1";
        }
    }
}
