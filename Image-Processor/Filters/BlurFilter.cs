using ImageProcessor.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageProcessor.Filters
{
    public static class BlurFilter
    {
        public static void Apply(ref BitmapImage image)
        {
            Bitmap source = image.Source;
            Bitmap copy = new Bitmap(source);
            Color pixel = new Color();
            int count = 0;
            int rSum = 0;
            int gSum = 0;
            int bSum = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    for (int x = 0; x < source.Width; x++)
                    {
                        pixel = source.GetPixel(x, y);
                        count = 1;
                        rSum = pixel.R;
                        gSum = pixel.G;
                        bSum = pixel.B;

                        if (x - 1 >= 0)
                        {
                            count++;
                            rSum += source.GetPixel(x - 1, y).R;
                            gSum += source.GetPixel(x - 1, y).G;
                            bSum += source.GetPixel(x - 1, y).B;
                        }

                        if (x + 1 < source.Width - 1)
                        {
                            count++;
                            rSum += source.GetPixel(x + 1, y).R;
                            gSum += source.GetPixel(x + 1, y).G;
                            bSum += source.GetPixel(x + 1, y).B;
                        }

                        if (y - 1 >= 0)
                        {
                            count++;
                            rSum += source.GetPixel(x, y - 1).R;
                            gSum += source.GetPixel(x, y - 1).G;
                            bSum += source.GetPixel(x, y - 1).B;
                        }

                        if (y + 1 < source.Height - 1)
                        {
                            count++;
                            rSum += source.GetPixel(x, y + 1).R;
                            gSum += source.GetPixel(x, y + 1).G;
                            bSum += source.GetPixel(x, y + 1).B;
                        }
                        source.SetPixel(x, y, Color.FromArgb(rSum / count, gSum / count, bSum / count));
                    }
                }
            }
        }
    }
}
