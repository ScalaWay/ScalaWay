using ScalaWay.Net.Abstractions.Proxies;
using ScalaWay.Net.Http.Abstractions.Options;
using ScalaWay.Net.Http.Abstractions.RateLimiter;
using ScalaWay.Net.Http.Abstractions.Requests;
using ScalaWay.Utils;
using System.Net;

namespace ScalaWay.Net.Http.Abstractions.Client
{
    public abstract class HttpRestClient : IHttpRestClient
    {
        #region Constructors

        protected HttpRestClient(IHttpClientOptions options)
        {
            options = options ?? throw new ArgumentNullException(nameof(options));

            this.BaseUrl = options.BaseUrl;
            this.Timeout = options.RequestTimout;
            this.Proxy = options.Proxy;
        }

        #endregion Constructors

        #region Properties

        public string BaseUrl { get; set; }

        public IProxy? Proxy { get; set; }

        public TimeSpan Timeout { get; set; }

        public IRequestFactory RequestFactory { get; set; }

        public IEnumerable<IRateLimiter> RateLimiters { get; }

        public ICollection<Cookie> Cookies { get; }

        public ICollection<NameValue> RequestHeaders { get; }

        public int TotalRequestsMade { get; set; }

        #endregion Properties

        #region Methods

        public void AddRateLimiter(IRateLimiter limiter)
        {
            // todo
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // todo
            throw new NotImplementedException();
        }

        public void RemoveRateLimiters()
        {
            // todo
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}