using CreateLogger.Common;
using CreateLogger.Enumerations;
using CreateLogger.IOManagemenet;
using CreateLogger.Models.Contracts;
using System;

namespace CreateLogger.Models.Appenders
{
    class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout, Level level) : base(layout, level)
        {
            this.writer = new ConsoleWriter();
        }

        public override void Append(IError error)
        {
            string format = this.Layout.Format;
            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;
            string formattedString = string.Format(format, dateTime.ToString(GlobalConstants.DateTimeFormat), level, message);

            this.writer.WriteLine(formattedString);
            this.messagesAppended++;
        }
    }
}
