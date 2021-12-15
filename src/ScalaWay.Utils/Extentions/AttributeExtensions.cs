using System.Reflection;

namespace ScalaWay.Utils.Extentions
{
    public static class AttributeExtensions
    {
        /// <summary>
        /// Utility method for returning the first matching custom attribute (or <c>null</c>) of the specified member.
        /// </summary>
        public static T GetCustomAttribute<T>(this MemberInfo info) where T : Attribute
        {
            object[] results = info.GetCustomAttributes(typeof(T), false).ToArray();
            return results.Length == 0 ? null : (T)results[0];
        }
    }
}