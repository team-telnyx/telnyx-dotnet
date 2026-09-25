using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Texml.Calls;

namespace Telnyx.Sdk.Services.Texml;

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
    }

    /// <inheritdoc/>
    public async Task<CallCreateResponse> Create(
        CallCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CallCreateResponse> Create(
        string connectionID,
        CallCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ConnectionID = connectionID
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
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallCreateResponse>> Create(
        CallCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConnectionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConnectionID' cannot be null"
            );
        }

        HttpRequest<CallCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var call = await response.Deserialize<CallCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                call.Validate();
            }
            return call;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CallCreateResponse>> Create(
        string connectionID,
        CallCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }
}