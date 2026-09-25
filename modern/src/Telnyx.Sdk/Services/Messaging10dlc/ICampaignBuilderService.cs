using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messaging10dlc.Campaign;
using Telnyx.Sdk.Models.Messaging10dlc.CampaignBuilder;
using CampaignBuilder = Telnyx.Sdk.Services.Messaging10dlc.CampaignBuilder;

namespace Telnyx.Sdk.Services.Messaging10dlc;

/// <summary>
/// Campaign operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICampaignBuilderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICampaignBuilderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICampaignBuilderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    CampaignBuilder::IBrandService Brand { get; }

    /// <summary>
/// Before creating a campaign, use the [Qualify By Usecase
/// endpoint](https://developers.telnyx.com/api-reference/campaign/qualify-by-usecase)
/// to ensure that the brand you want to assign a new campaign to is qualified for
/// the desired use case of that campaign. **Please note:** After campaign creation,
/// you'll only be able to edit the campaign's sample messages. Creating a campaign
/// will entail an upfront, non-refundable three month's cost that will depend on
/// the campaign's use case ([see 10DLC Costs section for
/// details](https://developers.telnyx.com/api-reference/campaign/get-campaign-cost)).
/// </summary>
    Task<TelnyxCampaignCsp> Submit(
        CampaignBuilderSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICampaignBuilderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICampaignBuilderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICampaignBuilderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    CampaignBuilder::IBrandServiceWithRawResponse Brand { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /10dlc/campaignBuilder</c>, but is otherwise the
/// same as <see cref="ICampaignBuilderService.Submit(CampaignBuilderSubmitParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TelnyxCampaignCsp>> Submit(
        CampaignBuilderSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}