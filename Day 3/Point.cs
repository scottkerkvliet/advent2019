using System;

namespace Day_3
{
  public class Point
  {
    public int x;
    public int y;

    public Point(int x, int y) {
      this.x = x;
      this.y = y;
    }

    public Point(Point point) {
      this.x = point.x;
      this.y = point.y;
    }

    public int Distance() {
      return Math.Abs(this.x) + Math.Abs(this.y);
    }

    public int Distance(Point point2) {
      return Math.Abs(this.x - point2.x) + Math.Abs(this.y - point2.y);
    }
  }
}
