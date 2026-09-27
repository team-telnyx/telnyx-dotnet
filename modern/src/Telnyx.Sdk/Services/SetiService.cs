using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Seti;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class SetiService : ISetiService
{
    readonly Lazy<ISetiServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISetiServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISetiService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new SetiService(this._client.WithOptions(modifier)); }

    public SetiService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SetiServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<SetiRetrieveBlackBoxTestResultsResponse> RetrieveBlackBoxTestResults(
        SetiRetrieveBlackBoxTestResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveBlackBoxTestResults(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SetiServiceWithRawResponse : ISetiServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISetiServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SetiServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SetiServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<SetiRetrieveBlackBoxTestResultsResponse>> RetrieveBlackBoxTestResults(
        SetiRetrieveBlackBoxTestResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SetiRetrieveBlackBoxTestResultsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<SetiRetrieveBlackBoxTestResultsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}