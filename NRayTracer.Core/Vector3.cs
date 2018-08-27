using System;
namespace NRayTracer.Core
{
    public struct Vector3 : IEquatable<Vector3>
    {
        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public double Magnitude => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));

        public Vector3 Normalized
        {
            get
            {
                var m = Magnitude;
                return new Vector3(X / m, Y / m, Z / m);
            }
        }

        public bool Equals(Vector3 other)
        {
            return FloatMath.AreEqual(X, other.X)
                            && FloatMath.AreEqual(Y, other.Y)
                            && FloatMath.AreEqual(Z, other.Z);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Vector3))
            {
                return false;
            }

            return Equals((Vector3)obj);
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        }

        public static Vector3 operator -(Vector3 t)
        {
            return new Vector3(-t.X, -t.Y, -t.Z);
        }

        public static Vector3 operator *(Vector3 t, double factor)
        {
            return new Vector3(t.X * factor, t.Y * factor, t.Z * factor);
        }

        public static Vector3 operator /(Vector3 t, double factor)
        {
            return new Vector3(t.X / factor, t.Y / factor, t.Z / factor);
        }

        public double Dot(Vector3 other)
        {
            return X * other.X + Y * other.Y + Z * other.Z;
        }

        public Vector3 Cross(Vector3 other)
        {
            return new Vector3(Y * other.Z - Z * other.Y,
                Z * other.X - X * other.Z,
                X * other.Y - Y * other.X);
        }
    }
}
