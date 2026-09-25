using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Whatsapp.PhoneNumbers.Profile;
using Telnyx.Sdk.Services.Whatsapp.PhoneNumbers.Profile;

namespace Telnyx.Sdk.Services.Whatsapp.PhoneNumbers;

/// <summary>
/// Manage Whatsapp phone numbers
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IProfileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IProfileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProfileService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IPhotoService Photo { get; }

    /// <summary>
/// Returns the business profile displayed for the specified WhatsApp phone number.
/// </summary>
    Task<ProfileRetrieveResponse> Retrieve(
        ProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ProfileRetrieveParams, CancellationToken)"/>
    Task<ProfileRetrieveResponse> Retrieve(
        string phoneNumber,
        ProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the supplied business-profile fields for the specified WhatsApp phone
/// number.
/// </summary>
    Task<ProfileUpdateResponse> Update(
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ProfileUpdateParams, CancellationToken)"/>
    Task<ProfileUpdateResponse> Update(
        string phoneNumber,
        ProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IProfileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IProfileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IPhotoServiceWithRawResponse Photo { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /v2/whatsapp/phone_numbers/{phone_number}/profile</c>, but is otherwise the
/// same as <see cref="IProfileService.Retrieve(ProfileRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ProfileRetrieveResponse>> Retrieve(
        ProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ProfileRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ProfileRetrieveResponse>> Retrieve(
        string phoneNumber,
        ProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /v2/whatsapp/phone_numbers/{phone_number}/profile</c>, but is otherwise the
/// same as <see cref="IProfileService.Update(ProfileUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ProfileUpdateResponse>> Update(
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ProfileUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ProfileUpdateResponse>> Update(
        string phoneNumber,
        ProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}