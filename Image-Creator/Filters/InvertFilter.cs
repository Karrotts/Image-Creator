using Image_Creator.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Image_Creator.Filters
{
    public static class InvertFilter
    {
        public static void Apply(ref BitmapImage image)
        {
            Bitmap source = image.Source;
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color pixel = source.GetPixel(x, y);
                    Color newPixel = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                    source.SetPixel(x, y, newPixel);
                }
            }

        }
    }
}
