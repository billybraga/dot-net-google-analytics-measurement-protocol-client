using System;

namespace MeasurementProtocolClient.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsNullableOrClass(this Type type)
        {
            return type.IsClass || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
    }
}
