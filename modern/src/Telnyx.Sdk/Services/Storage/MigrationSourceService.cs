using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Storage.MigrationSources;

namespace Telnyx.Sdk.Services.Storage;

/// <inheritdoc/>
public sealed class MigrationSourceService : IMigrationSourceService
{
    readonly Lazy<IMigrationSourceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMigrationSourceServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMigrationSourceService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MigrationSourceService(this._client.WithOptions(modifier)); }

    public MigrationSourceService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MigrationSourceServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<MigrationSourceCreateResponse> Create(
        MigrationSourceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MigrationSourceRetrieveResponse> Retrieve(
        MigrationSourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MigrationSourceRetrieveResponse> Retrieve(
        string id,
        MigrationSourceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MigrationSourceListResponse> List(
        MigrationSourceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MigrationSourceDeleteResponse> Delete(
        MigrationSourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MigrationSourceDeleteResponse> Delete(
        string id,
        MigrationSourceDeleteParams? parameters = null,
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
public sealed class MigrationSourceServiceWithRawResponse : IMigrationSourceServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMigrationSourceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MigrationSourceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MigrationSourceServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<MigrationSourceCreateResponse>> Create(
        MigrationSourceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MigrationSourceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var migrationSource = await response.Deserialize<MigrationSourceCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                migrationSource.Validate();
            }
            return migrationSource;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MigrationSourceRetrieveResponse>> Retrieve(
        MigrationSourceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MigrationSourceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var migrationSource = await response.Deserialize<MigrationSourceRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                migrationSource.Validate();
            }
            return migrationSource;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MigrationSourceRetrieveResponse>> Retrieve(
        string id,
        MigrationSourceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MigrationSourceListResponse>> List(
        MigrationSourceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MigrationSourceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var migrationSources = await response.Deserialize<MigrationSourceListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                migrationSources.Validate();
            }
            return migrationSources;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MigrationSourceDeleteResponse>> Delete(
        MigrationSourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MigrationSourceDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var migrationSource = await response.Deserialize<MigrationSourceDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                migrationSource.Validate();
            }
            return migrationSource;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MigrationSourceDeleteResponse>> Delete(
        string id,
        MigrationSourceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}