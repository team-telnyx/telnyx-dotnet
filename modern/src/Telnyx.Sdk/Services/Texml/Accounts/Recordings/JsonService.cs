using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Texml.Accounts;
using Telnyx.Sdk.Models.Texml.Accounts.Recordings.Json;

namespace Telnyx.Sdk.Services.Texml.Accounts.Recordings;

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
    public Task DeleteRecordingSidJson(
        JsonDeleteRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.DeleteRecordingSidJson(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task DeleteRecordingSidJson(
        string recordingSid,
        JsonDeleteRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.DeleteRecordingSidJson(parameters with{
            RecordingSid = recordingSid
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TexmlGetCallRecordingResponseBody> RetrieveRecordingSidJson(
        JsonRetrieveRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveRecordingSidJson(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TexmlGetCallRecordingResponseBody> RetrieveRecordingSidJson(
        string recordingSid,
        JsonRetrieveRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveRecordingSidJson(parameters with{
            RecordingSid = recordingSid
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
    public Task<HttpResponse> DeleteRecordingSidJson(
        JsonDeleteRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RecordingSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RecordingSid' cannot be null"
            );
        }

        HttpRequest<JsonDeleteRecordingSidJsonParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> DeleteRecordingSidJson(
        string recordingSid,
        JsonDeleteRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteRecordingSidJson(parameters with{
            RecordingSid = recordingSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TexmlGetCallRecordingResponseBody>> RetrieveRecordingSidJson(
        JsonRetrieveRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RecordingSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RecordingSid' cannot be null"
            );
        }

        HttpRequest<JsonRetrieveRecordingSidJsonParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var texmlGetCallRecordingResponseBody = await response.Deserialize<TexmlGetCallRecordingResponseBody>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                texmlGetCallRecordingResponseBody.Validate();
            }
            return texmlGetCallRecordingResponseBody;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TexmlGetCallRecordingResponseBody>> RetrieveRecordingSidJson(
        string recordingSid,
        JsonRetrieveRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveRecordingSidJson(parameters with{
            RecordingSid = recordingSid
        }, cancellationToken);
    }
}