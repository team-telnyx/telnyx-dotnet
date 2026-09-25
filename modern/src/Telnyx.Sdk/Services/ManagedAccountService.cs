using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.ManagedAccounts;
using ManagedAccounts = Telnyx.Sdk.Services.ManagedAccounts;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class ManagedAccountService : IManagedAccountService
{
    readonly Lazy<IManagedAccountServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IManagedAccountServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IManagedAccountService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ManagedAccountService(this._client.WithOptions(modifier)); }

    public ManagedAccountService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ManagedAccountServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _actions =new(() => new ManagedAccounts::ActionService(client)) ;
    }

    readonly Lazy<ManagedAccounts::IActionService> _actions;
    public ManagedAccounts::IActionService Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<ManagedAccountCreateResponse> Create(
        ManagedAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ManagedAccountRetrieveResponse> Retrieve(
        ManagedAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ManagedAccountRetrieveResponse> Retrieve(
        string id,
        ManagedAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ManagedAccountUpdateResponse> Update(
        ManagedAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ManagedAccountUpdateResponse> Update(
        string id,
        ManagedAccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ManagedAccountListPage> List(
        ManagedAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ManagedAccountGetAllocatableGlobalOutboundChannelsResponse> GetAllocatableGlobalOutboundChannels(
        ManagedAccountGetAllocatableGlobalOutboundChannelsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetAllocatableGlobalOutboundChannels(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ManagedAccountUpdateGlobalChannelLimitResponse> UpdateGlobalChannelLimit(
        ManagedAccountUpdateGlobalChannelLimitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.UpdateGlobalChannelLimit(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ManagedAccountUpdateGlobalChannelLimitResponse> UpdateGlobalChannelLimit(
        string id,
        ManagedAccountUpdateGlobalChannelLimitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateGlobalChannelLimit(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ManagedAccountServiceWithRawResponse : IManagedAccountServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IManagedAccountServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ManagedAccountServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ManagedAccountServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _actions =new(
            () => new ManagedAccounts::ActionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<ManagedAccounts::IActionServiceWithRawResponse> _actions;
    public ManagedAccounts::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ManagedAccountCreateResponse>> Create(
        ManagedAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ManagedAccountCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var managedAccount = await response.Deserialize<ManagedAccountCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                managedAccount.Validate();
            }
            return managedAccount;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ManagedAccountRetrieveResponse>> Retrieve(
        ManagedAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ManagedAccountRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var managedAccount = await response.Deserialize<ManagedAccountRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                managedAccount.Validate();
            }
            return managedAccount;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ManagedAccountRetrieveResponse>> Retrieve(
        string id,
        ManagedAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ManagedAccountUpdateResponse>> Update(
        ManagedAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ManagedAccountUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var managedAccount = await response.Deserialize<ManagedAccountUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                managedAccount.Validate();
            }
            return managedAccount;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ManagedAccountUpdateResponse>> Update(
        string id,
        ManagedAccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ManagedAccountListPage>> List(
        ManagedAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ManagedAccountListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<ManagedAccountListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ManagedAccountListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ManagedAccountGetAllocatableGlobalOutboundChannelsResponse>> GetAllocatableGlobalOutboundChannels(
        ManagedAccountGetAllocatableGlobalOutboundChannelsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ManagedAccountGetAllocatableGlobalOutboundChannelsParams> request = new(

        )
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ManagedAccountGetAllocatableGlobalOutboundChannelsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ManagedAccountUpdateGlobalChannelLimitResponse>> UpdateGlobalChannelLimit(
        ManagedAccountUpdateGlobalChannelLimitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ManagedAccountUpdateGlobalChannelLimitParams> request = new(

        )
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ManagedAccountUpdateGlobalChannelLimitResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ManagedAccountUpdateGlobalChannelLimitResponse>> UpdateGlobalChannelLimit(
        string id,
        ManagedAccountUpdateGlobalChannelLimitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateGlobalChannelLimit(parameters with{
            ID = id
        }, cancellationToken);
    }
}