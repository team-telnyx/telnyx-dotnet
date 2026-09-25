using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AvailablePhoneNumbers;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class AvailablePhoneNumberService : IAvailablePhoneNumberService
{
    readonly Lazy<IAvailablePhoneNumberServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAvailablePhoneNumberServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAvailablePhoneNumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AvailablePhoneNumberService(this._client.WithOptions(modifier));
    }

    public AvailablePhoneNumberService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AvailablePhoneNumberServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<AvailablePhoneNumberListResponse> List(
        AvailablePhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AvailablePhoneNumberServiceWithRawResponse : IAvailablePhoneNumberServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAvailablePhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AvailablePhoneNumberServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AvailablePhoneNumberServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<AvailablePhoneNumberListResponse>> List(
        AvailablePhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AvailablePhoneNumberListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var availablePhoneNumbers = await response.Deserialize<AvailablePhoneNumberListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                availablePhoneNumbers.Validate();
            }
            return availablePhoneNumbers;
        });
    }
}