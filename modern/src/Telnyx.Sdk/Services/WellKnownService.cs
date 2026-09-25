using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.WellKnown;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class WellKnownService : IWellKnownService
{
    readonly Lazy<IWellKnownServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWellKnownServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IWellKnownService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new WellKnownService(this._client.WithOptions(modifier)); }

    public WellKnownService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new WellKnownServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<WellKnownRetrieveAuthorizationServerMetadataResponse> RetrieveAuthorizationServerMetadata(
        WellKnownRetrieveAuthorizationServerMetadataParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveAuthorizationServerMetadata(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WellKnownRetrieveProtectedResourceMetadataResponse> RetrieveProtectedResourceMetadata(
        WellKnownRetrieveProtectedResourceMetadataParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveProtectedResourceMetadata(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class WellKnownServiceWithRawResponse : IWellKnownServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWellKnownServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WellKnownServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WellKnownServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<WellKnownRetrieveAuthorizationServerMetadataResponse>> RetrieveAuthorizationServerMetadata(
        WellKnownRetrieveAuthorizationServerMetadataParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WellKnownRetrieveAuthorizationServerMetadataParams> request = new(

        )
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<WellKnownRetrieveAuthorizationServerMetadataResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WellKnownRetrieveProtectedResourceMetadataResponse>> RetrieveProtectedResourceMetadata(
        WellKnownRetrieveProtectedResourceMetadataParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WellKnownRetrieveProtectedResourceMetadataParams> request = new(

        )
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<WellKnownRetrieveProtectedResourceMetadataResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}