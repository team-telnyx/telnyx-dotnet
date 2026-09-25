using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.RecordingTranscriptions;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class RecordingTranscriptionService : IRecordingTranscriptionService
{
    readonly Lazy<IRecordingTranscriptionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRecordingTranscriptionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRecordingTranscriptionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RecordingTranscriptionService(this._client.WithOptions(modifier));
    }

    public RecordingTranscriptionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RecordingTranscriptionServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<RecordingTranscriptionRetrieveResponse> Retrieve(
        RecordingTranscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RecordingTranscriptionRetrieveResponse> Retrieve(
        string recordingTranscriptionID,
        RecordingTranscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            RecordingTranscriptionID = recordingTranscriptionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RecordingTranscriptionListPage> List(
        RecordingTranscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RecordingTranscriptionDeleteResponse> Delete(
        RecordingTranscriptionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RecordingTranscriptionDeleteResponse> Delete(
        string recordingTranscriptionID,
        RecordingTranscriptionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            RecordingTranscriptionID = recordingTranscriptionID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class RecordingTranscriptionServiceWithRawResponse : IRecordingTranscriptionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRecordingTranscriptionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RecordingTranscriptionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RecordingTranscriptionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<RecordingTranscriptionRetrieveResponse>> Retrieve(
        RecordingTranscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RecordingTranscriptionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RecordingTranscriptionID' cannot be null"
            );
        }

        HttpRequest<RecordingTranscriptionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var recordingTranscription = await response.Deserialize<RecordingTranscriptionRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                recordingTranscription.Validate();
            }
            return recordingTranscription;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RecordingTranscriptionRetrieveResponse>> Retrieve(
        string recordingTranscriptionID,
        RecordingTranscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            RecordingTranscriptionID = recordingTranscriptionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RecordingTranscriptionListPage>> List(
        RecordingTranscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RecordingTranscriptionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<RecordingTranscriptionListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new RecordingTranscriptionListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RecordingTranscriptionDeleteResponse>> Delete(
        RecordingTranscriptionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RecordingTranscriptionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RecordingTranscriptionID' cannot be null"
            );
        }

        HttpRequest<RecordingTranscriptionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var recordingTranscription = await response.Deserialize<RecordingTranscriptionDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                recordingTranscription.Validate();
            }
            return recordingTranscription;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RecordingTranscriptionDeleteResponse>> Delete(
        string recordingTranscriptionID,
        RecordingTranscriptionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            RecordingTranscriptionID = recordingTranscriptionID
        }, cancellationToken);
    }
}