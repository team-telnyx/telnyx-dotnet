using System;
using System.Net;
using System.Net.Http;

namespace Telnyx.Sdk.Exceptions;

public class TelnyxApiException : TelnyxException
{
    public new HttpRequestException InnerException {
        get {
            if (base.InnerException == null)
            { throw new ArgumentNullException(); }
            return (HttpRequestException) base.InnerException;
        }
    }

    public TelnyxApiException (
        string message, HttpRequestException? innerException = null
    ) : base(message, innerException)
    {  }

    protected TelnyxApiException (HttpRequestException? innerException) : base(
        innerException
    )
    {  }

    /// <summary>A case-insensitive snapshot of response and content headers, available after disposal.</summary>
    public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IReadOnlyList<string>> ResponseHeaders { get; internal set; } =
      new System.Collections.ObjectModel.ReadOnlyDictionary<string, System.Collections.Generic.IReadOnlyList<string>>(
        new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IReadOnlyList<string>>(System.StringComparer.OrdinalIgnoreCase));

    public required HttpStatusCode StatusCode { get; init; }

    public required string ResponseBody { get; init; }

    public override string Message {
        get {
            return string.Format("Status Code: {0}\n{1}",
            StatusCode,
            ResponseBody);
        }
    }
}