using System.Net.Http;

namespace Telnyx.Sdk.Exceptions;

public class TelnyxNotFoundException : Telnyx4xxException
{
    public TelnyxNotFoundException (
        HttpRequestException? innerException = null
    ) : base(innerException)
    {  }
}