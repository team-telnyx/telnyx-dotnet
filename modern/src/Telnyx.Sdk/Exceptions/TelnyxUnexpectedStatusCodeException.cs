using System.Net.Http;

namespace Telnyx.Sdk.Exceptions;

public class TelnyxUnexpectedStatusCodeException : TelnyxApiException
{
    public TelnyxUnexpectedStatusCodeException (
        HttpRequestException? innerException = null
    ) : base(innerException)
    {  }
}