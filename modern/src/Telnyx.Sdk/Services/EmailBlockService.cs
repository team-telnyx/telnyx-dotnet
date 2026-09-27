using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailBlocks;
using Telnyx.Sdk.Services.EmailBlocks;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class EmailBlockService : IEmailBlockService
{
    readonly Lazy<IEmailBlockServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEmailBlockServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IEmailBlockService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new EmailBlockService(this._client.WithOptions(modifier)); }

    public EmailBlockService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new EmailBlockServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _imports =new(() => new ImportService(client)) ;
    }

    readonly Lazy<IImportService> _imports;
    public IImportService Imports { get { return _imports.Value; } }

    /// <inheritdoc/>
    public async Task<EmailBlockResponse> Create(
        EmailBlockCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EmailBlockResponse> Retrieve(
        EmailBlockRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailBlockResponse> Retrieve(
        string id,
        EmailBlockRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailBlockListPage> List(
        EmailBlockListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EmailBlockResponse> Delete(
        EmailBlockDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailBlockResponse> Delete(
        string id,
        EmailBlockDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailBlockRetrieveEventsPage> RetrieveEvents(
        EmailBlockRetrieveEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveEvents(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailBlockRetrieveEventsPage> RetrieveEvents(
        string id,
        EmailBlockRetrieveEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveEvents(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<string> RetrieveExport(
        EmailBlockRetrieveExportParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveExport(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class EmailBlockServiceWithRawResponse : IEmailBlockServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEmailBlockServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EmailBlockServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EmailBlockServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _imports =new(() => new ImportServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IImportServiceWithRawResponse> _imports;
    public IImportServiceWithRawResponse Imports {
        get { return _imports.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailBlockResponse>> Create(
        EmailBlockCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EmailBlockCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailBlockResponse = await response.Deserialize<EmailBlockResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailBlockResponse.Validate();
            }
            return emailBlockResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailBlockResponse>> Retrieve(
        EmailBlockRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailBlockRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailBlockResponse = await response.Deserialize<EmailBlockResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailBlockResponse.Validate();
            }
            return emailBlockResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailBlockResponse>> Retrieve(
        string id,
        EmailBlockRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailBlockListPage>> List(
        EmailBlockListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EmailBlockListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<EmailBlockListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new EmailBlockListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailBlockResponse>> Delete(
        EmailBlockDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailBlockDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailBlockResponse = await response.Deserialize<EmailBlockResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailBlockResponse.Validate();
            }
            return emailBlockResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailBlockResponse>> Delete(
        string id,
        EmailBlockDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailBlockRetrieveEventsPage>> RetrieveEvents(
        EmailBlockRetrieveEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailBlockRetrieveEventsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<EmailBlockRetrieveEventsPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new EmailBlockRetrieveEventsPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailBlockRetrieveEventsPage>> RetrieveEvents(
        string id,
        EmailBlockRetrieveEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveEvents(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<string>> RetrieveExport(
        EmailBlockRetrieveExportParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EmailBlockRetrieveExportParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<string>(token).ConfigureAwait(false);
        });
    }
}