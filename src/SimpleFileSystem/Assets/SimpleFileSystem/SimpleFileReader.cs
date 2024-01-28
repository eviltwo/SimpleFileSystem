using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleFileSystem
{
    public class SimpleFileReader
    {
        private readonly string _filePath;

        public string FilePath => _filePath;

        public SimpleFileReader(string filePath)
        {
            _filePath = filePath;
        }

        public byte[] Read()
        {
            return File.ReadAllBytes(_filePath);
        }

        public Task<byte[]> ReadAsync(CancellationToken cancellationToken)
        {
            return File.ReadAllBytesAsync(_filePath, cancellationToken);
        }

        public string ReadText()
        {
            return File.ReadAllText(_filePath);
        }

        public Task<string> ReadTextAsync(CancellationToken cancellationToken)
        {
            return File.ReadAllTextAsync(_filePath, cancellationToken);
        }
    }
}
