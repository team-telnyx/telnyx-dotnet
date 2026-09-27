using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.RoomRecordings;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class RoomRecordingService : IRoomRecordingService
{
    readonly Lazy<IRoomRecordingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRoomRecordingServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRoomRecordingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new RoomRecordingService(this._client.WithOptions(modifier)); }

    public RoomRecordingService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RoomRecordingServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<RoomRecordingRetrieveResponse> Retrieve(
        RoomRecordingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RoomRecordingRetrieveResponse> Retrieve(
        string roomRecordingID,
        RoomRecordingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            RoomRecordingID = roomRecordingID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RoomRecordingListPage> List(
        RoomRecordingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        RoomRecordingDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string roomRecordingID,
        RoomRecordingDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            RoomRecordingID = roomRecordingID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RoomRecordingDeleteBulkResponse> DeleteBulk(
        RoomRecordingDeleteBulkParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.DeleteBulk(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RoomRecordingServiceWithRawResponse : IRoomRecordingServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRoomRecordingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RoomRecordingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RoomRecordingServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<RoomRecordingRetrieveResponse>> Retrieve(
        RoomRecordingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RoomRecordingID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RoomRecordingID' cannot be null"
            );
        }

        HttpRequest<RoomRecordingRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var roomRecording = await response.Deserialize<RoomRecordingRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                roomRecording.Validate();
            }
            return roomRecording;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RoomRecordingRetrieveResponse>> Retrieve(
        string roomRecordingID,
        RoomRecordingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            RoomRecordingID = roomRecordingID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RoomRecordingListPage>> List(
        RoomRecordingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RoomRecordingListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<RoomRecordingListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new RoomRecordingListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        RoomRecordingDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RoomRecordingID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RoomRecordingID' cannot be null"
            );
        }

        HttpRequest<RoomRecordingDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string roomRecordingID,
        RoomRecordingDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            RoomRecordingID = roomRecordingID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RoomRecordingDeleteBulkResponse>> DeleteBulk(
        RoomRecordingDeleteBulkParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RoomRecordingDeleteBulkParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<RoomRecordingDeleteBulkResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}