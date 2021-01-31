using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileManagerFromIevgenii1501
{
    public static class ExtensionForLinq
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }
    }

    class PathView
    {
        private string _currentPath;

        public List<IReader> readers = new List<IReader>();
        public PathView(string basePath = @"c:\")
        {
            if (!Path.IsPathRooted(basePath))
            {
                throw new ArgumentException(nameof(basePath));
            }
            this._currentPath = basePath;
        }

        public void Show()
        {
            this.TryShowFile();

            var query = Directory.EnumerateDirectories(this._currentPath).Select(d => new DirectoryInfo(d))
                .OrderBy(d => d.Name).ThenBy(d => d.LastWriteTime).Cast<FileSystemInfo>();

            query = query.Concat(Directory.EnumerateFiles(_currentPath).Select(f => new FileInfo(f))
                .OrderBy(f => f.Name).ThenBy(f => f.LastWriteTime));

            Console.Clear();
            Console.WriteLine(this._currentPath);

            foreach (var d in query.Where(x => !x.Attributes.HasFlag(FileAttributes.Hidden)))
            {
                Console.WriteLine($"\t{d.Name}");
            }
        }

        public void Go(string dirName)
        {
            var newPath = Path.Combine(this._currentPath, dirName);
            newPath = Path.GetFullPath(newPath);
            if (Directory.Exists(newPath) || System.IO.File.Exists(newPath))
                this._currentPath = newPath;
        }

        private void TryShowFile()
        {
            if (!System.IO.File.Exists(this._currentPath))
                return;


            string extention = Path.GetExtension(_currentPath);

            //TODO: Rework using reflection and some greate OOP
            //Add reflection
            IReader reader = readers.Select(x => x).Where(x => extention.Equals(x.GetType().GetProperty("Format").GetValue(x).ToString())).FirstOrDefault();
            string resultStr = String.Empty;
            if (reader == null)
            {
                int count = 2048;
                byte[] result = new byte[count];
                using (var stream = System.IO.File.OpenRead(_currentPath))
                    count = stream.Read(result, 0, count);

                resultStr = BitConverter.ToString(result, 0, count).Replace('-', ' ');
            }
            else
            {
                resultStr = reader.GetFileData(_currentPath);
            }

            Console.Clear();
            Console.WriteLine(resultStr);
            Console.ReadLine();
            this.Go(Path.GetDirectoryName(this._currentPath));
        }
    }

    public interface IReader
    {
        public string GetFileData(string currentPath);
    }

    public class TxtReader : IReader
    {
        string formmat = ".txt";
        public string Format
        {
            get
            {
                return formmat;
            }
        }

        public string GetFileData(string currentPath)
        {
            int count = 1024;
            char[] result = new char[count];
            using (var reader = System.IO.File.OpenText(currentPath))
                count = reader.Read(result, 0, count);

            return new string(result);
        }
    }

    public class OtherFilesReader : IReader
    {
        string formmat = ".";
        public string Format
        {
            get
            {
                return formmat;
            }
        }

        public string GetFileData(string currentPath)
        {
            int count = 2048;
            byte[] result = new byte[count];
            using (var stream = System.IO.File.OpenRead(currentPath))
                count = stream.Read(result, 0, count);

            return BitConverter.ToString(result, 0, count).Replace('-', ' ');
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var pv = new PathView();
            //Add readers
            pv.readers.Add(new TxtReader());
            pv.readers.Add(new OtherFilesReader());
            do
            {
                pv.Show();
                pv.Go(Console.ReadLine());
            }
            while (true);
        }
    }
}
