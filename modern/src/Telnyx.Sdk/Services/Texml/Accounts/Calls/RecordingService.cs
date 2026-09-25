using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Texml.Accounts.Calls.Recordings;
using Telnyx.Sdk.Models.Texml.Accounts.Calls.RecordingsJson;

namespace Telnyx.Sdk.Services.Texml.Accounts.Calls;

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
    }

    /// <inheritdoc/>
    public async Task<TexmlCreateCallRecordingResponseBody> RecordingSidJson(
        RecordingRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RecordingSidJson(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TexmlCreateCallRecordingResponseBody> RecordingSidJson(
        string recordingSid,
        RecordingRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RecordingSidJson(parameters with{
            RecordingSid = recordingSid
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
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<TexmlCreateCallRecordingResponseBody>> RecordingSidJson(
        RecordingRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RecordingSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RecordingSid' cannot be null"
            );
        }

        HttpRequest<RecordingRecordingSidJsonParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var texmlCreateCallRecordingResponseBody = await response.Deserialize<TexmlCreateCallRecordingResponseBody>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                texmlCreateCallRecordingResponseBody.Validate();
            }
            return texmlCreateCallRecordingResponseBody;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TexmlCreateCallRecordingResponseBody>> RecordingSidJson(
        string recordingSid,
        RecordingRecordingSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RecordingSidJson(parameters with{
            RecordingSid = recordingSid
        }, cancellationToken);
    }
}