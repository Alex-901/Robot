
namespace Robot
{
    public class RobotController
    {
        private ConsoleCommand _currentCommand;

        public RobotController(ConsoleCommand command)
        {
            _currentCommand = command;
        }

        /// <summary>
        /// Move the robot forward one step in the direction it is facing
        /// </summary>
        public void Move()
        {
            if (ValidateMove())
            {
                switch (RobotState.CurrentDirection)
                {
                    case Constants.Direction.NORTH:
                        RobotState.X++;
                        break;
                    case Constants.Direction.SOUTH:
                        RobotState.X--;
                        break;
                    case Constants.Direction.WEST:
                        RobotState.Y--;
                        break;
                    case Constants.Direction.EAST:
                        RobotState.Y++;
                        break;
                }
            }
        }

        /// <summary>
        /// Place the robot on the table
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Place()
        {
            if (ValidatePlace())
            {
                RobotState.CurrentDirection = _currentCommand.Direction;
                RobotState.X = _currentCommand.X;
                RobotState.Y = _currentCommand.Y;
            }
        }

        /// <summary>
        /// Move the robot 90 degrees to the left
        /// </summary>
        public void Left()
        {
            switch (RobotState.CurrentDirection)
            {
                case Constants.Direction.NORTH:
                    RobotState.CurrentDirection = Constants.Direction.WEST;
                    break;
                case Constants.Direction.SOUTH:
                    RobotState.CurrentDirection = Constants.Direction.EAST;
                    break;
                case Constants.Direction.WEST:
                    RobotState.CurrentDirection = Constants.Direction.SOUTH;
                    break;
                case Constants.Direction.EAST:
                    RobotState.CurrentDirection = Constants.Direction.NORTH;
                    break;
            }
        }

        /// <summary>
        /// Move the robot 90 degrees to the right
        /// </summary>
        public void Right()
        {
            switch (RobotState.CurrentDirection)
            {
                case Constants.Direction.NORTH:
                    RobotState.CurrentDirection = Constants.Direction.EAST;
                    break;
                case Constants.Direction.SOUTH:
                    RobotState.CurrentDirection = Constants.Direction.WEST;
                    break;
                case Constants.Direction.WEST:
                    RobotState.CurrentDirection = Constants.Direction.NORTH;
                    break;
                case Constants.Direction.EAST:
                    RobotState.CurrentDirection = Constants.Direction.SOUTH;
                    break;
            }
        }

        /// <summary>
        /// Output the current location of the robot
        /// </summary>
        /// <returns></returns>
        public string Report()
        {
            return $"X: {RobotState.X}, Y: {RobotState.Y}, {RobotState.CurrentDirection}";
        }

        /// <summary>
        /// Ensure the robot will not fall off the table when moving
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool ValidateMove()
        {
            switch (RobotState.CurrentDirection)
            {
                case Constants.Direction.NORTH:
                    return (RobotState.X + 1 <= Constants.MAXROWS);
                case Constants.Direction.SOUTH:
                    return (RobotState.X - 1 >= Constants.MINROWS);
                case Constants.Direction.WEST:
                    return (RobotState.Y - 1 >= Constants.MINROWS);
                case Constants.Direction.EAST:
                    return (RobotState.Y + 1 <= Constants.MAXCOLUMNS);
            }

            return false;
        }

        /// <summary>
        /// Ensure the robot will not fall off the table when placing
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool ValidatePlace()
        {
            switch (_currentCommand.Direction)
            {
                case Constants.Direction.NORTH:
                    return (_currentCommand.X <= Constants.MAXROWS);
                case Constants.Direction.SOUTH:
                    return (_currentCommand.Y >= Constants.MINROWS);
                case Constants.Direction.WEST:
                    return (_currentCommand.Y >= Constants.MINROWS);
                case Constants.Direction.EAST:
                    return (_currentCommand.Y <= Constants.MAXCOLUMNS);
            }

            return false;
        }
    }
}

