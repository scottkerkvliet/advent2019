using System;
using System.Collections.Generic;
using System.Linq;
using Day_10;

namespace problem_1
{
  class Program
  {
    static void Main(string[] args)
    {
      var lines = new List<string>(System.IO.File.ReadAllLines(@"/home/scott/Documents/advent2019/Day_10/asteroids.txt"));

      var asteroids = new List<Asteroid>();
      var asteroidField = new List<List<Asteroid>>();

      for (var i = 0; i < lines.Count; i++) {
        var asteroidList = new List<Asteroid>();
        for (var j = 0; j < lines[i].Length; j++) {
          Asteroid newAsteroid = null;
          if (lines[i][j] == '#') {
            newAsteroid = new Asteroid(j, i);
            asteroids.Add(newAsteroid);
          }
          asteroidList.Add(newAsteroid);
        }
        asteroidField.Add(asteroidList);
      }

      for (var i = 0; i < asteroidField.Count; i++) {
        for (var j = 0; j < asteroidField[i].Count; j++) {
          if (asteroidField[i][j] == null) continue;
          FindPaths(asteroidField, j, i);
        }
      }

      Console.WriteLine(asteroids.Max(a => a.visibleAsteroids.Count));
    }

    static void FindPaths (List<List<Asteroid>> field, int x, int y) {
      var asteroid = field[y][x];
      x++;
      while (y < field.Count) {
        while (x < field[y].Count) {
          var otherAsteroid = field[y][x];
          if (otherAsteroid != null) {
            CheckVisibility(field, asteroid, otherAsteroid);
          }
          x++;
        }
        x = 0;
        y++;
      }
    }

    static void CheckVisibility (List<List<Asteroid>> field, Asteroid a, Asteroid b) {
      var deltas = GetDeltas(a, b);
      var x = a.x + deltas.Item1;
      var y = a.y + deltas.Item2;
      while (field[y][x] != b) {
        if (field[y][x] != null) {
          return;
        }
        x += deltas.Item1;
        y += deltas.Item2;
      }
      a.visibleAsteroids.Add(b);
      b.visibleAsteroids.Add(a);
    }

    static Tuple<int, int> GetDeltas (Asteroid a, Asteroid b) {
      var x = b.x - a.x;
      var y = b.y - a.y;

      var divisor = GCD(Math.Abs(x), Math.Abs(y));
      x = x / divisor;
      y = y / divisor;

      return new Tuple<int, int>(x, y);
    }

    static int GCD(int a, int b)
    {
      return b == 0 ? a : GCD(b, a % b);
    }
  }
}
