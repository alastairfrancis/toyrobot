using System;
using ToyRobotLib;

namespace ToyRobot
{
    class Program
    {
        /// <summary>
        /// Runs the robot simulator in a terminal window
        /// </summary>
        static void Main(string[] args)
        {
            var simulator = new RobotSimulator();

            simulator.CreateGridFromFile(@"Files\grid.txt");

            Console.WriteLine();
            simulator.RobotReset();
            simulator.ExecuteFile(@"Files\execution1.txt");

            Console.WriteLine();
            simulator.RobotReset();
            simulator.ExecuteFile(@"Files\execution2.txt");

            Console.WriteLine();
            simulator.RobotReset();
            simulator.ExecuteFile(@"Files\execution3.txt");

            Console.WriteLine();
            simulator.RobotReset();
            simulator.ExecuteFile(@"Files\execution4.txt");

            Console.WriteLine();
            simulator.RobotReset();
            simulator.Execute("place 1, 2, West");
            simulator.Execute("move");
            simulator.Execute("move");
            simulator.Execute("move");
            simulator.Execute("move");
            simulator.Execute("report");
            simulator.Execute("right");
            simulator.Execute("left");
            simulator.Execute("report");
            simulator.Execute("move");
            simulator.Execute("left");
            simulator.Execute("left");
            simulator.Execute("move");
            simulator.Execute("move");
            simulator.Execute("move");
            simulator.Execute("move");
            simulator.Execute("move");
            simulator.Execute("move");
            simulator.Execute("move");
            simulator.Execute("move");
            simulator.Execute("report");

            Console.WriteLine();
            Console.WriteLine("Select <ENTER> to exit");
            Console.ReadLine();
        }
    }
}
