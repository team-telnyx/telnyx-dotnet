using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Rcs.Brands;

namespace Telnyx.Sdk.Services.Rcs;

/// <summary>
/// Manage the legal business entities that operate RCS agents.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBrandService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBrandServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBrandService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates an editable RCS brand draft. Creating the draft does not begin external
/// review.
/// </summary>
    Task<BrandResponse> Create(
        BrandCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves an RCS brand and its current lifecycle status.
/// </summary>
    Task<BrandResponse> Retrieve(
        BrandRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(BrandRetrieveParams, CancellationToken)"/>
    Task<BrandResponse> Retrieve(
        string id,
        BrandRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates one or more fields on a brand while its status is `CREATED`. Submitted
/// brands cannot be changed.
/// </summary>
    Task<BrandResponse> Update(
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(BrandUpdateParams, CancellationToken)"/>
    Task<BrandResponse> Update(
        string id,
        BrandUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists RCS brands owned by the authenticated organization.
/// </summary>
    Task<List<BrandResponse>> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Starts asynchronous provider provisioning and external review for a brand.
/// Repeating this request for an in-progress brand returns its current state
/// without creating new work.
/// </summary>
    Task<BrandResponse> Submit(
        BrandSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Submit(BrandSubmitParams, CancellationToken)"/>
    Task<BrandResponse> Submit(
        string id,
        BrandSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IBrandService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBrandServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBrandServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /rcs/brands</c>, but is otherwise the
/// same as <see cref="IBrandService.Create(BrandCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BrandResponse>> Create(
        BrandCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /rcs/brands/{id}</c>, but is otherwise the
/// same as <see cref="IBrandService.Retrieve(BrandRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BrandResponse>> Retrieve(
        BrandRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(BrandRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BrandResponse>> Retrieve(
        string id,
        BrandRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /rcs/brands/{id}</c>, but is otherwise the
/// same as <see cref="IBrandService.Update(BrandUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BrandResponse>> Update(
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(BrandUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BrandResponse>> Update(
        string id,
        BrandUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /rcs/brands</c>, but is otherwise the
/// same as <see cref="IBrandService.List(BrandListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<List<BrandResponse>>> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /rcs/brands/{id}/submit</c>, but is otherwise the
/// same as <see cref="IBrandService.Submit(BrandSubmitParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BrandResponse>> Submit(
        BrandSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Submit(BrandSubmitParams, CancellationToken)"/>
    Task<HttpResponse<BrandResponse>> Submit(
        string id,
        BrandSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}