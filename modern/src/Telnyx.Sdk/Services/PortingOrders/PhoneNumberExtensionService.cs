using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.PortingOrders.PhoneNumberExtensions;

namespace Telnyx.Sdk.Services.PortingOrders;

/// <inheritdoc/>
public sealed class PhoneNumberExtensionService : IPhoneNumberExtensionService
{
    readonly Lazy<IPhoneNumberExtensionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPhoneNumberExtensionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPhoneNumberExtensionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhoneNumberExtensionService(this._client.WithOptions(modifier));
    }

    public PhoneNumberExtensionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PhoneNumberExtensionServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberExtensionCreateResponse> Create(
        PhoneNumberExtensionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberExtensionCreateResponse> Create(
        string portingOrderID,
        PhoneNumberExtensionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            PortingOrderID = portingOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberExtensionListPage> List(
        PhoneNumberExtensionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberExtensionListPage> List(
        string portingOrderID,
        PhoneNumberExtensionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            PortingOrderID = portingOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberExtensionDeleteResponse> Delete(
        PhoneNumberExtensionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberExtensionDeleteResponse> Delete(
        string id,
        PhoneNumberExtensionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PhoneNumberExtensionServiceWithRawResponse : IPhoneNumberExtensionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPhoneNumberExtensionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhoneNumberExtensionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PhoneNumberExtensionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberExtensionCreateResponse>> Create(
        PhoneNumberExtensionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PortingOrderID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PortingOrderID' cannot be null"
            );
        }

        HttpRequest<PhoneNumberExtensionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var phoneNumberExtension = await response.Deserialize<PhoneNumberExtensionCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                phoneNumberExtension.Validate();
            }
            return phoneNumberExtension;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberExtensionCreateResponse>> Create(
        string portingOrderID,
        PhoneNumberExtensionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            PortingOrderID = portingOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberExtensionListPage>> List(
        PhoneNumberExtensionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PortingOrderID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PortingOrderID' cannot be null"
            );
        }

        HttpRequest<PhoneNumberExtensionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PhoneNumberExtensionListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new PhoneNumberExtensionListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberExtensionListPage>> List(
        string portingOrderID,
        PhoneNumberExtensionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            PortingOrderID = portingOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberExtensionDeleteResponse>> Delete(
        PhoneNumberExtensionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PhoneNumberExtensionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var phoneNumberExtension = await response.Deserialize<PhoneNumberExtensionDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                phoneNumberExtension.Validate();
            }
            return phoneNumberExtension;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberExtensionDeleteResponse>> Delete(
        string id,
        PhoneNumberExtensionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}