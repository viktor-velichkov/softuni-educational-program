using CreateLogger.Enumerations;

namespace CreateLogger.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }
        Level Level { get; }

        void Append(IError error);
    }
}
