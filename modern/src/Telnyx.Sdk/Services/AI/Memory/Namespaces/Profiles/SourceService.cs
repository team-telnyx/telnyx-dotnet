using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles.Sources;

namespace Telnyx.Sdk.Services.AI.Memory.Namespaces.Profiles;

/// <inheritdoc/>
public sealed class SourceService : ISourceService
{
    readonly Lazy<ISourceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISourceServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISourceService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new SourceService(this._client.WithOptions(modifier)); }

    public SourceService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SourceServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<SourceRetrieveResponse> Retrieve(
        SourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SourceRetrieveResponse> Retrieve(
        string sourceID,
        SourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            SourceID = sourceID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SourceListPage> List(
        SourceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SourceListPage> List(
        string profileID,
        SourceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with{
            ProfileID = profileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SourceDeleteResponse> Delete(
        SourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SourceDeleteResponse> Delete(
        string sourceID,
        SourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            SourceID = sourceID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SourceServiceWithRawResponse : ISourceServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISourceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SourceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SourceServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<SourceRetrieveResponse>> Retrieve(
        SourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SourceID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.SourceID' cannot be null"
            );
        }

        HttpRequest<SourceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var source = await response.Deserialize<SourceRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                source.Validate();
            }
            return source;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SourceRetrieveResponse>> Retrieve(
        string sourceID,
        SourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            SourceID = sourceID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SourceListPage>> List(
        SourceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProfileID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ProfileID' cannot be null"
            );
        }

        HttpRequest<SourceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<SourceListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new SourceListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SourceListPage>> List(
        string profileID,
        SourceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with{
            ProfileID = profileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SourceDeleteResponse>> Delete(
        SourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SourceID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.SourceID' cannot be null"
            );
        }

        HttpRequest<SourceDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var source = await response.Deserialize<SourceDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                source.Validate();
            }
            return source;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SourceDeleteResponse>> Delete(
        string sourceID,
        SourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            SourceID = sourceID
        }, cancellationToken);
    }
}