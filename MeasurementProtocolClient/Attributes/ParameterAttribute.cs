using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

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
    }
}
