namespace Telnyx
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    /// <summary>
    /// Telnyx Exception.
    /// </summary>
    public class TelnyxException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TelnyxException"/> class.
        /// </summary>
        public TelnyxException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelnyxException"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        public TelnyxException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelnyxException"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="err">exception.</param>
        public TelnyxException(string message, Exception err)
            : base(message, err)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelnyxException"/> class.
        /// </summary>
        /// <param name="httpStatusCode">httpStatusCode.</param>
        /// <param name="telnyxErrors">telnyxErrors.</param>
        /// <param name="message">message.</param>
        public TelnyxException(HttpStatusCode httpStatusCode, IEnumerable<TelnyxError> telnyxErrors, string message)
            : base(message)
        {
            this.HttpStatusCode = httpStatusCode;
            this.TelnyxErrors = telnyxErrors;
        }

        public TelnyxException(HttpStatusCode httpStatusCode, TelnyxError telnyxError, string message)
            : base(message)
        {
            this.HttpStatusCode = httpStatusCode;
            this.TelnyxErrors = new List<TelnyxError> { telnyxError };
        }

        /// <summary>
        /// Gets or sets HttpStatusCode.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// Gets or sets TelnyxError.
        /// </summary>
        public IEnumerable<TelnyxError> TelnyxErrors { get; set; }

        /// <summary>
        /// Gets or sets TelnyxResponse.
        /// </summary>
        public TelnyxResponse TelnyxResponse { get; set; }
    }
}
