using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messaging10dlc.Campaign;
using Telnyx.Sdk.Models.Messaging10dlc.CampaignBuilder;
using CampaignBuilder = Telnyx.Sdk.Services.Messaging10dlc.CampaignBuilder;

namespace Telnyx.Sdk.Services.Messaging10dlc;

/// <inheritdoc/>
public sealed class CampaignBuilderService : ICampaignBuilderService
{
    readonly Lazy<ICampaignBuilderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICampaignBuilderServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICampaignBuilderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new CampaignBuilderService(this._client.WithOptions(modifier)); }

    public CampaignBuilderService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CampaignBuilderServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _brand =new(() => new CampaignBuilder::BrandService(client)) ;
    }

    readonly Lazy<CampaignBuilder::IBrandService> _brand;
    public CampaignBuilder::IBrandService Brand { get { return _brand.Value; } }

    /// <inheritdoc/>
    public async Task<TelnyxCampaignCsp> Submit(
        CampaignBuilderSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Submit(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CampaignBuilderServiceWithRawResponse : ICampaignBuilderServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICampaignBuilderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CampaignBuilderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CampaignBuilderServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _brand =new(
            () => new CampaignBuilder::BrandServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<CampaignBuilder::IBrandServiceWithRawResponse> _brand;
    public CampaignBuilder::IBrandServiceWithRawResponse Brand {
        get { return _brand.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TelnyxCampaignCsp>> Submit(
        CampaignBuilderSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CampaignBuilderSubmitParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var telnyxCampaignCsp = await response.Deserialize<TelnyxCampaignCsp>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                telnyxCampaignCsp.Validate();
            }
            return telnyxCampaignCsp;
        });
    }
}