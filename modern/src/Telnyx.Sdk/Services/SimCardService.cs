using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.SimCards;
using SimCards = Telnyx.Sdk.Services.SimCards;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class SimCardService : ISimCardService
{
    readonly Lazy<ISimCardServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISimCardServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISimCardService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new SimCardService(this._client.WithOptions(modifier)); }

    public SimCardService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SimCardServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _actions =new(() => new SimCards::ActionService(client)) ;
    }

    readonly Lazy<SimCards::IActionService> _actions;
    public SimCards::IActionService Actions { get { return _actions.Value; } }

    /// <inheritdoc/>
    public async Task<SimCardRetrieveResponse> Retrieve(
        SimCardRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SimCardRetrieveResponse> Retrieve(
        string id,
        SimCardRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SimCardUpdateResponse> Update(
        SimCardUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SimCardUpdateResponse> Update(
        string simCardID,
        SimCardUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            SimCardID = simCardID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SimCardListPage> List(
        SimCardListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SimCardDeleteResponse> Delete(
        SimCardDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SimCardDeleteResponse> Delete(
        string id,
        SimCardDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SimCardGetActivationCodeResponse> GetActivationCode(
        SimCardGetActivationCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetActivationCode(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SimCardGetActivationCodeResponse> GetActivationCode(
        string id,
        SimCardGetActivationCodeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetActivationCode(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SimCardGetDeviceDetailsResponse> GetDeviceDetails(
        SimCardGetDeviceDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetDeviceDetails(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SimCardGetDeviceDetailsResponse> GetDeviceDetails(
        string id,
        SimCardGetDeviceDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetDeviceDetails(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SimCardGetPublicIPResponse> GetPublicIP(
        SimCardGetPublicIPParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetPublicIP(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SimCardGetPublicIPResponse> GetPublicIP(
        string id,
        SimCardGetPublicIPParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetPublicIP(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SimCardListWirelessConnectivityLogsPage> ListWirelessConnectivityLogs(
        SimCardListWirelessConnectivityLogsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListWirelessConnectivityLogs(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SimCardListWirelessConnectivityLogsPage> ListWirelessConnectivityLogs(
        string id,
        SimCardListWirelessConnectivityLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListWirelessConnectivityLogs(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SimCardServiceWithRawResponse : ISimCardServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISimCardServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SimCardServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SimCardServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _actions =new(
            () => new SimCards::ActionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<SimCards::IActionServiceWithRawResponse> _actions;
    public SimCards::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardRetrieveResponse>> Retrieve(
        SimCardRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SimCardRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var simCard = await response.Deserialize<SimCardRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                simCard.Validate();
            }
            return simCard;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SimCardRetrieveResponse>> Retrieve(
        string id,
        SimCardRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardUpdateResponse>> Update(
        SimCardUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SimCardID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.SimCardID' cannot be null"
            );
        }

        HttpRequest<SimCardUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var simCard = await response.Deserialize<SimCardUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                simCard.Validate();
            }
            return simCard;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SimCardUpdateResponse>> Update(
        string simCardID,
        SimCardUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            SimCardID = simCardID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardListPage>> List(
        SimCardListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SimCardListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<SimCardListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new SimCardListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardDeleteResponse>> Delete(
        SimCardDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SimCardDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var simCard = await response.Deserialize<SimCardDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                simCard.Validate();
            }
            return simCard;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SimCardDeleteResponse>> Delete(
        string id,
        SimCardDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardGetActivationCodeResponse>> GetActivationCode(
        SimCardGetActivationCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SimCardGetActivationCodeParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<SimCardGetActivationCodeResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SimCardGetActivationCodeResponse>> GetActivationCode(
        string id,
        SimCardGetActivationCodeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetActivationCode(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardGetDeviceDetailsResponse>> GetDeviceDetails(
        SimCardGetDeviceDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SimCardGetDeviceDetailsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<SimCardGetDeviceDetailsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SimCardGetDeviceDetailsResponse>> GetDeviceDetails(
        string id,
        SimCardGetDeviceDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetDeviceDetails(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardGetPublicIPResponse>> GetPublicIP(
        SimCardGetPublicIPParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SimCardGetPublicIPParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<SimCardGetPublicIPResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SimCardGetPublicIPResponse>> GetPublicIP(
        string id,
        SimCardGetPublicIPParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetPublicIP(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardListWirelessConnectivityLogsPage>> ListWirelessConnectivityLogs(
        SimCardListWirelessConnectivityLogsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SimCardListWirelessConnectivityLogsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<SimCardListWirelessConnectivityLogsPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new SimCardListWirelessConnectivityLogsPage(this,
            parameters,
            page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SimCardListWirelessConnectivityLogsPage>> ListWirelessConnectivityLogs(
        string id,
        SimCardListWirelessConnectivityLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListWirelessConnectivityLogs(parameters with{
            ID = id
        }, cancellationToken);
    }
}