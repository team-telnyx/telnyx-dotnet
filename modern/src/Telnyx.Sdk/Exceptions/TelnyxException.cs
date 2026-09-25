using System;
using System.Net.Http;

namespace Telnyx.Sdk.Exceptions;

public class TelnyxException : Exception
{
    public TelnyxException (
        string message, Exception? innerException = null
    ) : base(message, innerException)
    {  }

    protected TelnyxException (HttpRequestException? innerException) : base(
        null, innerException
    )
    {  }
}