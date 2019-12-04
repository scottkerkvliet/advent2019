using System;
using System.Collections.Generic;
using Day_3;

namespace problem_1
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] lines = System.IO.File.ReadAllLines(@"/home/scott/Documents/Advent/Day 3/wires.txt");
      string wire1Input = lines[0];
      string[] wire1Directions = wire1Input.Split(',');
      List<Line> wire1 = new List<Line>();
      Point origin = new Point(0, 0);
      foreach (var direction in wire1Directions) {
        var newLine = new Line(origin, direction);
        wire1.Add(newLine);
        origin = newLine.point2;
      }

      string wire2Input = lines[1];
      string[] wire2Directions = wire2Input.Split(',');
      List<Line> wire2 = new List<Line>();
      origin = new Point(0, 0);
      foreach (var direction in wire2Directions) {
        var newLine = new Line(origin, direction);
        wire2.Add(newLine);
        origin = newLine.point2;
      }

      Point minIntersection = null;

      foreach (var wire1Line in wire1) {
        foreach (var wire2Line in wire2) {
          var intersection = wire1Line.FindIntersection(wire2Line);
          if (intersection == null) continue;

          if (minIntersection == null || minIntersection.Distance() > intersection.Distance()) {
            minIntersection = intersection;
          }
        }
      }

      Console.WriteLine("X: " + minIntersection.x + "   Y: " + minIntersection.y);
    }
  }
}
