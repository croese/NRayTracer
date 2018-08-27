namespace NRayTracer.Core
{
    public class Canvas
    {
        private readonly Color[] _pixels;

        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;
            _pixels = new Color[width * height];
        }

        public int Width { get; }
        public int Height { get; }

        public Color GetPixel(int x, int y)
        {
            return _pixels[y * Width + x];

        }

        public void WritePixel(int x, int y, Color color)
        {
            _pixels[y * Width + x] = color;
        }
    }
}
