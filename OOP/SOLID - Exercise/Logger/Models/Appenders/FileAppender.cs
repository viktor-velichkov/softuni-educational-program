using CreateLogger.Enumerations;
using CreateLogger.IOManagemenet;
using CreateLogger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateLogger.Models.Appenders
{
    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout, Level level, IFile file) : base(layout, level)
        {
            this.File = file;
            this.writer = new FileWriter(this.File.Path);
        }
        public IFile File { get; }

        public override void Append(IError error)
        {
            string formattedMessage = this.File.Write(this.Layout, error);
            this.writer.WriteLine(formattedMessage);
            this.messagesAppended++;
        }
        public override string ToString()
        {
            return base.ToString() + $", File size {this.File.Size}";
        }
    }
}
