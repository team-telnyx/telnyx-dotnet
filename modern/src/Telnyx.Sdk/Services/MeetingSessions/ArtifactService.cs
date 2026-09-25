using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.MeetingSessions.Artifacts;

namespace Telnyx.Sdk.Services.MeetingSessions;

/// <inheritdoc/>
public sealed class ArtifactService : IArtifactService
{
    readonly Lazy<IArtifactServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IArtifactServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IArtifactService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ArtifactService(this._client.WithOptions(modifier)); }

    public ArtifactService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ArtifactServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<MeetingSessionArtifactResponse> Create(
        ArtifactCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MeetingSessionArtifactResponse> Create(
        string id,
        ArtifactCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MeetingSessionArtifactResponse> Retrieve(
        ArtifactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MeetingSessionArtifactResponse> Retrieve(
        string artifactID,
        ArtifactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            ArtifactID = artifactID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ArtifactListResponse> List(
        ArtifactListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ArtifactListResponse> List(
        string id,
        ArtifactListParams? parameters = null,
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
public sealed class ArtifactServiceWithRawResponse : IArtifactServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IArtifactServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ArtifactServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ArtifactServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<MeetingSessionArtifactResponse>> Create(
        ArtifactCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ArtifactCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var meetingSessionArtifactResponse = await response.Deserialize<MeetingSessionArtifactResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                meetingSessionArtifactResponse.Validate();
            }
            return meetingSessionArtifactResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MeetingSessionArtifactResponse>> Create(
        string id,
        ArtifactCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MeetingSessionArtifactResponse>> Retrieve(
        ArtifactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ArtifactID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ArtifactID' cannot be null"
            );
        }

        HttpRequest<ArtifactRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var meetingSessionArtifactResponse = await response.Deserialize<MeetingSessionArtifactResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                meetingSessionArtifactResponse.Validate();
            }
            return meetingSessionArtifactResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MeetingSessionArtifactResponse>> Retrieve(
        string artifactID,
        ArtifactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            ArtifactID = artifactID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ArtifactListResponse>> List(
        ArtifactListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ArtifactListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var artifacts = await response.Deserialize<ArtifactListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                artifacts.Validate();
            }
            return artifacts;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ArtifactListResponse>> List(
        string id,
        ArtifactListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }
}