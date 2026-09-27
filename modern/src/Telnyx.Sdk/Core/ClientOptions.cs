using System;
using System.Net.Http;

namespace Telnyx.Sdk.Core;

/// <summary>
/// A class representing the SDK client configuration.
/// </summary>
public record struct ClientOptions()
{
    /// <summary>
/// The default value used for <see cref="MaxRetries"/>.
/// </summary>
    public static readonly int DefaultMaxRetries = 2;

    /// <summary>
/// The default value used for <see cref="Timeout"/>.
/// </summary>
    public static readonly TimeSpan DefaultTimeout = TimeSpan.FromMinutes(1);

    /// <summary>
    /// The HTTP client to use for making requests in the SDK.
    ///
    /// <para>The default transport does not follow redirects, to prevent forwarding
    /// custom secret headers to a different origin. Redirect responses are surfaced
    /// as HTTP errors. This also disables same-origin redirects; callers needing
    /// redirects must supply a transport that validates each hop. Caller-supplied
    /// HttpClient redirect and credential policies remain the caller's responsibility.</para>
    ///
    /// <para>Note: The HttpClient has a built-in timeout, which defaults to 100 seconds.
    /// When passing a custom HttpClient, this timeout may conflict with the SDK's
    /// own timeout handler and cause premature cancellation.</para>
    /// </summary>
    public HttpClient HttpClient { get; set; } = new
    (
        new HttpClientHandler()
        {
            // Prevent cross-origin forwarding of caller-supplied secret headers.
            // Redirect responses are returned to the caller rather than followed.
            AllowAutoRedirect = false,
            AutomaticDecompression = DecompressionMethods.Available
        }
    )
    {
        Timeout = global::System.Threading.Timeout.InfiniteTimeSpan
    };

    Lazy<string> _baseUrl = new(() => Environment.GetEnvironmentVariable("TELNYX_BASE_URL") ?? EnvironmentUrl.Production);
    /// <summary>
/// The base URL to use for every request.
/// 
/// <para>Defaults to the production environment: <see cref="EnvironmentUrl.Production"/></para>
/// </summary>
    public string BaseUrl {
        readonly get { return _baseUrl.Value ; }
        set { _baseUrl = new(() => value); }
    }

    /// <summary>
/// Whether to validate response bodies before returning them.
/// 
/// <para>Defaults to false, which means the shape of the response body will not be validated upfront.
/// Instead, validation will only occur for the parts of the response body that are accessed.</para>
/// 
/// <para>Note that when set to true, the response body is only validated if the response is
/// deserialized. Methods that don't eagerly deserialize the response, such as those on
/// <see cref="ITelnyxClient.WithRawResponse"/>, don't perform validation until deserialization
/// is triggered.</para>
/// </summary>
    public bool ResponseValidation { get; set; } = false;

    /// <summary>
/// The maximum number of times to retry failed requests, with a short exponential backoff between requests.
/// 
/// <para>
/// Only the following error types are retried:
/// <list type="bullet">
///   <item>Connection errors (for example, due to a network connectivity problem)</item>
///   <item>408 Request Timeout</item>
///   <item>409 Conflict</item>
///   <item>429 Rate Limit</item>
///   <item>5xx Internal</item>
/// </list>
/// </para>
/// 
/// <para>The API may also explicitly instruct the SDK to retry or not retry a request.</para>
/// 
/// <para>Defaults to 2 when null. Set to 0 to
/// disable retries, which also ignores API instructions to retry.</para>
/// </summary>
    public int? MaxRetries { get; set; } = null;

    /// <summary>
/// Sets the maximum time allowed for a complete HTTP call, not including retries.
/// 
/// <para>This includes resolving DNS, connecting, writing the request body, server processing, as
/// well as reading the response body.</para>
/// 
/// <para>Defaults to <c>TimeSpan.FromMinutes(1)</c> when null.</para>
/// </summary>
    public TimeSpan? Timeout { get; set; } = null;

    Lazy<string?> _apiKey = new(() => Environment.GetEnvironmentVariable("TELNYX_API_KEY"));
    public string? ApiKey {
        readonly get { return _apiKey.Value; }
        set { _apiKey = new(() => value); }
    }

    Lazy<string?> _publicKey = new(() => Environment.GetEnvironmentVariable("TELNYX_PUBLIC_KEY"));
    public string? PublicKey {
        readonly get { return _publicKey.Value; }
        set { _publicKey = new(() => value); }
    }

    Lazy<string?> _clientID = new(() => Environment.GetEnvironmentVariable("TELNYX_CLIENT_ID"));
    public string? ClientID {
        readonly get { return _clientID.Value; }
        set { _clientID = new(() => value); }
    }

    Lazy<string?> _clientSecret = new(() => Environment.GetEnvironmentVariable("TELNYX_CLIENT_SECRET"));
    public string? ClientSecret {
        readonly get { return _clientSecret.Value; }
        set { _clientSecret = new(() => value); }
    }

    /// <summary>
    /// Complete Payment authorization credential. Only sent to Payment-enabled operations.
    /// Bearer takes precedence when both are set; clear ApiKey on a scoped WithOptions
    /// copy for an explicit paid retry. Never constructed or retried automatically.
    /// </summary>
    public string? PaymentAuthorization { get; set; }
}