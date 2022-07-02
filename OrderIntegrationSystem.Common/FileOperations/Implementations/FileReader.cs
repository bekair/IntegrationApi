using OrderIntegrationSystem.Common.FileOperations.Interfaces;

namespace OrderIntegrationSystem.Common.FileOperations.Implementations
{
    public class FileReader : IFileReader
    {
        public IEnumerable<string> ReadFile(string path)
        {
            return File.ReadLines(path);
        }
    }
}
