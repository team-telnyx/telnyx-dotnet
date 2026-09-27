using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Assistants.Tools;

namespace Telnyx.Sdk.Services.AI.Assistants;

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
    public async Task<JsonElement> Add(
        ToolAddParams parameters, CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Add(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<JsonElement> Add(
        string toolID,
        ToolAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with{
            ToolID = toolID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Remove(
        ToolRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Remove(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<JsonElement> Remove(
        string toolID,
        ToolRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with{
            ToolID = toolID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ToolTestResponse> Test(
        ToolTestParams parameters, CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Test(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ToolTestResponse> Test(
        string toolID,
        ToolTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Test(parameters with{
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
    public async Task<HttpResponse<JsonElement>> Add(
        ToolAddParams parameters, CancellationToken cancellationToken = default
    )
    {
        if (parameters.ToolID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ToolID' cannot be null"
            );
        }

        HttpRequest<ToolAddParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> Add(
        string toolID,
        ToolAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with{
            ToolID = toolID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> Remove(
        ToolRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ToolID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ToolID' cannot be null"
            );
        }

        HttpRequest<ToolRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> Remove(
        string toolID,
        ToolRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with{
            ToolID = toolID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ToolTestResponse>> Test(
        ToolTestParams parameters, CancellationToken cancellationToken = default
    )
    {
        if (parameters.ToolID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ToolID' cannot be null"
            );
        }

        HttpRequest<ToolTestParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ToolTestResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ToolTestResponse>> Test(
        string toolID,
        ToolTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Test(parameters with{
            ToolID = toolID
        }, cancellationToken);
    }
}