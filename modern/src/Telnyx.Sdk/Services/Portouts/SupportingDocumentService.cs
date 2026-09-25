using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Portouts.SupportingDocuments;

namespace Telnyx.Sdk.Services.Portouts;

/// <inheritdoc/>
public sealed class SupportingDocumentService : ISupportingDocumentService
{
    readonly Lazy<ISupportingDocumentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISupportingDocumentServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISupportingDocumentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SupportingDocumentService(this._client.WithOptions(modifier));
    }

    public SupportingDocumentService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SupportingDocumentServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<SupportingDocumentCreateResponse> Create(
        SupportingDocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SupportingDocumentCreateResponse> Create(
        string id,
        SupportingDocumentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SupportingDocumentListResponse> List(
        SupportingDocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SupportingDocumentListResponse> List(
        string id,
        SupportingDocumentListParams? parameters = null,
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
public sealed class SupportingDocumentServiceWithRawResponse : ISupportingDocumentServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISupportingDocumentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SupportingDocumentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SupportingDocumentServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<SupportingDocumentCreateResponse>> Create(
        SupportingDocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SupportingDocumentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var supportingDocument = await response.Deserialize<SupportingDocumentCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                supportingDocument.Validate();
            }
            return supportingDocument;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SupportingDocumentCreateResponse>> Create(
        string id,
        SupportingDocumentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SupportingDocumentListResponse>> List(
        SupportingDocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SupportingDocumentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var supportingDocuments = await response.Deserialize<SupportingDocumentListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                supportingDocuments.Validate();
            }
            return supportingDocuments;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SupportingDocumentListResponse>> List(
        string id,
        SupportingDocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }
}