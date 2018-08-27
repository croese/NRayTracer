using System;

namespace NRayTracer.Core
{
  public struct Point3 : IEquatable<Point3>
  {
    public Point3(double x, double y, double z)
    {
      X = x;
      Y = y;
      Z = z;
    }

    public double X { get; }
    public double Y { get; }
    public double Z { get; }

    public bool Equals(Point3 other)
    {
      return FloatMath.AreEqual(X, other.X)
                      && FloatMath.AreEqual(Y, other.Y)
                      && FloatMath.AreEqual(Z, other.Z);
    }

    public override bool Equals(object obj)
    {
      if (obj == null || !(obj is Point3))
      {
        return false;
      }

      return Equals((Point3)obj);
    }

    public static Point3 operator +(Point3 lhs, Vector3 rhs)
    {
      return new Point3(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
    }

    public static Vector3 operator -(Point3 lhs, Point3 rhs)
    {
      return new Vector3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
    }

    public static Point3 operator -(Point3 lhs, Vector3 rhs)
    {
      return new Point3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
    }
  }
}
