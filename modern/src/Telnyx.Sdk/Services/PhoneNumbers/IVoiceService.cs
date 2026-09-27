using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PhoneNumbers.Voice;

namespace Telnyx.Sdk.Services.PhoneNumbers;

/// <summary>
/// Configure your phone numbers
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVoiceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVoiceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the specified phone number together with its current voice
/// configuration.
/// </summary>
    Task<VoiceRetrieveResponse> Retrieve(
        VoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VoiceRetrieveParams, CancellationToken)"/>
    Task<VoiceRetrieveResponse> Retrieve(
        string id,
        VoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the voice configuration for the specified phone number. The response
/// contains the phone number with its updated voice settings.
/// </summary>
    Task<VoiceUpdateResponse> Update(
        VoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(VoiceUpdateParams, CancellationToken)"/>
    Task<VoiceUpdateResponse> Update(
        string id,
        VoiceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns account phone numbers together with their voice settings. Results
/// support pagination, sorting, and filters for number, connection name, customer
/// reference, and voice usage payment method.
/// </summary>
    Task<VoiceListPage> List(
        VoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IVoiceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVoiceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVoiceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /phone_numbers/{id}/voice</c>, but is otherwise the
/// same as <see cref="IVoiceService.Retrieve(VoiceRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoiceRetrieveResponse>> Retrieve(
        VoiceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VoiceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<VoiceRetrieveResponse>> Retrieve(
        string id,
        VoiceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /phone_numbers/{id}/voice</c>, but is otherwise the
/// same as <see cref="IVoiceService.Update(VoiceUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoiceUpdateResponse>> Update(
        VoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(VoiceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<VoiceUpdateResponse>> Update(
        string id,
        VoiceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /phone_numbers/voice</c>, but is otherwise the
/// same as <see cref="IVoiceService.List(VoiceListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VoiceListPage>> List(
        VoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}