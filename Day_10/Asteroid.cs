using System;
using System.Collections.Generic;

namespace Day_10
{
  public class Asteroid
  {
    public int x;
    public int y;
    public List<Asteroid> visibleAsteroids;

    public Asteroid (int x, int y) {
      this.x = x;
      this.y = y;
      this.visibleAsteroids = new List<Asteroid>();
    }
  }
}
