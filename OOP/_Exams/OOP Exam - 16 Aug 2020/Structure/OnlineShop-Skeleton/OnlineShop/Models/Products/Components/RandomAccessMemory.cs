﻿namespace OnlineShop.Models.Products.Components
{
    public class RandomAccessMemory : Component
    {
        private const double MEMORY_PERFORMANCE_MULTIPLIER = 1.20;
        public RandomAccessMemory(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) 
            : base(id, manufacturer, model, price, overallPerformance, generation)
        {
           
        }

        public override double OverallPerformance => base.OverallPerformance * MEMORY_PERFORMANCE_MULTIPLIER;
    }
}
