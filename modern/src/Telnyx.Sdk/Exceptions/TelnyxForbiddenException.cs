using System.Net.Http;

namespace Telnyx.Sdk.Exceptions;

public class TelnyxForbiddenException : Telnyx4xxException
{
    public TelnyxForbiddenException (
        HttpRequestException? innerException = null
    ) : base(innerException)
    {  }
}