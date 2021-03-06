using ScalaWay.Net.Abstractions.Proxies;

namespace ScalaWay.Net.Http.Abstractions.Requests
{
    /// <summary>
    /// Request factory interface.
    /// </summary>
    public interface IRequestFactory
    {
        /// <summary>
        /// Create a request for an uri.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="uri"></param>
        /// <param name="requestId"></param>
        /// <returns></returns>
        IRequest Create(HttpMethod method, string uri, int requestId);

        /// <summary>
        /// Configure the requests created by this factory.
        /// </summary>
        /// <param name="requestTimeout">Request timeout to use</param>
        /// <param name="proxy">Proxy settings to use</param>
        /// <param name="httpClient">Optional shared http client instance</param>
        void Configure(TimeSpan requestTimeout, IProxy? proxy, HttpClient? httpClient = null);
    }
}