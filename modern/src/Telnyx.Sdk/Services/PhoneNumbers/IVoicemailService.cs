using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PhoneNumbers.Voicemail;

namespace Telnyx.Sdk.Services.PhoneNumbers;

/// <summary>
/// Voicemail API
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVoicemailService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVoicemailServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVoicemailService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Create voicemail settings for a phone number. You can also configure a custom
/// greeting by setting the `greeting` object: use `mode` `custom_greeting` together
/// with a `media_name` that points to an audio file uploaded through the Media
/// Storage API, or `mode` `default` to use the standard system greeting.
/// </summary>
    Task<VoicemailCreateResponse> Create(
        VoicemailCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(VoicemailCreateParams, CancellationToken)"/>
    Task<VoicemailCreateResponse> Create(
        string phoneNumberID,
        VoicemailCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the voicemail settings for a phone number
/// </summary>
    Task<VoicemailRetrieveResponse> Retrieve(
        VoicemailRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VoicemailRetrieveParams, CancellationToken)"/>
    Task<VoicemailRetrieveResponse> Retrieve(
        string phoneNumberID,
        VoicemailRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update voicemail settings for a phone number. You can also configure a custom
/// greeting by setting the `greeting` object: use `mode` `custom_greeting` together
/// with a `media_name` that points to an audio file uploaded through the Media
/// Storage API, or `mode` `default` to use the standard system greeting.
/// </summary>
    Task<VoicemailUpdateResponse> Update(
        VoicemailUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(VoicemailUpdateParams, CancellationToken)"/>
    Task<VoicemailUpdateResponse> Update(
        string phoneNumberID,
        VoicemailUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IVoicemailService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVoicemailServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVoicemailServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /phone_numbers/{phone_number_id}/voicemail</c>, but is otherwise the
/// same as <see cref="IVoicemailService.Create(VoicemailCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoicemailCreateResponse>> Create(
        VoicemailCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(VoicemailCreateParams, CancellationToken)"/>
    Task<HttpResponse<VoicemailCreateResponse>> Create(
        string phoneNumberID,
        VoicemailCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /phone_numbers/{phone_number_id}/voicemail</c>, but is otherwise the
/// same as <see cref="IVoicemailService.Retrieve(VoicemailRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoicemailRetrieveResponse>> Retrieve(
        VoicemailRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VoicemailRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<VoicemailRetrieveResponse>> Retrieve(
        string phoneNumberID,
        VoicemailRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /phone_numbers/{phone_number_id}/voicemail</c>, but is otherwise the
/// same as <see cref="IVoicemailService.Update(VoicemailUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoicemailUpdateResponse>> Update(
        VoicemailUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(VoicemailUpdateParams, CancellationToken)"/>
    Task<HttpResponse<VoicemailUpdateResponse>> Update(
        string phoneNumberID,
        VoicemailUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}