using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace ImageProcessor.Tools
{
    public class BitmapImage
    {
        private Bitmap _source;
        private string _directory;
        private string _path;
        private string _name;
        private FileType _filetype;

        public Bitmap Source 
        { 
            get { return _source;   } 
            set { _source = value;  } 
        }

        public string Directory { get { return _directory; } }
        public string Path      { get { return _path; } }
        public string FileName  { get { return _name; } }

        public BitmapImage(string path)
        {
            _path = path;
            _name = FileManager.GetFileName(path);
            _directory = FileManager.GetDirectory(path);
            _filetype = FileManager.GetFileType(_name);

            try
            {
                using (Stream bmpStream = File.Open(path, System.IO.FileMode.Open))
                {
                    Image image = Image.FromStream(bmpStream);
                    _source = new Bitmap(image);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Unable to open file: {_name}\n" +
                                  $"In directory: {_directory}\n" +
                                  $"Error: {exception.Message}");
                _source = null;
            }
        }
    }
}
