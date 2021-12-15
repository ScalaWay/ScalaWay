using Microsoft.Extensions.Logging;

namespace ScalaWay.Net.Websocket.Abstractions
{
    /// <summary>
    /// Websocket factory interface
    /// </summary>
    public interface IWebsocketFactory
    {
        /// <summary>
        /// Create a websocket for an url
        /// </summary>
        /// <param name="log"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        IWebsocket CreateWebsocket(ILogger log, string url);

        /// <summary>
        /// Create a websocket for an url
        /// </summary>
        /// <param name="log"></param>
        /// <param name="url"></param>
        /// <param name="cookies"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        IWebsocket CreateWebsocket(ILogger log, string url, IDictionary<string, string> cookies, IDictionary<string, string> headers);
    }
}