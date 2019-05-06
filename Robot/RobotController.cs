namespace Robot
{
    public class RobotController
    {
        public const int MAXROWS = 4;
        public const int MAXCOLUMNS = 4;

        public const int MINROWS = 0;
        public const int MINCOLUMNS = 0;

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

        /// <summary>
        /// Move the robot forward one step in the direction it is facing
        /// </summary>
        public void Move()
        {
            if (ValidateMove(RobotState.X, RobotState.Y, RobotState.CurrentDirection))
            {
                switch (RobotState.CurrentDirection)
                {
                    case Direction.NORTH:
                        RobotState.X++;
                        break;
                    case Direction.SOUTH:
                        RobotState.X--;
                        break;
                    case Direction.WEST:
                        RobotState.Y--;
                        break;
                    case Direction.EAST:
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
        public void Place(Direction direction, int x, int y)
        {
            if (ValidatePlace(x, y, direction))
            {
                RobotState.CurrentDirection = direction;
                RobotState.X = x;
                RobotState.Y = y;
            }
        }

        /// <summary>
        /// Move the robot 90 degrees to the left
        /// </summary>
        public void Left()
        {
            switch (RobotState.CurrentDirection)
            {
                case Direction.NORTH:
                    RobotState.CurrentDirection = Direction.WEST;
                    break;
                case Direction.SOUTH:
                    RobotState.CurrentDirection = Direction.EAST;
                    break;
                case Direction.WEST:
                    RobotState.CurrentDirection = Direction.SOUTH;
                    break;
                case Direction.EAST:
                    RobotState.CurrentDirection = Direction.NORTH;
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
                case Direction.NORTH:
                    RobotState.CurrentDirection = Direction.EAST;
                    break;
                case Direction.SOUTH:
                    RobotState.CurrentDirection = Direction.WEST;
                    break;
                case Direction.WEST:
                    RobotState.CurrentDirection = Direction.NORTH;
                    break;
                case Direction.EAST:
                    RobotState.CurrentDirection = Direction.SOUTH;
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
        public bool ValidateMove(int x, int y, Direction direction)
        {
            switch (direction)
            {
                case Direction.NORTH:
                    return (x + 1 <= MAXROWS);
                case Direction.SOUTH:
                    return (x - 1 >= MINROWS);
                case Direction.WEST:
                    return (y - 1 >= MINROWS);
                case Direction.EAST:
                    return (y + 1 <= MAXCOLUMNS);
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
        public bool ValidatePlace(int x, int y, Direction direction)
        {
            switch (direction)
            {
                case Direction.NORTH:
                    return (x <= MAXROWS);
                case Direction.SOUTH:
                    return (x >= MINROWS);
                case Direction.WEST:
                    return (y >= MINROWS);
                case Direction.EAST:
                    return (y <= MAXCOLUMNS);
            }

            return false;
        }
    }
}

