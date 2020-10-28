using System;
using System.ComponentModel;
using System.Reflection;

namespace LibraryConsole
{
    /// <summary>
    /// The CodeToolsBox is to have good Metord.
    /// <list type="bullet">
    /// <item>
    /// <term>GetEnumDescription</term>
    /// <description>Get the enum description</description>
    /// </item>
    /// </list>
    /// </summary>
    public static class CodeToolsBox
    {
        /// <summary>
        /// Get the enum description of the enum
        /// </summary>
        /// <returns>
        /// enum description
        /// </returns>
        /// <param name="value">The enumet you want to get the description of</param>
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[]) fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}