using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailBlocks;
using Telnyx.Sdk.Models.EmailUnsubscribeGroups.Suppressions;

namespace Telnyx.Sdk.Services.EmailUnsubscribeGroups;

/// <inheritdoc/>
public sealed class SuppressionService : ISuppressionService
{
    readonly Lazy<ISuppressionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISuppressionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISuppressionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new SuppressionService(this._client.WithOptions(modifier)); }

    public SuppressionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SuppressionServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<EmailBlockResponse> Create(
        SuppressionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailBlockResponse> Create(
        string id,
        SuppressionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SuppressionListPage> List(
        SuppressionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SuppressionListPage> List(
        string id,
        SuppressionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        SuppressionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string email,
        SuppressionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with{
            Email = email
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SuppressionServiceWithRawResponse : ISuppressionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISuppressionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SuppressionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SuppressionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailBlockResponse>> Create(
        SuppressionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SuppressionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailBlockResponse = await response.Deserialize<EmailBlockResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailBlockResponse.Validate();
            }
            return emailBlockResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailBlockResponse>> Create(
        string id,
        SuppressionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SuppressionListPage>> List(
        SuppressionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SuppressionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<SuppressionListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new SuppressionListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SuppressionListPage>> List(
        string id,
        SuppressionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        SuppressionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Email == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Email' cannot be null"
            );
        }

        HttpRequest<SuppressionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string email,
        SuppressionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            Email = email
        }, cancellationToken);
    }
}