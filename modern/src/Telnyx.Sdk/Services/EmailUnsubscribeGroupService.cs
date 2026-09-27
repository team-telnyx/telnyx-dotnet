using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailUnsubscribeGroups;
using Telnyx.Sdk.Services.EmailUnsubscribeGroups;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class EmailUnsubscribeGroupService : IEmailUnsubscribeGroupService
{
    readonly Lazy<IEmailUnsubscribeGroupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEmailUnsubscribeGroupServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IEmailUnsubscribeGroupService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EmailUnsubscribeGroupService(this._client.WithOptions(modifier));
    }

    public EmailUnsubscribeGroupService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new EmailUnsubscribeGroupServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _suppressions =new(() => new SuppressionService(client)) ;
    }

    readonly Lazy<ISuppressionService> _suppressions;
    public ISuppressionService Suppressions {
        get { return _suppressions.Value; }
    }

    /// <inheritdoc/>
    public async Task<UnsubscribeGroupResponse> Create(
        EmailUnsubscribeGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<UnsubscribeGroupResponse> Retrieve(
        EmailUnsubscribeGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<UnsubscribeGroupResponse> Retrieve(
        string id,
        EmailUnsubscribeGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UnsubscribeGroupResponse> Update(
        EmailUnsubscribeGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<UnsubscribeGroupResponse> Update(
        string id,
        EmailUnsubscribeGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailUnsubscribeGroupListPage> List(
        EmailUnsubscribeGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        EmailUnsubscribeGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string id,
        EmailUnsubscribeGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            ID = id
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class EmailUnsubscribeGroupServiceWithRawResponse : IEmailUnsubscribeGroupServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEmailUnsubscribeGroupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EmailUnsubscribeGroupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EmailUnsubscribeGroupServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _suppressions =new(
            () => new SuppressionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<ISuppressionServiceWithRawResponse> _suppressions;
    public ISuppressionServiceWithRawResponse Suppressions {
        get { return _suppressions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UnsubscribeGroupResponse>> Create(
        EmailUnsubscribeGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EmailUnsubscribeGroupCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var unsubscribeGroupResponse = await response.Deserialize<UnsubscribeGroupResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                unsubscribeGroupResponse.Validate();
            }
            return unsubscribeGroupResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UnsubscribeGroupResponse>> Retrieve(
        EmailUnsubscribeGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailUnsubscribeGroupRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var unsubscribeGroupResponse = await response.Deserialize<UnsubscribeGroupResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                unsubscribeGroupResponse.Validate();
            }
            return unsubscribeGroupResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<UnsubscribeGroupResponse>> Retrieve(
        string id,
        EmailUnsubscribeGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UnsubscribeGroupResponse>> Update(
        EmailUnsubscribeGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailUnsubscribeGroupUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var unsubscribeGroupResponse = await response.Deserialize<UnsubscribeGroupResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                unsubscribeGroupResponse.Validate();
            }
            return unsubscribeGroupResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<UnsubscribeGroupResponse>> Update(
        string id,
        EmailUnsubscribeGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailUnsubscribeGroupListPage>> List(
        EmailUnsubscribeGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EmailUnsubscribeGroupListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<EmailUnsubscribeGroupListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new EmailUnsubscribeGroupListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        EmailUnsubscribeGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailUnsubscribeGroupDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        EmailUnsubscribeGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}