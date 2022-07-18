using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        string model;
        string color;
        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }
        public string Model { get => this.model; set => this.model = value; }
        public string Color { get => this.color; set => this.color = value; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{this.Color} {this.GetType().Name} {this.Model}");
            result.AppendLine(this.Start());
            result.AppendLine(this.Stop());
            return result.ToString().Trim();
        }
    }
}
