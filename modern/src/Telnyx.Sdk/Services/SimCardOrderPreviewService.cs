using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.SimCardOrderPreview;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class SimCardOrderPreviewService : ISimCardOrderPreviewService
{
    readonly Lazy<ISimCardOrderPreviewServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISimCardOrderPreviewServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISimCardOrderPreviewService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SimCardOrderPreviewService(this._client.WithOptions(modifier));
    }

    public SimCardOrderPreviewService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SimCardOrderPreviewServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<SimCardOrderPreviewPreviewResponse> Preview(
        SimCardOrderPreviewPreviewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Preview(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SimCardOrderPreviewServiceWithRawResponse : ISimCardOrderPreviewServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISimCardOrderPreviewServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SimCardOrderPreviewServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SimCardOrderPreviewServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardOrderPreviewPreviewResponse>> Preview(
        SimCardOrderPreviewPreviewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SimCardOrderPreviewPreviewParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<SimCardOrderPreviewPreviewResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}