using System;
using System.IO;

namespace _04._CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream reader = new FileStream("../../../copyMe.png", FileMode.Open, FileAccess.Read))
            {
                using (FileStream writer = new FileStream("../../../copyMe - Copy.png", FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[4096];
                    while (reader.CanRead)
                    {
                        int bytesRead = reader.Read(buffer, 0, buffer.Length);
                        if (bytesRead==0)
                        {
                            break;
                        }
                        writer.Write(buffer, 0, buffer.Length);
                    }           
                }
            }
        }
    }
}
