using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Messaging10dlc.PhoneNumberCampaigns;

namespace Telnyx.Sdk.Services.Messaging10dlc;

/// <inheritdoc/>
public sealed class PhoneNumberCampaignService : IPhoneNumberCampaignService
{
    readonly Lazy<IPhoneNumberCampaignServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPhoneNumberCampaignServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPhoneNumberCampaignService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhoneNumberCampaignService(this._client.WithOptions(modifier));
    }

    public PhoneNumberCampaignService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PhoneNumberCampaignServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberCampaign> Create(
        PhoneNumberCampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberCampaign> Retrieve(
        PhoneNumberCampaignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberCampaign> Retrieve(
        string phoneNumber,
        PhoneNumberCampaignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberCampaign> Update(
        PhoneNumberCampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberCampaign> Update(
        string campaignPhoneNumber,
        PhoneNumberCampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            CampaignPhoneNumber = campaignPhoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberCampaignListPage> List(
        PhoneNumberCampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberCampaign> Delete(
        PhoneNumberCampaignDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberCampaign> Delete(
        string phoneNumber,
        PhoneNumberCampaignDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PhoneNumberCampaignServiceWithRawResponse : IPhoneNumberCampaignServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPhoneNumberCampaignServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhoneNumberCampaignServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PhoneNumberCampaignServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberCampaign>> Create(
        PhoneNumberCampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PhoneNumberCampaignCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var phoneNumberCampaign = await response.Deserialize<PhoneNumberCampaign>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                phoneNumberCampaign.Validate();
            }
            return phoneNumberCampaign;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberCampaign>> Retrieve(
        PhoneNumberCampaignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<PhoneNumberCampaignRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var phoneNumberCampaign = await response.Deserialize<PhoneNumberCampaign>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                phoneNumberCampaign.Validate();
            }
            return phoneNumberCampaign;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberCampaign>> Retrieve(
        string phoneNumber,
        PhoneNumberCampaignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberCampaign>> Update(
        PhoneNumberCampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignPhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CampaignPhoneNumber' cannot be null"
            );
        }

        HttpRequest<PhoneNumberCampaignUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var phoneNumberCampaign = await response.Deserialize<PhoneNumberCampaign>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                phoneNumberCampaign.Validate();
            }
            return phoneNumberCampaign;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberCampaign>> Update(
        string campaignPhoneNumber,
        PhoneNumberCampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            CampaignPhoneNumber = campaignPhoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberCampaignListPage>> List(
        PhoneNumberCampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PhoneNumberCampaignListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PhoneNumberCampaignListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new PhoneNumberCampaignListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberCampaign>> Delete(
        PhoneNumberCampaignDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<PhoneNumberCampaignDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var phoneNumberCampaign = await response.Deserialize<PhoneNumberCampaign>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                phoneNumberCampaign.Validate();
            }
            return phoneNumberCampaign;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberCampaign>> Delete(
        string phoneNumber,
        PhoneNumberCampaignDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}