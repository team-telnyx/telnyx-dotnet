using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.NotificationProfiles;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class NotificationProfileService : INotificationProfileService
{
    readonly Lazy<INotificationProfileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INotificationProfileServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public INotificationProfileService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NotificationProfileService(this._client.WithOptions(modifier));
    }

    public NotificationProfileService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new NotificationProfileServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<NotificationProfileCreateResponse> Create(
        NotificationProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NotificationProfileRetrieveResponse> Retrieve(
        NotificationProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NotificationProfileRetrieveResponse> Retrieve(
        string id,
        NotificationProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NotificationProfileUpdateResponse> Update(
        NotificationProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NotificationProfileUpdateResponse> Update(
        string notificationProfileID,
        NotificationProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            NotificationProfileID = notificationProfileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NotificationProfileListPage> List(
        NotificationProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NotificationProfileDeleteResponse> Delete(
        NotificationProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NotificationProfileDeleteResponse> Delete(
        string id,
        NotificationProfileDeleteParams? parameters = null,
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
public sealed class NotificationProfileServiceWithRawResponse : INotificationProfileServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public INotificationProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NotificationProfileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NotificationProfileServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationProfileCreateResponse>> Create(
        NotificationProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NotificationProfileCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var notificationProfile = await response.Deserialize<NotificationProfileCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                notificationProfile.Validate();
            }
            return notificationProfile;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationProfileRetrieveResponse>> Retrieve(
        NotificationProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<NotificationProfileRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var notificationProfile = await response.Deserialize<NotificationProfileRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                notificationProfile.Validate();
            }
            return notificationProfile;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NotificationProfileRetrieveResponse>> Retrieve(
        string id,
        NotificationProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationProfileUpdateResponse>> Update(
        NotificationProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.NotificationProfileID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.NotificationProfileID' cannot be null"
            );
        }

        HttpRequest<NotificationProfileUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var notificationProfile = await response.Deserialize<NotificationProfileUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                notificationProfile.Validate();
            }
            return notificationProfile;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NotificationProfileUpdateResponse>> Update(
        string notificationProfileID,
        NotificationProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            NotificationProfileID = notificationProfileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationProfileListPage>> List(
        NotificationProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NotificationProfileListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<NotificationProfileListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new NotificationProfileListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationProfileDeleteResponse>> Delete(
        NotificationProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<NotificationProfileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var notificationProfile = await response.Deserialize<NotificationProfileDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                notificationProfile.Validate();
            }
            return notificationProfile;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NotificationProfileDeleteResponse>> Delete(
        string id,
        NotificationProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}