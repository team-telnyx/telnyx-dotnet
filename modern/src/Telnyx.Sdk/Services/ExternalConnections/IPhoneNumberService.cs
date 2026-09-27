using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.ExternalConnections.PhoneNumbers;

namespace Telnyx.Sdk.Services.ExternalConnections;

/// <summary>
/// External Connections operations
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

    /// <summary>
/// Return the details of a phone number associated with the given external
/// connection.
/// </summary>
    Task<PhoneNumberRetrieveResponse> Retrieve(
        PhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PhoneNumberRetrieveParams, CancellationToken)"/>
    Task<PhoneNumberRetrieveResponse> Retrieve(
        string phoneNumberID,
        PhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Asynchronously update settings of the phone number associated with the given
/// external connection.
/// </summary>
    Task<PhoneNumberUpdateResponse> Update(
        PhoneNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(PhoneNumberUpdateParams, CancellationToken)"/>
    Task<PhoneNumberUpdateResponse> Update(
        string phoneNumberID,
        PhoneNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of all active phone numbers associated with the given external
/// connection.
/// </summary>
    Task<PhoneNumberListPage> List(
        PhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(PhoneNumberListParams, CancellationToken)"/>
    Task<PhoneNumberListPage> List(
        string id,
        PhoneNumberListParams? parameters = null,
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

    /// <summary>
/// Returns a raw HTTP response for <c>get /external_connections/{id}/phone_numbers/{phone_number_id}</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.Retrieve(PhoneNumberRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberRetrieveResponse>> Retrieve(
        PhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PhoneNumberRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberRetrieveResponse>> Retrieve(
        string phoneNumberID,
        PhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /external_connections/{id}/phone_numbers/{phone_number_id}</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.Update(PhoneNumberUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberUpdateResponse>> Update(
        PhoneNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(PhoneNumberUpdateParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberUpdateResponse>> Update(
        string phoneNumberID,
        PhoneNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /external_connections/{id}/phone_numbers</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.List(PhoneNumberListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberListPage>> List(
        PhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(PhoneNumberListParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberListPage>> List(
        string id,
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}