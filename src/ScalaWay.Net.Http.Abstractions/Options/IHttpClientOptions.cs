using ScalaWay.Net.Abstractions.Proxies;

namespace ScalaWay.Net.Http.Abstractions.Options
{
    public interface IHttpClientOptions
    {
        string BaseUrl { get; set; }

        IProxy? Proxy { get; set; }

        TimeSpan RequestTimout { get; set; }

        HttpClient HttpClient { get; set; }
    }
}