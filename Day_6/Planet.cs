using System.Collections.Generic;

namespace Day_6
{
  public class Planet
  {
    private List<Planet> orbitingPlanets;
    public string name;
    public int depth;

    public Planet(string name) {
      this.name = name;
      this.orbitingPlanets = new List<Planet>();
    }

    public void AddOrbitingPlanet(Planet child) {
      orbitingPlanets.Add(child);
      child.SetDepth(this.depth);
    }

    public void SetDepth(int depth) {
      this.depth = depth + 1;
      foreach (var planet in orbitingPlanets) {
        planet.SetDepth(this.depth);
      }
    }

    public int CountOrbits() {
      var orbits = depth;

      foreach (var planet in orbitingPlanets) {
        orbits += planet.CountOrbits();
      }

      return orbits;
    }

    public Planet GetPlanet(string name) {
      if (name == this.name) {
        return this;
      }

      foreach (var planet in this.orbitingPlanets) {
        var result = planet.GetPlanet(name);
        if (result != null) {
          return result;
        }
      }

      return null;
    }

    public int GetPlanetDistance(string name) {
      if (name == this.name) {
        return -1;
      }

      foreach (var planet in this.orbitingPlanets) {
        var result = planet.GetPlanetDistance(name);
        if (result >= 0) {
          return result + 1;
        }
      }

      return -1;
    }

    public int GetDistanceBetween(string planet1, string planet2) {
      var distanceTo1 = this.GetPlanetDistance(planet1);
      var distanceTo2 = this.GetPlanetDistance(planet2);
      var minDistance = (distanceTo1 == -1) || (distanceTo2 == -1) ? -1 : distanceTo1 + distanceTo2;

      foreach (var planet in this.orbitingPlanets) {
        var planetDistance = planet.GetDistanceBetween(planet1, planet2);
        if (planetDistance != -1 && planetDistance < minDistance) {
          minDistance = planetDistance;
        }
      }

      return minDistance;
    }
  }
}
