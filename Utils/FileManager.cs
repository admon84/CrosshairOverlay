using System;
using System.IO;
using System.Text;

namespace CrosshairOverlay.Utils
{
    public class FileManager
    {
        private string _filePathRelative;
        private string _fullPath;

        public FileManager(string fileName)
        {
            _filePathRelative = fileName;
            _fullPath = Directory.GetCurrentDirectory() + _filePathRelative.Substring(1);
        }

        public string GetPath() => _filePathRelative;
        public bool FileExists() => File.Exists(_fullPath);

        public string ReadFile()
        {
            var sb = new StringBuilder();
            try
            {
                using (StreamReader sr = File.OpenText(GetPath()))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        sb.Append($"{s}\n");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"The file {_filePathRelative} could not be read: {e.Message}");
            }

            if (sb.ToString().Length == 0)
            {
                throw new Exception($"The file {_filePathRelative} was empty.");
            }
            return sb.ToString();
        }
    }
}
