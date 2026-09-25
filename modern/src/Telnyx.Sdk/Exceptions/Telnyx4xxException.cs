using System.Net.Http;

namespace Telnyx.Sdk.Exceptions;

public class Telnyx4xxException : TelnyxApiException
{
    public Telnyx4xxException (
        HttpRequestException? innerException = null
    ) : base(innerException)
    {  }
}