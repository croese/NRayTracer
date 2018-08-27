using NRayTracer.Core;
using Xunit;

namespace NRayTracer.Tests
{
    public class CanvasTest
    {
        [Fact]
        public void CanCreateACanvas()
        {
            var c = new Canvas(10, 20);
            Assert.Equal(10, c.Width);
            Assert.Equal(20, c.Height);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Assert.Equal(new Color(0, 0, 0), c.GetPixel(i, j));
                }
            }
        }

        [Fact]
        public void CanSetACanvasPixel()
        {
            var c = new Canvas(10, 20);
            var red = new Color(1, 0, 0);
            c.WritePixel(2, 3, red);
            Assert.Equal(red, c.GetPixel(2, 3));
        }
    }
}
