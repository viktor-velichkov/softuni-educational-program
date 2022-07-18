using System;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            bool isValid = true;
            Type type = obj.GetType();
            var properties = type.GetProperties(BindingFlags.NonPublic
                                              | BindingFlags.Public
                                              | BindingFlags.Static
                                              | BindingFlags.Instance)
                                                .Where(x => x.GetCustomAttributes(typeof(MyValidationAttribute)).Count() > 0);
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(typeof(MyValidationAttribute)).Cast<MyValidationAttribute>();
                foreach (var attr in attributes)
                {
                    if (!attr.IsValid(property.GetValue(obj)))
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid == false)
                {
                    break;
                }
            }
            return isValid;
        }
    }
}
