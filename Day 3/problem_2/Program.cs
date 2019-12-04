using System;
using System.Collections.Generic;
using Day_3;

namespace problem_2
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] lines = System.IO.File.ReadAllLines(@"/home/scott/Documents/Advent/Day 3/wires.txt");
      string wire1Input = lines[0];
      string[] wire1Directions = wire1Input.Split(',');
      List<Line> wire1 = new List<Line>();
      Line previousLine = new Line(new Point(0, 0), "U0");
      foreach (var direction in wire1Directions) {
        var newLine = new Line(previousLine, direction);
        wire1.Add(newLine);
        previousLine = newLine;
      }

      string wire2Input = lines[1];
      string[] wire2Directions = wire2Input.Split(',');
      List<Line> wire2 = new List<Line>();
      previousLine = new Line(new Point(0, 0), "U0");
      foreach (var direction in wire2Directions) {
        var newLine = new Line(previousLine, direction);
        wire2.Add(newLine);
        previousLine = newLine;
      }

      int minSteps = 0;

      foreach (var wire1Line in wire1) {
        foreach (var wire2Line in wire2) {
          var intersection = wire1Line.FindIntersection(wire2Line);
          if (intersection == null) continue;

          int newSteps = wire1Line.distance + (wire1Line.point1.Distance(intersection)) + wire2Line.distance + (wire2Line.point1.Distance(intersection));

          if (minSteps == 0 || minSteps > newSteps) {
            minSteps = newSteps;
          }
        }
      }

      Console.WriteLine("Min Steps: " + minSteps);
    }
  }
}
