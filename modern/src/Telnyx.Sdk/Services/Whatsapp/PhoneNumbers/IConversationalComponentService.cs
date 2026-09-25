using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Whatsapp.PhoneNumbers.ConversationalComponents;

namespace Telnyx.Sdk.Services.Whatsapp.PhoneNumbers;

/// <summary>
/// Manage Whatsapp phone numbers
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IConversationalComponentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IConversationalComponentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConversationalComponentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns the conversational components configured for the specified WhatsApp
/// phone number.
/// </summary>
    Task<ConversationalComponentListResponse> List(
        ConversationalComponentListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ConversationalComponentListParams, CancellationToken)"/>
    Task<ConversationalComponentListResponse> List(
        string phoneNumber,
        ConversationalComponentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the conversational components configured for the specified WhatsApp
/// phone number.
/// </summary>
    Task<ConversationalComponentPatchAllResponse> PatchAll(
        ConversationalComponentPatchAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="PatchAll(ConversationalComponentPatchAllParams, CancellationToken)"/>
    Task<ConversationalComponentPatchAllResponse> PatchAll(
        string phoneNumber,
        ConversationalComponentPatchAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IConversationalComponentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IConversationalComponentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConversationalComponentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /v2/whatsapp/phone_numbers/{phone_number}/conversational_components</c>, but is otherwise the
/// same as <see cref="IConversationalComponentService.List(ConversationalComponentListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConversationalComponentListResponse>> List(
        ConversationalComponentListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(ConversationalComponentListParams, CancellationToken)"/>
    Task<HttpResponse<ConversationalComponentListResponse>> List(
        string phoneNumber,
        ConversationalComponentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /v2/whatsapp/phone_numbers/{phone_number}/conversational_components</c>, but is otherwise the
/// same as <see cref="IConversationalComponentService.PatchAll(ConversationalComponentPatchAllParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConversationalComponentPatchAllResponse>> PatchAll(
        ConversationalComponentPatchAllParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="PatchAll(ConversationalComponentPatchAllParams, CancellationToken)"/>
    Task<HttpResponse<ConversationalComponentPatchAllResponse>> PatchAll(
        string phoneNumber,
        ConversationalComponentPatchAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}