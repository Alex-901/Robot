using System;
using static Robot.RobotController;

namespace Robot
{
    public class Program
    {
        static void Main(string[] args)
        {
            AwaitCommand();
        }

        public static void AwaitCommand()
        {
            var input = Console.ReadLine().ToUpper();
            var split = input.Split(' ');
            var controller = new RobotController();

            if(split[0] != null && Enum.TryParse(split[0], out RobotCommands command))
            {
                //Don't continue if the command is not place and the robot is not on the table 
                if (command != RobotCommands.PLACE && RobotState.CurrentDirection == Direction.NOTSET)
                {
                    AwaitCommand();
                }

                switch (command)
                {
                    case RobotCommands.MOVE:
                        controller.Move();
                        break;
                    case RobotCommands.REPORT:
                        Console.WriteLine(controller.Report());
                        break;
                    case RobotCommands.LEFT:
                        controller.Left();
                        break;
                    case RobotCommands.RIGHT:
                        controller.Right();
                        break;
                    case RobotCommands.PLACE:
                        ParseCommand(split[1], out int x, out int y, out Direction direction);
                        controller.Place(direction, x, y);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Command: Please Pass one of the following:");
                Console.WriteLine(RobotCommands.MOVE);
                Console.WriteLine(RobotCommands.REPORT);
                Console.WriteLine(RobotCommands.LEFT);
                Console.WriteLine(RobotCommands.RIGHT);
                Console.WriteLine(RobotCommands.PLACE);
            }

            AwaitCommand();
        }

        public static void ParseCommand(string input, out int x, out int y, out Direction direction)
        {
            try
            {
                var split2 = input.Split(',');
                x = Convert.ToInt32(split2[0]);
                y = Convert.ToInt32(split2[1]);
                Enum.TryParse(split2[2].ToUpper(), out Direction placeDirection);

                direction = placeDirection;
            }
            catch (Exception)
            {
                x = 0;
                y = 0;
                direction = Direction.NORTH;
                //TODO: Output message
            }
        }
    }
}
