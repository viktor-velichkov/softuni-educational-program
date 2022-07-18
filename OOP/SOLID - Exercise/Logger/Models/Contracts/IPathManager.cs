namespace CreateLogger.Models.Contracts
{
    public interface IPathManager
    {
        string FilePath { get; }
        string FileDirPath { get; }
        string GetCurrentDir();
        void EnsureDirectoryAndFileExists();
    }
}
