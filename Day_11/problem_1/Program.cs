using System;
using System.Collections.Generic;
using System.Linq;
using Day_11;

namespace problem_1
{
  class Program
  {
    static void Main(string[] args)
    {
      var lines = new List<string>(System.IO.File.ReadAllLines(@"/home/scott/Documents/advent2019/Day_11/moons.txt"));
      var moons = new List<Moon>();

      foreach (var line in lines) {
        var coordinates = line.TrimEnd('>').Split(',');
        var x = int.Parse(coordinates[0].Split('=')[1]);
        var y = int.Parse(coordinates[1].Split('=')[1]);
        var z = int.Parse(coordinates[2].Split('=')[1]);

        moons.Add(new Moon(new Point(x, y, z), new Point(0, 0, 0)));
      }

      var steps = 1000;

      for (int step = 0; step < steps; step++) {
        for (int i = 0; i < moons.Count; i++) {
          for (int j = i + 1; j < moons.Count; j++) {
            moons[i].applyGravity(moons[j]);
          }
        }
        for (int i = 0; i < moons.Count; i++) {
          moons[i].applyVelocity();
        }
      }

      foreach (var moon in moons) {
        Console.WriteLine(moon.Print());
      }

      Console.WriteLine("Total Energy: " + moons.Sum(moon => moon.getEnergy()));
    }
  }
}
