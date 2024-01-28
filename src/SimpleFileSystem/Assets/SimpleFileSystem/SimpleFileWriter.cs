using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleFileSystem
{
    public class SimpleFileWriter
    {
        private readonly string _filePath;
        private readonly string _tmpFilePath;

        public string FilePath => _filePath;

        public SimpleFileWriter(string filePath, string tmpFileName = "TemporaryFile")
        {
            _filePath = filePath;
            var directory = Path.GetDirectoryName(filePath);
            _tmpFilePath = Path.Combine(directory, tmpFileName);
        }

        public void Write(byte[] data)
        {
            File.WriteAllBytes(_tmpFilePath, data);
            ApplyFileByTemporary(_tmpFilePath, _filePath);
        }

        public async Task WriteAsync(byte[] data, CancellationToken cancellationToken)
        {
            await File.WriteAllBytesAsync(FilePath, data, cancellationToken);
            ApplyFileByTemporary(_tmpFilePath, _filePath);
        }

        public void WriteText(string data)
        {
            File.WriteAllText(_tmpFilePath, data);
            ApplyFileByTemporary(_tmpFilePath, _filePath);
        }

        public async Task WriteTextAsync(string data, CancellationToken cancellationToken)
        {
            await File.WriteAllTextAsync(_tmpFilePath, data, cancellationToken);
            ApplyFileByTemporary(_tmpFilePath, _filePath);
        }

        private static void ApplyFileByTemporary(string tmpFilePath, string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Replace(tmpFilePath, filePath, null, true);
                }
                else
                {
                    File.Move(tmpFilePath, filePath);
                }
            }
            finally
            {
                File.Delete(tmpFilePath);
            }
        }
    }
}

