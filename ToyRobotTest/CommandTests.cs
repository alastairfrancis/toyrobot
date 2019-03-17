using System;
using Xunit;
using ToyRobotLib;
using ToyRobotLib.Types;

namespace ToyRobot.Test
{
    /// <summary>
    /// Robot command testing
    /// </summary>
    public class CommandTests
    {
        private readonly RobotSimulator _simulator;

        public CommandTests()
        {
            _simulator = new RobotSimulator();
            _simulator.CreateGrid(5, 5);
        }

        [Theory]
        [InlineData("Place 0, 0, North", 0, 0, Heading.North)]
        [InlineData("Place 3, 3, North", 3, 3, Heading.North)]
        public void VerifyPlaceCommand(string command, int expectedX, int expectedY, Heading expectedHeading)
        {
            _simulator.RobotReset();
            _simulator.Execute(command);

            var position = _simulator.RobotPosition();

            Assert.Equal(position.X, expectedX);
            Assert.Equal(position.Y, expectedY);
            Assert.Equal(position.Heading, expectedHeading);
        }

        [Theory]
        [InlineData("Place -2, 1, West", null)]
        [InlineData("Place 7, -1, East", null)]
        [InlineData("Place 0, 0, Northerly", null)]
        public void VerifyInvalidPlaceCommands(string command, Vector expectedPosition)
        {
            _simulator.RobotReset();
            _simulator.Execute(command);

            var position = _simulator.RobotPosition();

            Assert.Equal(position, expectedPosition);
            Assert.Equal(position, expectedPosition);
            Assert.Equal(position, expectedPosition);
        }

        [Theory]
        [InlineData("Place 1, 2, East", 2, 2, Heading.East)]
        [InlineData("Place 4, 1, North", 4, 2, Heading.North)]
        [InlineData("Place 0, 0, West", 0, 0, Heading.West)]
        [InlineData("Place 4, 4, North", 4, 4, Heading.North)]
        public void VerifyMoveCommands(string command, int expectedX, int expectedY, Heading expectedHeading)
        {
            _simulator.RobotReset();
            _simulator.Execute(command);
            _simulator.Execute("move");

            var position = _simulator.RobotPosition();

            Assert.Equal(position.X, expectedX);
            Assert.Equal(position.Y, expectedY);
            Assert.Equal(position.Heading, expectedHeading);
        }

        [Theory]
        [InlineData("Place 0, 0, West", Heading.North)]
        [InlineData("Place 0, 0, East", Heading.South)]
        [InlineData("Place 0, 0, North", Heading.East)]
        [InlineData("Place 0, 0, South", Heading.West)]
        public void VerifyRightTurnCommands(string command, Heading expectedHeading)
        {
            _simulator.RobotReset();
            _simulator.Execute(command);
            _simulator.Execute("right");

            var position = _simulator.RobotPosition();

            Assert.Equal(position.Heading, expectedHeading);
        }

        [Theory]
        [InlineData("Place 0, 0, West", Heading.South)]
        [InlineData("Place 0, 0, East", Heading.North)]
        [InlineData("Place 0, 0, North", Heading.West)]
        [InlineData("Place 0, 0, South", Heading.East)]
        public void VerifyLeftTurnCommands(string command, Heading expectedHeading)
        {
            _simulator.RobotReset();
            _simulator.Execute(command);
            _simulator.Execute("left");

            var position = _simulator.RobotPosition();

            Assert.Equal(position.Heading, expectedHeading);

        }
    }
}
