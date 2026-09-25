using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Dir.PhoneNumberBatches;

namespace Telnyx.Sdk.Services.Dir;

/// <inheritdoc/>
public sealed class PhoneNumberBatchService : IPhoneNumberBatchService
{
    readonly Lazy<IPhoneNumberBatchServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPhoneNumberBatchServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPhoneNumberBatchService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new PhoneNumberBatchService(this._client.WithOptions(modifier)); }

    public PhoneNumberBatchService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PhoneNumberBatchServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberBatchRetrieveResponse> Retrieve(
        PhoneNumberBatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberBatchRetrieveResponse> Retrieve(
        string batchID,
        PhoneNumberBatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            BatchID = batchID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberBatchListPage> List(
        PhoneNumberBatchListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberBatchListPage> List(
        string dirID,
        PhoneNumberBatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            DirID = dirID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PhoneNumberBatchServiceWithRawResponse : IPhoneNumberBatchServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPhoneNumberBatchServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhoneNumberBatchServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PhoneNumberBatchServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberBatchRetrieveResponse>> Retrieve(
        PhoneNumberBatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BatchID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BatchID' cannot be null"
            );
        }

        HttpRequest<PhoneNumberBatchRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var phoneNumberBatch = await response.Deserialize<PhoneNumberBatchRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                phoneNumberBatch.Validate();
            }
            return phoneNumberBatch;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberBatchRetrieveResponse>> Retrieve(
        string batchID,
        PhoneNumberBatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            BatchID = batchID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberBatchListPage>> List(
        PhoneNumberBatchListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DirID' cannot be null"
            );
        }

        HttpRequest<PhoneNumberBatchListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PhoneNumberBatchListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new PhoneNumberBatchListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberBatchListPage>> List(
        string dirID,
        PhoneNumberBatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            DirID = dirID
        }, cancellationToken);
    }
}