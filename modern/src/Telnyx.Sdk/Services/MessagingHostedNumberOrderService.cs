using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.MessagingHostedNumberOrders;
using MessagingHostedNumberOrders = Telnyx.Sdk.Services.MessagingHostedNumberOrders;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class MessagingHostedNumberOrderService : IMessagingHostedNumberOrderService
{
    readonly Lazy<IMessagingHostedNumberOrderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMessagingHostedNumberOrderServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMessagingHostedNumberOrderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MessagingHostedNumberOrderService(this._client.WithOptions(modifier));
    }

    public MessagingHostedNumberOrderService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MessagingHostedNumberOrderServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _actions =new(
            () => new MessagingHostedNumberOrders::ActionService(client)
        ) ;
    }

    readonly Lazy<MessagingHostedNumberOrders::IActionService> _actions;
    public MessagingHostedNumberOrders::IActionService Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<MessagingHostedNumberOrderCreateResponse> Create(
        MessagingHostedNumberOrderCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MessagingHostedNumberOrderRetrieveResponse> Retrieve(
        MessagingHostedNumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessagingHostedNumberOrderRetrieveResponse> Retrieve(
        string id,
        MessagingHostedNumberOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessagingHostedNumberOrderListPage> List(
        MessagingHostedNumberOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MessagingHostedNumberOrderDeleteResponse> Delete(
        MessagingHostedNumberOrderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessagingHostedNumberOrderDeleteResponse> Delete(
        string id,
        MessagingHostedNumberOrderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessagingHostedNumberOrderCheckEligibilityResponse> CheckEligibility(
        MessagingHostedNumberOrderCheckEligibilityParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.CheckEligibility(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MessagingHostedNumberOrderCreateVerificationCodesResponse> CreateVerificationCodes(
        MessagingHostedNumberOrderCreateVerificationCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.CreateVerificationCodes(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessagingHostedNumberOrderCreateVerificationCodesResponse> CreateVerificationCodes(
        string id,
        MessagingHostedNumberOrderCreateVerificationCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateVerificationCodes(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessagingHostedNumberOrderValidateCodesResponse> ValidateCodes(
        MessagingHostedNumberOrderValidateCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ValidateCodes(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessagingHostedNumberOrderValidateCodesResponse> ValidateCodes(
        string id,
        MessagingHostedNumberOrderValidateCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ValidateCodes(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MessagingHostedNumberOrderServiceWithRawResponse : IMessagingHostedNumberOrderServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMessagingHostedNumberOrderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MessagingHostedNumberOrderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MessagingHostedNumberOrderServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _actions =new(
            () => new MessagingHostedNumberOrders::ActionServiceWithRawResponse(
                client
            )
        ) ;
    }

    readonly Lazy<MessagingHostedNumberOrders::IActionServiceWithRawResponse> _actions;
    public MessagingHostedNumberOrders::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingHostedNumberOrderCreateResponse>> Create(
        MessagingHostedNumberOrderCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MessagingHostedNumberOrderCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messagingHostedNumberOrder = await response.Deserialize<MessagingHostedNumberOrderCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messagingHostedNumberOrder.Validate();
            }
            return messagingHostedNumberOrder;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingHostedNumberOrderRetrieveResponse>> Retrieve(
        MessagingHostedNumberOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MessagingHostedNumberOrderRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messagingHostedNumberOrder = await response.Deserialize<MessagingHostedNumberOrderRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messagingHostedNumberOrder.Validate();
            }
            return messagingHostedNumberOrder;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessagingHostedNumberOrderRetrieveResponse>> Retrieve(
        string id,
        MessagingHostedNumberOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingHostedNumberOrderListPage>> List(
        MessagingHostedNumberOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MessagingHostedNumberOrderListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MessagingHostedNumberOrderListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MessagingHostedNumberOrderListPage(this,
            parameters,
            page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingHostedNumberOrderDeleteResponse>> Delete(
        MessagingHostedNumberOrderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MessagingHostedNumberOrderDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messagingHostedNumberOrder = await response.Deserialize<MessagingHostedNumberOrderDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messagingHostedNumberOrder.Validate();
            }
            return messagingHostedNumberOrder;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessagingHostedNumberOrderDeleteResponse>> Delete(
        string id,
        MessagingHostedNumberOrderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingHostedNumberOrderCheckEligibilityResponse>> CheckEligibility(
        MessagingHostedNumberOrderCheckEligibilityParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MessagingHostedNumberOrderCheckEligibilityParams> request = new(

        )
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MessagingHostedNumberOrderCheckEligibilityResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingHostedNumberOrderCreateVerificationCodesResponse>> CreateVerificationCodes(
        MessagingHostedNumberOrderCreateVerificationCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MessagingHostedNumberOrderCreateVerificationCodesParams> request = new(

        )
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MessagingHostedNumberOrderCreateVerificationCodesResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessagingHostedNumberOrderCreateVerificationCodesResponse>> CreateVerificationCodes(
        string id,
        MessagingHostedNumberOrderCreateVerificationCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateVerificationCodes(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingHostedNumberOrderValidateCodesResponse>> ValidateCodes(
        MessagingHostedNumberOrderValidateCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MessagingHostedNumberOrderValidateCodesParams> request = new(

        )
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MessagingHostedNumberOrderValidateCodesResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessagingHostedNumberOrderValidateCodesResponse>> ValidateCodes(
        string id,
        MessagingHostedNumberOrderValidateCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ValidateCodes(parameters with{
            ID = id
        }, cancellationToken);
    }
}