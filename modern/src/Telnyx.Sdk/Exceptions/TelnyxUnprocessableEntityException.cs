using System.Net.Http;

namespace Telnyx.Sdk.Exceptions;

public class TelnyxUnprocessableEntityException : Telnyx4xxException
{
    public TelnyxUnprocessableEntityException (
        HttpRequestException? innerException = null
    ) : base(innerException)
    {  }
}