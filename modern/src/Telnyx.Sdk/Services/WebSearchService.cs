using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.WebSearch;
using Telnyx.Sdk.Services.WebSearch;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class WebSearchService : IWebSearchService
{
    readonly Lazy<IWebSearchServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWebSearchServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IWebSearchService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new WebSearchService(this._client.WithOptions(modifier)); }

    public WebSearchService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new WebSearchServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _research =new(() => new ResearchService(client)) ;
    }

    readonly Lazy<IResearchService> _research;
    public IResearchService Research { get { return _research.Value; } }

    /// <inheritdoc/>
    public async Task<WebSearchCreateResponse> Create(
        WebSearchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WebSearchContentsResponse> Contents(
        WebSearchContentsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Contents(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class WebSearchServiceWithRawResponse : IWebSearchServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWebSearchServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WebSearchServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WebSearchServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _research =new(() => new ResearchServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IResearchServiceWithRawResponse> _research;
    public IResearchServiceWithRawResponse Research {
        get { return _research.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebSearchCreateResponse>> Create(
        WebSearchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WebSearchCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var webSearch = await response.Deserialize<WebSearchCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                webSearch.Validate();
            }
            return webSearch;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebSearchContentsResponse>> Contents(
        WebSearchContentsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WebSearchContentsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<WebSearchContentsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}