using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Family
    {
        public string Name { get; set; }
        public List<Person> Members { get; set; }
        public Family()
        {
            this.Members = new List<Person>();
        }
        public virtual void AddMember(Person member)
        {
            this.Members.Add(member);
        }
        public Person GetOldestMember()
        {
            int maxAge = int.MinValue;
            Person oldestMember = new Person();
            foreach (var person in this.Members)
            {
                if (person.Age>maxAge)
                {
                    maxAge = person.Age;
                    oldestMember = person;
                }
            }
            return oldestMember;
        }
    }
}
