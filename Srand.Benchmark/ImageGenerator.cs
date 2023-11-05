using System.Drawing;
using System.Drawing.Imaging;

namespace Srand.Test
{
    public class ImageGenerator
    {
        public int Width { get; set; } = 512;
        public int Height { get; set; } = 512;
        public float Brightness { get; set; } = 1f;

        private Bitmap OutTexture;

        public void Create(string outputFile, Func<byte[]> colorsProvider)
        {
            OutTexture = new Bitmap(Width, Height);
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var bytes = colorsProvider();
                    Color color = Color.FromArgb(255, bytes[0], bytes[1], bytes[2]);
                    OutTexture.SetPixel(x, y, color);
                }
            }

            // Save the texture as a PNG file
            OutTexture.Save(outputFile, ImageFormat.Png);
        }
    }
}
