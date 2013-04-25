using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeasurementProtocolClient.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsNullableOrClass(this Type type)
        {
            return type.IsClass || type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}
