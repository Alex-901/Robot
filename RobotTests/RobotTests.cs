using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobotTests
{
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        public void Move()
        {
            Robot.RobotController controller = new Robot.RobotController();

            Robot.RobotState.CurrentDirection = Robot.RobotController.Direction.NORTH;

            controller.Move();

            Assert.AreEqual(Robot.RobotController.Direction.NORTH, Robot.RobotState.CurrentDirection);
        }

        [TestMethod]
        public void Place()
        {
            var x = 4;
            var y = 0;
            Robot.RobotController controller = new Robot.RobotController();

            controller.Place(Robot.RobotController.Direction.NORTH, x, y);

            Assert.AreEqual(Robot.RobotController.Direction.NORTH, Robot.RobotState.CurrentDirection);
            Assert.AreEqual(x, Robot.RobotState.X);
            Assert.AreEqual(y, Robot.RobotState.Y);
        }

        [TestMethod]
        public void Right()
        {
            Robot.RobotController controller = new Robot.RobotController();
            Robot.RobotState.CurrentDirection = Robot.RobotController.Direction.NORTH;

            controller.Right();

            Assert.AreEqual(Robot.RobotController.Direction.EAST, Robot.RobotState.CurrentDirection);
        }

        [TestMethod]
        public void Left()
        {
            Robot.RobotController controller = new Robot.RobotController();
            Robot.RobotState.CurrentDirection = Robot.RobotController.Direction.NORTH;

            controller.Left();

            Assert.AreEqual(Robot.RobotController.Direction.WEST, Robot.RobotState.CurrentDirection);
        }

        [TestMethod]
        public void EnsurePlaceIsFirstCommand()
        {
            //Reset the state
            Robot.RobotState.CurrentDirection = Robot.RobotController.Direction.NOTSET;

            // The direction should not have changed if the robot has not been placed on the table
            Robot.RobotController controller = new Robot.RobotController();

            var x = Robot.RobotState.X;
            var y = Robot.RobotState.Y;
            var direction = Robot.RobotState.CurrentDirection;

            controller.Move();

            Assert.AreEqual(direction, Robot.RobotState.CurrentDirection);
            Assert.AreEqual(x, Robot.RobotState.X);
            Assert.AreEqual(y, Robot.RobotState.Y);

        }

        [TestMethod]
        public void Test1()
        {
            // The direction should not have changed if the robot has not been placed on the table
            Robot.RobotController controller = new Robot.RobotController();

            controller.Place(Robot.RobotController.Direction.NORTH, 0, 0);
            controller.Move();
            controller.Move();
            controller.Right();
            controller.Move();

            Assert.AreEqual(Robot.RobotController.Direction.EAST, Robot.RobotState.CurrentDirection);
            Assert.AreEqual(2, Robot.RobotState.X);
            Assert.AreEqual(1, Robot.RobotState.Y);

        }

        [TestMethod]
        public void Test2()
        {
            // The direction should not have changed if the robot has not been placed on the table
            Robot.RobotController controller = new Robot.RobotController();

            controller.Place(Robot.RobotController.Direction.SOUTH, 4, 4);
            controller.Move();
            controller.Move();
            controller.Right();
            controller.Move();

            Assert.AreEqual(Robot.RobotController.Direction.WEST, Robot.RobotState.CurrentDirection);
            Assert.AreEqual(2, Robot.RobotState.X);
            Assert.AreEqual(3, Robot.RobotState.Y);

        }
    }
}
