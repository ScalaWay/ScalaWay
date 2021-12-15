using ScalaWay.Net.Abstractions.Proxies;
using ScalaWay.Net.Http.Abstractions.RateLimiter;
using ScalaWay.Net.Http.Abstractions.Requests;
using ScalaWay.Utils;
using System.Net;

namespace ScalaWay.Net.Http.Abstractions.Client
{
    public interface IHttpRestClient : IDisposable
    {
        /// <summary>
        /// Base URL for all request.
        /// </summary>
        string BaseUrl { get; set; }

        /// <summary>
        /// Timeout value for all requests (used if not supplied in the request method).
        /// </summary>
        TimeSpan Timeout { get; set; }

        /// <summary>
        ///
        /// </summary>
        IProxy? Proxy { get; set; }

        int TotalRequestsMade { get; set; }

        /// <summary>
        /// The factory for creating requests.
        /// </summary>
        IRequestFactory RequestFactory { get; set; }

        /// <summary>
        /// List of active rate limiters
        /// </summary>
        IEnumerable<IRateLimiter> RateLimiters { get; }

        /// <summary>
        /// Adds a rate limiter to the client. There are 2 choices, the <see cref="RateLimiterTotal"/> and the <see cref="RateLimiterPerEndpoint"/>.
        /// </summary>
        /// <param name="limiter">The limiter to add</param>
        void AddRateLimiter(IRateLimiter limiter);

        /// <summary>
        /// Removes all rate limiters from this client
        /// </summary>
        void RemoveRateLimiters();

        /// <summary>
        /// Used to set cookies for requests.
        /// </summary>
        ICollection<Cookie> Cookies { get; }

        /// <summary>
        /// Request headers.
        /// </summary>
        ICollection<NameValue> RequestHeaders { get; }

        //Task SendRequestAsync();
    }
}