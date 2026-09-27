using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.NotificationSettings;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class NotificationSettingService : INotificationSettingService
{
    readonly Lazy<INotificationSettingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INotificationSettingServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public INotificationSettingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NotificationSettingService(this._client.WithOptions(modifier));
    }

    public NotificationSettingService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new NotificationSettingServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<NotificationSettingCreateResponse> Create(
        NotificationSettingCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NotificationSettingRetrieveResponse> Retrieve(
        NotificationSettingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NotificationSettingRetrieveResponse> Retrieve(
        string id,
        NotificationSettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NotificationSettingListPage> List(
        NotificationSettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NotificationSettingDeleteResponse> Delete(
        NotificationSettingDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NotificationSettingDeleteResponse> Delete(
        string id,
        NotificationSettingDeleteParams? parameters = null,
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
public sealed class NotificationSettingServiceWithRawResponse : INotificationSettingServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public INotificationSettingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NotificationSettingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NotificationSettingServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationSettingCreateResponse>> Create(
        NotificationSettingCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NotificationSettingCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var notificationSetting = await response.Deserialize<NotificationSettingCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                notificationSetting.Validate();
            }
            return notificationSetting;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationSettingRetrieveResponse>> Retrieve(
        NotificationSettingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<NotificationSettingRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var notificationSetting = await response.Deserialize<NotificationSettingRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                notificationSetting.Validate();
            }
            return notificationSetting;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NotificationSettingRetrieveResponse>> Retrieve(
        string id,
        NotificationSettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationSettingListPage>> List(
        NotificationSettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NotificationSettingListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<NotificationSettingListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new NotificationSettingListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationSettingDeleteResponse>> Delete(
        NotificationSettingDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<NotificationSettingDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var notificationSetting = await response.Deserialize<NotificationSettingDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                notificationSetting.Validate();
            }
            return notificationSetting;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NotificationSettingDeleteResponse>> Delete(
        string id,
        NotificationSettingDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}