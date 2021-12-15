using ScalaWay.Utils.Extentions;

namespace ScalaWay.Utils.Helpers
{
    public static class EnumHelpers
    {
        /// <summary>
        /// Returns the defined string value of an Enum.
        /// </summary>
        public static string GetEnumStringValue(Enum value)
        {
            return value.GetStringValue();
        }
    }
}