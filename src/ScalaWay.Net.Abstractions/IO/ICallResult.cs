using ScalaWay.Net.Abstractions.Errors;

namespace ScalaWay.Net.Abstractions.IO
{
    /// <summary>
    /// Represents the result of a network operation.
    /// </summary>
    public interface ICallResult
    {
        Error? Error { get; set; }

        bool Success { get; }
    }

    public interface ICallResult<T> : ICallResult
    {
        T Data { get; set; }
    }
}