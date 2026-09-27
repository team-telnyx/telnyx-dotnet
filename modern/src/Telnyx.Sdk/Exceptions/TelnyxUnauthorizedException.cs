using System.Net.Http;

namespace Telnyx.Sdk.Exceptions;

public class TelnyxUnauthorizedException : Telnyx4xxException
{
    public TelnyxUnauthorizedException (
        HttpRequestException? innerException = null
    ) : base(innerException)
    {  }
}