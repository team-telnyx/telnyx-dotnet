using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Messages.Rcs;

namespace Telnyx.Sdk.Services.Messages;

/// <inheritdoc/>
public sealed class RcService : IRcService
{
    readonly Lazy<IRcServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRcServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRcService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new RcService(this._client.WithOptions(modifier)); }

    public RcService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RcServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<RcGenerateDeeplinkResponse> GenerateDeeplink(
        RcGenerateDeeplinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GenerateDeeplink(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RcGenerateDeeplinkResponse> GenerateDeeplink(
        string agentID,
        RcGenerateDeeplinkParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GenerateDeeplink(parameters with{
            AgentID = agentID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RcSendResponse> Send(
        RcSendParams parameters, CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Send(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RcServiceWithRawResponse : IRcServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRcServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new RcServiceWithRawResponse(this._client.WithOptions(modifier)); }

    public RcServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<RcGenerateDeeplinkResponse>> GenerateDeeplink(
        RcGenerateDeeplinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AgentID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AgentID' cannot be null"
            );
        }

        HttpRequest<RcGenerateDeeplinkParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<RcGenerateDeeplinkResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RcGenerateDeeplinkResponse>> GenerateDeeplink(
        string agentID,
        RcGenerateDeeplinkParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GenerateDeeplink(parameters with{
            AgentID = agentID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RcSendResponse>> Send(
        RcSendParams parameters, CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RcSendParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<RcSendResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}