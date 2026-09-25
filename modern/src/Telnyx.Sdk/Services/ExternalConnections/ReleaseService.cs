using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.ExternalConnections.Releases;

namespace Telnyx.Sdk.Services.ExternalConnections;

/// <inheritdoc/>
public sealed class ReleaseService : IReleaseService
{
    readonly Lazy<IReleaseServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IReleaseServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IReleaseService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ReleaseService(this._client.WithOptions(modifier)); }

    public ReleaseService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ReleaseServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ReleaseRetrieveResponse> Retrieve(
        ReleaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ReleaseRetrieveResponse> Retrieve(
        string releaseID,
        ReleaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            ReleaseID = releaseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ReleaseListPage> List(
        ReleaseListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ReleaseListPage> List(
        string id,
        ReleaseListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ReleaseServiceWithRawResponse : IReleaseServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IReleaseServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ReleaseServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ReleaseServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReleaseRetrieveResponse>> Retrieve(
        ReleaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ReleaseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ReleaseID' cannot be null"
            );
        }

        HttpRequest<ReleaseRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var release = await response.Deserialize<ReleaseRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                release.Validate();
            }
            return release;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ReleaseRetrieveResponse>> Retrieve(
        string releaseID,
        ReleaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            ReleaseID = releaseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReleaseListPage>> List(
        ReleaseListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ReleaseListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<ReleaseListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ReleaseListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ReleaseListPage>> List(
        string id,
        ReleaseListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }
}