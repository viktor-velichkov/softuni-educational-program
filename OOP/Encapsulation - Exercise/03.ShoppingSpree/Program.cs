using _03.ShoppingSpree.Core;
using _03.ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;

namespace _03.ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Engine engine = new Engine();
                engine.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }            
        }
    }
}

