using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.DocumentLinks;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class DocumentLinkService : IDocumentLinkService
{
    readonly Lazy<IDocumentLinkServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDocumentLinkServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IDocumentLinkService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new DocumentLinkService(this._client.WithOptions(modifier)); }

    public DocumentLinkService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new DocumentLinkServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<DocumentLinkListPage> List(
        DocumentLinkListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class DocumentLinkServiceWithRawResponse : IDocumentLinkServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDocumentLinkServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DocumentLinkServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DocumentLinkServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<DocumentLinkListPage>> List(
        DocumentLinkListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DocumentLinkListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<DocumentLinkListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new DocumentLinkListPage(this, parameters, page);
        });
    }
}