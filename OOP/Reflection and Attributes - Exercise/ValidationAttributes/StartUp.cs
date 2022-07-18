using System;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main()
        {
            var person = new Person
             (
                 "Viktor",
                 20
             );

            bool isValidEntity = Validator.IsValid((object)person);

            Console.WriteLine(isValidEntity);
        }
    }
}
