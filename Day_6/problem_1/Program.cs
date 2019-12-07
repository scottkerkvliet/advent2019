using System;
using System.Collections.Generic;
using Day_6;

namespace problem_1
{
  class Program
  {
    static void Main(string[] args)
    {
      var lines = new List<string>(System.IO.File.ReadAllLines(@"/home/scott/Documents/advent2019/Day_6/planets.txt"));

      var rootPlanets = Program.GetPlanets(lines);

      var totalOrbits = 0;
      foreach (var planet in rootPlanets) {
        totalOrbits += planet.CountOrbits();
      }
      Console.WriteLine(totalOrbits);
    }

    static List<Planet> GetPlanets(List<string> inputs) {
      var rootPlanets = new List<Planet>();
      foreach (var input in inputs) {
        var splitInput = input.Split(')');
        Planet parent = null;
        foreach (var planet in rootPlanets) {
          parent = planet.GetPlanet(splitInput[0]);
          if (parent != null) {
            break;
          }
        }
        if (parent == null) {
          parent = new Planet(splitInput[0]);
          rootPlanets.Add(parent);
        }

        Planet child = null;
        foreach (var planet in rootPlanets) {
          if (planet.name == splitInput[1]) {
            child = planet;
            rootPlanets.Remove(planet);
            break;
          }
          child = planet.GetPlanet(splitInput[1]);
          if (child != null) {
            break;
          }
        }
        if (child == null) {
          child = new Planet(splitInput[1]);
        }
        parent.AddOrbitingPlanet(child);
      }

      return rootPlanets;
    }
  }
}
