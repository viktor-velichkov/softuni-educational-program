﻿using System;

namespace Shapes.Models
{
    public class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public double Radius
        {
            get { return this.radius; }
            private set { this.radius = value; }
        }

        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public override double CalculatePerimeter()
        {
            return Math.PI * 2 * this.Radius;
        }
        public override string Draw()
        {
            return base.Draw();
        }
    }
}
