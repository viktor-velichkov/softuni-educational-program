using CreateLogger.Common;
using CreateLogger.Enumerations;
using CreateLogger.Models.Contracts;
using System;
using System.IO;
using System.Linq;

namespace CreateLogger.Models
{
    public class LogFile : IFile
    {
        private readonly IPathManager pathManager;
        public LogFile(IPathManager pathManager)
        {
            this.pathManager = pathManager;
            this.pathManager.EnsureDirectoryAndFileExists();
        }
        public long Size => this.CalculateFileSize();

        public string Path => this.pathManager.FilePath;


        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;
            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;
            string formattedMessage = string.Format(format, dateTime.ToString(GlobalConstants.DateTimeFormat), level, message);
            return formattedMessage;
        }

        private long CalculateFileSize()
        {
            string fileText = File.ReadAllText(this.Path);
            return fileText.ToCharArray().Where(x=>Char.IsLetter(x)).Sum(x => x);
        }
    }
}
