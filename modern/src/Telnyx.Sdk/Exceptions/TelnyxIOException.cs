using System;
using System.Net.Http;

namespace Telnyx.Sdk.Exceptions;

public class TelnyxIOException : TelnyxException
{
    public new HttpRequestException InnerException {
        get {
            if (base.InnerException == null)
            { throw new ArgumentNullException(); }
            return (HttpRequestException) base.InnerException;
        }
    }

    public TelnyxIOException (
        string message, HttpRequestException? innerException = null
    ) : base(message, innerException)
    {  }
}