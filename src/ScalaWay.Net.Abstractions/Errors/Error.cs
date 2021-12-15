namespace ScalaWay.Net.Abstractions.Errors
{
    public abstract class Error : IError
    {
        #region Constructors

        protected Error(int? code, string message, object? data)
        {
            Code = code;
            Message = message;
            Data = data;
        }

        #endregion Constructors

        /// <summary>
        /// The error code from the server
        /// </summary>
        public int? Code { get; set; }

        /// <summary>
        /// The message for the error that occurred
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The data which caused the error
        /// </summary>
        public object? Data { get; set; }

        #region Overrided Methods

        /// <summary>
        /// String representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Code}: {Message} {Data}";
        }

        #endregion Overrided Methods
    }
}