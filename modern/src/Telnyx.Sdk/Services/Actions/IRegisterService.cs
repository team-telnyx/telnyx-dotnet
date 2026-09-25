using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Actions.Register;

namespace Telnyx.Sdk.Services.Actions;

/// <summary>
/// SIM Cards operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRegisterService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRegisterServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRegisterService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Register the SIM cards associated with the provided registration codes to the
/// current user's account.&lt;br/&gt;&lt;br/&gt; If
/// &lt;code&gt;sim_card_group_id&lt;/code&gt; is provided, the SIM cards will be
/// associated with that group. Otherwise, the default group for the current user
/// will be used.&lt;br/&gt;&lt;br/&gt;
/// </summary>
    Task<RegisterCreateResponse> Create(
        RegisterCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRegisterService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRegisterServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRegisterServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /actions/register/sim_cards</c>, but is otherwise the
/// same as <see cref="IRegisterService.Create(RegisterCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RegisterCreateResponse>> Create(
        RegisterCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}