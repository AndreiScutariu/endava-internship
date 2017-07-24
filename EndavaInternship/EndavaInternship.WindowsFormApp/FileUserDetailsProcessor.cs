using System;
using System.IO;

namespace EndavaInternship.WindowsFormApp
{
    public class FileUserDetailsProcessor
    {
        private readonly Action<string> _logger;

        public FileUserDetailsProcessor(Action<string> logger)
        {
            _logger = logger;
        }

        public void Proces(string path)
        {
            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                _logger("processing client: " + fileInfo.Name);

                var lines = File.ReadAllLines(file);

                var clientName = lines[0];

                var client = new Client
                {
                    Id = fileInfo.Name,
                    Name = clientName
                };

                //...
            }
        }
    }
}