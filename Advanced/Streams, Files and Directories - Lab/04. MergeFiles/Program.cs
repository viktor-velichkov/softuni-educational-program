using System;
using System.IO;

namespace _04._MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader1 = new StreamReader("../../../FileOne.txt"))
            {
                using (StreamReader reader2 = new StreamReader("../../../FileTwo.txt"))
                {
                    string line1 = reader1.ReadLine();
                    string line2 = reader2.ReadLine();
                    using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
                    {
                        while (line1 != null || line2 != null)
                        {

                            writer.WriteLine(line1);
                            writer.WriteLine(line2);

                            line1 = reader1.ReadLine();
                            line2 = reader2.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
