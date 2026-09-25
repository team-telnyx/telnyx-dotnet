using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Whatsapp.PhoneNumbers.CallingSettings;

namespace Telnyx.Sdk.Services.Whatsapp.PhoneNumbers;

/// <summary>
/// Manage Whatsapp phone numbers
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICallingSettingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICallingSettingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallingSettingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns the WhatsApp calling configuration for the specified phone number.
/// </summary>
    Task<CallingSettingRetrieveResponse> Retrieve(
        CallingSettingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CallingSettingRetrieveParams, CancellationToken)"/>
    Task<CallingSettingRetrieveResponse> Retrieve(
        string phoneNumber,
        CallingSettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Enables or disables WhatsApp calling for the specified phone number.
/// </summary>
    Task<CallingSettingUpdateResponse> Update(
        CallingSettingUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CallingSettingUpdateParams, CancellationToken)"/>
    Task<CallingSettingUpdateResponse> Update(
        string phoneNumber,
        CallingSettingUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICallingSettingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICallingSettingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallingSettingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /v2/whatsapp/phone_numbers/{phone_number}/calling_settings</c>, but is otherwise the
/// same as <see cref="ICallingSettingService.Retrieve(CallingSettingRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallingSettingRetrieveResponse>> Retrieve(
        CallingSettingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CallingSettingRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CallingSettingRetrieveResponse>> Retrieve(
        string phoneNumber,
        CallingSettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /v2/whatsapp/phone_numbers/{phone_number}/calling_settings</c>, but is otherwise the
/// same as <see cref="ICallingSettingService.Update(CallingSettingUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallingSettingUpdateResponse>> Update(
        CallingSettingUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CallingSettingUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CallingSettingUpdateResponse>> Update(
        string phoneNumber,
        CallingSettingUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}