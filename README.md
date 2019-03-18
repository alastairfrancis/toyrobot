# Toy Robot Code Challenge

Developer: Alastair Francis <BR>
Environment: C# .NET Core <BR>
Dev Environment: Visual Studio 2017<BR>

## Description: 
Console application to simulate sending commands to a toy robot. Commands can be executed individually, or run from file as a script.

## Build and Run:
Open the solution file in Visual Studio to build and run the application.
* Run the ToyRobotConsole project to run some tests.  Output is to the console.

## Robot Commands:
**PLACE _X,Y,H_** - Places the robot on the grid at position X, Y with heading H (North, East, South, West) <BR>
**MOVE** - Moves the robot one cell forward <BR>
**LEFT** - Turns the robot left 90 degrees <BR>
**RIGHT** - Turns the robot right 90 degrees <BR>
**REPORT** - Displays the robot's position <BR>

## Unit Tests:
Unit tests have been implemented in xUnit, and can be run in the Visual Studio test runner.

## Grid:
An empty rectangular grid can be created, or a grid loaded from file.  In the grid file, empty cells are represented by _o_, any other character represents a blocked cell.

## Future Enhancements:
* The solution is implemented as a console application, but the Robot, and Grid could be exposed as services for Web or Service APIs. However, this seemed beyond the scope of the exercise.
* Headings in command are case sensitive.
* A more elaborate parser could be implemented that accepts quoted strings, but they weren't required for this exercise.

