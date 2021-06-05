using Image_Creator.Tools;
using System.Drawing;

namespace Image_Creator.Filters
{
    public static class BWFilter
    {
        public static void Apply(ref BitmapImage image)
        {
            Bitmap source = image.Source;
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color pixel = source.GetPixel(x, y);
                    int average = (pixel.R + pixel.G + pixel.B) / 3;
                    Color newPixel = Color.FromArgb(average, average, average);
                    source.SetPixel(x, y, newPixel);
                }
            }
        }
    }
}
