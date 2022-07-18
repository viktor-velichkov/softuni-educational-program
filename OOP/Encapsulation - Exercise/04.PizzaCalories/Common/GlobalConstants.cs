using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories.Common
{
    public class GlobalConstants
    {
        public static string InvalidDoughExceptionMessage = "Invalid type of dough.";
        public static string DoughWeightOutOfRangeExceptionMessage = "Dough weight should be in the range [{0}..{1}].";
        public static string InvalidToppingTypeExceptionMessage = "Cannot place {0} on top of your pizza.";
        public static string ToppingWeightOutOfRangeExceptionMessage = "{0} weight should be in the range [{1}..{2}].";
        public static string InvalidPizzaNameExceptionMessage = "Pizza name should be between 1 and 15 symbols.";
        public static string InvalidToppingsCountExceptionMessage = "Number of toppings should be in range [{0}..{1}].";

    }
}
