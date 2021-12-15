namespace ScalaWay.Utils.Extentions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Utility method for throwing an <see cref="System.ArgumentNullException"/> if the object is
        /// <c>null</c>.
        /// </summary>
        public static T ThrowIfNull<T>(this T obj, string paramName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(paramName);
            }

            return obj;
        }
    }
}