using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Storage.Cloudfs;
using Cloudfs = Telnyx.Sdk.Services.Storage.Cloudfs;

namespace Telnyx.Sdk.Services.Storage;

/// <summary>
/// Manage CloudFS filesystems — JuiceFS-compatible filesystems backed by Telnyx Cloud Storage
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICloudfService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICloudfServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICloudfService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Cloudfs::IActionService Actions { get; }

    /// <summary>
/// Creates a CloudFS filesystem. Provisioning is synchronous — typically a few
/// seconds, up to a few minutes — and the filesystem is returned with status
/// `ready`, together with its S3 bucket and metadata connection details. This
/// response is the only time the filesystem's `meta_token` — and the
/// credential-bearing `meta_url` — are returned; store them securely. If the token
/// is lost, issue a new one with the rotate-meta-token action. Names are unique
/// within your organization: creating with an existing name returns a `422`.
/// Requests are idempotent: retrying with the same `Idempotency-Key` within 24
/// hours replays the original response instead of creating another filesystem.
/// </summary>
    Task<CloudfsFilesystemResponseWrapper> Create(
        CloudfCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves a CloudFS filesystem by its ID. The returned `meta_url` omits the
/// credential — the metadata token is only ever returned by create and
/// rotate-meta-token. A filesystem whose last lifecycle action failed includes a
/// customer-safe `error` message.
/// </summary>
    Task<CloudfsFilesystemDetailResponseWrapper> Retrieve(
        CloudfRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CloudfRetrieveParams, CancellationToken)"/>
    Task<CloudfsFilesystemDetailResponseWrapper> Retrieve(
        string id,
        CloudfRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates a CloudFS filesystem. Only `name` can be changed; other fields are
/// immutable and unknown fields are rejected with a `400`. Renaming to a name that
/// already exists in your organization returns a `422`.
/// </summary>
    Task<CloudfsFilesystemDetailResponseWrapper> Update(
        CloudfUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CloudfUpdateParams, CancellationToken)"/>
    Task<CloudfsFilesystemDetailResponseWrapper> Update(
        string id,
        CloudfUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists the CloudFS filesystems for the authenticated user's organization. Results
/// use cursor-based pagination: fetch the next page by passing `meta.cursors.after`
/// as `page[after]`, or follow the `meta.next` URL.
/// </summary>
    Task<CloudfListPage> List(
        CloudfListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes a CloudFS filesystem, removing its S3 bucket and its
/// metadata database. Deletion is synchronous: the response returns the
/// filesystem's final state with status `deleted`. There is no restore. A
/// filesystem that is still `provisioning` returns a `409`. If the filesystem still
/// contains data, the request may be rejected with a `409` — drain the bucket and
/// retry.
/// </summary>
    Task<CloudfsFilesystemDetailResponseWrapper> Delete(
        CloudfDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(CloudfDeleteParams, CancellationToken)"/>
    Task<CloudfsFilesystemDetailResponseWrapper> Delete(
        string id,
        CloudfDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICloudfService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICloudfServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICloudfServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Cloudfs::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /storage/cloudfs</c>, but is otherwise the
/// same as <see cref="ICloudfService.Create(CloudfCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CloudfsFilesystemResponseWrapper>> Create(
        CloudfCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /storage/cloudfs/{id}</c>, but is otherwise the
/// same as <see cref="ICloudfService.Retrieve(CloudfRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CloudfsFilesystemDetailResponseWrapper>> Retrieve(
        CloudfRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CloudfRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CloudfsFilesystemDetailResponseWrapper>> Retrieve(
        string id,
        CloudfRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /storage/cloudfs/{id}</c>, but is otherwise the
/// same as <see cref="ICloudfService.Update(CloudfUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CloudfsFilesystemDetailResponseWrapper>> Update(
        CloudfUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CloudfUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CloudfsFilesystemDetailResponseWrapper>> Update(
        string id,
        CloudfUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /storage/cloudfs</c>, but is otherwise the
/// same as <see cref="ICloudfService.List(CloudfListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CloudfListPage>> List(
        CloudfListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /storage/cloudfs/{id}</c>, but is otherwise the
/// same as <see cref="ICloudfService.Delete(CloudfDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CloudfsFilesystemDetailResponseWrapper>> Delete(
        CloudfDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(CloudfDeleteParams, CancellationToken)"/>
    Task<HttpResponse<CloudfsFilesystemDetailResponseWrapper>> Delete(
        string id,
        CloudfDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}