using ScalaWay.Net.Abstractions.IO;
using ScalaWay.Net.Http.Abstractions.Client;
using ScalaWay.Net.Http.Abstractions.Enums;

namespace ScalaWay.Net.Http.Abstractions.RateLimiter
{
    public interface IRateLimiter
    {
        /// <summary>
        /// Limit the request if needed.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="url"></param>
        /// <param name="limitBehaviour"></param>
        /// <param name="credits"></param>
        /// <returns></returns>
        ICallResult<double> LimitRequest(IHttpRestClient client, string url, RateLimitingBehaviour limitBehaviour, int credits = 1);
    }
}