﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _08.CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = "n/a";
            this.Efficiency = "n/a";
        }
        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.Displacement = displacement.ToString();
        }
        public Engine(string model, int power, string efficiency) : this(model, power)
        {
            this.Efficiency = efficiency;
        }
        public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
        {
            this.Displacement = displacement.ToString();
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }
        public override string ToString()
        {
            return $"  {this.Model}:\n    Power: {this.Power}\n    Displacement: {this.Displacement}\n    Efficiency: {this.Efficiency}";
        }

    }
}

