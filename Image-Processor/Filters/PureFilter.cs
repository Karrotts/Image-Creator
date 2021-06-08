using ImageProcessor.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageProcessor.Filters
{
    public static class PureFilter
    {
        public static void Apply(ref BitmapImage image)
        {
            Bitmap source = image.Source;
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color pixel = source.GetPixel(x, y);
                    int[] colorValues = { pixel.R, pixel.G, pixel.B };
                    int maxColor = colorValues.Max();
                    int index = colorValues.ToList().IndexOf(maxColor);
                    Color newPixel = new Color();
                    switch (index)
                    {
                        case 0:
                            newPixel = Color.FromArgb(pixel.R, 0, 0);
                            break;
                        case 1:
                            newPixel = Color.FromArgb(0, pixel.G, 0);
                            break;
                        case 2:
                            newPixel = Color.FromArgb(0, 0, pixel.B);
                            break;
                    }
                    source.SetPixel(x, y, newPixel);
                }
            }
        }

        public static void ApplyBlackWhite(ref BitmapImage image)
        {
            Bitmap source = image.Source;
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color pixel = source.GetPixel(x, y);
                    Color newPixel = new Color();
                    if (pixel.R > 0)
                    {
                        newPixel = Color.FromArgb(255, 255, 255);
                        source.SetPixel(x, y, newPixel);
                        continue;
                    }

                    if (pixel.B > 0)
                    {
                        newPixel = Color.FromArgb(255, 255, 255);
                        source.SetPixel(x, y, newPixel);
                        continue;
                    }

                    if (pixel.G > 0)
                    {
                        newPixel = Color.FromArgb(0, 0, 0);
                        source.SetPixel(x, y, newPixel);
                        continue;
                    }
                }
            }
        }
    }
}
