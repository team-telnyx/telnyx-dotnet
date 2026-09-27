using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.PortingOrders.AssociatedPhoneNumbers;

namespace Telnyx.Sdk.Services.PortingOrders;

/// <inheritdoc/>
public sealed class AssociatedPhoneNumberService : IAssociatedPhoneNumberService
{
    readonly Lazy<IAssociatedPhoneNumberServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAssociatedPhoneNumberServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAssociatedPhoneNumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AssociatedPhoneNumberService(this._client.WithOptions(modifier));
    }

    public AssociatedPhoneNumberService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AssociatedPhoneNumberServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<AssociatedPhoneNumberCreateResponse> Create(
        AssociatedPhoneNumberCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AssociatedPhoneNumberCreateResponse> Create(
        string portingOrderID,
        AssociatedPhoneNumberCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            PortingOrderID = portingOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AssociatedPhoneNumberListPage> List(
        AssociatedPhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AssociatedPhoneNumberListPage> List(
        string portingOrderID,
        AssociatedPhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            PortingOrderID = portingOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AssociatedPhoneNumberDeleteResponse> Delete(
        AssociatedPhoneNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AssociatedPhoneNumberDeleteResponse> Delete(
        string id,
        AssociatedPhoneNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AssociatedPhoneNumberServiceWithRawResponse : IAssociatedPhoneNumberServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAssociatedPhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AssociatedPhoneNumberServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AssociatedPhoneNumberServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<AssociatedPhoneNumberCreateResponse>> Create(
        AssociatedPhoneNumberCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PortingOrderID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PortingOrderID' cannot be null"
            );
        }

        HttpRequest<AssociatedPhoneNumberCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var associatedPhoneNumber = await response.Deserialize<AssociatedPhoneNumberCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                associatedPhoneNumber.Validate();
            }
            return associatedPhoneNumber;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AssociatedPhoneNumberCreateResponse>> Create(
        string portingOrderID,
        AssociatedPhoneNumberCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            PortingOrderID = portingOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AssociatedPhoneNumberListPage>> List(
        AssociatedPhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PortingOrderID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PortingOrderID' cannot be null"
            );
        }

        HttpRequest<AssociatedPhoneNumberListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<AssociatedPhoneNumberListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new AssociatedPhoneNumberListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AssociatedPhoneNumberListPage>> List(
        string portingOrderID,
        AssociatedPhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            PortingOrderID = portingOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AssociatedPhoneNumberDeleteResponse>> Delete(
        AssociatedPhoneNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<AssociatedPhoneNumberDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var associatedPhoneNumber = await response.Deserialize<AssociatedPhoneNumberDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                associatedPhoneNumber.Validate();
            }
            return associatedPhoneNumber;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AssociatedPhoneNumberDeleteResponse>> Delete(
        string id,
        AssociatedPhoneNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}