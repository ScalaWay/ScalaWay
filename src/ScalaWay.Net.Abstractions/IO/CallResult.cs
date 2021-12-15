using ScalaWay.Net.Abstractions.Errors;
using System.Diagnostics.CodeAnalysis;

namespace ScalaWay.Net.Abstractions.IO
{
    public class CallResult : ICallResult
    {
        protected CallResult(Error? error)
        {
            Error = error;
        }

        /// <summary>
        /// An error if the call didn't succeed, will always be filled if Success = false.
        /// </summary>
        public Error? Error { get; set; }

        /// <summary>
        /// Whether the call was successful.
        /// </summary>
        public virtual bool Success { get => Error == null; }

        /// <summary>
        /// Overwrite bool check so we can use if(callResult) instead of if(callResult.Success).
        /// </summary>
        /// <param name="obj"></param>
        public static implicit operator bool(CallResult obj)
        {
            return obj?.Success == true;
        }
    }

    public class CallResult<T> : CallResult, ICallResult<T>
    {
        /// <summary>
        /// The data returned by the call, only available when Success = true.
        /// </summary>
        public T Data { get; set; }

        protected CallResult([AllowNull] T data, Error? error) : base(error)
        {
            Data = data;
        }

        /// <summary>
        /// Overwrite bool check so we can use if(callResult) instead of if(callResult.Success).
        /// </summary>
        /// <param name="obj"></param>
        public static implicit operator bool(CallResult<T> obj)
        {
            return obj?.Success == true;
        }

        /// <summary>
        /// Whether the call was successful or not. Useful for nullability checking.
        /// </summary>
        /// <param name="data">The data returned by the call.</param>
        /// <param name="error"><see cref="Error"/> on failure.</param>
        /// <returns><c>true</c> when <see cref="CallResult{T}"/> succeeded, <c>false</c> otherwise.</returns>
        public bool GetResultOrError([MaybeNullWhen(false)] out T data, [NotNullWhen(false)] out Error? error)
        {
            if (Success)
            {
                data = Data!;
                error = null;

                return true;
            }
            else
            {
                data = default;
                error = Error!;

                return false;
            }
        }

        /// <summary>
        /// Copy the CallResult to a new data type.
        /// </summary>
        /// <typeparam name="K">The new type</typeparam>
        /// <param name="data">The data of the new type</param>
        /// <returns></returns>
        public CallResult<K> As<K>([AllowNull] K data)
        {
            return new CallResult<K>(data, Error);
        }
    }
}