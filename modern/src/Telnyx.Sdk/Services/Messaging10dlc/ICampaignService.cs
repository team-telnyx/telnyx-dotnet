using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messaging10dlc.Campaign;
using Telnyx.Sdk.Services.Messaging10dlc.Campaign;

namespace Telnyx.Sdk.Services.Messaging10dlc;

/// <summary>
/// Campaign operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICampaignService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICampaignServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICampaignService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    IUsecaseService Usecase { get; }

    IOsrService Osr { get; }

    /// <summary>
/// Retrieve campaign details by `campaignId`.
/// </summary>
    Task<TelnyxCampaignCsp> Retrieve(
        CampaignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CampaignRetrieveParams, CancellationToken)"/>
    Task<TelnyxCampaignCsp> Retrieve(
        string campaignID,
        CampaignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update a campaign's properties by `campaignId`. **Please note:** only sample
/// messages are editable.
/// </summary>
    Task<TelnyxCampaignCsp> Update(
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CampaignUpdateParams, CancellationToken)"/>
    Task<TelnyxCampaignCsp> Update(
        string campaignID,
        CampaignUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a list of campaigns associated with a supplied `brandId`.
/// </summary>
    Task<CampaignListPage> List(
        CampaignListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Manually accept a campaign shared with Telnyx
/// </summary>
    Task<Dictionary<string, JsonElement>> AcceptSharing(
        CampaignAcceptSharingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="AcceptSharing(CampaignAcceptSharingParams, CancellationToken)"/>
    Task<Dictionary<string, JsonElement>> AcceptSharing(
        string campaignID,
        CampaignAcceptSharingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Terminate a campaign. Note that once deactivated, a campaign cannot be restored.
/// </summary>
    Task<CampaignDeactivateResponse> Deactivate(
        CampaignDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Deactivate(CampaignDeactivateParams, CancellationToken)"/>
    Task<CampaignDeactivateResponse> Deactivate(
        string campaignID,
        CampaignDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get the campaign metadata for each MNO it was submitted to.
/// </summary>
    Task<CampaignGetMnoMetadataResponse> GetMnoMetadata(
        CampaignGetMnoMetadataParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetMnoMetadata(CampaignGetMnoMetadataParams, CancellationToken)"/>
    Task<CampaignGetMnoMetadataResponse> GetMnoMetadata(
        string campaignID,
        CampaignGetMnoMetadataParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve campaign's operation status at MNO level.
/// </summary>
    Task<Dictionary<string, JsonElement>> GetOperationStatus(
        CampaignGetOperationStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetOperationStatus(CampaignGetOperationStatusParams, CancellationToken)"/>
    Task<Dictionary<string, JsonElement>> GetOperationStatus(
        string campaignID,
        CampaignGetOperationStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns whether the campaign is configured for partner sharing and the current
/// sharing state.
/// </summary>
    Task<CampaignGetSharingStatusResponse> GetSharingStatus(
        CampaignGetSharingStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetSharingStatus(CampaignGetSharingStatusParams, CancellationToken)"/>
    Task<CampaignGetSharingStatusResponse> GetSharingStatus(
        string campaignID,
        CampaignGetSharingStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Submits an appeal for rejected native campaigns in TELNYX_FAILED or MNO_REJECTED
/// status. The appeal is recorded for manual compliance team review and the
/// campaign status is reset to TCR_ACCEPTED. Note: Appeal forwarding is handled
/// manually to allow proper review before incurring upstream charges.
/// </summary>
    Task<CampaignSubmitAppealResponse> SubmitAppeal(
        CampaignSubmitAppealParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SubmitAppeal(CampaignSubmitAppealParams, CancellationToken)"/>
    Task<CampaignSubmitAppealResponse> SubmitAppeal(
        string campaignID,
        CampaignSubmitAppealParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICampaignService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICampaignServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICampaignServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IUsecaseServiceWithRawResponse Usecase { get; }

    IOsrServiceWithRawResponse Osr { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/campaign/{campaignId}</c>, but is otherwise the
/// same as <see cref="ICampaignService.Retrieve(CampaignRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TelnyxCampaignCsp>> Retrieve(
        CampaignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CampaignRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TelnyxCampaignCsp>> Retrieve(
        string campaignID,
        CampaignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /10dlc/campaign/{campaignId}</c>, but is otherwise the
/// same as <see cref="ICampaignService.Update(CampaignUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TelnyxCampaignCsp>> Update(
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CampaignUpdateParams, CancellationToken)"/>
    Task<HttpResponse<TelnyxCampaignCsp>> Update(
        string campaignID,
        CampaignUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/campaign</c>, but is otherwise the
/// same as <see cref="ICampaignService.List(CampaignListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CampaignListPage>> List(
        CampaignListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /10dlc/campaign/acceptSharing/{campaignId}</c>, but is otherwise the
/// same as <see cref="ICampaignService.AcceptSharing(CampaignAcceptSharingParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Dictionary<string, JsonElement>>> AcceptSharing(
        CampaignAcceptSharingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="AcceptSharing(CampaignAcceptSharingParams, CancellationToken)"/>
    Task<HttpResponse<Dictionary<string, JsonElement>>> AcceptSharing(
        string campaignID,
        CampaignAcceptSharingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /10dlc/campaign/{campaignId}</c>, but is otherwise the
/// same as <see cref="ICampaignService.Deactivate(CampaignDeactivateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CampaignDeactivateResponse>> Deactivate(
        CampaignDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Deactivate(CampaignDeactivateParams, CancellationToken)"/>
    Task<HttpResponse<CampaignDeactivateResponse>> Deactivate(
        string campaignID,
        CampaignDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/campaign/{campaignId}/mnoMetadata</c>, but is otherwise the
/// same as <see cref="ICampaignService.GetMnoMetadata(CampaignGetMnoMetadataParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CampaignGetMnoMetadataResponse>> GetMnoMetadata(
        CampaignGetMnoMetadataParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetMnoMetadata(CampaignGetMnoMetadataParams, CancellationToken)"/>
    Task<HttpResponse<CampaignGetMnoMetadataResponse>> GetMnoMetadata(
        string campaignID,
        CampaignGetMnoMetadataParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/campaign/{campaignId}/operationStatus</c>, but is otherwise the
/// same as <see cref="ICampaignService.GetOperationStatus(CampaignGetOperationStatusParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Dictionary<string, JsonElement>>> GetOperationStatus(
        CampaignGetOperationStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetOperationStatus(CampaignGetOperationStatusParams, CancellationToken)"/>
    Task<HttpResponse<Dictionary<string, JsonElement>>> GetOperationStatus(
        string campaignID,
        CampaignGetOperationStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/campaign/{campaignId}/sharing</c>, but is otherwise the
/// same as <see cref="ICampaignService.GetSharingStatus(CampaignGetSharingStatusParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CampaignGetSharingStatusResponse>> GetSharingStatus(
        CampaignGetSharingStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetSharingStatus(CampaignGetSharingStatusParams, CancellationToken)"/>
    Task<HttpResponse<CampaignGetSharingStatusResponse>> GetSharingStatus(
        string campaignID,
        CampaignGetSharingStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /10dlc/campaign/{campaignId}/appeal</c>, but is otherwise the
/// same as <see cref="ICampaignService.SubmitAppeal(CampaignSubmitAppealParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CampaignSubmitAppealResponse>> SubmitAppeal(
        CampaignSubmitAppealParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SubmitAppeal(CampaignSubmitAppealParams, CancellationToken)"/>
    Task<HttpResponse<CampaignSubmitAppealResponse>> SubmitAppeal(
        string campaignID,
        CampaignSubmitAppealParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}