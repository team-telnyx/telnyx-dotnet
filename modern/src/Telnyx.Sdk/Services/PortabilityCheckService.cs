using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PortabilityChecks;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class PortabilityCheckService : IPortabilityCheckService
{
    readonly Lazy<IPortabilityCheckServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPortabilityCheckServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPortabilityCheckService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new PortabilityCheckService(this._client.WithOptions(modifier)); }

    public PortabilityCheckService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PortabilityCheckServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<PortabilityCheckRunResponse> Run(
        PortabilityCheckRunParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Run(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PortabilityCheckServiceWithRawResponse : IPortabilityCheckServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPortabilityCheckServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PortabilityCheckServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PortabilityCheckServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<PortabilityCheckRunResponse>> Run(
        PortabilityCheckRunParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PortabilityCheckRunParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<PortabilityCheckRunResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}