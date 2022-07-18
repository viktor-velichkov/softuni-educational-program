﻿using System;
using System.IO;

namespace CreateLogger.IOManagemenet
{
    public class FileWriter : IWriter
    {
        public FileWriter(string filePath)
        {
            this.FilePath = filePath;
        }
        public string FilePath { get;}
        public void Write(string text)
        {
            File.AppendAllText(this.FilePath, text);
        }

        public void WriteLine(string text)
        {
            File.AppendAllText(this.FilePath, text + Environment.NewLine);
        }
    }
}
