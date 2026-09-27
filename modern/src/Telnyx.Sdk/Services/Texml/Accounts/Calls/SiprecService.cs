using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Texml.Accounts.Calls.Siprec;

namespace Telnyx.Sdk.Services.Texml.Accounts.Calls;

/// <inheritdoc/>
public sealed class SiprecService : ISiprecService
{
    readonly Lazy<ISiprecServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISiprecServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISiprecService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new SiprecService(this._client.WithOptions(modifier)); }

    public SiprecService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SiprecServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<SiprecSiprecSidJsonResponse> SiprecSidJson(
        SiprecSiprecSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.SiprecSidJson(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SiprecSiprecSidJsonResponse> SiprecSidJson(
        string siprecSid,
        SiprecSiprecSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SiprecSidJson(parameters with{
            SiprecSid = siprecSid
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SiprecServiceWithRawResponse : ISiprecServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISiprecServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SiprecServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SiprecServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<SiprecSiprecSidJsonResponse>> SiprecSidJson(
        SiprecSiprecSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SiprecSid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.SiprecSid' cannot be null"
            );
        }

        HttpRequest<SiprecSiprecSidJsonParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<SiprecSiprecSidJsonResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SiprecSiprecSidJsonResponse>> SiprecSidJson(
        string siprecSid,
        SiprecSiprecSidJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SiprecSidJson(parameters with{
            SiprecSid = siprecSid
        }, cancellationToken);
    }
}