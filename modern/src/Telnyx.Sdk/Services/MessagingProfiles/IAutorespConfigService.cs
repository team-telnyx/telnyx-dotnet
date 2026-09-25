using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MessagingProfiles.AutorespConfigs;

namespace Telnyx.Sdk.Services.MessagingProfiles;

/// <summary>
/// Opt-Out Management
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAutorespConfigService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAutorespConfigServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAutorespConfigService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates an auto-response rule on the specified messaging profile. Matching
/// inbound messages trigger the configured response.
/// </summary>
    Task<AutoRespConfigResponse> Create(
        AutorespConfigCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(AutorespConfigCreateParams, CancellationToken)"/>
    Task<AutoRespConfigResponse> Create(
        string profileID,
        AutorespConfigCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the matching criteria and response content for the specified
/// auto-response rule.
/// </summary>
    Task<AutoRespConfigResponse> Retrieve(
        AutorespConfigRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AutorespConfigRetrieveParams, CancellationToken)"/>
    Task<AutoRespConfigResponse> Retrieve(
        string autorespCfgID,
        AutorespConfigRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Replaces the configuration of the specified auto-response rule.
/// </summary>
    Task<AutoRespConfigResponse> Update(
        AutorespConfigUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(AutorespConfigUpdateParams, CancellationToken)"/>
    Task<AutoRespConfigResponse> Update(
        string autorespCfgID,
        AutorespConfigUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the auto-response rules configured for the specified messaging profile.
/// </summary>
    Task<AutorespConfigListResponse> List(
        AutorespConfigListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(AutorespConfigListParams, CancellationToken)"/>
    Task<AutorespConfigListResponse> List(
        string profileID,
        AutorespConfigListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the specified auto-response rule from the messaging profile.
/// </summary>
    Task<string> Delete(
        AutorespConfigDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(AutorespConfigDeleteParams, CancellationToken)"/>
    Task<string> Delete(
        string autorespCfgID,
        AutorespConfigDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAutorespConfigService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAutorespConfigServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAutorespConfigServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /messaging_profiles/{profile_id}/autoresp_configs</c>, but is otherwise the
/// same as <see cref="IAutorespConfigService.Create(AutorespConfigCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AutoRespConfigResponse>> Create(
        AutorespConfigCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(AutorespConfigCreateParams, CancellationToken)"/>
    Task<HttpResponse<AutoRespConfigResponse>> Create(
        string profileID,
        AutorespConfigCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_profiles/{profile_id}/autoresp_configs/{autoresp_cfg_id}</c>, but is otherwise the
/// same as <see cref="IAutorespConfigService.Retrieve(AutorespConfigRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AutoRespConfigResponse>> Retrieve(
        AutorespConfigRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(AutorespConfigRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AutoRespConfigResponse>> Retrieve(
        string autorespCfgID,
        AutorespConfigRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /messaging_profiles/{profile_id}/autoresp_configs/{autoresp_cfg_id}</c>, but is otherwise the
/// same as <see cref="IAutorespConfigService.Update(AutorespConfigUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AutoRespConfigResponse>> Update(
        AutorespConfigUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(AutorespConfigUpdateParams, CancellationToken)"/>
    Task<HttpResponse<AutoRespConfigResponse>> Update(
        string autorespCfgID,
        AutorespConfigUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_profiles/{profile_id}/autoresp_configs</c>, but is otherwise the
/// same as <see cref="IAutorespConfigService.List(AutorespConfigListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AutorespConfigListResponse>> List(
        AutorespConfigListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(AutorespConfigListParams, CancellationToken)"/>
    Task<HttpResponse<AutorespConfigListResponse>> List(
        string profileID,
        AutorespConfigListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /messaging_profiles/{profile_id}/autoresp_configs/{autoresp_cfg_id}</c>, but is otherwise the
/// same as <see cref="IAutorespConfigService.Delete(AutorespConfigDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<string>> Delete(
        AutorespConfigDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(AutorespConfigDeleteParams, CancellationToken)"/>
    Task<HttpResponse<string>> Delete(
        string autorespCfgID,
        AutorespConfigDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}