using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.ManagedAccounts.Actions;

namespace Telnyx.Sdk.Services.ManagedAccounts;

/// <summary>
/// Managed Accounts operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IActionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IActionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Disables a managed account, forbidding it to use Telnyx services, including
/// sending or receiving phone calls and SMS messages. Ongoing phone calls will not
/// be affected. The managed account and its sub-users will no longer be able to log
/// in via the mission control portal.
/// </summary>
    Task<ActionDisableResponse> Disable(
        ActionDisableParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Disable(ActionDisableParams, CancellationToken)"/>
    Task<ActionDisableResponse> Disable(
        string id,
        ActionDisableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Enables a managed account and its sub-users to use Telnyx services.
/// </summary>
    Task<ActionEnableResponse> Enable(
        ActionEnableParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Enable(ActionEnableParams, CancellationToken)"/>
    Task<ActionEnableResponse> Enable(
        string id,
        ActionEnableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IActionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IActionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /managed_accounts/{id}/actions/disable</c>, but is otherwise the
/// same as <see cref="IActionService.Disable(ActionDisableParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionDisableResponse>> Disable(
        ActionDisableParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Disable(ActionDisableParams, CancellationToken)"/>
    Task<HttpResponse<ActionDisableResponse>> Disable(
        string id,
        ActionDisableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /managed_accounts/{id}/actions/enable</c>, but is otherwise the
/// same as <see cref="IActionService.Enable(ActionEnableParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionEnableResponse>> Enable(
        ActionEnableParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Enable(ActionEnableParams, CancellationToken)"/>
    Task<HttpResponse<ActionEnableResponse>> Enable(
        string id,
        ActionEnableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}