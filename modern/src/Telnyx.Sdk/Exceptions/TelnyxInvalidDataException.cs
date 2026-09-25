using System;

namespace Telnyx.Sdk.Exceptions;

public class TelnyxInvalidDataException : TelnyxException
{
    public TelnyxInvalidDataException (
        string message, Exception? innerException = null
    ) : base(message, innerException)
    {  }
}