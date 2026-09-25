using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messaging10dlc.Campaign.Osr;

namespace Telnyx.Sdk.Services.Messaging10dlc.Campaign;

/// <summary>
/// Campaign operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IOsrService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IOsrServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOsrService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the optional shared-responsibility attributes recorded for the campaign.
/// Use these values to inspect the campaign configuration submitted to the
/// registry.
/// </summary>
    Task<Dictionary<string, JsonElement>> GetAttributes(
        OsrGetAttributesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetAttributes(OsrGetAttributesParams, CancellationToken)"/>
    Task<Dictionary<string, JsonElement>> GetAttributes(
        string campaignID,
        OsrGetAttributesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IOsrService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IOsrServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IOsrServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/campaign/{campaignId}/osr/attributes</c>, but is otherwise the
/// same as <see cref="IOsrService.GetAttributes(OsrGetAttributesParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Dictionary<string, JsonElement>>> GetAttributes(
        OsrGetAttributesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetAttributes(OsrGetAttributesParams, CancellationToken)"/>
    Task<HttpResponse<Dictionary<string, JsonElement>>> GetAttributes(
        string campaignID,
        OsrGetAttributesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}