using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messaging10dlc.CampaignBuilder.Brand;

namespace Telnyx.Sdk.Services.Messaging10dlc.CampaignBuilder;

/// <summary>
/// Campaign operations
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
/// This endpoint allows you to see whether or not the supplied brand is suitable
/// for your desired campaign use case.
/// </summary>
    Task<BrandQualifyByUsecaseResponse> QualifyByUsecase(
        BrandQualifyByUsecaseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="QualifyByUsecase(BrandQualifyByUsecaseParams, CancellationToken)"/>
    Task<BrandQualifyByUsecaseResponse> QualifyByUsecase(
        string usecase,
        BrandQualifyByUsecaseParams parameters,
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
/// Returns a raw HTTP response for <c>get /10dlc/campaignBuilder/brand/{brandId}/usecase/{usecase}</c>, but is otherwise the
/// same as <see cref="IBrandService.QualifyByUsecase(BrandQualifyByUsecaseParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<BrandQualifyByUsecaseResponse>> QualifyByUsecase(
        BrandQualifyByUsecaseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="QualifyByUsecase(BrandQualifyByUsecaseParams, CancellationToken)"/>
    Task<HttpResponse<BrandQualifyByUsecaseResponse>> QualifyByUsecase(
        string usecase,
        BrandQualifyByUsecaseParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}