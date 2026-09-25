using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.NumbersFeatures;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class NumbersFeatureService : INumbersFeatureService
{
    readonly Lazy<INumbersFeatureServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INumbersFeatureServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public INumbersFeatureService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new NumbersFeatureService(this._client.WithOptions(modifier)); }

    public NumbersFeatureService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new NumbersFeatureServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<NumbersFeatureCreateResponse> Create(
        NumbersFeatureCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class NumbersFeatureServiceWithRawResponse : INumbersFeatureServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public INumbersFeatureServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NumbersFeatureServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NumbersFeatureServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumbersFeatureCreateResponse>> Create(
        NumbersFeatureCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<NumbersFeatureCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var numbersFeature = await response.Deserialize<NumbersFeatureCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                numbersFeature.Validate();
            }
            return numbersFeature;
        });
    }
}