using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = "n/a";
            this.Color = "n/a";
        }
        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight.ToString();
        }
        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Color = color;
        }
        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            this.Weight = weight.ToString();
            this.Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            return $"{this.Model}:\n{this.Engine.ToString()}\n  Weight: {this.Weight}\n  Color: {this.Color}";
        }
    }
}
