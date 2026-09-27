using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Storage.Sqldbs;
using Sqldbs = Telnyx.Sdk.Services.Storage.Sqldbs;

namespace Telnyx.Sdk.Services.Storage;

/// <inheritdoc/>
public sealed class SqldbService : ISqldbService
{
    readonly Lazy<ISqldbServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISqldbServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISqldbService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new SqldbService(this._client.WithOptions(modifier)); }

    public SqldbService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SqldbServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _actions =new(() => new Sqldbs::ActionService(client)) ;
    }

    readonly Lazy<Sqldbs::IActionService> _actions;
    public Sqldbs::IActionService Actions { get { return _actions.Value; } }

    /// <inheritdoc/>
    public async Task<SqlDatabaseResponseWrapper> Create(
        SqldbCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SqlDatabaseResponseWrapper> Retrieve(
        SqldbRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SqlDatabaseResponseWrapper> Retrieve(
        string id,
        SqldbRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SqldbListPage> List(
        SqldbListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        SqldbDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string id,
        SqldbDeleteParams? parameters = null,
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
public sealed class SqldbServiceWithRawResponse : ISqldbServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISqldbServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SqldbServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SqldbServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _actions =new(() => new Sqldbs::ActionServiceWithRawResponse(client)) ;
    }

    readonly Lazy<Sqldbs::IActionServiceWithRawResponse> _actions;
    public Sqldbs::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SqlDatabaseResponseWrapper>> Create(
        SqldbCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SqldbCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var sqlDatabaseResponseWrapper = await response.Deserialize<SqlDatabaseResponseWrapper>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                sqlDatabaseResponseWrapper.Validate();
            }
            return sqlDatabaseResponseWrapper;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SqlDatabaseResponseWrapper>> Retrieve(
        SqldbRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SqldbRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var sqlDatabaseResponseWrapper = await response.Deserialize<SqlDatabaseResponseWrapper>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                sqlDatabaseResponseWrapper.Validate();
            }
            return sqlDatabaseResponseWrapper;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SqlDatabaseResponseWrapper>> Retrieve(
        string id,
        SqldbRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SqldbListPage>> List(
        SqldbListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SqldbListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<SqldbListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new SqldbListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        SqldbDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SqldbDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        SqldbDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}