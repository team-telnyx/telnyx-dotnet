using System.Net.Http;

namespace Telnyx.Sdk.Exceptions;

public class Telnyx5xxException : TelnyxApiException
{
    public Telnyx5xxException (
        HttpRequestException? innerException = null
    ) : base(innerException)
    {  }
}