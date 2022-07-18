using Shapes.Models;
using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape firstShape = new Rectangle(3,4);
            Shape secondShape = new Circle(10);
            Console.WriteLine(firstShape.Draw());
            Console.WriteLine(secondShape.Draw());
            Console.WriteLine(firstShape.CalculateArea());
            Console.WriteLine(secondShape.CalculatePerimeter());

        }
    }
}
