using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Recordings;
using Recordings = Telnyx.Sdk.Services.Recordings;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class RecordingService : IRecordingService
{
    readonly Lazy<IRecordingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRecordingServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRecordingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new RecordingService(this._client.WithOptions(modifier)); }

    public RecordingService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RecordingServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _actions =new(() => new Recordings::ActionService(client)) ;
    }

    readonly Lazy<Recordings::IActionService> _actions;
    public Recordings::IActionService Actions { get { return _actions.Value; } }

    /// <inheritdoc/>
    public async Task<RecordingResponse> Retrieve(
        RecordingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RecordingResponse> Retrieve(
        string recordingID,
        RecordingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            RecordingID = recordingID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RecordingListPage> List(
        RecordingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RecordingResponse> Delete(
        RecordingDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RecordingResponse> Delete(
        string recordingID,
        RecordingDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            RecordingID = recordingID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class RecordingServiceWithRawResponse : IRecordingServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRecordingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RecordingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RecordingServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _actions =new(
            () => new Recordings::ActionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<Recordings::IActionServiceWithRawResponse> _actions;
    public Recordings::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RecordingResponse>> Retrieve(
        RecordingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RecordingID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RecordingID' cannot be null"
            );
        }

        HttpRequest<RecordingRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var recordingResponse = await response.Deserialize<RecordingResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                recordingResponse.Validate();
            }
            return recordingResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RecordingResponse>> Retrieve(
        string recordingID,
        RecordingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            RecordingID = recordingID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RecordingListPage>> List(
        RecordingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RecordingListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<RecordingListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new RecordingListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RecordingResponse>> Delete(
        RecordingDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RecordingID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RecordingID' cannot be null"
            );
        }

        HttpRequest<RecordingDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var recordingResponse = await response.Deserialize<RecordingResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                recordingResponse.Validate();
            }
            return recordingResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RecordingResponse>> Delete(
        string recordingID,
        RecordingDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            RecordingID = recordingID
        }, cancellationToken);
    }
}