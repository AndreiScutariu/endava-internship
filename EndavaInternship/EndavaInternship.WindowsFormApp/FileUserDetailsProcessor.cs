using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EndavaInternship.WindowsFormApp
{
    public class FileUserDetailsProcessor
    {
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly Action<string> _log;

        public FileUserDetailsProcessor(Action<string> log, CancellationTokenSource cancellationTokenSource)
        {
            _log = log;
            _cancellationTokenSource = cancellationTokenSource;
        }

        public IEnumerable<Task<string>> Proces(string path)
        {
            return Directory.GetFiles(path).Select(filePath => Task.Factory.StartNew(() =>
            {
                var file = new FileInfo(filePath);
                var fileName = file.Name;

                _log("Start process file: " + fileName);

                Thread.Sleep(TimeSpan.FromMilliseconds(1000));

                var guid = new Guid(fileName);

                _log("End process file: " + guid);

                return fileName;
            }, _cancellationTokenSource.Token));
        }

        public int Count(string path)
        {
            var files = Directory.GetFiles(path);

            Parallel.For(0, files.Length, i =>
            {
                var file = new FileInfo(files[i]);
                var fileName = file.Name;

                _log("Parallel.For " + fileName);
            });

            return 0;
        }
    }
}