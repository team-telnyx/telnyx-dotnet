using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPAssignmentHealth;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Global IPs
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IGlobalIPAssignmentHealthService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGlobalIPAssignmentHealthServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGlobalIPAssignmentHealthService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Retrieve health check metrics for your Global IP assignments.
/// </summary>
    Task<GlobalIPAssignmentHealthRetrieveResponse> Retrieve(
        GlobalIPAssignmentHealthRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IGlobalIPAssignmentHealthService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGlobalIPAssignmentHealthServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGlobalIPAssignmentHealthServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /global_ip_assignment_health</c>, but is otherwise the
/// same as <see cref="IGlobalIPAssignmentHealthService.Retrieve(GlobalIPAssignmentHealthRetrieveParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<GlobalIPAssignmentHealthRetrieveResponse>> Retrieve(
        GlobalIPAssignmentHealthRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}