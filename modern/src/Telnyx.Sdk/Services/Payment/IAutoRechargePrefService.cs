using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Payment.AutoRechargePrefs;

namespace Telnyx.Sdk.Services.Payment;

/// <summary>
/// V2 Auto Recharge Preferences API
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAutoRechargePrefService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAutoRechargePrefServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAutoRechargePrefService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Update payment auto recharge preferences.
/// </summary>
    Task<AutoRechargePrefUpdateResponse> Update(
        AutoRechargePrefUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the payment auto recharge preferences.
/// </summary>
    Task<AutoRechargePrefListResponse> List(
        AutoRechargePrefListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAutoRechargePrefService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAutoRechargePrefServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAutoRechargePrefServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /payment/auto_recharge_prefs</c>, but is otherwise the
/// same as <see cref="IAutoRechargePrefService.Update(AutoRechargePrefUpdateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AutoRechargePrefUpdateResponse>> Update(
        AutoRechargePrefUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /payment/auto_recharge_prefs</c>, but is otherwise the
/// same as <see cref="IAutoRechargePrefService.List(AutoRechargePrefListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AutoRechargePrefListResponse>> List(
        AutoRechargePrefListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}