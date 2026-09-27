using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.RequirementTypes;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Types of requirements for international numbers and porting orders
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRequirementTypeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRequirementTypeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRequirementTypeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns the details of a single requirement type by its identifier, describing a
/// kind of documentation needed for regulatory purposes.
/// </summary>
    Task<RequirementTypeRetrieveResponse> Retrieve(
        RequirementTypeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RequirementTypeRetrieveParams, CancellationToken)"/>
    Task<RequirementTypeRetrieveResponse> Retrieve(
        string id,
        RequirementTypeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// List all requirement types ordered by created_at descending
/// </summary>
    Task<RequirementTypeListResponse> List(
        RequirementTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRequirementTypeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRequirementTypeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRequirementTypeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /requirement_types/{id}</c>, but is otherwise the
/// same as <see cref="IRequirementTypeService.Retrieve(RequirementTypeRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RequirementTypeRetrieveResponse>> Retrieve(
        RequirementTypeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RequirementTypeRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RequirementTypeRetrieveResponse>> Retrieve(
        string id,
        RequirementTypeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /requirement_types</c>, but is otherwise the
/// same as <see cref="IRequirementTypeService.List(RequirementTypeListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RequirementTypeListResponse>> List(
        RequirementTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}