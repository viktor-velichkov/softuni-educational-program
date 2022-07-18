using System;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        int minValue;
        int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }
        public int MinValue
        {
            get { return this.minValue; }
            private set
            {
                this.minValue = value;
            }
        }
        public int MaxValue
        {
            get { return this.maxValue; }
            private set
            {
                this.maxValue = value;
            }
        }
        public override bool IsValid(object obj)
        {
            if (!(obj is int))
            {
                throw new ArgumentException();
            }
            else
            {
                int intValue = (int)obj;
                return intValue > this.MinValue && intValue < this.MaxValue;
            }
        }
    }
}
