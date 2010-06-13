using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Stacky
{
    /// <summary>
    /// Enum helper methods.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Gets the attribute of the specified type for the provided enum value.
        /// </summary>
        /// <typeparam name="T">The attribute type.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns>The attribute if it exists, otherwise null.</returns>
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