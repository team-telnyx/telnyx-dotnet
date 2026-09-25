using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Addresses.Actions;

namespace Telnyx.Sdk.Services.Addresses;

/// <summary>
/// Operations to work with Address records. Address records are emergency-validated
/// addresses meant to be associated with phone numbers. They are validated for emergency
/// usage purposes at creation time, although you may validate them separately with
/// a custom workflow using the ValidateAddress operation separately. Address records
/// are not usable for physical orders, such as for Telnyx SIM cards, please use UserAddress
/// for that. It is not possible to entirely skip emergency service validation for
/// Address records; if an emergency provider for a phone number rejects the address
/// then it cannot be used on a phone number. To prevent records from getting out
/// of sync, Address records are immutable and cannot be altered once created. If
/// you realize you need to alter an address, a new record must be created with the
/// differing address.
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
/// Accept the validated address suggestion for this address, replacing the original
/// values, and finish uploading the numbers associated with it to Microsoft for
/// Operator Connect.
/// </summary>
    Task<ActionAcceptSuggestionsResponse> AcceptSuggestions(
        ActionAcceptSuggestionsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="AcceptSuggestions(ActionAcceptSuggestionsParams, CancellationToken)"/>
    Task<ActionAcceptSuggestionsResponse> AcceptSuggestions(
        string addressUuid,
        ActionAcceptSuggestionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Validates an address for emergency services.
/// </summary>
    Task<ActionValidateResponse> Validate(
        ActionValidateParams parameters,
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
/// Returns a raw HTTP response for <c>post /addresses/{id}/actions/accept_suggestions</c>, but is otherwise the
/// same as <see cref="IActionService.AcceptSuggestions(ActionAcceptSuggestionsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionAcceptSuggestionsResponse>> AcceptSuggestions(
        ActionAcceptSuggestionsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="AcceptSuggestions(ActionAcceptSuggestionsParams, CancellationToken)"/>
    Task<HttpResponse<ActionAcceptSuggestionsResponse>> AcceptSuggestions(
        string addressUuid,
        ActionAcceptSuggestionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /addresses/actions/validate</c>, but is otherwise the
/// same as <see cref="IActionService.Validate(ActionValidateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ActionValidateResponse>> Validate(
        ActionValidateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}