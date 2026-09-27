using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Texml.Accounts.Calls.RecordingsJson;

namespace Telnyx.Sdk.Services.Texml.Accounts.Calls;

/// <inheritdoc/>
public sealed class RecordingsJsonService : IRecordingsJsonService
{
    readonly Lazy<IRecordingsJsonServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRecordingsJsonServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRecordingsJsonService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new RecordingsJsonService(this._client.WithOptions(modifier)); }

    public RecordingsJsonService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RecordingsJsonServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<TexmlCreateCallRecordingResponseBody> RecordingsJson(
        RecordingsJsonRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RecordingsJson(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TexmlCreateCallRecordingResponseBody> RecordingsJson(
        string callSid,
        RecordingsJsonRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RecordingsJson(parameters with{
            CallSid = callSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TexmlGetCallRecordingsResponseBody> RetrieveRecordingsJson(
        RecordingsJsonRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveRecordingsJson(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TexmlGetCallRecordingsResponseBody> RetrieveRecordingsJson(
        string callSid,
        RecordingsJsonRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveRecordingsJson(parameters with{
            CallSid = callSid
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class RecordingsJsonServiceWithRawResponse : IRecordingsJsonServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRecordingsJsonServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RecordingsJsonServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RecordingsJsonServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<TexmlCreateCallRecordingResponseBody>> RecordingsJson(
        RecordingsJsonRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallSid' cannot be null"
            );
        }

        HttpRequest<RecordingsJsonRecordingsJsonParams> request = new()
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
    public Task<HttpResponse<TexmlCreateCallRecordingResponseBody>> RecordingsJson(
        string callSid,
        RecordingsJsonRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RecordingsJson(parameters with{
            CallSid = callSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TexmlGetCallRecordingsResponseBody>> RetrieveRecordingsJson(
        RecordingsJsonRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallSid' cannot be null"
            );
        }

        HttpRequest<RecordingsJsonRetrieveRecordingsJsonParams> request = new()
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
        string callSid,
        RecordingsJsonRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveRecordingsJson(parameters with{
            CallSid = callSid
        }, cancellationToken);
    }
}