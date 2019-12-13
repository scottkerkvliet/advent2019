using System;

namespace Day_11
{
  public class Point
  {
    public int x, y, z;

    public Point (int x, int y, int z) {
      this.x = x;
      this.y = y;
      this.z = z;
    }

    public string Print () {
      return "<x=" + x + ", y=" + y + ", z=" + z + ">";
    }

    public int getEnergy () {
      return Math.Abs(x) + Math.Abs(y) + Math.Abs(z);
    }
  }
}
