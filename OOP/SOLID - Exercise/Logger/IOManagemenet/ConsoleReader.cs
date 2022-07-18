using CreateLogger.IOManagemenet.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreateLogger.IOManagemenet
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
