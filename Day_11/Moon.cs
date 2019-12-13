using System;

namespace Day_11
{
  public class Moon
  {
    public Point location;
    public Point velocity;

    public Moon (Point location, Point velocity) {
      this.location = location;
      this.velocity = velocity;
    }

    public void applyGravity (Moon moon) {
      var xChange = location.x < moon.location.x ? 1 : (location.x > moon.location.x ? -1 : 0);
      var yChange = location.y < moon.location.y ? 1 : (location.y > moon.location.y ? -1 : 0);
      var zChange = location.z < moon.location.z ? 1 : (location.z > moon.location.z ? -1 : 0);

      velocity.x += xChange;
      velocity.y += yChange;
      velocity.z += zChange;

      moon.velocity.x += (xChange * -1);
      moon.velocity.y += (yChange * -1);
      moon.velocity.z += (zChange * -1);
    }

    public void applyVelocity () {
      location.x += velocity.x;
      location.y += velocity.y;
      location.z += velocity.z;
    }

    public string Print () {
      return "pos=" + location.Print() + ", vel=" + velocity.Print();
    }

    public int getEnergy () {
      return location.getEnergy() * velocity.getEnergy();
    }
  }
}
