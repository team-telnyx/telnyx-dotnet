using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Conferences;
using Conferences = Telnyx.Sdk.Services.Conferences;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class ConferenceService : IConferenceService
{
    readonly Lazy<IConferenceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IConferenceServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IConferenceService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ConferenceService(this._client.WithOptions(modifier)); }

    public ConferenceService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ConferenceServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _actions =new(() => new Conferences::ActionService(client)) ;
    }

    readonly Lazy<Conferences::IActionService> _actions;
    public Conferences::IActionService Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<ConferenceCreateResponse> Create(
        ConferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ConferenceRetrieveResponse> Retrieve(
        ConferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ConferenceRetrieveResponse> Retrieve(
        string id,
        ConferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ConferenceListPage> List(
        ConferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ConferenceListParticipantsPage> ListParticipants(
        ConferenceListParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListParticipants(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ConferenceListParticipantsPage> ListParticipants(
        string conferenceID,
        ConferenceListParticipantsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListParticipants(parameters with{
            ConferenceID = conferenceID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ConferenceParticipantResource> RetrieveParticipant(
        ConferenceRetrieveParticipantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveParticipant(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ConferenceParticipantResource> RetrieveParticipant(
        string participantID,
        ConferenceRetrieveParticipantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveParticipant(parameters with{
            ParticipantID = participantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ConferenceParticipantResource> UpdateParticipant(
        ConferenceUpdateParticipantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.UpdateParticipant(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ConferenceParticipantResource> UpdateParticipant(
        string participantID,
        ConferenceUpdateParticipantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateParticipant(parameters with{
            ParticipantID = participantID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ConferenceServiceWithRawResponse : IConferenceServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IConferenceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ConferenceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ConferenceServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _actions =new(
            () => new Conferences::ActionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<Conferences::IActionServiceWithRawResponse> _actions;
    public Conferences::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConferenceCreateResponse>> Create(
        ConferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ConferenceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var conference = await response.Deserialize<ConferenceCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                conference.Validate();
            }
            return conference;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConferenceRetrieveResponse>> Retrieve(
        ConferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ConferenceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var conference = await response.Deserialize<ConferenceRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                conference.Validate();
            }
            return conference;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ConferenceRetrieveResponse>> Retrieve(
        string id,
        ConferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConferenceListPage>> List(
        ConferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ConferenceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<ConferenceListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ConferenceListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConferenceListParticipantsPage>> ListParticipants(
        ConferenceListParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConferenceID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConferenceID' cannot be null"
            );
        }

        HttpRequest<ConferenceListParticipantsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<ConferenceListParticipantsPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ConferenceListParticipantsPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ConferenceListParticipantsPage>> ListParticipants(
        string conferenceID,
        ConferenceListParticipantsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListParticipants(parameters with{
            ConferenceID = conferenceID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConferenceParticipantResource>> RetrieveParticipant(
        ConferenceRetrieveParticipantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ParticipantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ParticipantID' cannot be null"
            );
        }

        HttpRequest<ConferenceRetrieveParticipantParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var conferenceParticipantResource = await response.Deserialize<ConferenceParticipantResource>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                conferenceParticipantResource.Validate();
            }
            return conferenceParticipantResource;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ConferenceParticipantResource>> RetrieveParticipant(
        string participantID,
        ConferenceRetrieveParticipantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveParticipant(parameters with{
            ParticipantID = participantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConferenceParticipantResource>> UpdateParticipant(
        ConferenceUpdateParticipantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ParticipantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ParticipantID' cannot be null"
            );
        }

        HttpRequest<ConferenceUpdateParticipantParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var conferenceParticipantResource = await response.Deserialize<ConferenceParticipantResource>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                conferenceParticipantResource.Validate();
            }
            return conferenceParticipantResource;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ConferenceParticipantResource>> UpdateParticipant(
        string participantID,
        ConferenceUpdateParticipantParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateParticipant(parameters with{
            ParticipantID = participantID
        }, cancellationToken);
    }
}