using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MobilePhoneNumbers;
using MobilePhoneNumbers = Telnyx.Sdk.Services.MobilePhoneNumbers;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Mobile phone number operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMobilePhoneNumberService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMobilePhoneNumberServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMobilePhoneNumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    MobilePhoneNumbers::IMessagingService Messaging { get; }

    /// <summary>
/// Retrieve the details of a specific mobile phone number.
/// </summary>
    Task<MobilePhoneNumberRetrieveResponse> Retrieve(
        MobilePhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MobilePhoneNumberRetrieveParams, CancellationToken)"/>
    Task<MobilePhoneNumberRetrieveResponse> Retrieve(
        string id,
        MobilePhoneNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update the settings of a specific mobile phone number.
/// </summary>
    Task<MobilePhoneNumberUpdateResponse> Update(
        MobilePhoneNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(MobilePhoneNumberUpdateParams, CancellationToken)"/>
    Task<MobilePhoneNumberUpdateResponse> Update(
        string id,
        MobilePhoneNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a paginated list of mobile phone numbers on your account.
/// </summary>
    Task<MobilePhoneNumberListPage> List(
        MobilePhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMobilePhoneNumberService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMobilePhoneNumberServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMobilePhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    MobilePhoneNumbers::IMessagingServiceWithRawResponse Messaging { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /v2/mobile_phone_numbers/{id}</c>, but is otherwise the
/// same as <see cref="IMobilePhoneNumberService.Retrieve(MobilePhoneNumberRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MobilePhoneNumberRetrieveResponse>> Retrieve(
        MobilePhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MobilePhoneNumberRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MobilePhoneNumberRetrieveResponse>> Retrieve(
        string id,
        MobilePhoneNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /v2/mobile_phone_numbers/{id}</c>, but is otherwise the
/// same as <see cref="IMobilePhoneNumberService.Update(MobilePhoneNumberUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MobilePhoneNumberUpdateResponse>> Update(
        MobilePhoneNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(MobilePhoneNumberUpdateParams, CancellationToken)"/>
    Task<HttpResponse<MobilePhoneNumberUpdateResponse>> Update(
        string id,
        MobilePhoneNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /v2/mobile_phone_numbers</c>, but is otherwise the
/// same as <see cref="IMobilePhoneNumberService.List(MobilePhoneNumberListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MobilePhoneNumberListPage>> List(
        MobilePhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}