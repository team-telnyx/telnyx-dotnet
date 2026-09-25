using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PhoneNumbers;
using PhoneNumbers = Telnyx.Sdk.Services.PhoneNumbers;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Configure your phone numbers
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPhoneNumberService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPhoneNumberServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    PhoneNumbers::IActionService Actions { get; }

    PhoneNumbers::ICsvDownloadService CsvDownloads { get; }

    PhoneNumbers::IJobService Jobs { get; }

    PhoneNumbers::IMessagingService Messaging { get; }

    PhoneNumbers::IVoiceService Voice { get; }

    PhoneNumbers::IVoicemailService Voicemail { get; }

    /// <summary>
/// Returns the detailed configuration and current state of the phone number
/// identified by `id`.
/// </summary>
    Task<PhoneNumberRetrieveResponse> Retrieve(
        PhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PhoneNumberRetrieveParams, CancellationToken)"/>
    Task<PhoneNumberRetrieveResponse> Retrieve(
        string id,
        PhoneNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the configurable settings of the specified phone number. The response
/// contains the complete updated phone-number representation.
/// </summary>
    Task<PhoneNumberUpdateResponse> Update(
        PhoneNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(PhoneNumberUpdateParams, CancellationToken)"/>
    Task<PhoneNumberUpdateResponse> Update(
        string phoneNumberID,
        PhoneNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns phone numbers associated with the account. Results support pagination,
/// sorting, and filters for number attributes, status, source, connections, billing
/// groups, emergency addresses, tags, and customer references.
/// </summary>
    Task<PhoneNumberListPage> List(
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the specified phone number from the account. The response contains the
/// phone number's final deleted representation.
/// </summary>
    Task<PhoneNumberDeleteResponse> Delete(
        PhoneNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PhoneNumberDeleteParams, CancellationToken)"/>
    Task<PhoneNumberDeleteResponse> Delete(
        string id,
        PhoneNumberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// List phone numbers, This endpoint is a lighter version of the /phone_numbers
/// endpoint having higher performance and rate limit.
/// </summary>
    Task<PhoneNumberSlimListPage> SlimList(
        PhoneNumberSlimListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPhoneNumberService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPhoneNumberServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    PhoneNumbers::IActionServiceWithRawResponse Actions { get; }

    PhoneNumbers::ICsvDownloadServiceWithRawResponse CsvDownloads { get; }

    PhoneNumbers::IJobServiceWithRawResponse Jobs { get; }

    PhoneNumbers::IMessagingServiceWithRawResponse Messaging { get; }

    PhoneNumbers::IVoiceServiceWithRawResponse Voice { get; }

    PhoneNumbers::IVoicemailServiceWithRawResponse Voicemail { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /phone_numbers/{id}</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.Retrieve(PhoneNumberRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberRetrieveResponse>> Retrieve(
        PhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PhoneNumberRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberRetrieveResponse>> Retrieve(
        string id,
        PhoneNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /phone_numbers/{id}</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.Update(PhoneNumberUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberUpdateResponse>> Update(
        PhoneNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(PhoneNumberUpdateParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberUpdateResponse>> Update(
        string phoneNumberID,
        PhoneNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /phone_numbers</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.List(PhoneNumberListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberListPage>> List(
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /phone_numbers/{id}</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.Delete(PhoneNumberDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberDeleteResponse>> Delete(
        PhoneNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PhoneNumberDeleteParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberDeleteResponse>> Delete(
        string id,
        PhoneNumberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /phone_numbers/slim</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.SlimList(PhoneNumberSlimListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberSlimListPage>> SlimList(
        PhoneNumberSlimListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}