using CreateLogger.Models.Contracts;
using System.IO;

namespace CreateLogger.Models
{
    public class PathManager : IPathManager
    {
        private readonly string currentAppPath;
        private readonly string folderName;
        private readonly string fileName;

        public PathManager()
        {
            this.currentAppPath = this.GetCurrentDir();
        }
        public PathManager(string folderName, string fileName) : this()
        {
            this.folderName = folderName;
            this.fileName = fileName;
        }
        public string FileDirPath => Path.Combine(this.currentAppPath, this.folderName);

        public string FilePath => Path.Combine(this.FileDirPath, fileName);

        public void EnsureDirectoryAndFileExists()
        {
            if (!Directory.Exists(this.FileDirPath))
            {
                Directory.CreateDirectory(this.FileDirPath);
            }
            File.AppendAllText(this.FilePath,string.Empty);
        }

        public string GetCurrentDir()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
