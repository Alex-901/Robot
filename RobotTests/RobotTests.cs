using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobotTests
{
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        public void Move()
        {
            Robot.RobotController controller = new Robot.RobotController(new Robot.ConsoleCommand() { Direction = Robot.Constants.Direction.NORTH, X = 0, Y = 0 });

            Robot.RobotState.CurrentDirection = Robot.Constants.Direction.NORTH;

            controller.Move();

            Assert.AreEqual(Robot.Constants.Direction.NORTH, Robot.RobotState.CurrentDirection);
        }

        [TestMethod]
        public void Place()
        {
            var x = 4;
            var y = 0;
            Robot.RobotController controller = new Robot.RobotController(new Robot.ConsoleCommand() { Direction = Robot.Constants.Direction.NORTH, X = x, Y = y });

            controller.Place();

            Assert.AreEqual(Robot.Constants.Direction.NORTH, Robot.RobotState.CurrentDirection);
            Assert.AreEqual(x, Robot.RobotState.X);
            Assert.AreEqual(y, Robot.RobotState.Y);
        }

        [TestMethod]
        public void Right()
        {
            Robot.RobotController controller = new Robot.RobotController(new Robot.ConsoleCommand() { Direction = Robot.Constants.Direction.NORTH, X = 0, Y = 0 });
            Robot.RobotState.CurrentDirection = Robot.Constants.Direction.NORTH;

            controller.Right();

            Assert.AreEqual(Robot.Constants.Direction.EAST, Robot.RobotState.CurrentDirection);
        }

        [TestMethod]
        public void Left()
        {
            Robot.RobotController controller = new Robot.RobotController(new Robot.ConsoleCommand() { Direction = Robot.Constants.Direction.NORTH, X = 0, Y = 0 });

            controller.Left();

            Assert.AreEqual(Robot.Constants.Direction.WEST, Robot.RobotState.CurrentDirection);
        }

        [TestMethod]
        public void EnsurePlaceIsFirstCommand()
        {
            //Reset the state
            Robot.RobotState.CurrentDirection = Robot.Constants.Direction.NOTSET;

            // The direction should not have changed if the robot has not been placed on the table
            Robot.RobotController controller = new Robot.RobotController(new Robot.ConsoleCommand() { Direction = Robot.RobotState.CurrentDirection, X = Robot.RobotState.X, Y = Robot.RobotState.Y });

            controller.Move();

            Assert.AreEqual(Robot.Constants.Direction.NOTSET, Robot.RobotState.CurrentDirection);
            Assert.AreEqual(0, Robot.RobotState.X);
            Assert.AreEqual(0, Robot.RobotState.Y);
        }

        [TestMethod]
        public void Test1()
        {
            // The direction should not have changed if the robot has not been placed on the table
            Robot.RobotController controller = new Robot.RobotController(new Robot.ConsoleCommand() { Direction = Robot.Constants.Direction.NORTH, X = 0, Y = 0 });

            controller.Place();
            controller.Move();
            controller.Move();
            controller.Right();
            controller.Move();

            Assert.AreEqual(Robot.Constants.Direction.EAST, Robot.RobotState.CurrentDirection);
            Assert.AreEqual(2, Robot.RobotState.X);
            Assert.AreEqual(1, Robot.RobotState.Y);
        }

        [TestMethod]
        public void Test2()
        {
            // The direction should not have changed if the robot has not been placed on the table
            Robot.RobotController controller = new Robot.RobotController(new Robot.ConsoleCommand() { Direction = Robot.Constants.Direction.SOUTH, X = 4, Y = 4 });

            controller.Place();
            controller.Move();
            controller.Move();
            controller.Right();
            controller.Move();

            Assert.AreEqual(Robot.Constants.Direction.WEST, Robot.RobotState.CurrentDirection);
            Assert.AreEqual(2, Robot.RobotState.X);
            Assert.AreEqual(3, Robot.RobotState.Y);
        }
    }
}
