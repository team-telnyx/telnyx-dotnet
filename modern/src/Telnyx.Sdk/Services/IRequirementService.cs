using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Requirements;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Requirements for international numbers and porting orders
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRequirementService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRequirementServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRequirementService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns a single document requirement record by its identifier, describing the
/// documentation needed for number-related actions. A specific requirement version
/// can be requested.
/// </summary>
    Task<RequirementRetrieveResponse> Retrieve(
        RequirementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RequirementRetrieveParams, CancellationToken)"/>
    Task<RequirementRetrieveResponse> Retrieve(
        string id,
        RequirementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// List all requirements with filtering, sorting, and pagination
/// </summary>
    Task<RequirementListPage> List(
        RequirementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRequirementService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRequirementServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRequirementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /requirements/{id}</c>, but is otherwise the
/// same as <see cref="IRequirementService.Retrieve(RequirementRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RequirementRetrieveResponse>> Retrieve(
        RequirementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RequirementRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RequirementRetrieveResponse>> Retrieve(
        string id,
        RequirementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /requirements</c>, but is otherwise the
/// same as <see cref="IRequirementService.List(RequirementListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RequirementListPage>> List(
        RequirementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}