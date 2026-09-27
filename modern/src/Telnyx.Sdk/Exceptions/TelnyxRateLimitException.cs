using System.Net.Http;

namespace Telnyx.Sdk.Exceptions;

public class TelnyxRateLimitException : Telnyx4xxException
{
    public TelnyxRateLimitException (
        HttpRequestException? innerException = null
    ) : base(innerException)
    {  }
}