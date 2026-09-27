using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messaging10dlc.PhoneNumberCampaigns;

namespace Telnyx.Sdk.Services.Messaging10dlc;

/// <summary>
/// Phone number campaign assignment
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPhoneNumberCampaignService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPhoneNumberCampaignServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberCampaignService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Assigns a phone number to a 10DLC campaign. The assignment controls which
/// registered campaign is used for traffic from that number.
/// </summary>
    Task<PhoneNumberCampaign> Create(
        PhoneNumberCampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve an individual phone number/campaign assignment by `phoneNumber`.
/// </summary>
    Task<PhoneNumberCampaign> Retrieve(
        PhoneNumberCampaignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PhoneNumberCampaignRetrieveParams, CancellationToken)"/>
    Task<PhoneNumberCampaign> Retrieve(
        string phoneNumber,
        PhoneNumberCampaignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Replaces the 10DLC campaign assignment for the specified phone number.
/// </summary>
    Task<PhoneNumberCampaign> Update(
        PhoneNumberCampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(PhoneNumberCampaignUpdateParams, CancellationToken)"/>
    Task<PhoneNumberCampaign> Update(
        string campaignPhoneNumber,
        PhoneNumberCampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns phone-number-to-campaign assignments for the authenticated account.
/// Apply the documented filters and pagination parameters to narrow the result set.
/// </summary>
    Task<PhoneNumberCampaignListPage> List(
        PhoneNumberCampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This endpoint allows you to remove a campaign assignment from the supplied
/// `phoneNumber`.
/// </summary>
    Task<PhoneNumberCampaign> Delete(
        PhoneNumberCampaignDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PhoneNumberCampaignDeleteParams, CancellationToken)"/>
    Task<PhoneNumberCampaign> Delete(
        string phoneNumber,
        PhoneNumberCampaignDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPhoneNumberCampaignService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPhoneNumberCampaignServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberCampaignServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /10dlc/phone_number_campaigns</c>, but is otherwise the
/// same as <see cref="IPhoneNumberCampaignService.Create(PhoneNumberCampaignCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberCampaign>> Create(
        PhoneNumberCampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/phone_number_campaigns/{phoneNumber}</c>, but is otherwise the
/// same as <see cref="IPhoneNumberCampaignService.Retrieve(PhoneNumberCampaignRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberCampaign>> Retrieve(
        PhoneNumberCampaignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PhoneNumberCampaignRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberCampaign>> Retrieve(
        string phoneNumber,
        PhoneNumberCampaignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /10dlc/phone_number_campaigns/{phoneNumber}</c>, but is otherwise the
/// same as <see cref="IPhoneNumberCampaignService.Update(PhoneNumberCampaignUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberCampaign>> Update(
        PhoneNumberCampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(PhoneNumberCampaignUpdateParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberCampaign>> Update(
        string campaignPhoneNumber,
        PhoneNumberCampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/phone_number_campaigns</c>, but is otherwise the
/// same as <see cref="IPhoneNumberCampaignService.List(PhoneNumberCampaignListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberCampaignListPage>> List(
        PhoneNumberCampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /10dlc/phone_number_campaigns/{phoneNumber}</c>, but is otherwise the
/// same as <see cref="IPhoneNumberCampaignService.Delete(PhoneNumberCampaignDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberCampaign>> Delete(
        PhoneNumberCampaignDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PhoneNumberCampaignDeleteParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberCampaign>> Delete(
        string phoneNumber,
        PhoneNumberCampaignDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}