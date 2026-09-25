using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Porting.LoaConfigurations;

namespace Telnyx.Sdk.Services.Porting;

/// <summary>
/// Endpoints related to porting orders management.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ILoaConfigurationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILoaConfigurationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILoaConfigurationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a new LOA configuration with your company details and branding for use
/// when generating LOA documents for porting orders.
/// </summary>
    Task<LoaConfigurationCreateResponse> Create(
        LoaConfigurationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single LOA (Letter of Authorization) configuration by
/// its identifier.
/// </summary>
    Task<LoaConfigurationRetrieveResponse> Retrieve(
        LoaConfigurationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(LoaConfigurationRetrieveParams, CancellationToken)"/>
    Task<LoaConfigurationRetrieveResponse> Retrieve(
        string id,
        LoaConfigurationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified LOA configuration with the provided fields and returns the
/// updated configuration.
/// </summary>
    Task<LoaConfigurationUpdateResponse> Update(
        LoaConfigurationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(LoaConfigurationUpdateParams, CancellationToken)"/>
    Task<LoaConfigurationUpdateResponse> Update(
        string id,
        LoaConfigurationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of your LOA (Letter of Authorization) configurations.
/// LOA configurations customize the company details and branding used on generated
/// LOA documents.
/// </summary>
    Task<LoaConfigurationListPage> List(
        LoaConfigurationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified LOA configuration so it can no longer be used
/// when generating LOA documents.
/// </summary>
    Task Delete(
        LoaConfigurationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(LoaConfigurationDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        LoaConfigurationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Preview the LOA template that would be generated without need to create LOA
/// configuration.
/// 
/// <para>It's the caller's responsibility to dispose the returned response.</para>
/// </summary>
    Task<HttpResponse> Preview(
        LoaConfigurationPreviewParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Preview the LOA template that would be generated without need to create LOA
/// configuration.
/// 
/// <para>It's the caller's responsibility to dispose the returned response.</para>
/// </summary>
    Task<HttpResponse> Preview0(
        LoaConfigurationPreview0Params parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Renders a preview of the LOA document produced by this configuration so you can
/// verify company details and branding before using it on porting orders.
/// 
/// <para>It's the caller's responsibility to dispose the returned response.</para>
/// </summary>
    Task<HttpResponse> Preview1(
        LoaConfigurationPreview1Params parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Preview1(LoaConfigurationPreview1Params, CancellationToken)"/>
    Task<HttpResponse> Preview1(
        string id,
        LoaConfigurationPreview1Params? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ILoaConfigurationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILoaConfigurationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILoaConfigurationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /porting/loa_configurations</c>, but is otherwise the
/// same as <see cref="ILoaConfigurationService.Create(LoaConfigurationCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<LoaConfigurationCreateResponse>> Create(
        LoaConfigurationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting/loa_configurations/{id}</c>, but is otherwise the
/// same as <see cref="ILoaConfigurationService.Retrieve(LoaConfigurationRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<LoaConfigurationRetrieveResponse>> Retrieve(
        LoaConfigurationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(LoaConfigurationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<LoaConfigurationRetrieveResponse>> Retrieve(
        string id,
        LoaConfigurationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /porting/loa_configurations/{id}</c>, but is otherwise the
/// same as <see cref="ILoaConfigurationService.Update(LoaConfigurationUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<LoaConfigurationUpdateResponse>> Update(
        LoaConfigurationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(LoaConfigurationUpdateParams, CancellationToken)"/>
    Task<HttpResponse<LoaConfigurationUpdateResponse>> Update(
        string id,
        LoaConfigurationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting/loa_configurations</c>, but is otherwise the
/// same as <see cref="ILoaConfigurationService.List(LoaConfigurationListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<LoaConfigurationListPage>> List(
        LoaConfigurationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /porting/loa_configurations/{id}</c>, but is otherwise the
/// same as <see cref="ILoaConfigurationService.Delete(LoaConfigurationDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        LoaConfigurationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(LoaConfigurationDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        LoaConfigurationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /porting/loa_configurations/preview</c>, but is otherwise the
/// same as <see cref="ILoaConfigurationService.Preview(LoaConfigurationPreviewParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Preview(
        LoaConfigurationPreviewParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /porting/loa_configurations/preview</c>, but is otherwise the
/// same as <see cref="ILoaConfigurationService.Preview0(LoaConfigurationPreview0Params, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Preview0(
        LoaConfigurationPreview0Params parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting/loa_configurations/{id}/preview</c>, but is otherwise the
/// same as <see cref="ILoaConfigurationService.Preview1(LoaConfigurationPreview1Params, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Preview1(
        LoaConfigurationPreview1Params parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Preview1(LoaConfigurationPreview1Params, CancellationToken)"/>
    Task<HttpResponse> Preview1(
        string id,
        LoaConfigurationPreview1Params? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}