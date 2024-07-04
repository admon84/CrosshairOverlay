using System.Text;
using System;
using System.IO;

namespace CrosshairOverlay.Settings
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
        public string GetAbsolutePath() => _fullPath;
        public bool FileExists() => File.Exists(_fullPath);

        public void CreateFile()
        {
            if (FileExists())
            {
                throw new Exception($"Trying to create {_fullPath} even though file exists.");
            }

            try
            {
                File.Create(_fullPath).Close();
            }
            catch (Exception e)
            {
                throw new Exception($"Trying to create {_fullPath} : {e.Message}");
            }
        }

        public void DeleteFile()
        {
            try
            {
                if (FileExists())
                {
                    File.Delete(_fullPath);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Tried to remove {_fullPath} but got error: {e.Message}");
            }
        }

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

        public bool WriteFile(string content)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(_filePathRelative))
                {
                    sw.WriteLine(content);
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"The file {_filePathRelative} could not be written: {e.Message}");
            }
            return true;
        }
    }
}
