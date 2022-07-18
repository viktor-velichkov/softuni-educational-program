namespace CreateLogger.Models.Contracts
{
    public interface IFile
    {
        string Path { get; }
        long Size { get; }
        public string Write(ILayout layout, IError error);
    }
}
