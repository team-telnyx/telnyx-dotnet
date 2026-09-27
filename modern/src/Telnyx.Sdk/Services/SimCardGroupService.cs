using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.SimCardGroups;
using SimCardGroups = Telnyx.Sdk.Services.SimCardGroups;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class SimCardGroupService : ISimCardGroupService
{
    readonly Lazy<ISimCardGroupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISimCardGroupServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISimCardGroupService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new SimCardGroupService(this._client.WithOptions(modifier)); }

    public SimCardGroupService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SimCardGroupServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _actions =new(() => new SimCardGroups::ActionService(client)) ;
    }

    readonly Lazy<SimCardGroups::IActionService> _actions;
    public SimCardGroups::IActionService Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<SimCardGroupCreateResponse> Create(
        SimCardGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SimCardGroupRetrieveResponse> Retrieve(
        SimCardGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SimCardGroupRetrieveResponse> Retrieve(
        string id,
        SimCardGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SimCardGroupUpdateResponse> Update(
        SimCardGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SimCardGroupUpdateResponse> Update(
        string id,
        SimCardGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SimCardGroupListPage> List(
        SimCardGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SimCardGroupDeleteResponse> Delete(
        SimCardGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SimCardGroupDeleteResponse> Delete(
        string id,
        SimCardGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SimCardGroupServiceWithRawResponse : ISimCardGroupServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISimCardGroupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SimCardGroupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SimCardGroupServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _actions =new(
            () => new SimCardGroups::ActionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<SimCardGroups::IActionServiceWithRawResponse> _actions;
    public SimCardGroups::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardGroupCreateResponse>> Create(
        SimCardGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SimCardGroupCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var simCardGroup = await response.Deserialize<SimCardGroupCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                simCardGroup.Validate();
            }
            return simCardGroup;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardGroupRetrieveResponse>> Retrieve(
        SimCardGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SimCardGroupRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var simCardGroup = await response.Deserialize<SimCardGroupRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                simCardGroup.Validate();
            }
            return simCardGroup;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SimCardGroupRetrieveResponse>> Retrieve(
        string id,
        SimCardGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardGroupUpdateResponse>> Update(
        SimCardGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SimCardGroupUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var simCardGroup = await response.Deserialize<SimCardGroupUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                simCardGroup.Validate();
            }
            return simCardGroup;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SimCardGroupUpdateResponse>> Update(
        string id,
        SimCardGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardGroupListPage>> List(
        SimCardGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SimCardGroupListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<SimCardGroupListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new SimCardGroupListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SimCardGroupDeleteResponse>> Delete(
        SimCardGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SimCardGroupDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var simCardGroup = await response.Deserialize<SimCardGroupDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                simCardGroup.Validate();
            }
            return simCardGroup;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SimCardGroupDeleteResponse>> Delete(
        string id,
        SimCardGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}