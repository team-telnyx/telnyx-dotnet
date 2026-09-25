using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.SimCardDataUsageNotifications;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class SimCardDataUsageNotificationService : ISimCardDataUsageNotificationService
{
    readonly Lazy<ISimCardDataUsageNotificationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISimCardDataUsageNotificationServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISimCardDataUsageNotificationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SimCardDataUsageNotificationService(this._client.WithOptions(modifier));
    }

    public SimCardDataUsageNotificationService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SimCardDataUsageNotificationServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<SimCardDataUsageNotificationCreateResponse> Create(
        SimCardDataUsageNotificationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SimCardDataUsageNotificationRetrieveResponse> Retrieve(
        SimCardDataUsageNotificationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SimCardDataUsageNotificationRetrieveResponse> Retrieve(
        string id,
        SimCardDataUsageNotificationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SimCardDataUsageNotificationUpdateResponse> Update(
        SimCardDataUsageNotificationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SimCardDataUsageNotificationUpdateResponse> Update(
        string simCardDataUsageNotificationID,
        SimCardDataUsageNotificationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            SimCardDataUsageNotificationID = simCardDataUsageNotificationID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SimCardDataUsageNotificationListPage> List(
        SimCardDataUsageNotificationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SimCardDataUsageNotificationDeleteResponse> Delete(
        SimCardDataUsageNotificationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SimCardDataUsageNotificationDeleteResponse> Delete(
        string id,
        SimCardDataUsageNotificationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SimCardDataUsageNotificationServiceWithRawResponse : ISimCardDataUsageNotificationServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISimCardDataUsageNotificationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SimCardDataUsageNotificationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SimCardDataUsageNotificationServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardDataUsageNotificationCreateResponse>> Create(
        SimCardDataUsageNotificationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SimCardDataUsageNotificationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var simCardDataUsageNotification = await response.Deserialize<SimCardDataUsageNotificationCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                simCardDataUsageNotification.Validate();
            }
            return simCardDataUsageNotification;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardDataUsageNotificationRetrieveResponse>> Retrieve(
        SimCardDataUsageNotificationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SimCardDataUsageNotificationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var simCardDataUsageNotification = await response.Deserialize<SimCardDataUsageNotificationRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                simCardDataUsageNotification.Validate();
            }
            return simCardDataUsageNotification;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SimCardDataUsageNotificationRetrieveResponse>> Retrieve(
        string id,
        SimCardDataUsageNotificationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardDataUsageNotificationUpdateResponse>> Update(
        SimCardDataUsageNotificationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SimCardDataUsageNotificationID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.SimCardDataUsageNotificationID' cannot be null"
            );
        }

        HttpRequest<SimCardDataUsageNotificationUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var simCardDataUsageNotification = await response.Deserialize<SimCardDataUsageNotificationUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                simCardDataUsageNotification.Validate();
            }
            return simCardDataUsageNotification;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SimCardDataUsageNotificationUpdateResponse>> Update(
        string simCardDataUsageNotificationID,
        SimCardDataUsageNotificationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            SimCardDataUsageNotificationID = simCardDataUsageNotificationID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardDataUsageNotificationListPage>> List(
        SimCardDataUsageNotificationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SimCardDataUsageNotificationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<SimCardDataUsageNotificationListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new SimCardDataUsageNotificationListPage(this,
            parameters,
            page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardDataUsageNotificationDeleteResponse>> Delete(
        SimCardDataUsageNotificationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SimCardDataUsageNotificationDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var simCardDataUsageNotification = await response.Deserialize<SimCardDataUsageNotificationDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                simCardDataUsageNotification.Validate();
            }
            return simCardDataUsageNotification;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SimCardDataUsageNotificationDeleteResponse>> Delete(
        string id,
        SimCardDataUsageNotificationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}