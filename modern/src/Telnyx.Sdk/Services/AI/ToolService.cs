using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Tools;

namespace Telnyx.Sdk.Services.AI;

/// <inheritdoc/>
public sealed class ToolService : IToolService
{
    readonly Lazy<IToolServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IToolServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IToolService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new ToolService(this._client.WithOptions(modifier)); }

    public ToolService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ToolServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<SharedToolResponse> Create(
        ToolCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SharedToolResponse> Retrieve(
        ToolRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SharedToolResponse> Retrieve(
        string toolID,
        ToolRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ToolID = toolID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SharedToolResponse> Update(
        ToolUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SharedToolResponse> Update(
        string toolID,
        ToolUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ToolID = toolID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ToolListPage> List(
        ToolListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Delete(
        ToolDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<JsonElement> Delete(
        string toolID,
        ToolDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ToolID = toolID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ToolServiceWithRawResponse : IToolServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IToolServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ToolServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ToolServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<SharedToolResponse>> Create(
        ToolCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ToolCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var sharedToolResponse = await response.Deserialize<SharedToolResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                sharedToolResponse.Validate();
            }
            return sharedToolResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SharedToolResponse>> Retrieve(
        ToolRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ToolID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ToolID' cannot be null"
            );
        }

        HttpRequest<ToolRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var sharedToolResponse = await response.Deserialize<SharedToolResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                sharedToolResponse.Validate();
            }
            return sharedToolResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SharedToolResponse>> Retrieve(
        string toolID,
        ToolRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ToolID = toolID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SharedToolResponse>> Update(
        ToolUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ToolID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ToolID' cannot be null"
            );
        }

        HttpRequest<ToolUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var sharedToolResponse = await response.Deserialize<SharedToolResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                sharedToolResponse.Validate();
            }
            return sharedToolResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SharedToolResponse>> Update(
        string toolID,
        ToolUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ToolID = toolID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ToolListPage>> List(
        ToolListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ToolListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<ToolListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ToolListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> Delete(
        ToolDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ToolID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ToolID' cannot be null"
            );
        }

        HttpRequest<ToolDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> Delete(
        string toolID,
        ToolDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ToolID = toolID
        }, cancellationToken);
    }
}