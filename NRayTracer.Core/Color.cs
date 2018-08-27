using System;

namespace NRayTracer.Core
{
    public struct Color : IEquatable<Color>
    {
        public Color(double red, double green, double blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public double Red { get; }
        public double Green { get; }
        public double Blue { get; }

        public bool Equals(Color other)
        {
            return FloatMath.AreEqual(Red, other.Red)
                            && FloatMath.AreEqual(Green, other.Green)
                            && FloatMath.AreEqual(Blue, other.Blue);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Color))
            {
                return false;
            }

            return Equals((Color)obj);
        }

        public static Color operator +(Color lhs, Color rhs)
        {
            return new Color(lhs.Red + rhs.Red, lhs.Green + rhs.Green, lhs.Blue + rhs.Blue);
        }

        public static Color operator -(Color lhs, Color rhs)
        {
            return new Color(lhs.Red - rhs.Red, lhs.Green - rhs.Green, lhs.Blue - rhs.Blue);
        }

        public static Color operator *(Color c, double factor)
        {
            return new Color(c.Red * factor, c.Green * factor, c.Blue * factor);
        }

        public static Color operator *(Color lhs, Color rhs)
        {
            return new Color(lhs.Red * rhs.Red, lhs.Green * rhs.Green, lhs.Blue * rhs.Blue);
        }
    }
}
