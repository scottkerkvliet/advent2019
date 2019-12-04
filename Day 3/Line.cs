using System;

namespace Day_3
{
  public class Line
  {
    public Point point1;
    public Point point2;
    public int distance;

    public Line(Point origin, string direction) {
      this.point1 = origin;
      this.point2 = new Point(origin);
      this.distance = 0;

      this.addDirection(direction);
    }

    public Line(Line line, string direction) {
      this.point1 = new Point(line.point2);
      this.point2 = new Point(line.point2);
      this.distance = line.distance + line.point1.Distance(line.point2);

      this.addDirection(direction);
    }

    public Point FindIntersection(Line line2) {
      var x1 = Math.Min(this.point1.x, this.point2.x);
      var x2 = Math.Max(this.point1.x, this.point2.x);
      var y1 = Math.Min(this.point1.y, this.point2.y);
      var y2 = Math.Max(this.point1.y, this.point2.y);
      var line2x1 = Math.Min(line2.point1.x, line2.point2.x);
      var line2x2 = Math.Max(line2.point1.x, line2.point2.x);
      var line2y1 = Math.Min(line2.point1.y, line2.point2.y);
      var line2y2 = Math.Max(line2.point1.y, line2.point2.y);

      int xIntersection = 0;
      bool isXIntersect = false;
      int yIntersection = 0;
      bool isYIntersect = false;

      if (line2x1 >= x1 && line2x1 <= x2) {
        xIntersection = line2x1;
        isXIntersect = true;
      }
      else if (x1 >= line2x1 && x1 <= line2x2) {
        xIntersection = x1;
        isXIntersect = true;
      }
      if (line2y1 >= y1 && line2y1 <= y2) {
        yIntersection = line2y1;
        isYIntersect = true;
      }
      else if (y1 >= line2y1 && y1 <= line2y2) {
        yIntersection = y1;
        isYIntersect = true;
      }

      if (isXIntersect && isYIntersect && (xIntersection != 0 || yIntersection != 0)) {
        return new Point(xIntersection, yIntersection);
      }

      return null;
    }

    private void addDirection(string direction) {
      int magnitude = int.Parse(direction.Substring(1));
      switch(direction[0]) {
        case 'R':
          point2.x += magnitude;
          break;
        case 'L':
          point2.x -= magnitude;
          break;
        case 'U':
          point2.y += magnitude;
          break;
        case 'D':
          point2.y -= magnitude;
          break;
      }
    }
  }
}
