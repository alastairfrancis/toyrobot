using System;
using Xunit;
using ToyRobotLib;
using ToyRobotLib.Types;

namespace ToyRobot.Test
{
    /// <summary>
    /// Run a sequence of commands, and check the expected robot position
    /// </summary>
    public class ScriptTests
    {
        private readonly RobotSimulator _simulator;

        public ScriptTests()
        {
            _simulator = new RobotSimulator();
            _simulator.CreateGrid(5, 5);
        }

        [Fact]
        public void VerifyScript1()
        {
            _simulator.RobotReset();

            _simulator.Execute("place 0, 0, North");
            _simulator.Execute("move");
            _simulator.Execute("report");

            var position = _simulator.RobotPosition();

            Assert.Equal(0, position.X);
            Assert.Equal(1, position.Y);
            Assert.Equal(Heading.North, position.Heading);
        }

        [Fact]
        public void VerifyScript2()
        {
            _simulator.RobotReset();

            _simulator.Execute("place 0, 0, North");
            _simulator.Execute("left");
            _simulator.Execute("report");

            var position = _simulator.RobotPosition();
            
            Assert.Equal(0, position.X);
            Assert.Equal(0, position.Y);
            Assert.Equal(Heading.West, position.Heading);
        }

        [Fact]
        public void VerifyScript3()
        {
            _simulator.RobotReset();

            _simulator.Execute("place 1, 2, East");
            _simulator.Execute("move");
            _simulator.Execute("move");
            _simulator.Execute("left");
            _simulator.Execute("move");
            _simulator.Execute("report");

            var position = _simulator.RobotPosition();

            Assert.Equal(3, position.X);
            Assert.Equal(3, position.Y);
            Assert.Equal(Heading.North, position.Heading);
        }


        [Fact]
        public void VerifyScript4()
        {
            _simulator.RobotReset();

            _simulator.Execute("place 0, 0, West");
            _simulator.Execute("move");
            _simulator.Execute("move");
            _simulator.Execute("right");
            _simulator.Execute("move");
            _simulator.Execute("move");
            _simulator.Execute("report");

            var position = _simulator.RobotPosition();

            Assert.Equal(0, position.X);
            Assert.Equal(2, position.Y);
            Assert.Equal(Heading.North, position.Heading);
        }

        [Fact]
        public void VerifyScript5()
        {
            _simulator.RobotReset();

            _simulator.Execute("place 4, 4, East");
            _simulator.Execute("move");
            _simulator.Execute("move");
            _simulator.Execute("right");
            _simulator.Execute("move");
            _simulator.Execute("right");
            _simulator.Execute("move");
            _simulator.Execute("move");
            _simulator.Execute("report");

            var position = _simulator.RobotPosition();

            Assert.Equal(2, position.X);
            Assert.Equal(3, position.Y);
            Assert.Equal(Heading.West, position.Heading);
        }
    }
}
