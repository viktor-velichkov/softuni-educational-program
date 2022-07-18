using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace _05._DateModifier
{
    class DateModifier
    {
        public static int CalculateDaysDifference(string dateOne, string dateTwo)
        {
            DateTime firstDate = DateTime.ParseExact(dateOne,"yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(dateTwo, "yyyy MM dd", CultureInfo.InvariantCulture);
            return Math.Abs((secondDate - firstDate).Days);
        }
    }
}
