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
    }
}