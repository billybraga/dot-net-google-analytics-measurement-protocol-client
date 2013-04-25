using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MeasurementProtocolClient.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class MaxByteCountAttribute : ValidationAttribute
    {
        private int maxByteCount;

        public MaxByteCountAttribute(int maxByteCount)
        {
            this.maxByteCount = maxByteCount;
        }

        public override bool IsValid(string value)
        {
            return Encoding.UTF8.GetByteCount(value) <= maxByteCount;
        }
    }
}
