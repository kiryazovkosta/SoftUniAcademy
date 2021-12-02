namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    internal class Spy
    {
        public string StealFieldInfo(string typeName, params string[] fields)
        {
            StringBuilder result = new StringBuilder();

            Type classType = Type.GetType(typeName);
            result.AppendLine($"Class under investigation: {classType.FullName}");

            FieldInfo[] typeFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            var classInstance = Activator.CreateInstance(classType);
            foreach (var field in typeFields)
            {
                if (fields.Contains(field.Name))
                {
                    result.AppendLine($"{field.Name} = {field.GetValue(classInstance) }");
                }
            }

            return result.ToString();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder result = new StringBuilder(); 

            Type classType = Type.GetType(className);
            var getters = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Where(m => m.Name.StartsWith("get_"));
            foreach (var getter in getters)
            {
                result.AppendLine($"{getter.Name} will return {getter.ReturnType.FullName}");
            }

            var setters = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Where(m => m.Name.StartsWith("set_"));
            foreach (var setter in setters)
            {
                result.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First(p => p.Name == "value").ParameterType.FullName}");
            }

            return result.ToString();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder result = new StringBuilder();

            Type classType = Type.GetType(className);

            FieldInfo[] publicFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            foreach (var field in publicFields)
            {
                result.AppendLine($"{field.Name} must be private!");
            }

            var getMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).Where(m => m.Name.StartsWith("get_"));
            foreach (var getMethod in getMethods)
            {
                result.AppendLine($"{getMethod.Name} have to be public!");
            }

            var setMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public).Where(m => m.Name.StartsWith("set_")).ToList();
            foreach (var setMethod in setMethods)
            {
                result.AppendLine($"{setMethod.Name} have to be public!");
            }

            return result.ToString();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder result = new StringBuilder();

            Type classType = Type.GetType(className);
            result.AppendLine($"All Private Methods of Class: {classType.FullName}");
            result.AppendLine($"Base Class: {classType.BaseType.Name}");

            var methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var method in methods)
            {
                result.AppendLine(method.Name);
            }

            return result.ToString();
        }
    }
}