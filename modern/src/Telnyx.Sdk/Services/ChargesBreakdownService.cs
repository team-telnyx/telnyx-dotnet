using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.ChargesBreakdown;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class ChargesBreakdownService : IChargesBreakdownService
{
    readonly Lazy<IChargesBreakdownServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IChargesBreakdownServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IChargesBreakdownService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ChargesBreakdownService(this._client.WithOptions(modifier)); }

    public ChargesBreakdownService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ChargesBreakdownServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ChargesBreakdownRetrieveResponse> Retrieve(
        ChargesBreakdownRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ChargesBreakdownServiceWithRawResponse : IChargesBreakdownServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IChargesBreakdownServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ChargesBreakdownServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ChargesBreakdownServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChargesBreakdownRetrieveResponse>> Retrieve(
        ChargesBreakdownRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ChargesBreakdownRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var chargesBreakdown = await response.Deserialize<ChargesBreakdownRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                chargesBreakdown.Validate();
            }
            return chargesBreakdown;
        });
    }
}