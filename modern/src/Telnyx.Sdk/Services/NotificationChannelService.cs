using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.NotificationChannels;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class NotificationChannelService : INotificationChannelService
{
    readonly Lazy<INotificationChannelServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INotificationChannelServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public INotificationChannelService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NotificationChannelService(this._client.WithOptions(modifier));
    }

    public NotificationChannelService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new NotificationChannelServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<NotificationChannelCreateResponse> Create(
        NotificationChannelCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NotificationChannelRetrieveResponse> Retrieve(
        NotificationChannelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NotificationChannelRetrieveResponse> Retrieve(
        string id,
        NotificationChannelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NotificationChannelUpdateResponse> Update(
        NotificationChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NotificationChannelUpdateResponse> Update(
        string notificationChannelID,
        NotificationChannelUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            NotificationChannelID = notificationChannelID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NotificationChannelListPage> List(
        NotificationChannelListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NotificationChannelDeleteResponse> Delete(
        NotificationChannelDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NotificationChannelDeleteResponse> Delete(
        string id,
        NotificationChannelDeleteParams? parameters = null,
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
public sealed class NotificationChannelServiceWithRawResponse : INotificationChannelServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public INotificationChannelServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NotificationChannelServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NotificationChannelServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationChannelCreateResponse>> Create(
        NotificationChannelCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NotificationChannelCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var notificationChannel = await response.Deserialize<NotificationChannelCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                notificationChannel.Validate();
            }
            return notificationChannel;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationChannelRetrieveResponse>> Retrieve(
        NotificationChannelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<NotificationChannelRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var notificationChannel = await response.Deserialize<NotificationChannelRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                notificationChannel.Validate();
            }
            return notificationChannel;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NotificationChannelRetrieveResponse>> Retrieve(
        string id,
        NotificationChannelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationChannelUpdateResponse>> Update(
        NotificationChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.NotificationChannelID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.NotificationChannelID' cannot be null"
            );
        }

        HttpRequest<NotificationChannelUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var notificationChannel = await response.Deserialize<NotificationChannelUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                notificationChannel.Validate();
            }
            return notificationChannel;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NotificationChannelUpdateResponse>> Update(
        string notificationChannelID,
        NotificationChannelUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            NotificationChannelID = notificationChannelID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationChannelListPage>> List(
        NotificationChannelListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NotificationChannelListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<NotificationChannelListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new NotificationChannelListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationChannelDeleteResponse>> Delete(
        NotificationChannelDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<NotificationChannelDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var notificationChannel = await response.Deserialize<NotificationChannelDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                notificationChannel.Validate();
            }
            return notificationChannel;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NotificationChannelDeleteResponse>> Delete(
        string id,
        NotificationChannelDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}