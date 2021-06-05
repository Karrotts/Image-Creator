using ImageProcessor.Filters;
using ImageProcessor.Tools;
using System;
using System.Drawing;

namespace ImageProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            BitmapImage image = new BitmapImage(@"C:\Users\Wes\Pictures\cooper.jpg");
            if (image.Source != null)
            {
                Console.WriteLine("Image Loaded Successfully");
                //CRTFilter.Apply(ref image);
                //BWFilter.Apply(ref image);
                //InvertFilter.Apply(ref image);
                PureFilter.Apply(ref image);
                FileManager.SaveBitmap(image.Source, FileType.PNG, image.Directory, "test");
            }
        }
    }
}
