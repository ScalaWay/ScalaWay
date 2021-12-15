namespace ScalaWay.Net.Abstractions.Errors
{
    public interface IError
    {
        /// <summary>
        /// The error code from the server
        /// </summary>
        int? Code { get; set; }

        /// <summary>
        /// The message for the error that occurred
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// The data which caused the error
        /// </summary>
        object? Data { get; set; }
    }
}