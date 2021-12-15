using System.Net;

namespace ScalaWay.Net.Http.Abstractions.Responses
{
    /// <summary>
    /// Response object interface
    /// </summary>
    public interface IResponse
    {
        /// <summary>
        /// The response status code
        /// </summary>
        HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Whether the status code indicates a success status
        /// </summary>
        bool IsSuccessStatusCode { get; }

        /// <summary>
        /// The response headers
        /// </summary>
        IEnumerable<KeyValuePair<string, IEnumerable<string>>> ResponseHeaders { get; }

        /// <summary>
        /// Get the response stream
        /// </summary>
        /// <returns></returns>
        Task<Stream> GetResponseStreamAsync();

        /// <summary>
        /// Close the response
        /// </summary>
        void Close();
    }
}