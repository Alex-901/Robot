using System;

namespace Robot
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AwaitCommand();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format(Constants.GENERALERROR, ex));
            }
        }

        public static void AwaitCommand()
        {
            var input = Console.ReadLine().ToUpper();

            if (!Helpers.ValidateAndParse(input, out string exception, out ConsoleCommand consoleCommand))
            {
                Console.WriteLine(exception);
                AwaitCommand();
            }
            else
            {
                var controller = new RobotController(consoleCommand);

                //Don't continue if the command is not place and the robot is not on the table 
                if (consoleCommand.Command != Constants.RobotCommands.PLACE && RobotState.CurrentDirection == Constants.Direction.NOTSET)
                {
                    Console.WriteLine(Constants.PLACECOMMANDFIRST);
                    AwaitCommand();
                }

                switch (consoleCommand.Command)
                {
                    case Constants.RobotCommands.MOVE:
                        controller.Move();
                        break;
                    case Constants.RobotCommands.REPORT:
                        Console.WriteLine(controller.Report());
                        break;
                    case Constants.RobotCommands.LEFT:
                        controller.Left();
                        break;
                    case Constants.RobotCommands.RIGHT:
                        controller.Right();
                        break;
                    case Constants.RobotCommands.PLACE:
                        controller.Place();
                        break;
                    default:
                        break;
                }
            }

            AwaitCommand();
        }
    }
}
