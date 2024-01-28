using System.IO;

namespace SimpleFileSystem
{
    public class SimpleSaveDataController
    {
        private readonly string _directoryPath;

        public string DirectoryPath => _directoryPath;

        public SimpleSaveDataController(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        /// <summary>
        /// Check if file exists.
        /// </summary>
        /// <returns>True if file exists.</returns>
        public bool Exists(string fileName)
        {
            var filePath = Path.Combine(_directoryPath, fileName);
            return File.Exists(filePath);
        }

        /// <summary>
        /// Save bytes data to file.
        /// </summary>
        /// <returns>File path.</returns>
        public string Save(string fileName, byte[] data)
        {
            var filePath = Path.Combine(_directoryPath, fileName);
            var writer = new SimpleFileWriter(filePath);
            writer.Write(data);
            return filePath;
        }

        /// <summary>
        /// Save text data to file.
        /// </summary>
        /// <returns>File path.</returns>
        public string SaveText(string fileName, string data)
        {
            var filePath = Path.Combine(_directoryPath, fileName);
            var writer = new SimpleFileWriter(filePath);
            writer.WriteText(data);
            return filePath;
        }

        /// <summary>
        /// Load bytes data from file.
        /// </summary>
        /// <returns>File data.</returns>
        public byte[] Load(string fileName)
        {
            var filePath = Path.Combine(_directoryPath, fileName);
            var reader = new SimpleFileReader(filePath);
            return reader.Read();
        }

        /// <summary>
        /// Load text data from file.
        /// </summary>
        /// <returns>File data.</returns>
        public string LoadText(string fileName)
        {
            var filePath = Path.Combine(_directoryPath, fileName);
            var reader = new SimpleFileReader(filePath);
            return reader.ReadText();
        }
    }
}