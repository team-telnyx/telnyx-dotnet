using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PortingPhoneNumbers;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class PortingPhoneNumberService : IPortingPhoneNumberService
{
    readonly Lazy<IPortingPhoneNumberServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPortingPhoneNumberServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPortingPhoneNumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PortingPhoneNumberService(this._client.WithOptions(modifier));
    }

    public PortingPhoneNumberService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PortingPhoneNumberServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<PortingPhoneNumberListPage> List(
        PortingPhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PortingPhoneNumberServiceWithRawResponse : IPortingPhoneNumberServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPortingPhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PortingPhoneNumberServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PortingPhoneNumberServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<PortingPhoneNumberListPage>> List(
        PortingPhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PortingPhoneNumberListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PortingPhoneNumberListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new PortingPhoneNumberListPage(this, parameters, page);
        });
    }
}