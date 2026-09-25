using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailBlocks.Imports;

namespace Telnyx.Sdk.Services.EmailBlocks;

/// <inheritdoc/>
public sealed class ImportService : IImportService
{
    readonly Lazy<IImportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IImportServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IImportService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ImportService(this._client.WithOptions(modifier)); }

    public ImportService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ImportServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<EmailBlockImportResponse> Create(
        ImportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EmailBlockImportResponse> Retrieve(
        ImportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailBlockImportResponse> Retrieve(
        string id,
        ImportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ImportServiceWithRawResponse : IImportServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IImportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ImportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ImportServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailBlockImportResponse>> Create(
        ImportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ImportCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailBlockImportResponse = await response.Deserialize<EmailBlockImportResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailBlockImportResponse.Validate();
            }
            return emailBlockImportResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailBlockImportResponse>> Retrieve(
        ImportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ImportRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailBlockImportResponse = await response.Deserialize<EmailBlockImportResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailBlockImportResponse.Validate();
            }
            return emailBlockImportResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailBlockImportResponse>> Retrieve(
        string id,
        ImportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }
}