using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.PhoneNumbers.Messaging;

namespace Telnyx.Sdk.Services.PhoneNumbers;

/// <inheritdoc/>
public sealed class MessagingService : IMessagingService
{
    readonly Lazy<IMessagingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMessagingServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMessagingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MessagingService(this._client.WithOptions(modifier)); }

    public MessagingService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MessagingServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<MessagingRetrieveResponse> Retrieve(
        MessagingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessagingRetrieveResponse> Retrieve(
        string id,
        MessagingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessagingUpdateResponse> Update(
        MessagingUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessagingUpdateResponse> Update(
        string id,
        MessagingUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessagingListPage> List(
        MessagingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MessagingServiceWithRawResponse : IMessagingServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMessagingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MessagingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MessagingServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingRetrieveResponse>> Retrieve(
        MessagingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MessagingRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messaging = await response.Deserialize<MessagingRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messaging.Validate();
            }
            return messaging;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessagingRetrieveResponse>> Retrieve(
        string id,
        MessagingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingUpdateResponse>> Update(
        MessagingUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MessagingUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messaging = await response.Deserialize<MessagingUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messaging.Validate();
            }
            return messaging;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessagingUpdateResponse>> Update(
        string id,
        MessagingUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingListPage>> List(
        MessagingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MessagingListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MessagingListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MessagingListPage(this, parameters, page);
        });
    }
}