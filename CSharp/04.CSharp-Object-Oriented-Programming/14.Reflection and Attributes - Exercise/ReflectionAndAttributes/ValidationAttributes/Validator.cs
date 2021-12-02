namespace ValidationAttributes
{
    using System.Linq;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            bool isValid = true;
            var properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false).Where(a => a.GetType().IsSubclassOf(typeof(MyValidationAttribute))).Cast<MyValidationAttribute>().ToArray();
                foreach (var attribute in attributes)
                {
                    isValid = attribute.IsValid(property.GetValue(obj));
                    if (isValid)
                    {
                        continue;
                    }

                    return isValid;
                }
            }

            return isValid;
        }
    }
}