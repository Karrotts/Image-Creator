using System.Drawing;
using Image_Creator.Tools;

namespace Image_Creator.Filters
{
    public static class CRTFilter
    {
        private enum RGB
        {
            R,
            G,
            B
        }

        public static void Apply(ref BitmapImage image)
        {
            Bitmap source = image.Source;
            for (int y = 0; y < source.Height; y++)
            {
                RGB current = RGB.R;
                for (int x = 0; x < source.Width; x++)
                {
                    Color pixel = source.GetPixel(x, y);
                    int average = (pixel.R + pixel.G + pixel.B) / 3;
                    switch (current)
                    {
                        case RGB.R:
                            source.SetPixel(x, y, Color.FromArgb(pixel.R, 0, 0));
                            break;
                        case RGB.G:
                            source.SetPixel(x, y, Color.FromArgb(0, pixel.G, 0));
                            break;
                        case RGB.B:
                            source.SetPixel(x, y, Color.FromArgb(0, 0, pixel.B));
                            break;
                    }
                    current = Next(current);
                }
            }
        }

        private static RGB Next(RGB current)
        {
            switch(current)
            {
                case RGB.R:
                    return RGB.G;
                    break;
                case RGB.G:
                    return RGB.B;
                    break;
                case RGB.B:
                    return RGB.R;
                    break;
            }
            return RGB.R;
        }

    }
}
