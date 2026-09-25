using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Texml.Accounts.Conferences.Participants;

namespace Telnyx.Sdk.Services.Texml.Accounts.Conferences;

/// <inheritdoc/>
public sealed class ParticipantService : IParticipantService
{
    readonly Lazy<IParticipantServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IParticipantServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IParticipantService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ParticipantService(this._client.WithOptions(modifier)); }

    public ParticipantService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ParticipantServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ParticipantResource> Retrieve(
        ParticipantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ParticipantResource> Retrieve(
        string callSidOrParticipantLabel,
        ParticipantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            CallSidOrParticipantLabel = callSidOrParticipantLabel
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ParticipantResource> Update(
        ParticipantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ParticipantResource> Update(
        string callSidOrParticipantLabel,
        ParticipantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            CallSidOrParticipantLabel = callSidOrParticipantLabel
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        ParticipantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string callSidOrParticipantLabel,
        ParticipantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with{
            CallSidOrParticipantLabel = callSidOrParticipantLabel
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ParticipantParticipantsResponse> Participants(
        ParticipantParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Participants(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ParticipantParticipantsResponse> Participants(
        string conferenceSid,
        ParticipantParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Participants(parameters with{
            ConferenceSid = conferenceSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ParticipantRetrieveParticipantsResponse> RetrieveParticipants(
        ParticipantRetrieveParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveParticipants(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ParticipantRetrieveParticipantsResponse> RetrieveParticipants(
        string conferenceSid,
        ParticipantRetrieveParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveParticipants(parameters with{
            ConferenceSid = conferenceSid
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ParticipantServiceWithRawResponse : IParticipantServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IParticipantServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ParticipantServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ParticipantServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ParticipantResource>> Retrieve(
        ParticipantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallSidOrParticipantLabel == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallSidOrParticipantLabel' cannot be null"
            );
        }

        HttpRequest<ParticipantRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var participantResource = await response.Deserialize<ParticipantResource>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                participantResource.Validate();
            }
            return participantResource;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ParticipantResource>> Retrieve(
        string callSidOrParticipantLabel,
        ParticipantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            CallSidOrParticipantLabel = callSidOrParticipantLabel
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ParticipantResource>> Update(
        ParticipantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallSidOrParticipantLabel == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallSidOrParticipantLabel' cannot be null"
            );
        }

        HttpRequest<ParticipantUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var participantResource = await response.Deserialize<ParticipantResource>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                participantResource.Validate();
            }
            return participantResource;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ParticipantResource>> Update(
        string callSidOrParticipantLabel,
        ParticipantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            CallSidOrParticipantLabel = callSidOrParticipantLabel
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        ParticipantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallSidOrParticipantLabel == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallSidOrParticipantLabel' cannot be null"
            );
        }

        HttpRequest<ParticipantDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string callSidOrParticipantLabel,
        ParticipantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            CallSidOrParticipantLabel = callSidOrParticipantLabel
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ParticipantParticipantsResponse>> Participants(
        ParticipantParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConferenceSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConferenceSid' cannot be null"
            );
        }

        HttpRequest<ParticipantParticipantsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ParticipantParticipantsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ParticipantParticipantsResponse>> Participants(
        string conferenceSid,
        ParticipantParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Participants(parameters with{
            ConferenceSid = conferenceSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ParticipantRetrieveParticipantsResponse>> RetrieveParticipants(
        ParticipantRetrieveParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConferenceSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConferenceSid' cannot be null"
            );
        }

        HttpRequest<ParticipantRetrieveParticipantsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ParticipantRetrieveParticipantsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ParticipantRetrieveParticipantsResponse>> RetrieveParticipants(
        string conferenceSid,
        ParticipantRetrieveParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveParticipants(parameters with{
            ConferenceSid = conferenceSid
        }, cancellationToken);
    }
}