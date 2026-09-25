using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Organizations.Users;
using Users = Telnyx.Sdk.Services.Organizations.Users;

namespace Telnyx.Sdk.Services.Organizations;

/// <summary>
/// Operations related to users in your organization
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUserServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Users::IActionService Actions { get; }

    /// <summary>
/// Returns the details of a user in your organization, optionally including the
/// groups the user belongs to.
/// </summary>
    Task<UserRetrieveResponse> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(UserRetrieveParams, CancellationToken)"/>
    Task<UserRetrieveResponse> Retrieve(
        string id,
        UserRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of the users in your organization.
/// </summary>
    Task<UserListPage> List(
        UserListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a report of all users in your organization with their group memberships.
/// This endpoint returns all users without pagination and always includes group
/// information. The report can be retrieved in JSON or CSV format by sending
/// specific content-type headers.
/// </summary>
    Task<UserGetGroupsReportResponse> GetGroupsReport(
        UserGetGroupsReportParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IUserService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUserServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Users::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /organizations/users/{id}</c>, but is otherwise the
/// same as <see cref="IUserService.Retrieve(UserRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UserRetrieveResponse>> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(UserRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<UserRetrieveResponse>> Retrieve(
        string id,
        UserRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /organizations/users</c>, but is otherwise the
/// same as <see cref="IUserService.List(UserListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UserListPage>> List(
        UserListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /organizations/users/users_groups_report</c>, but is otherwise the
/// same as <see cref="IUserService.GetGroupsReport(UserGetGroupsReportParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UserGetGroupsReportResponse>> GetGroupsReport(
        UserGetGroupsReportParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}