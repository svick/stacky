using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Stacky
{
    public static class EnumHelper
    {
        public static T GetAttribute<T>(this Enum value)
            where T : Attribute
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            T[] attributes = (T[])fi.GetCustomAttributes(typeof(T), false);
            if (attributes == null)
                return null;
            return attributes.FirstOrDefault();
        }
    }
}