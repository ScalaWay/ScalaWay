namespace ScalaWay.Utils.Extentions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Utility method for throwing an <see cref="System.ArgumentNullException"/> if the string is
        /// <c>null</c> or empty.
        /// </summary>
        /// <returns>The original string.</returns>
        public static string ThrowIfNullOrEmpty(this string str, string paramName)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("Parameter was empty", paramName);
            }
            return str;
        }
    }
}