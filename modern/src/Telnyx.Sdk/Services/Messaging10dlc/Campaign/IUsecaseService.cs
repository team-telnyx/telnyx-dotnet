using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messaging10dlc.Campaign.Usecase;

namespace Telnyx.Sdk.Services.Messaging10dlc.Campaign;

/// <summary>
/// Campaign operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IUsecaseService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUsecaseServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsecaseService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the upfront and monthly cost associated with the selected 10DLC campaign
/// use case.
/// </summary>
    Task<UsecaseGetCostResponse> GetCost(
        UsecaseGetCostParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IUsecaseService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUsecaseServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsecaseServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/campaign/usecase/cost</c>, but is otherwise the
/// same as <see cref="IUsecaseService.GetCost(UsecaseGetCostParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<UsecaseGetCostResponse>> GetCost(
        UsecaseGetCostParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}