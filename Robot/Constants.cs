using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    public static class Constants
    {
        public const int MAXROWS = 4;
        public const int MAXCOLUMNS = 4;

        public const int MINROWS = 0;
        public const int MINCOLUMNS = 0;

        public const string INVALIDCOMMAND = "The command you have entered in not valid";
        public const string PLACECOMMANDFIRST = "PLACE must be the first command";
        public const string GENERALERROR = "An exception has occured: {0}";

        public enum RobotCommands
        {
            MOVE,
            REPORT,
            LEFT,
            RIGHT,
            PLACE
        }
        public enum Direction
        {
            NORTH,
            SOUTH,
            WEST,
            EAST,
            NOTSET
        }
    }
}
