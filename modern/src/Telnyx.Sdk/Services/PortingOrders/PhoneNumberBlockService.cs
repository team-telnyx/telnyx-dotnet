using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.PortingOrders.PhoneNumberBlocks;

namespace Telnyx.Sdk.Services.PortingOrders;

/// <inheritdoc/>
public sealed class PhoneNumberBlockService : IPhoneNumberBlockService
{
    readonly Lazy<IPhoneNumberBlockServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPhoneNumberBlockServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPhoneNumberBlockService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new PhoneNumberBlockService(this._client.WithOptions(modifier)); }

    public PhoneNumberBlockService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PhoneNumberBlockServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberBlockCreateResponse> Create(
        PhoneNumberBlockCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberBlockCreateResponse> Create(
        string portingOrderID,
        PhoneNumberBlockCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            PortingOrderID = portingOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberBlockListPage> List(
        PhoneNumberBlockListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberBlockListPage> List(
        string portingOrderID,
        PhoneNumberBlockListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            PortingOrderID = portingOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberBlockDeleteResponse> Delete(
        PhoneNumberBlockDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberBlockDeleteResponse> Delete(
        string id,
        PhoneNumberBlockDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PhoneNumberBlockServiceWithRawResponse : IPhoneNumberBlockServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPhoneNumberBlockServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhoneNumberBlockServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PhoneNumberBlockServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberBlockCreateResponse>> Create(
        PhoneNumberBlockCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PortingOrderID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PortingOrderID' cannot be null"
            );
        }

        HttpRequest<PhoneNumberBlockCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var phoneNumberBlock = await response.Deserialize<PhoneNumberBlockCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                phoneNumberBlock.Validate();
            }
            return phoneNumberBlock;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberBlockCreateResponse>> Create(
        string portingOrderID,
        PhoneNumberBlockCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            PortingOrderID = portingOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberBlockListPage>> List(
        PhoneNumberBlockListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PortingOrderID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PortingOrderID' cannot be null"
            );
        }

        HttpRequest<PhoneNumberBlockListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PhoneNumberBlockListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new PhoneNumberBlockListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberBlockListPage>> List(
        string portingOrderID,
        PhoneNumberBlockListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            PortingOrderID = portingOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberBlockDeleteResponse>> Delete(
        PhoneNumberBlockDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PhoneNumberBlockDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var phoneNumberBlock = await response.Deserialize<PhoneNumberBlockDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                phoneNumberBlock.Validate();
            }
            return phoneNumberBlock;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberBlockDeleteResponse>> Delete(
        string id,
        PhoneNumberBlockDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}