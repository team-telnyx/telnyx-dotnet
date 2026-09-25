using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Faxes;
using Faxes = Telnyx.Sdk.Services.Faxes;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class FaxService : IFaxService
{
    readonly Lazy<IFaxServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFaxServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IFaxService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new FaxService(this._client.WithOptions(modifier)); }

    public FaxService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new FaxServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _actions =new(() => new Faxes::ActionService(client)) ;
    }

    readonly Lazy<Faxes::IActionService> _actions;
    public Faxes::IActionService Actions { get { return _actions.Value; } }

    /// <inheritdoc/>
    public async Task<FaxCreateResponse> Create(
        FaxCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FaxRetrieveResponse> Retrieve(
        FaxRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FaxRetrieveResponse> Retrieve(
        string id,
        FaxRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FaxListPage> List(
        FaxListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        FaxDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string id,
        FaxDeleteParams? parameters = null,
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
public sealed class FaxServiceWithRawResponse : IFaxServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFaxServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new FaxServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FaxServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _actions =new(() => new Faxes::ActionServiceWithRawResponse(client)) ;
    }

    readonly Lazy<Faxes::IActionServiceWithRawResponse> _actions;
    public Faxes::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FaxCreateResponse>> Create(
        FaxCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FaxCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var fax = await response.Deserialize<FaxCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                fax.Validate();
            }
            return fax;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FaxRetrieveResponse>> Retrieve(
        FaxRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<FaxRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var fax = await response.Deserialize<FaxRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                fax.Validate();
            }
            return fax;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FaxRetrieveResponse>> Retrieve(
        string id,
        FaxRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FaxListPage>> List(
        FaxListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<FaxListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<FaxListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new FaxListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        FaxDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<FaxDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        FaxDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}