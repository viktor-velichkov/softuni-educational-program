using System;
using System.Reflection;

namespace ValidationAttributes.Attributes
{
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
        protected static PropertyInfo[] GetAllPropertiesOfType(Type type)
        {
            return type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
        }
    }
}
