using ScalaWay.Utils.Attributes;
using System.Reflection;

namespace ScalaWay.Utils.Extentions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns the defined string value of an Enum.
        /// </summary>
        public static string GetStringValue(this Enum value)
        {
            FieldInfo entry = value.GetType().GetField(value.ToString());
            entry.ThrowIfNull("value");

            // If set, return the value.
            var attribute = entry.GetCustomAttribute<StringValueAttribute>();
            if (attribute != null)
            {
                return attribute.Text;
            }

            // Otherwise, throw an exception.
            throw new ArgumentException(
                string.Format("Enum value '{0}' does not contain a StringValue attribute", entry), "value");
        }
    }
}