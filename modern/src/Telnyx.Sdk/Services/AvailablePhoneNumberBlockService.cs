using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AvailablePhoneNumberBlocks;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class AvailablePhoneNumberBlockService : IAvailablePhoneNumberBlockService
{
    readonly Lazy<IAvailablePhoneNumberBlockServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAvailablePhoneNumberBlockServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAvailablePhoneNumberBlockService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AvailablePhoneNumberBlockService(this._client.WithOptions(modifier));
    }

    public AvailablePhoneNumberBlockService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AvailablePhoneNumberBlockServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<AvailablePhoneNumberBlockListResponse> List(
        AvailablePhoneNumberBlockListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AvailablePhoneNumberBlockServiceWithRawResponse : IAvailablePhoneNumberBlockServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAvailablePhoneNumberBlockServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AvailablePhoneNumberBlockServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AvailablePhoneNumberBlockServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<AvailablePhoneNumberBlockListResponse>> List(
        AvailablePhoneNumberBlockListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AvailablePhoneNumberBlockListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var availablePhoneNumberBlocks = await response.Deserialize<AvailablePhoneNumberBlockListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                availablePhoneNumberBlocks.Validate();
            }
            return availablePhoneNumberBlocks;
        });
    }
}