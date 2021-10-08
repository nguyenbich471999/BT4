using System;

namespace BT4.Models
{
    internal class StringlengthAttribute : Attribute
    {
        private int v;

        public StringlengthAttribute(int v)
        {
            this.v = v;
        }
    }
}