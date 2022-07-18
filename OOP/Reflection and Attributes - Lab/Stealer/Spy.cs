using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fields)
        {
            Type type = Type.GetType(className);
            var instance = Activator.CreateInstance(type);

            var typeFields = type.GetFields(BindingFlags.Public
                          | BindingFlags.NonPublic
                          | BindingFlags.Instance
                          | BindingFlags.Static).Where(x => fields.Contains(x.Name));
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {type.Name}");
            foreach (var item in typeFields)
            {
                sb.AppendLine($"{item.Name} = {item.GetValue(instance)}");
            }
            return sb.ToString();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            Type type = Type.GetType(className);
            var typeFields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            var typePublicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            var typeNonPublicMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo field in typeFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo method in typeNonPublicMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (MethodInfo method in typePublicMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            return sb.ToString().Trim();

        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);
            var typeNonPublicMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {type.Name}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");
            foreach (MethodInfo method in typeNonPublicMethods)
            {
                sb.AppendLine($"{method.Name}");
            }
            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type type = Type.GetType(className);
            var typeMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            foreach (MethodInfo method in typeMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in typeMethods.Where(x=>x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
            return sb.ToString().Trim();
        }
    }
}
