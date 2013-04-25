using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeasurementProtocolClient
{
    public class Size
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Size(int width, int height)
        {
            Height = height;
            Width = width;

            if (Encoding.UTF8.GetByteCount(ToString()) > 20)
                throw new Exception("Parameter must be less than 20 bytes");
        }

        public override string ToString()
        {
            return string.Format("{0}x{1}", Width, Height);
        }
    }
}
