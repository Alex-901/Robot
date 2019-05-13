using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    public class ConsoleCommand
    {
        public Constants.RobotCommands Command { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Constants.Direction Direction { get; set; }
    }
}
