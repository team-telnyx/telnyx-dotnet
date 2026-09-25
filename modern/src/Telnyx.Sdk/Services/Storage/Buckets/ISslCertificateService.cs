using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Storage.Buckets.SslCertificate;

namespace Telnyx.Sdk.Services.Storage.Buckets;

/// <summary>
/// SSL certificate operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISslCertificateService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISslCertificateServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISslCertificateService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Uploads an SSL certificate and its matching secret so that you can use Telnyx's
/// storage as your CDN.
/// </summary>
    Task<SslCertificateCreateResponse> Create(
        SslCertificateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(SslCertificateCreateParams, CancellationToken)"/>
    Task<SslCertificateCreateResponse> Create(
        string bucketName,
        SslCertificateCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the stored certificate detail of a bucket, if applicable.
/// </summary>
    Task<SslCertificateRetrieveResponse> Retrieve(
        SslCertificateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SslCertificateRetrieveParams, CancellationToken)"/>
    Task<SslCertificateRetrieveResponse> Retrieve(
        string bucketName,
        SslCertificateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes an SSL certificate and its matching secret.
/// </summary>
    Task<SslCertificateDeleteResponse> Delete(
        SslCertificateDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SslCertificateDeleteParams, CancellationToken)"/>
    Task<SslCertificateDeleteResponse> Delete(
        string bucketName,
        SslCertificateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISslCertificateService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISslCertificateServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISslCertificateServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /storage/buckets/{bucketName}/ssl_certificate</c>, but is otherwise the
/// same as <see cref="ISslCertificateService.Create(SslCertificateCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SslCertificateCreateResponse>> Create(
        SslCertificateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(SslCertificateCreateParams, CancellationToken)"/>
    Task<HttpResponse<SslCertificateCreateResponse>> Create(
        string bucketName,
        SslCertificateCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /storage/buckets/{bucketName}/ssl_certificate</c>, but is otherwise the
/// same as <see cref="ISslCertificateService.Retrieve(SslCertificateRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SslCertificateRetrieveResponse>> Retrieve(
        SslCertificateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SslCertificateRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SslCertificateRetrieveResponse>> Retrieve(
        string bucketName,
        SslCertificateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /storage/buckets/{bucketName}/ssl_certificate</c>, but is otherwise the
/// same as <see cref="ISslCertificateService.Delete(SslCertificateDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SslCertificateDeleteResponse>> Delete(
        SslCertificateDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SslCertificateDeleteParams, CancellationToken)"/>
    Task<HttpResponse<SslCertificateDeleteResponse>> Delete(
        string bucketName,
        SslCertificateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}