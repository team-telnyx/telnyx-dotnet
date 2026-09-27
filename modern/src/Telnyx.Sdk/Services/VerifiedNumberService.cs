using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.VerifiedNumbers;
using VerifiedNumbers = Telnyx.Sdk.Services.VerifiedNumbers;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class VerifiedNumberService : IVerifiedNumberService
{
    readonly Lazy<IVerifiedNumberServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVerifiedNumberServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IVerifiedNumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new VerifiedNumberService(this._client.WithOptions(modifier)); }

    public VerifiedNumberService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new VerifiedNumberServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _actions =new(() => new VerifiedNumbers::ActionService(client)) ;
    }

    readonly Lazy<VerifiedNumbers::IActionService> _actions;
    public VerifiedNumbers::IActionService Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<VerifiedNumberCreateResponse> Create(
        VerifiedNumberCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<VerifiedNumberDataWrapper> Retrieve(
        VerifiedNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VerifiedNumberDataWrapper> Retrieve(
        string phoneNumber,
        VerifiedNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VerifiedNumberListPage> List(
        VerifiedNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<VerifiedNumberDataWrapper> Delete(
        VerifiedNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VerifiedNumberDataWrapper> Delete(
        string phoneNumber,
        VerifiedNumberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class VerifiedNumberServiceWithRawResponse : IVerifiedNumberServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVerifiedNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new VerifiedNumberServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VerifiedNumberServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _actions =new(
            () => new VerifiedNumbers::ActionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<VerifiedNumbers::IActionServiceWithRawResponse> _actions;
    public VerifiedNumbers::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VerifiedNumberCreateResponse>> Create(
        VerifiedNumberCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VerifiedNumberCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var verifiedNumber = await response.Deserialize<VerifiedNumberCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                verifiedNumber.Validate();
            }
            return verifiedNumber;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VerifiedNumberDataWrapper>> Retrieve(
        VerifiedNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<VerifiedNumberRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var verifiedNumberDataWrapper = await response.Deserialize<VerifiedNumberDataWrapper>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                verifiedNumberDataWrapper.Validate();
            }
            return verifiedNumberDataWrapper;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VerifiedNumberDataWrapper>> Retrieve(
        string phoneNumber,
        VerifiedNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VerifiedNumberListPage>> List(
        VerifiedNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<VerifiedNumberListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<VerifiedNumberListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new VerifiedNumberListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VerifiedNumberDataWrapper>> Delete(
        VerifiedNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<VerifiedNumberDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var verifiedNumberDataWrapper = await response.Deserialize<VerifiedNumberDataWrapper>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                verifiedNumberDataWrapper.Validate();
            }
            return verifiedNumberDataWrapper;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VerifiedNumberDataWrapper>> Delete(
        string phoneNumber,
        VerifiedNumberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}