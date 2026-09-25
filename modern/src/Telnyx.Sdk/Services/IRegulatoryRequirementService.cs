using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.RegulatoryRequirements;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Regulatory Requirements
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRegulatoryRequirementService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRegulatoryRequirementServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRegulatoryRequirementService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns regulatory requirements for number ordering, porting, or other supported
/// actions. Results can be filtered by phone number, requirement group, country,
/// number type, and action.
/// </summary>
    Task<RegulatoryRequirementRetrieveResponse> Retrieve(
        RegulatoryRequirementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRegulatoryRequirementService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRegulatoryRequirementServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRegulatoryRequirementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /regulatory_requirements</c>, but is otherwise the
/// same as <see cref="IRegulatoryRequirementService.Retrieve(RegulatoryRequirementRetrieveParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RegulatoryRequirementRetrieveResponse>> Retrieve(
        RegulatoryRequirementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}