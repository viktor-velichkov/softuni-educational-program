using System;
using System.IO;

namespace _05._SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream reader = new FileStream("../../../sliceMe.txt", FileMode.Open, FileAccess.Read))
            {
                long size = reader.Length / 4;
                byte[] byteArray = new byte[size];

                for (int i = 0; i < 4; i++)
                {
                    reader.Read(byteArray, 0, byteArray.Length);
                    using (FileStream writer = new FileStream($"../../../Part-{i + 1}.txt", FileMode.Create, FileAccess.Write))
                    {
                        writer.Write(byteArray);
                    }

                }
            }
        }
    }
}
