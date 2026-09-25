using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Calls;
using Calls = Telnyx.Sdk.Services.Calls;

namespace Telnyx.Sdk.Services;

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
        _actions =new(() => new Calls::ActionService(client)) ;
    }

    readonly Lazy<Calls::IActionService> _actions;
    public Calls::IActionService Actions { get { return _actions.Value; } }

    /// <inheritdoc/>
    public async Task<CallDialResponse> Dial(
        CallDialParams parameters, CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Dial(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CallRetrieveStatusResponse> RetrieveStatus(
        CallRetrieveStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveStatus(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CallRetrieveStatusResponse> RetrieveStatus(
        string callControlID,
        CallRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveStatus(parameters with{
            CallControlID = callControlID
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

        _actions =new(() => new Calls::ActionServiceWithRawResponse(client)) ;
    }

    readonly Lazy<Calls::IActionServiceWithRawResponse> _actions;
    public Calls::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallDialResponse>> Dial(
        CallDialParams parameters, CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CallDialParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<CallDialResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallRetrieveStatusResponse>> RetrieveStatus(
        CallRetrieveStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallControlID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CallControlID' cannot be null"
            );
        }

        HttpRequest<CallRetrieveStatusParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<CallRetrieveStatusResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CallRetrieveStatusResponse>> RetrieveStatus(
        string callControlID,
        CallRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveStatus(parameters with{
            CallControlID = callControlID
        }, cancellationToken);
    }
}