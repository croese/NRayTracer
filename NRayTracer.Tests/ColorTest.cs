using NRayTracer.Core;
using Xunit;

namespace NRayTracer.Tests
{
    public class ColorTest
    {
        [Fact]
        public void CanCreateAColor()
        {
            var c = new Color(-0.5, 0.4, 1.7);
            Assert.True(FloatMath.AreEqual(c.Red, -0.5));
            Assert.True(FloatMath.AreEqual(c.Green, 0.4));
            Assert.True(FloatMath.AreEqual(c.Blue, 1.7));
        }

        [Fact]
        public void ColorsCanBeAdded()
        {
            var c1 = new Color(0.9, 0.6, 0.75);
            var c2 = new Color(0.7, 0.1, 0.25);
            Assert.Equal(new Color(1.6, 0.7, 1.0), c1 + c2);
        }

        [Fact]
        public void ColorsCanBeSubtracted()
        {
            var c1 = new Color(0.9, 0.6, 0.75);
            var c2 = new Color(0.7, 0.1, 0.25);
            Assert.Equal(new Color(0.2, 0.5, 0.5), c1 - c2);
        }

        [Fact]
        public void ColorsCanBeMultipliedByAScalar()
        {
            var c = new Color(0.2, 0.3, 0.4);
            Assert.Equal(new Color(0.4, 0.6, 0.8), c * 2);
        }

        [Fact]
        public void ColorsCanBeMultiplied()
        {
            var c1 = new Color(1, 0.2, 0.4);
            var c2 = new Color(0.9, 1, 0.1);
            Assert.Equal(new Color(0.9, 0.2, 0.04), c1 * c2);
        }
    }
}
