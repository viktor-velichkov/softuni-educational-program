using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05._DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, decimal>> fileInfo = new Dictionary<string, Dictionary<string, decimal>>();
            string[] files = Directory.GetFiles($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}");

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                string extension = info.Extension;
                string fileName = info.Name;
                decimal size = CalculateFileSize(file);
                if (!fileInfo.ContainsKey(extension))
                {
                    fileInfo.Add(extension, new Dictionary<string, decimal>());
                }                
                fileInfo[extension].Add(fileName, size);
            }
            using (StreamWriter writer = new StreamWriter($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\report.txt"))
            {
                foreach (var item in fileInfo.OrderByDescending(x => x.Value.Values.Count).ThenBy(x => x.Key))
                {
                    writer.WriteLine(item.Key);
                    foreach (var file in item.Value.OrderBy(x => x.Value))
                    {
                        writer.WriteLine($"--{file.Key} - {file.Value:f3}kb");
                    }
                }
            }
            

        }
        static decimal CalculateFileSize(string filepath)
        {
            decimal size = 0;
            using (FileStream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                size = stream.Length;
            }
            return size / 1024;
        }
    }
}
