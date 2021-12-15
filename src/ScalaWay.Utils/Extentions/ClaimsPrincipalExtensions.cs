using System.Security.Claims;

namespace ScalaWay.Utils.Extentions
{
    public static class ClaimsPrincipalExtensions
    {
        public static T GetCurrentUserId<T>(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var identifierClaim = principal.FindFirst(ClaimTypes.NameIdentifier);

            if (identifierClaim == null)
                throw new Exception();

            var userId = identifierClaim.Value;

            if (typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(userId, typeof(T));
            }
            else if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
            {
                return userId != null ? (T)Convert.ChangeType(userId, typeof(T)) : (T)Convert.ChangeType(0, typeof(T));
            }
            else
            {
                throw new Exception("Invalid type provided");
            }
        }

        public static Guid GetCurrentUserId(this ClaimsPrincipal principal)
        {
            return Guid.Parse(principal.GetCurrentUserId<string>());
        }
    }
}