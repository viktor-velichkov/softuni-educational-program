using System.ComponentModel.DataAnnotations;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class Person
    {
        private string fullName;
        private int age;

        public Person(string name, int age)
        {
            this.FullName = name;
            this.Age = age;
        }
        [MyRequired]
        public string FullName
        {
            get { return this.fullName; }
            private set { this.fullName = value; }
        }
        [MyRange(12, 90)]
        public int Age
        {
            get { return this.age; }
            private set { this.age = value; }
        }

    }
}
