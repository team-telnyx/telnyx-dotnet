using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Assistants.CanaryDeploys;

namespace Telnyx.Sdk.Services.AI.Assistants;

/// <inheritdoc/>
public sealed class CanaryDeployService : ICanaryDeployService
{
    readonly Lazy<ICanaryDeployServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICanaryDeployServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICanaryDeployService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new CanaryDeployService(this._client.WithOptions(modifier)); }

    public CanaryDeployService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CanaryDeployServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<CanaryDeployResponse> Create(
        CanaryDeployCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CanaryDeployResponse> Create(
        string assistantID,
        CanaryDeployCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CanaryDeployResponse> Retrieve(
        CanaryDeployRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CanaryDeployResponse> Retrieve(
        string assistantID,
        CanaryDeployRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CanaryDeployResponse> Update(
        CanaryDeployUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CanaryDeployResponse> Update(
        string assistantID,
        CanaryDeployUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        CanaryDeployDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string assistantID,
        CanaryDeployDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            AssistantID = assistantID
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CanaryDeployServiceWithRawResponse : ICanaryDeployServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICanaryDeployServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CanaryDeployServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CanaryDeployServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<CanaryDeployResponse>> Create(
        CanaryDeployCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AssistantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AssistantID' cannot be null"
            );
        }

        HttpRequest<CanaryDeployCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var canaryDeployResponse = await response.Deserialize<CanaryDeployResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                canaryDeployResponse.Validate();
            }
            return canaryDeployResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CanaryDeployResponse>> Create(
        string assistantID,
        CanaryDeployCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CanaryDeployResponse>> Retrieve(
        CanaryDeployRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AssistantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AssistantID' cannot be null"
            );
        }

        HttpRequest<CanaryDeployRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var canaryDeployResponse = await response.Deserialize<CanaryDeployResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                canaryDeployResponse.Validate();
            }
            return canaryDeployResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CanaryDeployResponse>> Retrieve(
        string assistantID,
        CanaryDeployRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CanaryDeployResponse>> Update(
        CanaryDeployUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AssistantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AssistantID' cannot be null"
            );
        }

        HttpRequest<CanaryDeployUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var canaryDeployResponse = await response.Deserialize<CanaryDeployResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                canaryDeployResponse.Validate();
            }
            return canaryDeployResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CanaryDeployResponse>> Update(
        string assistantID,
        CanaryDeployUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        CanaryDeployDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AssistantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AssistantID' cannot be null"
            );
        }

        HttpRequest<CanaryDeployDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string assistantID,
        CanaryDeployDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }
}