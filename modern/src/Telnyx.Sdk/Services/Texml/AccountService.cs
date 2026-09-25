using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Texml.Accounts;
using Telnyx.Sdk.Models.Texml.Accounts.Calls.RecordingsJson;
using Accounts = Telnyx.Sdk.Services.Texml.Accounts;

namespace Telnyx.Sdk.Services.Texml;

/// <inheritdoc/>
public sealed class AccountService : IAccountService
{
    readonly Lazy<IAccountServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccountServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAccountService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new AccountService(this._client.WithOptions(modifier)); }

    public AccountService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AccountServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _calls =new(() => new Accounts::CallService(client)) ;
        _conferences =new(() => new Accounts::ConferenceService(client)) ;
        _recordings =new(() => new Accounts::RecordingService(client)) ;
        _transcriptions =new(() => new Accounts::TranscriptionService(client)) ;
        _queues =new(() => new Accounts::QueueService(client)) ;
    }

    readonly Lazy<Accounts::ICallService> _calls;
    public Accounts::ICallService Calls { get { return _calls.Value; } }

    readonly Lazy<Accounts::IConferenceService> _conferences;
    public Accounts::IConferenceService Conferences {
        get { return _conferences.Value; }
    }

    readonly Lazy<Accounts::IRecordingService> _recordings;
    public Accounts::IRecordingService Recordings {
        get { return _recordings.Value; }
    }

    readonly Lazy<Accounts::ITranscriptionService> _transcriptions;
    public Accounts::ITranscriptionService Transcriptions {
        get { return _transcriptions.Value; }
    }

    readonly Lazy<Accounts::IQueueService> _queues;
    public Accounts::IQueueService Queues { get { return _queues.Value; } }

    /// <inheritdoc/>
    public async Task<TexmlGetCallRecordingsResponseBody> RetrieveRecordingsJson(
        AccountRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveRecordingsJson(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TexmlGetCallRecordingsResponseBody> RetrieveRecordingsJson(
        string accountSid,
        AccountRetrieveRecordingsJsonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveRecordingsJson(parameters with{
            AccountSid = accountSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AccountRetrieveTranscriptionsJsonResponse> RetrieveTranscriptionsJson(
        AccountRetrieveTranscriptionsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveTranscriptionsJson(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AccountRetrieveTranscriptionsJsonResponse> RetrieveTranscriptionsJson(
        string accountSid,
        AccountRetrieveTranscriptionsJsonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveTranscriptionsJson(parameters with{
            AccountSid = accountSid
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AccountServiceWithRawResponse : IAccountServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccountServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AccountServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AccountServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _calls =new(() => new Accounts::CallServiceWithRawResponse(client)) ;
        _conferences =new(
            () => new Accounts::ConferenceServiceWithRawResponse(client)
        ) ;
        _recordings =new(
            () => new Accounts::RecordingServiceWithRawResponse(client)
        ) ;
        _transcriptions =new(
            () => new Accounts::TranscriptionServiceWithRawResponse(client)
        ) ;
        _queues =new(() => new Accounts::QueueServiceWithRawResponse(client)) ;
    }

    readonly Lazy<Accounts::ICallServiceWithRawResponse> _calls;
    public Accounts::ICallServiceWithRawResponse Calls {
        get { return _calls.Value; }
    }

    readonly Lazy<Accounts::IConferenceServiceWithRawResponse> _conferences;
    public Accounts::IConferenceServiceWithRawResponse Conferences {
        get { return _conferences.Value; }
    }

    readonly Lazy<Accounts::IRecordingServiceWithRawResponse> _recordings;
    public Accounts::IRecordingServiceWithRawResponse Recordings {
        get { return _recordings.Value; }
    }

    readonly Lazy<Accounts::ITranscriptionServiceWithRawResponse> _transcriptions;
    public Accounts::ITranscriptionServiceWithRawResponse Transcriptions {
        get { return _transcriptions.Value; }
    }

    readonly Lazy<Accounts::IQueueServiceWithRawResponse> _queues;
    public Accounts::IQueueServiceWithRawResponse Queues {
        get { return _queues.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TexmlGetCallRecordingsResponseBody>> RetrieveRecordingsJson(
        AccountRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AccountSid' cannot be null"
            );
        }

        HttpRequest<AccountRetrieveRecordingsJsonParams> request = new()
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
        string accountSid,
        AccountRetrieveRecordingsJsonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveRecordingsJson(parameters with{
            AccountSid = accountSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountRetrieveTranscriptionsJsonResponse>> RetrieveTranscriptionsJson(
        AccountRetrieveTranscriptionsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AccountSid' cannot be null"
            );
        }

        HttpRequest<AccountRetrieveTranscriptionsJsonParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<AccountRetrieveTranscriptionsJsonResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AccountRetrieveTranscriptionsJsonResponse>> RetrieveTranscriptionsJson(
        string accountSid,
        AccountRetrieveTranscriptionsJsonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveTranscriptionsJson(parameters with{
            AccountSid = accountSid
        }, cancellationToken);
    }
}