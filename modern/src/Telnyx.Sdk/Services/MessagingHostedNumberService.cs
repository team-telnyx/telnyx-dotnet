using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.MessagingHostedNumbers;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class MessagingHostedNumberService : IMessagingHostedNumberService
{
    readonly Lazy<IMessagingHostedNumberServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMessagingHostedNumberServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMessagingHostedNumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MessagingHostedNumberService(this._client.WithOptions(modifier));
    }

    public MessagingHostedNumberService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MessagingHostedNumberServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<MessagingHostedNumberRetrieveResponse> Retrieve(
        MessagingHostedNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessagingHostedNumberRetrieveResponse> Retrieve(
        string id,
        MessagingHostedNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessagingHostedNumberUpdateResponse> Update(
        MessagingHostedNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessagingHostedNumberUpdateResponse> Update(
        string id,
        MessagingHostedNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessagingHostedNumberListPage> List(
        MessagingHostedNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MessagingHostedNumberDeleteResponse> Delete(
        MessagingHostedNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessagingHostedNumberDeleteResponse> Delete(
        string id,
        MessagingHostedNumberDeleteParams? parameters = null,
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
public sealed class MessagingHostedNumberServiceWithRawResponse : IMessagingHostedNumberServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMessagingHostedNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MessagingHostedNumberServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MessagingHostedNumberServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingHostedNumberRetrieveResponse>> Retrieve(
        MessagingHostedNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MessagingHostedNumberRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messagingHostedNumber = await response.Deserialize<MessagingHostedNumberRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messagingHostedNumber.Validate();
            }
            return messagingHostedNumber;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessagingHostedNumberRetrieveResponse>> Retrieve(
        string id,
        MessagingHostedNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingHostedNumberUpdateResponse>> Update(
        MessagingHostedNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MessagingHostedNumberUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messagingHostedNumber = await response.Deserialize<MessagingHostedNumberUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messagingHostedNumber.Validate();
            }
            return messagingHostedNumber;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessagingHostedNumberUpdateResponse>> Update(
        string id,
        MessagingHostedNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingHostedNumberListPage>> List(
        MessagingHostedNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MessagingHostedNumberListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MessagingHostedNumberListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MessagingHostedNumberListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingHostedNumberDeleteResponse>> Delete(
        MessagingHostedNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MessagingHostedNumberDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messagingHostedNumber = await response.Deserialize<MessagingHostedNumberDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messagingHostedNumber.Validate();
            }
            return messagingHostedNumber;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessagingHostedNumberDeleteResponse>> Delete(
        string id,
        MessagingHostedNumberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}