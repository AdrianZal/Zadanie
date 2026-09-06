using ZadanieRekrutacyjne.Services;

namespace Zadanierekrutacyjne.Tests.ServicesTests
{
    public class FileServiceTests : IDisposable
    {
        private readonly string _testFilePath = "test_catfacts.txt";

        public FileServiceTests()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }

        [Fact]
        public async Task SaveFactAsync_AppendsFactToFile()
        {
            // Arrange
            var fileService = new FileService(_testFilePath);
            var testFact = "fact: Test cat fact | length: 14";

            // Act
            await fileService.SaveFactAsync(testFact);

            // Assert
            Assert.True(File.Exists(_testFilePath));
            var lines = await File.ReadAllLinesAsync(_testFilePath);
            Assert.Single(lines);
            Assert.Equal(testFact, lines[0]);
        }

        public void Dispose()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }
    }
}