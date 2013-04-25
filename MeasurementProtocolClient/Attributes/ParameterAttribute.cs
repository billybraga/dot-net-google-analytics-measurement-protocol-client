using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MeasurementProtocolClient.Extensions;

namespace MeasurementProtocolClient.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ParameterAttribute : Attribute
    {
        private string parameterName;

        public ParameterAttribute(string parameterName)
        {
            this.parameterName = parameterName;
        }
        
        public static NameValueCollection GetNameValueCollection<T>(T obj) where T : class
        {            
            var items =
            (
                from prop in typeof(T).GetProperties()
                let customAttributes = prop.GetCustomAttributes(typeof(ParameterAttribute), false)
                let value = prop.GetValue(obj, null)
                where customAttributes.Length > 0 && (!prop.PropertyType.IsNullableOrClass() || value != null)
                select new
                {
                    parameterName = ((ParameterAttribute)customAttributes[0]).parameterName,
                    value = value
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
