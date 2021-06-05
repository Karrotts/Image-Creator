using Image_Creator.Tools;
using System;
using System.Drawing;

namespace Image_Creator
{
    class Program
    {
        static void Main(string[] args)
        {
            BitmapImage image = new BitmapImage(Console.ReadLine());
            if (image.Source != null)
            {
                Console.WriteLine("Image Loaded Successfully");
            }
        }
    }
}
