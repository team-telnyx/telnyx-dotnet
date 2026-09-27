using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Memory.Namespaces;
using Telnyx.Sdk.Services.AI.Memory.Namespaces;

namespace Telnyx.Sdk.Services.AI.Memory;

/// <summary>
/// Whether a write has finished.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface INamespaceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INamespaceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INamespaceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IProfileService Profiles { get; }

    ISettingService Settings { get; }

    /// <summary>
/// Whether a write has finished. Both `ingest` and `remember` return an
/// `operation_id`, and a memory is not recallable until its operation completes —
/// extraction, embedding and consolidation all run first.
/// </summary>
    Task<NamespaceRetrieveResponse> Retrieve(
        NamespaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NamespaceRetrieveParams, CancellationToken)"/>
    Task<NamespaceRetrieveResponse> Retrieve(
        string operationID,
        NamespaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="INamespaceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INamespaceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INamespaceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IProfileServiceWithRawResponse Profiles { get; }

    ISettingServiceWithRawResponse Settings { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/memory/namespaces/{namespace}/operations/{operation_id}</c>, but is otherwise the
/// same as <see cref="INamespaceService.Retrieve(NamespaceRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NamespaceRetrieveResponse>> Retrieve(
        NamespaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NamespaceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<NamespaceRetrieveResponse>> Retrieve(
        string operationID,
        NamespaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}