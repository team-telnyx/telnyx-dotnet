using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.MeetingSessions;
using MeetingSessions = Telnyx.Sdk.Services.MeetingSessions;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class MeetingSessionService : IMeetingSessionService
{
    readonly Lazy<IMeetingSessionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMeetingSessionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMeetingSessionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MeetingSessionService(this._client.WithOptions(modifier)); }

    public MeetingSessionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MeetingSessionServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _actions =new(() => new MeetingSessions::ActionService(client)) ;
        _artifacts =new(() => new MeetingSessions::ArtifactService(client)) ;
    }

    readonly Lazy<MeetingSessions::IActionService> _actions;
    public MeetingSessions::IActionService Actions {
        get { return _actions.Value; }
    }

    readonly Lazy<MeetingSessions::IArtifactService> _artifacts;
    public MeetingSessions::IArtifactService Artifacts {
        get { return _artifacts.Value; }
    }

    /// <inheritdoc/>
    public async Task<MeetingSessionResponse> Create(
        MeetingSessionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MeetingSessionResponse> Retrieve(
        MeetingSessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MeetingSessionResponse> Retrieve(
        string id,
        MeetingSessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MeetingSessionResponse> Update(
        MeetingSessionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MeetingSessionResponse> Update(
        string id,
        MeetingSessionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MeetingSessionListResponse> List(
        MeetingSessionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MeetingSessionResponse> Delete(
        MeetingSessionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MeetingSessionResponse> Delete(
        string id,
        MeetingSessionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MeetingSessionDeleteRecordingMediaResponse> DeleteRecordingMedia(
        MeetingSessionDeleteRecordingMediaParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.DeleteRecordingMedia(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MeetingSessionDeleteRecordingMediaResponse> DeleteRecordingMedia(
        string id,
        MeetingSessionDeleteRecordingMediaParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DeleteRecordingMedia(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MeetingSessionRetrieveEventsResponse> RetrieveEvents(
        MeetingSessionRetrieveEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveEvents(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MeetingSessionRetrieveEventsResponse> RetrieveEvents(
        string id,
        MeetingSessionRetrieveEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveEvents(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MeetingSessionRetrieveRecordingsResponse> RetrieveRecordings(
        MeetingSessionRetrieveRecordingsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveRecordings(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MeetingSessionRetrieveRecordingsResponse> RetrieveRecordings(
        string id,
        MeetingSessionRetrieveRecordingsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveRecordings(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MeetingSessionRetrieveTranscriptResponse> RetrieveTranscript(
        MeetingSessionRetrieveTranscriptParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveTranscript(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MeetingSessionRetrieveTranscriptResponse> RetrieveTranscript(
        string id,
        MeetingSessionRetrieveTranscriptParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveTranscript(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MeetingSessionServiceWithRawResponse : IMeetingSessionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMeetingSessionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MeetingSessionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MeetingSessionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _actions =new(
            () => new MeetingSessions::ActionServiceWithRawResponse(client)
        ) ;
        _artifacts =new(
            () => new MeetingSessions::ArtifactServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<MeetingSessions::IActionServiceWithRawResponse> _actions;
    public MeetingSessions::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    readonly Lazy<MeetingSessions::IArtifactServiceWithRawResponse> _artifacts;
    public MeetingSessions::IArtifactServiceWithRawResponse Artifacts {
        get { return _artifacts.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MeetingSessionResponse>> Create(
        MeetingSessionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MeetingSessionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var meetingSessionResponse = await response.Deserialize<MeetingSessionResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                meetingSessionResponse.Validate();
            }
            return meetingSessionResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MeetingSessionResponse>> Retrieve(
        MeetingSessionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MeetingSessionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var meetingSessionResponse = await response.Deserialize<MeetingSessionResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                meetingSessionResponse.Validate();
            }
            return meetingSessionResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MeetingSessionResponse>> Retrieve(
        string id,
        MeetingSessionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MeetingSessionResponse>> Update(
        MeetingSessionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MeetingSessionUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var meetingSessionResponse = await response.Deserialize<MeetingSessionResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                meetingSessionResponse.Validate();
            }
            return meetingSessionResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MeetingSessionResponse>> Update(
        string id,
        MeetingSessionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MeetingSessionListResponse>> List(
        MeetingSessionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MeetingSessionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var meetingSessions = await response.Deserialize<MeetingSessionListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                meetingSessions.Validate();
            }
            return meetingSessions;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MeetingSessionResponse>> Delete(
        MeetingSessionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MeetingSessionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var meetingSessionResponse = await response.Deserialize<MeetingSessionResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                meetingSessionResponse.Validate();
            }
            return meetingSessionResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MeetingSessionResponse>> Delete(
        string id,
        MeetingSessionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MeetingSessionDeleteRecordingMediaResponse>> DeleteRecordingMedia(
        MeetingSessionDeleteRecordingMediaParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MeetingSessionDeleteRecordingMediaParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MeetingSessionDeleteRecordingMediaResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MeetingSessionDeleteRecordingMediaResponse>> DeleteRecordingMedia(
        string id,
        MeetingSessionDeleteRecordingMediaParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DeleteRecordingMedia(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MeetingSessionRetrieveEventsResponse>> RetrieveEvents(
        MeetingSessionRetrieveEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MeetingSessionRetrieveEventsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MeetingSessionRetrieveEventsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MeetingSessionRetrieveEventsResponse>> RetrieveEvents(
        string id,
        MeetingSessionRetrieveEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveEvents(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MeetingSessionRetrieveRecordingsResponse>> RetrieveRecordings(
        MeetingSessionRetrieveRecordingsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MeetingSessionRetrieveRecordingsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MeetingSessionRetrieveRecordingsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MeetingSessionRetrieveRecordingsResponse>> RetrieveRecordings(
        string id,
        MeetingSessionRetrieveRecordingsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveRecordings(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MeetingSessionRetrieveTranscriptResponse>> RetrieveTranscript(
        MeetingSessionRetrieveTranscriptParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MeetingSessionRetrieveTranscriptParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MeetingSessionRetrieveTranscriptResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MeetingSessionRetrieveTranscriptResponse>> RetrieveTranscript(
        string id,
        MeetingSessionRetrieveTranscriptParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveTranscript(parameters with{
            ID = id
        }, cancellationToken);
    }
}