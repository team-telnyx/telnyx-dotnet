using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messaging10dlc.Campaign;
using Telnyx.Sdk.Models.Messaging10dlc.PartnerCampaigns;

namespace Telnyx.Sdk.Services.Messaging10dlc;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPartnerCampaignService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPartnerCampaignServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPartnerCampaignService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Retrieve campaign details by `campaignId`.
/// </summary>
    Task<TelnyxDownstreamCampaign> Retrieve(
        PartnerCampaignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PartnerCampaignRetrieveParams, CancellationToken)"/>
    Task<TelnyxDownstreamCampaign> Retrieve(
        string campaignID,
        PartnerCampaignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update campaign details by `campaignId`. **Please note:** Only webhook urls are
/// editable.
/// </summary>
    Task<TelnyxDownstreamCampaign> Update(
        PartnerCampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(PartnerCampaignUpdateParams, CancellationToken)"/>
    Task<TelnyxDownstreamCampaign> Update(
        string campaignID,
        PartnerCampaignUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve all partner campaigns you have shared to Telnyx in a paginated fashion.
/// 
/// <para>This endpoint is currently limited to only returning shared campaigns that
/// Telnyx has accepted. In other words, shared but pending campaigns are currently
/// omitted from the response from this endpoint.</para>
/// </summary>
    Task<PartnerCampaignListPage> List(
        PartnerCampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get all partner campaigns you have shared to Telnyx in a paginated fashion
/// 
/// <para>This endpoint is currently limited to only returning shared campaigns that
/// Telnyx has accepted. In other words, shared but pending campaigns are currently
/// omitted from the response from this endpoint.</para>
/// </summary>
    Task<PartnerCampaignListSharedByMePage> ListSharedByMe(
        PartnerCampaignListSharedByMeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the partner-sharing state for the specified campaign.
/// </summary>
    Task<Dictionary<string, CampaignSharingStatus>> RetrieveSharingStatus(
        PartnerCampaignRetrieveSharingStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveSharingStatus(PartnerCampaignRetrieveSharingStatusParams, CancellationToken)"/>
    Task<Dictionary<string, CampaignSharingStatus>> RetrieveSharingStatus(
        string campaignID,
        PartnerCampaignRetrieveSharingStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPartnerCampaignService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPartnerCampaignServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPartnerCampaignServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/partner_campaigns/{campaignId}</c>, but is otherwise the
/// same as <see cref="IPartnerCampaignService.Retrieve(PartnerCampaignRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TelnyxDownstreamCampaign>> Retrieve(
        PartnerCampaignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PartnerCampaignRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TelnyxDownstreamCampaign>> Retrieve(
        string campaignID,
        PartnerCampaignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /10dlc/partner_campaigns/{campaignId}</c>, but is otherwise the
/// same as <see cref="IPartnerCampaignService.Update(PartnerCampaignUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TelnyxDownstreamCampaign>> Update(
        PartnerCampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(PartnerCampaignUpdateParams, CancellationToken)"/>
    Task<HttpResponse<TelnyxDownstreamCampaign>> Update(
        string campaignID,
        PartnerCampaignUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/partner_campaigns</c>, but is otherwise the
/// same as <see cref="IPartnerCampaignService.List(PartnerCampaignListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PartnerCampaignListPage>> List(
        PartnerCampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/partnerCampaign/sharedByMe</c>, but is otherwise the
/// same as <see cref="IPartnerCampaignService.ListSharedByMe(PartnerCampaignListSharedByMeParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PartnerCampaignListSharedByMePage>> ListSharedByMe(
        PartnerCampaignListSharedByMeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/partnerCampaign/{campaignId}/sharing</c>, but is otherwise the
/// same as <see cref="IPartnerCampaignService.RetrieveSharingStatus(PartnerCampaignRetrieveSharingStatusParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Dictionary<string, CampaignSharingStatus>>> RetrieveSharingStatus(
        PartnerCampaignRetrieveSharingStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveSharingStatus(PartnerCampaignRetrieveSharingStatusParams, CancellationToken)"/>
    Task<HttpResponse<Dictionary<string, CampaignSharingStatus>>> RetrieveSharingStatus(
        string campaignID,
        PartnerCampaignRetrieveSharingStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}