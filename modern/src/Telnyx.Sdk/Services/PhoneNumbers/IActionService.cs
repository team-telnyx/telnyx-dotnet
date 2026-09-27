using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PhoneNumbers.Actions;

namespace Telnyx.Sdk.Services.PhoneNumbers;

/// <summary>
/// Configure your phone numbers
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
/// Adds the specified phone number to a bundle or removes it from a bundle
/// according to the requested status change. The response contains the phone number
/// with its updated bundle state.
/// </summary>
    Task<ActionChangeBundleStatusResponse> ChangeBundleStatus(
        ActionChangeBundleStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ChangeBundleStatus(ActionChangeBundleStatusParams, CancellationToken)"/>
    Task<ActionChangeBundleStatusResponse> ChangeBundleStatus(
        string id,
        ActionChangeBundleStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Associates emergency-service settings with the specified phone number. The
/// operation returns the updated phone-number configuration when completed
/// immediately or an accepted state when processing continues asynchronously.
/// </summary>
    Task<ActionEnableEmergencyResponse> EnableEmergency(
        ActionEnableEmergencyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="EnableEmergency(ActionEnableEmergencyParams, CancellationToken)"/>
    Task<ActionEnableEmergencyResponse> EnableEmergency(
        string id,
        ActionEnableEmergencyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Verifies ownership of the provided phone numbers and returns a mapping of
/// numbers to their IDs, plus a list of numbers not found in the account.
/// </summary>
    Task<ActionVerifyOwnershipResponse> VerifyOwnership(
        ActionVerifyOwnershipParams parameters,
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
/// Returns a raw HTTP response for <c>patch /phone_numbers/{id}/actions/bundle_status_change</c>, but is otherwise the
/// same as <see cref="IActionService.ChangeBundleStatus(ActionChangeBundleStatusParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionChangeBundleStatusResponse>> ChangeBundleStatus(
        ActionChangeBundleStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ChangeBundleStatus(ActionChangeBundleStatusParams, CancellationToken)"/>
    Task<HttpResponse<ActionChangeBundleStatusResponse>> ChangeBundleStatus(
        string id,
        ActionChangeBundleStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /phone_numbers/{id}/actions/enable_emergency</c>, but is otherwise the
/// same as <see cref="IActionService.EnableEmergency(ActionEnableEmergencyParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionEnableEmergencyResponse>> EnableEmergency(
        ActionEnableEmergencyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="EnableEmergency(ActionEnableEmergencyParams, CancellationToken)"/>
    Task<HttpResponse<ActionEnableEmergencyResponse>> EnableEmergency(
        string id,
        ActionEnableEmergencyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /phone_numbers/actions/verify_ownership</c>, but is otherwise the
/// same as <see cref="IActionService.VerifyOwnership(ActionVerifyOwnershipParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionVerifyOwnershipResponse>> VerifyOwnership(
        ActionVerifyOwnershipParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}