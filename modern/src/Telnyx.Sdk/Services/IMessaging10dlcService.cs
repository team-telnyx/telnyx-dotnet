using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messaging10dlc;
using Telnyx.Sdk.Services.Messaging10dlc;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMessaging10dlcService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessaging10dlcServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessaging10dlcService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IBrandService Brand { get; }

    ICampaignService Campaign { get; }

    ICampaignBuilderService CampaignBuilder { get; }

    IPartnerCampaignService PartnerCampaigns { get; }

    IPhoneNumberCampaignService PhoneNumberCampaigns { get; }

    IPhoneNumberAssignmentByProfileService PhoneNumberAssignmentByProfile {
        get;
    }

    /// <summary>
/// Returns the accepted values for the selected 10DLC enumeration endpoint. Use
/// these values when constructing brand and campaign requests.
/// </summary>
    Task<Messaging10dlcGetEnumResponse> GetEnum(
        Messaging10dlcGetEnumParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetEnum(Messaging10dlcGetEnumParams, CancellationToken)"/>
    Task<Messaging10dlcGetEnumResponse> GetEnum(
        ApiEnum<string, Endpoint> endpoint,
        Messaging10dlcGetEnumParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMessaging10dlcService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessaging10dlcServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessaging10dlcServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IBrandServiceWithRawResponse Brand { get; }

    ICampaignServiceWithRawResponse Campaign { get; }

    ICampaignBuilderServiceWithRawResponse CampaignBuilder { get; }

    IPartnerCampaignServiceWithRawResponse PartnerCampaigns { get; }

    IPhoneNumberCampaignServiceWithRawResponse PhoneNumberCampaigns { get; }

    IPhoneNumberAssignmentByProfileServiceWithRawResponse PhoneNumberAssignmentByProfile {
        get;
    }

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/enum/{endpoint}</c>, but is otherwise the
/// same as <see cref="IMessaging10dlcService.GetEnum(Messaging10dlcGetEnumParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Messaging10dlcGetEnumResponse>> GetEnum(
        Messaging10dlcGetEnumParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetEnum(Messaging10dlcGetEnumParams, CancellationToken)"/>
    Task<HttpResponse<Messaging10dlcGetEnumResponse>> GetEnum(
        ApiEnum<string, Endpoint> endpoint,
        Messaging10dlcGetEnumParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}