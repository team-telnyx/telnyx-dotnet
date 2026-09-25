using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.RequirementGroups;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Requirement Groups
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRequirementGroupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRequirementGroupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRequirementGroupService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a regulatory requirement group for a country, number type, and ordering
/// or porting action. Optional customer-reference and requirement values are
/// retained on the created group.
/// </summary>
    Task<RequirementGroup> Create(
        RequirementGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the regulatory requirement group identified by `id`, including its
/// requirement values and current approval status.
/// </summary>
    Task<RequirementGroup> Retrieve(
        RequirementGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RequirementGroupRetrieveParams, CancellationToken)"/>
    Task<RequirementGroup> Retrieve(
        string id,
        RequirementGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the customer reference or regulatory requirement values on the specified
/// requirement group. The response contains the updated group.
/// </summary>
    Task<RequirementGroup> Update(
        RequirementGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(RequirementGroupUpdateParams, CancellationToken)"/>
    Task<RequirementGroup> Update(
        string id,
        RequirementGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns regulatory requirement groups for the account. Results can be filtered
/// by country, number type, action, approval status, and customer reference.
/// </summary>
    Task<List<RequirementGroup>> List(
        RequirementGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the regulatory requirement group identified by `id`. The response
/// contains the deleted requirement-group representation.
/// </summary>
    Task<RequirementGroup> Delete(
        RequirementGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(RequirementGroupDeleteParams, CancellationToken)"/>
    Task<RequirementGroup> Delete(
        string id,
        RequirementGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Submits the specified regulatory requirement group for approval. The response
/// contains the requirement group with its resulting approval status.
/// </summary>
    Task<RequirementGroup> SubmitForApproval(
        RequirementGroupSubmitForApprovalParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SubmitForApproval(RequirementGroupSubmitForApprovalParams, CancellationToken)"/>
    Task<RequirementGroup> SubmitForApproval(
        string id,
        RequirementGroupSubmitForApprovalParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRequirementGroupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRequirementGroupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRequirementGroupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /requirement_groups</c>, but is otherwise the
/// same as <see cref="IRequirementGroupService.Create(RequirementGroupCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RequirementGroup>> Create(
        RequirementGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /requirement_groups/{id}</c>, but is otherwise the
/// same as <see cref="IRequirementGroupService.Retrieve(RequirementGroupRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RequirementGroup>> Retrieve(
        RequirementGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RequirementGroupRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RequirementGroup>> Retrieve(
        string id,
        RequirementGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /requirement_groups/{id}</c>, but is otherwise the
/// same as <see cref="IRequirementGroupService.Update(RequirementGroupUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RequirementGroup>> Update(
        RequirementGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(RequirementGroupUpdateParams, CancellationToken)"/>
    Task<HttpResponse<RequirementGroup>> Update(
        string id,
        RequirementGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /requirement_groups</c>, but is otherwise the
/// same as <see cref="IRequirementGroupService.List(RequirementGroupListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<List<RequirementGroup>>> List(
        RequirementGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /requirement_groups/{id}</c>, but is otherwise the
/// same as <see cref="IRequirementGroupService.Delete(RequirementGroupDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RequirementGroup>> Delete(
        RequirementGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(RequirementGroupDeleteParams, CancellationToken)"/>
    Task<HttpResponse<RequirementGroup>> Delete(
        string id,
        RequirementGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /requirement_groups/{id}/submit_for_approval</c>, but is otherwise the
/// same as <see cref="IRequirementGroupService.SubmitForApproval(RequirementGroupSubmitForApprovalParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RequirementGroup>> SubmitForApproval(
        RequirementGroupSubmitForApprovalParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SubmitForApproval(RequirementGroupSubmitForApprovalParams, CancellationToken)"/>
    Task<HttpResponse<RequirementGroup>> SubmitForApproval(
        string id,
        RequirementGroupSubmitForApprovalParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}