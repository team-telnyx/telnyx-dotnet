using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Texml.Accounts.Calls.RecordingsJson;
using Telnyx.Sdk.Models.Texml.Accounts.Conferences;
using Telnyx.Sdk.Services.Texml.Accounts.Conferences;

namespace Telnyx.Sdk.Services.Texml.Accounts;

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
        _participants =new(() => new ParticipantService(client)) ;
    }

    readonly Lazy<IParticipantService> _participants;
    public IParticipantService Participants {
        get { return _participants.Value; }
    }

    /// <inheritdoc/>
    public async Task<ConferenceResource> Retrieve(
        ConferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ConferenceResource> Retrieve(
        string conferenceSid,
        ConferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            ConferenceSid = conferenceSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ConferenceResource> Update(
        ConferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ConferenceResource> Update(
        string conferenceSid,
        ConferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ConferenceSid = conferenceSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ConferenceRetrieveConferencesResponse> RetrieveConferences(
        ConferenceRetrieveConferencesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveConferences(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ConferenceRetrieveConferencesResponse> RetrieveConferences(
        string accountSid,
        ConferenceRetrieveConferencesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveConferences(parameters with{
            AccountSid = accountSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ConferenceRetrieveRecordingsResponse> RetrieveRecordings(
        ConferenceRetrieveRecordingsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveRecordings(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ConferenceRetrieveRecordingsResponse> RetrieveRecordings(
        string conferenceSid,
        ConferenceRetrieveRecordingsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveRecordings(parameters with{
            ConferenceSid = conferenceSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TexmlGetCallRecordingsResponseBody> RetrieveRecordingsJson(
        ConferenceRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveRecordingsJson(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TexmlGetCallRecordingsResponseBody> RetrieveRecordingsJson(
        string conferenceSid,
        ConferenceRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveRecordingsJson(parameters with{
            ConferenceSid = conferenceSid
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

        _participants =new(
            () => new ParticipantServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<IParticipantServiceWithRawResponse> _participants;
    public IParticipantServiceWithRawResponse Participants {
        get { return _participants.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConferenceResource>> Retrieve(
        ConferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConferenceSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConferenceSid' cannot be null"
            );
        }

        HttpRequest<ConferenceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var conferenceResource = await response.Deserialize<ConferenceResource>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                conferenceResource.Validate();
            }
            return conferenceResource;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ConferenceResource>> Retrieve(
        string conferenceSid,
        ConferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            ConferenceSid = conferenceSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConferenceResource>> Update(
        ConferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConferenceSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConferenceSid' cannot be null"
            );
        }

        HttpRequest<ConferenceUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var conferenceResource = await response.Deserialize<ConferenceResource>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                conferenceResource.Validate();
            }
            return conferenceResource;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ConferenceResource>> Update(
        string conferenceSid,
        ConferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ConferenceSid = conferenceSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConferenceRetrieveConferencesResponse>> RetrieveConferences(
        ConferenceRetrieveConferencesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AccountSid' cannot be null"
            );
        }

        HttpRequest<ConferenceRetrieveConferencesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ConferenceRetrieveConferencesResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ConferenceRetrieveConferencesResponse>> RetrieveConferences(
        string accountSid,
        ConferenceRetrieveConferencesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveConferences(parameters with{
            AccountSid = accountSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConferenceRetrieveRecordingsResponse>> RetrieveRecordings(
        ConferenceRetrieveRecordingsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConferenceSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConferenceSid' cannot be null"
            );
        }

        HttpRequest<ConferenceRetrieveRecordingsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ConferenceRetrieveRecordingsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ConferenceRetrieveRecordingsResponse>> RetrieveRecordings(
        string conferenceSid,
        ConferenceRetrieveRecordingsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveRecordings(parameters with{
            ConferenceSid = conferenceSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TexmlGetCallRecordingsResponseBody>> RetrieveRecordingsJson(
        ConferenceRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConferenceSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConferenceSid' cannot be null"
            );
        }

        HttpRequest<ConferenceRetrieveRecordingsJsonParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var texmlGetCallRecordingsResponseBody = await response.Deserialize<TexmlGetCallRecordingsResponseBody>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                texmlGetCallRecordingsResponseBody.Validate();
            }
            return texmlGetCallRecordingsResponseBody;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TexmlGetCallRecordingsResponseBody>> RetrieveRecordingsJson(
        string conferenceSid,
        ConferenceRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveRecordingsJson(parameters with{
            ConferenceSid = conferenceSid
        }, cancellationToken);
    }
}