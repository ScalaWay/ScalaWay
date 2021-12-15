namespace ScalaWay.Utils.Extentions
{
    public static class EnumerableExtensions
    {
        /// <summary>Returns <c>true</c> in case the enumerable is <c>null</c> or empty.</summary>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> coll)
        {
            return coll == null || coll.Any();
        }
    }
}