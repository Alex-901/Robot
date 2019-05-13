using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    public static class Helpers
    {
        public static bool ValidateAndParse(string input, out string exceptionMessage, out ConsoleCommand inputCommand)
        {
            exceptionMessage = string.Empty;
            inputCommand = new ConsoleCommand();
            
            try
            {
                var baseCommand = input.Split(' ');
                var commandFound = Enum.TryParse(baseCommand[0], out Constants.RobotCommands command);
                inputCommand.Command = command;

                if (!commandFound)
                {
                    exceptionMessage = Constants.INVALIDCOMMAND;
                    return false;
                }
                
                if (command == Constants.RobotCommands.PLACE)
                {
                    var placeSplit = baseCommand[1].Split(',');
                    inputCommand.X = Convert.ToInt32(placeSplit[0]);
                    inputCommand.Y = Convert.ToInt32(placeSplit[1]);
                    Enum.TryParse(placeSplit[2].ToUpper(), out Constants.Direction placeDirection);

                    inputCommand.Direction = placeDirection;
                }

                return true;
            }
            catch (Exception)
            {
                exceptionMessage = Constants.INVALIDCOMMAND;
                return false;
            }
        }
    }
}
