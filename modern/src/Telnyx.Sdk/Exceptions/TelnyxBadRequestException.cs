using System.Net.Http;

namespace Telnyx.Sdk.Exceptions;

public class TelnyxBadRequestException : Telnyx4xxException
{
    public TelnyxBadRequestException (
        HttpRequestException? innerException = null
    ) : base(innerException)
    {  }
}