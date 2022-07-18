using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class Cat : Animal
    {
        public override void WhatSays()
        {
            base.WhatSays();
            Console.WriteLine("Az sym kotka!  Mqu!");
        }
    }

    
}
