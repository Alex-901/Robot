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
                if(!Enum.TryParse(input, out Constants.RobotCommands command))
                {
                    if(ParseCommand(input, out int x, out int y, out Constants.Direction direction, out Constants.RobotCommands cmd))
                    {
                        inputCommand.Command = cmd;
                        inputCommand.X = x;
                        inputCommand.Y = y;
                        inputCommand.Direction = direction;

                        return true;
                    }
                    else
                    {
                        exceptionMessage = Constants.INVALIDCOMMAND;
                        return false;
                    }
                }
                else
                {
                    inputCommand.Command = command;
                    return true;
                }
            }
            catch (Exception)
            {
                exceptionMessage = Constants.INVALIDCOMMAND;
                return false;
            }
        }

        public static bool ParseCommand(string input, out int x, out int y, out Constants.Direction direction, out Constants.RobotCommands command)
        {
            try
            {
                var split = input.Split(' ');
                command = Constants.RobotCommands.PLACE;

                if (Enum.TryParse(split[0].ToUpper(), out Constants.RobotCommands splitCommand))
                {
                    command = splitCommand;
                }
                
                var split2 = split[1].Split(',');
                x = Convert.ToInt32(split2[0]);
                y = Convert.ToInt32(split2[1]);
                Enum.TryParse(split2[2].ToUpper(), out Constants.Direction placeDirection);

                direction = placeDirection;

                return true;
            }
            catch (Exception)
            {
                x = 0;
                y = 0;
                direction = Constants.Direction.NORTH;
                command = Constants.RobotCommands.PLACE;
                return false;
                //TODO: Output message
            }
        }
    }
}
