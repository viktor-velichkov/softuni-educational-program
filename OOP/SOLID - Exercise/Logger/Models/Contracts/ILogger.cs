using CreateLogger.Models.Contracts;
using System.Collections.Generic;

namespace CreateLogger.Models
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }
        void Log(IError error);
    }
}
