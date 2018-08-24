using System;

namespace NRayTracer.Core
{
    public static class Tuple
    {
        public static Tuple4 NewPoint(double a, double b, double c) => new Tuple4(a, b, c, 1.0);

        public static Tuple4 NewVector(double a, double b, double c) => new Tuple4(a, b, c, 0);
    }

    public struct Tuple4 : IEquatable<Tuple4>
    {
        public Tuple4(double a, double b, double c, double d)
        {
            X = a;
            Y = b;
            Z = c;
            W = d;
        }

        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public double W { get; }
        public bool IsPoint => W == 1.0;
        public bool IsVector => W == 0;
        public double Magnitude => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2) + Math.Pow(W, 2));

        public Tuple4 Normalized
        {
            get
            {
                var m = Magnitude;
                return new Tuple4(X / m, Y / m, Z / m, W / m);
            }
        }

        public bool Equals(Tuple4 other)
        {
            return FloatMath.AreEqual(X, other.X)
                && FloatMath.AreEqual(Y, other.Y)
                && FloatMath.AreEqual(Z, other.Z)
                && FloatMath.AreEqual(W, other.W);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Tuple4))
            {
                return false;
            }

            return Equals((Tuple4)obj);
        }

        public static Tuple4 operator +(Tuple4 lhs, Tuple4 rhs)
        {
            return new Tuple4(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z, lhs.W + rhs.W);
        }

        public static Tuple4 operator -(Tuple4 lhs, Tuple4 rhs)
        {
            return new Tuple4(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z, lhs.W - rhs.W);
        }

        public static Tuple4 operator -(Tuple4 t)
        {
            return new Tuple4(-t.X, -t.Y, -t.Z, -t.W);
        }

        public static Tuple4 operator *(Tuple4 t, double factor)
        {
            return new Tuple4(t.X * factor, t.Y * factor, t.Z * factor, t.W * factor);
        }

        public static Tuple4 operator /(Tuple4 t, double factor)
        {
            return new Tuple4(t.X / factor, t.Y / factor, t.Z / factor, t.W / factor);
        }

        public double Dot(Tuple4 other)
        {
            return X * other.X + Y * other.Y + Z * other.Z + W * other.W;
        }

        public Tuple4 Cross(Tuple4 other)
        {
            return Tuple.NewVector(Y * other.Z - Z * other.Y,
                Z * other.X - X * other.Z,
                X * other.Y - Y * other.X);
        }
    }
}
