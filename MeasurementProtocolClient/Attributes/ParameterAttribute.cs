using System;
using System.Collections.Specialized;
using System.Linq;
using MeasurementProtocolClient.Extensions;

namespace MeasurementProtocolClient.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterAttribute : Attribute
    {
        private readonly string parameterName;

        public ParameterAttribute(string parameterName)
        {
            this.parameterName = parameterName;
        }

        public static NameValueCollection GetNameValueCollection<T>(T obj) where T : class
        {
            var items =
            (
                from prop in typeof(T).GetProperties()
                let customAttributes = prop.GetCustomAttributes(typeof(ParameterAttribute), true)
                let value = prop.GetValue(obj, null)
                where customAttributes.Length > 0 && (!prop.PropertyType.IsNullableOrClass() || value != null)
                select new
                {
                    ((ParameterAttribute)customAttributes[0]).parameterName, value
                }
            )
            .ToArray();

            var collection = new NameValueCollection(items.Length);

            foreach (var item in items)
            {
                collection.Add(item.parameterName, item.value.ToString());
            }

            return collection;
        }
    }
}
