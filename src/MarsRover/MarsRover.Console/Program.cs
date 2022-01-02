// See https://aka.ms/new-console-template for more information

using MarsRover.App;
using MarsRover.App.Location;
using MarsRover.App.Obstructions;
using System;

Console.WriteLine("Hello, World!");

Console.WriteLine("Grid width?");
var width = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Grid height?");
var height = Convert.ToInt32(Console.ReadLine());

var obstructor = new ObstructedGridProvider(width, height);
var rover = new Rover(new Grid(width, height, obstructor));

Console.WriteLine("Obstacles located at:");
foreach (var obst in obstructor.GetObstructions())
{
    Console.WriteLine(obst);
}

Console.WriteLine("Input the commands (LRBF) and hit enter. When you are done, press 'q'");

char command = ' ';
while (command != 'q')
{
    Console.Write("\nNext Command: ");
    command = Console.ReadKey().KeyChar;

    //sb.Append(command);
    var output = rover.Execute(command.ToString());
    Console.WriteLine($"\nThe output is: {output}");
}