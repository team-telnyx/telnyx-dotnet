using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Enterprises.Reputation;
using Telnyx.Sdk.Models.Enterprises.Reputation.Loa;

namespace Telnyx.Sdk.Services.Enterprises.Reputation;

/// <summary>
/// Phone-number reputation monitoring (spam-score lookup and tracking).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ILoaService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILoaServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILoaService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Point the enterprise's reputation settings at a new signed LOA document. This
/// resets LOA approval to `pending`; the new document must be approved before
/// additional phone numbers can be added.
/// </summary>
    Task<EnterpriseReputationPublicWrapped> Update(
        LoaUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(LoaUpdateParams, CancellationToken)"/>
    Task<EnterpriseReputationPublicWrapped> Update(
        string enterpriseID,
        LoaUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Render the LOA for this enterprise as a PDF. The enterprise identity, address,
/// and authorized-representative contact are taken from the enterprise record; the
/// optional `agent` block is supplied only when a third-party partner manages the
/// numbers. The response is the PDF itself (unsigned unless a `signature` is
/// provided). Sign it and upload it to the Telnyx Documents API (`POST
/// /v2/documents`, see https://developers.telnyx.com/api/documents) to obtain the
/// `loa_document_id` required by `POST .../reputation`.
/// 
/// <para>It's the caller's responsibility to dispose the returned response.</para>
/// </summary>
    Task<HttpResponse> Render(
        LoaRenderParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Render(LoaRenderParams, CancellationToken)"/>
    Task<HttpResponse> Render(
        string enterpriseID,
        LoaRenderParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ILoaService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILoaServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILoaServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /enterprises/{enterprise_id}/reputation/loa</c>, but is otherwise the
/// same as <see cref="ILoaService.Update(LoaUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EnterpriseReputationPublicWrapped>> Update(
        LoaUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(LoaUpdateParams, CancellationToken)"/>
    Task<HttpResponse<EnterpriseReputationPublicWrapped>> Update(
        string enterpriseID,
        LoaUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /enterprises/{enterprise_id}/reputation/loa</c>, but is otherwise the
/// same as <see cref="ILoaService.Render(LoaRenderParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Render(
        LoaRenderParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Render(LoaRenderParams, CancellationToken)"/>
    Task<HttpResponse> Render(
        string enterpriseID,
        LoaRenderParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}