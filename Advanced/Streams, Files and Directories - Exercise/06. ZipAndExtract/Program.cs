using System;
using System.IO;
using System.IO.Compression;

namespace _06._ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ZipFile.CreateFromDirectory($@"{desktopDir}\SourceFolder", $@"{desktopDir}\DestinationFolder\myZip.zip");
            ZipFile.ExtractToDirectory($@"{desktopDir}\DestinationFolder\myZip.zip", $@"{desktopDir}\FinalDestinationFolder");
        }
    }
}
