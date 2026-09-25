using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Whatsapp.PhoneNumbers.Profile.Photo;

namespace Telnyx.Sdk.Services.Whatsapp.PhoneNumbers.Profile;

/// <summary>
/// Manage Whatsapp phone numbers
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPhotoService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPhotoServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhotoService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the current business-profile photo for the specified WhatsApp phone
/// number.
/// </summary>
    Task<PhotoRetrieveResponse> Retrieve(
        PhotoRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PhotoRetrieveParams, CancellationToken)"/>
    Task<PhotoRetrieveResponse> Retrieve(
        string phoneNumber,
        PhotoRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Removes the business-profile photo from the specified WhatsApp phone number.
/// </summary>
    Task Delete(
        PhotoDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PhotoDeleteParams, CancellationToken)"/>
    Task Delete(
        string phoneNumber,
        PhotoDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Uploads and assigns a business-profile photo to the specified WhatsApp phone
/// number.
/// </summary>
    Task<PhotoUploadResponse> Upload(
        PhotoUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Upload(PhotoUploadParams, CancellationToken)"/>
    Task<PhotoUploadResponse> Upload(
        string phoneNumber,
        PhotoUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPhotoService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPhotoServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhotoServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /v2/whatsapp/phone_numbers/{phone_number}/profile/photo</c>, but is otherwise the
/// same as <see cref="IPhotoService.Retrieve(PhotoRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhotoRetrieveResponse>> Retrieve(
        PhotoRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PhotoRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PhotoRetrieveResponse>> Retrieve(
        string phoneNumber,
        PhotoRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /v2/whatsapp/phone_numbers/{phone_number}/profile/photo</c>, but is otherwise the
/// same as <see cref="IPhotoService.Delete(PhotoDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        PhotoDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PhotoDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string phoneNumber,
        PhotoDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /v2/whatsapp/phone_numbers/{phone_number}/profile/photo</c>, but is otherwise the
/// same as <see cref="IPhotoService.Upload(PhotoUploadParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhotoUploadResponse>> Upload(
        PhotoUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Upload(PhotoUploadParams, CancellationToken)"/>
    Task<HttpResponse<PhotoUploadResponse>> Upload(
        string phoneNumber,
        PhotoUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}