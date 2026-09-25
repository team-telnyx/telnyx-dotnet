using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Storage.Migrations;
using Migrations = Telnyx.Sdk.Services.Storage.Migrations;

namespace Telnyx.Sdk.Services.Storage;

/// <inheritdoc/>
public sealed class MigrationService : IMigrationService
{
    readonly Lazy<IMigrationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMigrationServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMigrationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MigrationService(this._client.WithOptions(modifier)); }

    public MigrationService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MigrationServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _actions =new(() => new Migrations::ActionService(client)) ;
    }

    readonly Lazy<Migrations::IActionService> _actions;
    public Migrations::IActionService Actions { get { return _actions.Value; } }

    /// <inheritdoc/>
    public async Task<MigrationCreateResponse> Create(
        MigrationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MigrationRetrieveResponse> Retrieve(
        MigrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MigrationRetrieveResponse> Retrieve(
        string id,
        MigrationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MigrationListResponse> List(
        MigrationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MigrationServiceWithRawResponse : IMigrationServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMigrationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MigrationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MigrationServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _actions =new(
            () => new Migrations::ActionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<Migrations::IActionServiceWithRawResponse> _actions;
    public Migrations::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MigrationCreateResponse>> Create(
        MigrationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MigrationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var migration = await response.Deserialize<MigrationCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                migration.Validate();
            }
            return migration;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MigrationRetrieveResponse>> Retrieve(
        MigrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MigrationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var migration = await response.Deserialize<MigrationRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                migration.Validate();
            }
            return migration;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MigrationRetrieveResponse>> Retrieve(
        string id,
        MigrationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MigrationListResponse>> List(
        MigrationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MigrationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var migrations = await response.Deserialize<MigrationListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                migrations.Validate();
            }
            return migrations;
        });
    }
}