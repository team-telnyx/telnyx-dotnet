using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PortingOrders.PhoneNumberConfigurations;

namespace Telnyx.Sdk.Services.PortingOrders;

/// <inheritdoc/>
public sealed class PhoneNumberConfigurationService : IPhoneNumberConfigurationService
{
    readonly Lazy<IPhoneNumberConfigurationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPhoneNumberConfigurationServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPhoneNumberConfigurationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhoneNumberConfigurationService(this._client.WithOptions(modifier));
    }

    public PhoneNumberConfigurationService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PhoneNumberConfigurationServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberConfigurationCreateResponse> Create(
        PhoneNumberConfigurationCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberConfigurationListPage> List(
        PhoneNumberConfigurationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PhoneNumberConfigurationServiceWithRawResponse : IPhoneNumberConfigurationServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPhoneNumberConfigurationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhoneNumberConfigurationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PhoneNumberConfigurationServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberConfigurationCreateResponse>> Create(
        PhoneNumberConfigurationCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PhoneNumberConfigurationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var phoneNumberConfiguration = await response.Deserialize<PhoneNumberConfigurationCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                phoneNumberConfiguration.Validate();
            }
            return phoneNumberConfiguration;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberConfigurationListPage>> List(
        PhoneNumberConfigurationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PhoneNumberConfigurationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PhoneNumberConfigurationListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new PhoneNumberConfigurationListPage(this, parameters, page);
        });
    }
}