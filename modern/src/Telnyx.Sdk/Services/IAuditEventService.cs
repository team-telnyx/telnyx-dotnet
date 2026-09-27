using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuditEvents;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Audit log operations.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAuditEventService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAuditEventServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAuditEventService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Retrieve a list of audit log entries. Audit logs are a best-effort, eventually
/// consistent record of significant account-related changes.
/// </summary>
    Task<AuditEventListPage> List(
        AuditEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAuditEventService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAuditEventServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAuditEventServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /audit_events</c>, but is otherwise the
/// same as <see cref="IAuditEventService.List(AuditEventListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AuditEventListPage>> List(
        AuditEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}