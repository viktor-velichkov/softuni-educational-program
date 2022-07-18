using CreateLogger.Enumerations;
using System;

namespace CreateLogger.Models
{
    public interface IError
    {
        DateTime DateTime { get; }
        string Message { get; }
        Level Level{ get; }
    }
}