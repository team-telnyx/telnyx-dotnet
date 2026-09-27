using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.IntegrationSecrets;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class IntegrationSecretService : IIntegrationSecretService
{
    readonly Lazy<IIntegrationSecretServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IIntegrationSecretServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IIntegrationSecretService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new IntegrationSecretService(this._client.WithOptions(modifier)); }

    public IntegrationSecretService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new IntegrationSecretServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<IntegrationSecretCreateResponse> Create(
        IntegrationSecretCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<IntegrationSecretListPage> List(
        IntegrationSecretListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        IntegrationSecretDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string id,
        IntegrationSecretDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            ID = id
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class IntegrationSecretServiceWithRawResponse : IIntegrationSecretServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IIntegrationSecretServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new IntegrationSecretServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public IntegrationSecretServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<IntegrationSecretCreateResponse>> Create(
        IntegrationSecretCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IntegrationSecretCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var integrationSecret = await response.Deserialize<IntegrationSecretCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                integrationSecret.Validate();
            }
            return integrationSecret;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IntegrationSecretListPage>> List(
        IntegrationSecretListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<IntegrationSecretListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<IntegrationSecretListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new IntegrationSecretListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        IntegrationSecretDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<IntegrationSecretDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        IntegrationSecretDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}