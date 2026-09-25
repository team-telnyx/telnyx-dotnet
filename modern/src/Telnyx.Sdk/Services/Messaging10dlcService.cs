using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Messaging10dlc;
using Telnyx.Sdk.Services.Messaging10dlc;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class Messaging10dlcService : IMessaging10dlcService
{
    readonly Lazy<IMessaging10dlcServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMessaging10dlcServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMessaging10dlcService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new Messaging10dlcService(this._client.WithOptions(modifier)); }

    public Messaging10dlcService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new Messaging10dlcServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _brand =new(() => new BrandService(client)) ;
        _campaign =new(() => new CampaignService(client)) ;
        _campaignBuilder =new(() => new CampaignBuilderService(client)) ;
        _partnerCampaigns =new(() => new PartnerCampaignService(client)) ;
        _phoneNumberCampaigns =new(
            () => new PhoneNumberCampaignService(client)
        ) ;
        _phoneNumberAssignmentByProfile =new(
            () => new PhoneNumberAssignmentByProfileService(client)
        ) ;
    }

    readonly Lazy<IBrandService> _brand;
    public IBrandService Brand { get { return _brand.Value; } }

    readonly Lazy<ICampaignService> _campaign;
    public ICampaignService Campaign { get { return _campaign.Value; } }

    readonly Lazy<ICampaignBuilderService> _campaignBuilder;
    public ICampaignBuilderService CampaignBuilder {
        get { return _campaignBuilder.Value; }
    }

    readonly Lazy<IPartnerCampaignService> _partnerCampaigns;
    public IPartnerCampaignService PartnerCampaigns {
        get { return _partnerCampaigns.Value; }
    }

    readonly Lazy<IPhoneNumberCampaignService> _phoneNumberCampaigns;
    public IPhoneNumberCampaignService PhoneNumberCampaigns {
        get { return _phoneNumberCampaigns.Value; }
    }

    readonly Lazy<IPhoneNumberAssignmentByProfileService> _phoneNumberAssignmentByProfile;
    public IPhoneNumberAssignmentByProfileService PhoneNumberAssignmentByProfile {
        get { return _phoneNumberAssignmentByProfile.Value; }
    }

    /// <inheritdoc/>
    public async Task<Messaging10dlcGetEnumResponse> GetEnum(
        Messaging10dlcGetEnumParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetEnum(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<Messaging10dlcGetEnumResponse> GetEnum(
        ApiEnum<string, Endpoint> endpoint,
        Messaging10dlcGetEnumParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetEnum(parameters with{
            Endpoint = endpoint
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class Messaging10dlcServiceWithRawResponse : IMessaging10dlcServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMessaging10dlcServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new Messaging10dlcServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public Messaging10dlcServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _brand =new(() => new BrandServiceWithRawResponse(client)) ;
        _campaign =new(() => new CampaignServiceWithRawResponse(client)) ;
        _campaignBuilder =new(
            () => new CampaignBuilderServiceWithRawResponse(client)
        ) ;
        _partnerCampaigns =new(
            () => new PartnerCampaignServiceWithRawResponse(client)
        ) ;
        _phoneNumberCampaigns =new(
            () => new PhoneNumberCampaignServiceWithRawResponse(client)
        ) ;
        _phoneNumberAssignmentByProfile =new(
            () => new PhoneNumberAssignmentByProfileServiceWithRawResponse(
                client
            )
        ) ;
    }

    readonly Lazy<IBrandServiceWithRawResponse> _brand;
    public IBrandServiceWithRawResponse Brand { get { return _brand.Value; } }

    readonly Lazy<ICampaignServiceWithRawResponse> _campaign;
    public ICampaignServiceWithRawResponse Campaign {
        get { return _campaign.Value; }
    }

    readonly Lazy<ICampaignBuilderServiceWithRawResponse> _campaignBuilder;
    public ICampaignBuilderServiceWithRawResponse CampaignBuilder {
        get { return _campaignBuilder.Value; }
    }

    readonly Lazy<IPartnerCampaignServiceWithRawResponse> _partnerCampaigns;
    public IPartnerCampaignServiceWithRawResponse PartnerCampaigns {
        get { return _partnerCampaigns.Value; }
    }

    readonly Lazy<IPhoneNumberCampaignServiceWithRawResponse> _phoneNumberCampaigns;
    public IPhoneNumberCampaignServiceWithRawResponse PhoneNumberCampaigns {
        get { return _phoneNumberCampaigns.Value; }
    }

    readonly Lazy<IPhoneNumberAssignmentByProfileServiceWithRawResponse> _phoneNumberAssignmentByProfile;
    public IPhoneNumberAssignmentByProfileServiceWithRawResponse PhoneNumberAssignmentByProfile {
        get { return _phoneNumberAssignmentByProfile.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Messaging10dlcGetEnumResponse>> GetEnum(
        Messaging10dlcGetEnumParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Endpoint == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Endpoint' cannot be null"
            );
        }

        HttpRequest<Messaging10dlcGetEnumParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<Messaging10dlcGetEnumResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<Messaging10dlcGetEnumResponse>> GetEnum(
        ApiEnum<string, Endpoint> endpoint,
        Messaging10dlcGetEnumParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetEnum(parameters with{
            Endpoint = endpoint
        }, cancellationToken);
    }
}