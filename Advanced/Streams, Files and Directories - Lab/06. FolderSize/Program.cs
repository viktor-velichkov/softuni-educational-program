using System;
using System.IO;

namespace _06._FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("../../../TestFolder");
            decimal sumSize = 0;
            foreach (var file in files)
            {
                using (FileStream stream = new FileStream(file,FileMode.Open,FileAccess.Read))
                {
                    FileInfo info = new FileInfo(file);
                    sumSize += info.Length;
                }
            }
            using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
            {
                writer.WriteLine(sumSize / 1024 / 1024);
            }
            
        }
    }
}
