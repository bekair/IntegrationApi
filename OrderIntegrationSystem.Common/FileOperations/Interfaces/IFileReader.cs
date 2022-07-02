namespace OrderIntegrationSystem.Common.FileOperations.Interfaces
{
    public interface IFileReader
    {
        IEnumerable<string> ReadFile(string path);
    }
}
