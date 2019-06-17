using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MeasurementProtocolClient.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MaxByteCountAttribute : ValidationAttribute
    {
        private readonly int maxByteCount;

        public MaxByteCountAttribute(int maxByteCount)
        {
            this.maxByteCount = maxByteCount;
        }

        public override bool IsValid(object value)
        {
            return value != null && Encoding.UTF8.GetByteCount(value.ToString()) <= maxByteCount;
        }
    }
}
