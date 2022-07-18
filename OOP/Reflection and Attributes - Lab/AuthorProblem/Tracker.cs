using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public  void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            var typeMethods = type.GetMethods(BindingFlags.Instance|BindingFlags.NonPublic| BindingFlags.Public | BindingFlags.Static);
            foreach (MethodInfo method in typeMethods)
            {
                var authorAttributes = method.GetCustomAttributes(typeof(AuthorAttribute));
                if (authorAttributes.Count() > 0)
                {
                    foreach (var attr in authorAttributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {(attr as AuthorAttribute).Name}");
                    }
                }
            }
        }
    }
}
