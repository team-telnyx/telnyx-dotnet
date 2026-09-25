using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.Texml.Accounts.Transcriptions;

namespace Telnyx.Sdk.Services.Texml.Accounts;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITranscriptionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITranscriptionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITranscriptionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IJsonService Json { get; }
}

/// <summary>
/// A view of <see cref="ITranscriptionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITranscriptionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITranscriptionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IJsonServiceWithRawResponse Json { get; }
}