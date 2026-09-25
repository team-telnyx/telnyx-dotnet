using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.PortingOrders.ActionRequirements;

namespace Telnyx.Sdk.Services.PortingOrders;

/// <inheritdoc/>
public sealed class ActionRequirementService : IActionRequirementService
{
    readonly Lazy<IActionRequirementServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IActionRequirementServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IActionRequirementService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ActionRequirementService(this._client.WithOptions(modifier)); }

    public ActionRequirementService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ActionRequirementServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ActionRequirementListPage> List(
        ActionRequirementListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionRequirementListPage> List(
        string portingOrderID,
        ActionRequirementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            PortingOrderID = portingOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActionRequirementInitiateResponse> Initiate(
        ActionRequirementInitiateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Initiate(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActionRequirementInitiateResponse> Initiate(
        string id,
        ActionRequirementInitiateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Initiate(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ActionRequirementServiceWithRawResponse : IActionRequirementServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IActionRequirementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ActionRequirementServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ActionRequirementServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionRequirementListPage>> List(
        ActionRequirementListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PortingOrderID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PortingOrderID' cannot be null"
            );
        }

        HttpRequest<ActionRequirementListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<ActionRequirementListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ActionRequirementListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionRequirementListPage>> List(
        string portingOrderID,
        ActionRequirementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            PortingOrderID = portingOrderID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActionRequirementInitiateResponse>> Initiate(
        ActionRequirementInitiateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ActionRequirementInitiateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ActionRequirementInitiateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActionRequirementInitiateResponse>> Initiate(
        string id,
        ActionRequirementInitiateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Initiate(parameters with{
            ID = id
        }, cancellationToken);
    }
}