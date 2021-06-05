using System;
using System.Drawing;
using System.IO;

namespace Image_Creator.Tools
{
    public enum FileType
    {
        PNG,
        JPG,
        BMP,
        TIF,
        GIF,
        UKN // UNKNOWN FILE TYPE
    }

    public static class FileManager
    {
        /// <summary>
        /// Returns the name of a file given the input path
        /// </summary>
        /// <param name="path"></param>
        /// <returns>A string file name</returns>
        public static string GetFileName(string path)
        {
            // splits at \ and returns the last element
            string[] split = path.Split('\\');
            return split[split.Length - 1];
        }

        /// <summary>
        /// Returns the directory of a file given the path to a file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        /// <returns>Directory of file</returns>
        public static string GetDirectory(string path)
        {
            // replace the file name with and empty string to get the directory
            return path.Replace(GetFileName(path), "");
        }

        /// <summary>
        /// Given a string file name ("example.png") returns the file type (PNG)
        /// </summary>
        /// <param name="filename">File name with dot notation ending</param>
        /// <returns>FileType</returns>
        public static FileType GetFileType(string filename)
        {
            string[] split = filename.Split('.');

            // file type is unknown if we cant determine the ending of the file
            if (split.Length == 1) return FileType.UKN;

            // get the last element in array which should be the file type
            string type = split[split.Length - 1].ToUpper();

            // normalize string for special case file types
            type = type == "TIFF" ? "TIF" : type;
            type = type == "JPEG" ? "JPG" : type;

            // try and parse data back to enum
            if (Enum.TryParse(typeof(FileType), type, out object? result))
            {
                return (FileType)result;
            }

            // file type was not found
            Console.WriteLine("Error: File Type Unknown.");
            return FileType.UKN;
        }

        /// <summary>
        /// Transforms FileType into correct ImageFormat
        /// </summary>
        /// <param name="type"></param>
        /// <returns>System.Drawing.Imaging.ImageFormat</returns>
        public static System.Drawing.Imaging.ImageFormat FileTypeToImageFormat(FileType type)
        {
            switch(type)
            {
                case FileType.PNG:
                    return System.Drawing.Imaging.ImageFormat.Png;
                case FileType.JPG:
                    return System.Drawing.Imaging.ImageFormat.Jpeg;
                case FileType.BMP:
                    return System.Drawing.Imaging.ImageFormat.Bmp;
                case FileType.GIF:
                    return System.Drawing.Imaging.ImageFormat.Gif;
                case FileType.TIF:
                    return System.Drawing.Imaging.ImageFormat.Tiff;
                default:
                    return System.Drawing.Imaging.ImageFormat.Png;
            }
        }

        /// <summary>
        /// Saves bitmap in directory with the given file type and name
        /// </summary>
        /// <param name="image"></param>
        /// <param name="type"></param>
        /// <param name="path"></param>
        public static void SaveBitmap(Bitmap image, FileType type, string directory, string name)
        {
            image.Save($@"{directory}{name}.{type}" , FileTypeToImageFormat(type));
        }
    }
}
