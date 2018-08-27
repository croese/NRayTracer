﻿using NRayTracer.Core;
using System;
using Xunit;
using Tuple = NRayTracer.Core.Tuple;

namespace NRayTracer.Tests
{
    public class VectorTest
    {
        [Fact]
        public void CanCreateAVector()
        {
            var t = new Vector3(4.3, -4.2, 3.1);
            Assert.True(FloatMath.AreEqual(4.3, t.X));
            Assert.True(FloatMath.AreEqual(-4.2, t.Y));
            Assert.True(FloatMath.AreEqual(3.1, t.Z));
        }

        [Fact]
        public void VectorNotEqualToNull()
        {
            var t = new Vector3(1, 1, 1);
            Assert.False(t.Equals(null));
        }

        [Fact]
        public void VectorNotEqualToAnotherType()
        {
            var t = new Vector3(1, 1, 1);
            Assert.False(t.Equals(42));
        }

        [Fact]
        public void CanAddAVectorToAnotherVector()
        {
            var v1 = new Vector3(3, -2, 5);
            var v2 = new Vector3(-2, 3, 1);
            Assert.Equal(new Vector3(1, 1, 6), v1 + v2);
            Assert.Equal(new Vector3(1, 1, 6), v2 + v1);
        }

        [Fact]
        public void CanSubtractTwoVectors()
        {
            var v1 = new Vector3(3, 2, 1);
            var v2 = new Vector3(5, 6, 7);
            Assert.Equal(new Vector3(-2, -4, -6), v1 - v2);
        }

        [Fact]
        public void CanSubtractAVectorFromTheZeroVector()
        {
            var zero = new Vector3(0, 0, 0);
            var v = new Vector3(1, -2, 3);
            Assert.Equal(new Vector3(-1, 2, -3), zero - v);
        }

        [Fact]
        public void CanNegateAVector()
        {
            var a = new Vector3(1, -2, 3);
            Assert.Equal(new Vector3(-1, 2, -3), -a);
        }

        [Fact]
        public void CanMultiplyAVectorByAScalar()
        {
            var a = new Vector3(1, -2, 3);
            Assert.Equal(new Vector3(3.5, -7, 10.5), a * 3.5);
        }

        [Fact]
        public void CanMultiplyAVectorByAFraction()
        {
            var a = new Vector3(1, -2, 3);
            Assert.Equal(new Vector3(0.5, -1, 1.5), a * 0.5);
        }

        [Fact]
        public void CanDivideAVectorByAScalar()
        {
            var a = new Vector3(1, -2, 3);
            Assert.Equal(new Vector3(0.5, -1, 1.5), a / 2);
        }

        [Theory]
        [InlineData(1, 0, 0, 1)]
        [InlineData(0, 1, 0, 1)]
        [InlineData(0, 0, 1, 1)]
        public void VectorsHaveAMagnitude(double a, double b, double c, double expected)
        {
            var v = new Vector3(a, b, c);
            Assert.True(FloatMath.AreEqual(v.Magnitude, expected));
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-1, -2, -3)]
        public void VectorsHaveAFloatingPointMagnitude(double a, double b, double c)
        {
            var v = new Vector3(a, b, c);
            Assert.True(FloatMath.AreEqual(v.Magnitude, Math.Sqrt(14)));
        }

        [Theory]
        [InlineData(4, 0, 0, 1, 0, 0)]
        [InlineData(1, 2, 3, 0.26726, 0.53452, 0.80178)]
        public void CanNormalizeAVector(double v1, double v2, double v3, double r1, double r2, double r3)
        {
            var v = new Vector3(v1, v2, v3);
            Assert.Equal(new Vector3(r1, r2, r3), v.Normalized);
        }

        [Fact]
        public void MagnitudeOfANormalizedVectorEqualsOne()
        {
            var v = new Vector3(1, 2, 3);
            Assert.True(FloatMath.AreEqual(1, v.Normalized.Magnitude));
        }

        [Fact]
        public void CanCalculateTheDotProductOfTwoVectors()
        {
            var a = new Vector3(1, 2, 3);
            var b = new Vector3(2, 3, 4);
            Assert.True(FloatMath.AreEqual(20, a.Dot(b)));
        }

        [Fact]
        public void CanCalculateTheCrossProductOfTwoVectors()
        {
            var a = new Vector3(1, 2, 3);
            var b = new Vector3(2, 3, 4);
            Assert.Equal(new Vector3(-1, 2, -1), a.Cross(b));
            Assert.Equal(new Vector3(1, -2, 1), b.Cross(a));
        }
    }
}