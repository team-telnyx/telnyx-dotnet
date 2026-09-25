using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles.Memories;

namespace Telnyx.Sdk.Services.AI.Memory.Namespaces.Profiles;

/// <inheritdoc/>
public sealed class MemoryService : IMemoryService
{
    readonly Lazy<IMemoryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMemoryServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMemoryService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MemoryService(this._client.WithOptions(modifier)); }

    public MemoryService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MemoryServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<MemoryRetrieveResponse> Retrieve(
        MemoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MemoryRetrieveResponse> Retrieve(
        string memoryID,
        MemoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            MemoryID = memoryID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MemoryListPage> List(
        MemoryListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MemoryListPage> List(
        string profileID,
        MemoryListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with{
            ProfileID = profileID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MemoryServiceWithRawResponse : IMemoryServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMemoryServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MemoryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MemoryServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<MemoryRetrieveResponse>> Retrieve(
        MemoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MemoryID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MemoryID' cannot be null"
            );
        }

        HttpRequest<MemoryRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var memory = await response.Deserialize<MemoryRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                memory.Validate();
            }
            return memory;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MemoryRetrieveResponse>> Retrieve(
        string memoryID,
        MemoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            MemoryID = memoryID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MemoryListPage>> List(
        MemoryListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProfileID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ProfileID' cannot be null"
            );
        }

        HttpRequest<MemoryListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MemoryListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MemoryListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MemoryListPage>> List(
        string profileID,
        MemoryListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with{
            ProfileID = profileID
        }, cancellationToken);
    }
}