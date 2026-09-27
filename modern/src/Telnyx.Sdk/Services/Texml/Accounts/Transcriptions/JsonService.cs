using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Texml.Accounts.Transcriptions.Json;

namespace Telnyx.Sdk.Services.Texml.Accounts.Transcriptions;

/// <inheritdoc/>
public sealed class JsonService : IJsonService
{
    readonly Lazy<IJsonServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IJsonServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IJsonService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new JsonService(this._client.WithOptions(modifier)); }

    public JsonService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new JsonServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public Task DeleteRecordingTranscriptionSidJson(
        JsonDeleteRecordingTranscriptionSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.DeleteRecordingTranscriptionSidJson(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task DeleteRecordingTranscriptionSidJson(
        string recordingTranscriptionSid,
        JsonDeleteRecordingTranscriptionSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.DeleteRecordingTranscriptionSidJson(parameters with{
            RecordingTranscriptionSid = recordingTranscriptionSid
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TexmlRecordingTranscription> RetrieveRecordingTranscriptionSidJson(
        JsonRetrieveRecordingTranscriptionSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveRecordingTranscriptionSidJson(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TexmlRecordingTranscription> RetrieveRecordingTranscriptionSidJson(
        string recordingTranscriptionSid,
        JsonRetrieveRecordingTranscriptionSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveRecordingTranscriptionSidJson(parameters with{
            RecordingTranscriptionSid = recordingTranscriptionSid
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class JsonServiceWithRawResponse : IJsonServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IJsonServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new JsonServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public JsonServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteRecordingTranscriptionSidJson(
        JsonDeleteRecordingTranscriptionSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RecordingTranscriptionSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RecordingTranscriptionSid' cannot be null"
            );
        }

        HttpRequest<JsonDeleteRecordingTranscriptionSidJsonParams> request = new(

        )
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> DeleteRecordingTranscriptionSidJson(
        string recordingTranscriptionSid,
        JsonDeleteRecordingTranscriptionSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteRecordingTranscriptionSidJson(parameters with{
            RecordingTranscriptionSid = recordingTranscriptionSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TexmlRecordingTranscription>> RetrieveRecordingTranscriptionSidJson(
        JsonRetrieveRecordingTranscriptionSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RecordingTranscriptionSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RecordingTranscriptionSid' cannot be null"
            );
        }

        HttpRequest<JsonRetrieveRecordingTranscriptionSidJsonParams> request = new(

        )
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var texmlRecordingTranscription = await response.Deserialize<TexmlRecordingTranscription>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                texmlRecordingTranscription.Validate();
            }
            return texmlRecordingTranscription;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TexmlRecordingTranscription>> RetrieveRecordingTranscriptionSidJson(
        string recordingTranscriptionSid,
        JsonRetrieveRecordingTranscriptionSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveRecordingTranscriptionSidJson(parameters with{
            RecordingTranscriptionSid = recordingTranscriptionSid
        }, cancellationToken);
    }
}