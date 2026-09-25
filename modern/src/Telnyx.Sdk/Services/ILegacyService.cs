using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.Legacy;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ILegacyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILegacyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILegacyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IReportingService Reporting { get; }
}

/// <summary>
/// A view of <see cref="ILegacyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILegacyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILegacyServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IReportingServiceWithRawResponse Reporting { get; }
}