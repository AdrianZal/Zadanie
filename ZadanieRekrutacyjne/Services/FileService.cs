
namespace ZadanieRekrutacyjne.Services
{
    public class FileService : IFileService
    {
        private readonly string _filePath;

        public FileService(string filePath = "catfacts.txt")
        {
            _filePath = filePath;
        }

        public async Task SaveFactAsync(string fact)
        {
            await File.AppendAllTextAsync(
                _filePath,
                fact + Environment.NewLine
            );
        }
    }
}
