using System;

namespace NRayTracer.Core
{
    public static class FloatMath
    {
        public const double EPSILON = 0.00001;

        public static bool AreEqual(double a, double b)
        {
            return Math.Abs(a - b) < EPSILON;
        }
    }
}
