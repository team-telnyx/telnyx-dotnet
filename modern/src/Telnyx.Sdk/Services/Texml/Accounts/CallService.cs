using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Texml.Accounts.Calls;
using Calls = Telnyx.Sdk.Services.Texml.Accounts.Calls;

namespace Telnyx.Sdk.Services.Texml.Accounts;

/// <inheritdoc/>
public sealed class CallService : ICallService
{
    readonly Lazy<ICallServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICallServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICallService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new CallService(this._client.WithOptions(modifier)); }

    public CallService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CallServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _recordingsJson =new(() => new Calls::RecordingsJsonService(client)) ;
        _recordings =new(() => new Calls::RecordingService(client)) ;
        _siprec =new(() => new Calls::SiprecService(client)) ;
        _streams =new(() => new Calls::StreamService(client)) ;
    }

    readonly Lazy<Calls::IRecordingsJsonService> _recordingsJson;
    public Calls::IRecordingsJsonService RecordingsJson {
        get { return _recordingsJson.Value; }
    }

    readonly Lazy<Calls::IRecordingService> _recordings;
    public Calls::IRecordingService Recordings {
        get { return _recordings.Value; }
    }

    readonly Lazy<Calls::ISiprecService> _siprec;
    public Calls::ISiprecService Siprec { get { return _siprec.Value; } }

    readonly Lazy<Calls::IStreamService> _streams;
    public Calls::IStreamService Streams { get { return _streams.Value; } }

    /// <inheritdoc/>
    public async Task<CallResource> Retrieve(
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CallResource> Retrieve(
        string callSid,
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            CallSid = callSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CallResource> Update(
        CallUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CallResource> Update(
        string callSid,
        CallUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            CallSid = callSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CallCallsResponse> Calls(
        CallCallsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Calls(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CallCallsResponse> Calls(
        string accountSid,
        CallCallsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Calls(parameters with{
            AccountSid = accountSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CallRetrieveCallsResponse> RetrieveCalls(
        CallRetrieveCallsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveCalls(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CallRetrieveCallsResponse> RetrieveCalls(
        string accountSid,
        CallRetrieveCallsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveCalls(parameters with{
            AccountSid = accountSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CallSiprecJsonResponse> SiprecJson(
        CallSiprecJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.SiprecJson(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CallSiprecJsonResponse> SiprecJson(
        string callSid,
        CallSiprecJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SiprecJson(parameters with{
            CallSid = callSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CallStreamsJsonResponse> StreamsJson(
        CallStreamsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.StreamsJson(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CallStreamsJsonResponse> StreamsJson(
        string callSid,
        CallStreamsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.StreamsJson(parameters with{
            CallSid = callSid
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CallServiceWithRawResponse : ICallServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICallServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CallServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CallServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _recordingsJson =new(
            () => new Calls::RecordingsJsonServiceWithRawResponse(client)
        ) ;
        _recordings =new(
            () => new Calls::RecordingServiceWithRawResponse(client)
        ) ;
        _siprec =new(() => new Calls::SiprecServiceWithRawResponse(client)) ;
        _streams =new(() => new Calls::StreamServiceWithRawResponse(client)) ;
    }

    readonly Lazy<Calls::IRecordingsJsonServiceWithRawResponse> _recordingsJson;
    public Calls::IRecordingsJsonServiceWithRawResponse RecordingsJson {
        get { return _recordingsJson.Value; }
    }

    readonly Lazy<Calls::IRecordingServiceWithRawResponse> _recordings;
    public Calls::IRecordingServiceWithRawResponse Recordings {
        get { return _recordings.Value; }
    }

    readonly Lazy<Calls::ISiprecServiceWithRawResponse> _siprec;
    public Calls::ISiprecServiceWithRawResponse Siprec {
        get { return _siprec.Value; }
    }

    readonly Lazy<Calls::IStreamServiceWithRawResponse> _streams;
    public Calls::IStreamServiceWithRawResponse Streams {
        get { return _streams.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallResource>> Retrieve(
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallSid' cannot be null"
            );
        }

        HttpRequest<CallRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var callResource = await response.Deserialize<CallResource>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                callResource.Validate();
            }
            return callResource;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CallResource>> Retrieve(
        string callSid,
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            CallSid = callSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallResource>> Update(
        CallUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallSid' cannot be null"
            );
        }

        HttpRequest<CallUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var callResource = await response.Deserialize<CallResource>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                callResource.Validate();
            }
            return callResource;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CallResource>> Update(
        string callSid,
        CallUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            CallSid = callSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallCallsResponse>> Calls(
        CallCallsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AccountSid' cannot be null"
            );
        }

        HttpRequest<CallCallsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<CallCallsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CallCallsResponse>> Calls(
        string accountSid,
        CallCallsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Calls(parameters with{
            AccountSid = accountSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallRetrieveCallsResponse>> RetrieveCalls(
        CallRetrieveCallsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccountSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AccountSid' cannot be null"
            );
        }

        HttpRequest<CallRetrieveCallsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<CallRetrieveCallsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CallRetrieveCallsResponse>> RetrieveCalls(
        string accountSid,
        CallRetrieveCallsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveCalls(parameters with{
            AccountSid = accountSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallSiprecJsonResponse>> SiprecJson(
        CallSiprecJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallSid' cannot be null"
            );
        }

        HttpRequest<CallSiprecJsonParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<CallSiprecJsonResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CallSiprecJsonResponse>> SiprecJson(
        string callSid,
        CallSiprecJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SiprecJson(parameters with{
            CallSid = callSid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallStreamsJsonResponse>> StreamsJson(
        CallStreamsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallSid' cannot be null"
            );
        }

        HttpRequest<CallStreamsJsonParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<CallStreamsJsonResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CallStreamsJsonResponse>> StreamsJson(
        string callSid,
        CallStreamsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.StreamsJson(parameters with{
            CallSid = callSid
        }, cancellationToken);
    }
}