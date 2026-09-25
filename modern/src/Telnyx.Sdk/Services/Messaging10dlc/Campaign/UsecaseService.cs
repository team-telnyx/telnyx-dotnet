using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messaging10dlc.Campaign.Usecase;

namespace Telnyx.Sdk.Services.Messaging10dlc.Campaign;

/// <inheritdoc/>
public sealed class UsecaseService : IUsecaseService
{
    readonly Lazy<IUsecaseServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUsecaseServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IUsecaseService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new UsecaseService(this._client.WithOptions(modifier)); }

    public UsecaseService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new UsecaseServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<UsecaseGetCostResponse> GetCost(
        UsecaseGetCostParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetCost(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class UsecaseServiceWithRawResponse : IUsecaseServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUsecaseServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new UsecaseServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UsecaseServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<UsecaseGetCostResponse>> GetCost(
        UsecaseGetCostParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UsecaseGetCostParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<UsecaseGetCostResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}