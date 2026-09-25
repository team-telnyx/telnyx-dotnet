using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Storage;
using Telnyx.Sdk.Services.Storage;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class StorageService : IStorageService
{
    readonly Lazy<IStorageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IStorageServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IStorageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new StorageService(this._client.WithOptions(modifier)); }

    public StorageService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new StorageServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _buckets =new(() => new BucketService(client)) ;
        _migrationSources =new(() => new MigrationSourceService(client)) ;
        _migrations =new(() => new MigrationService(client)) ;
        _kvs =new(() => new KvService(client)) ;
        _cloudfs =new(() => new CloudfService(client)) ;
        _sqldbs =new(() => new SqldbService(client)) ;
    }

    readonly Lazy<IBucketService> _buckets;
    public IBucketService Buckets { get { return _buckets.Value; } }

    readonly Lazy<IMigrationSourceService> _migrationSources;
    public IMigrationSourceService MigrationSources {
        get { return _migrationSources.Value; }
    }

    readonly Lazy<IMigrationService> _migrations;
    public IMigrationService Migrations { get { return _migrations.Value; } }

    readonly Lazy<IKvService> _kvs;
    public IKvService Kvs { get { return _kvs.Value; } }

    readonly Lazy<ICloudfService> _cloudfs;
    public ICloudfService Cloudfs { get { return _cloudfs.Value; } }

    readonly Lazy<ISqldbService> _sqldbs;
    public ISqldbService Sqldbs { get { return _sqldbs.Value; } }

    /// <inheritdoc/>
    public async Task<StorageListMigrationSourceCoverageResponse> ListMigrationSourceCoverage(
        StorageListMigrationSourceCoverageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListMigrationSourceCoverage(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class StorageServiceWithRawResponse : IStorageServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IStorageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new StorageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public StorageServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _buckets =new(() => new BucketServiceWithRawResponse(client)) ;
        _migrationSources =new(
            () => new MigrationSourceServiceWithRawResponse(client)
        ) ;
        _migrations =new(() => new MigrationServiceWithRawResponse(client)) ;
        _kvs =new(() => new KvServiceWithRawResponse(client)) ;
        _cloudfs =new(() => new CloudfServiceWithRawResponse(client)) ;
        _sqldbs =new(() => new SqldbServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IBucketServiceWithRawResponse> _buckets;
    public IBucketServiceWithRawResponse Buckets {
        get { return _buckets.Value; }
    }

    readonly Lazy<IMigrationSourceServiceWithRawResponse> _migrationSources;
    public IMigrationSourceServiceWithRawResponse MigrationSources {
        get { return _migrationSources.Value; }
    }

    readonly Lazy<IMigrationServiceWithRawResponse> _migrations;
    public IMigrationServiceWithRawResponse Migrations {
        get { return _migrations.Value; }
    }

    readonly Lazy<IKvServiceWithRawResponse> _kvs;
    public IKvServiceWithRawResponse Kvs { get { return _kvs.Value; } }

    readonly Lazy<ICloudfServiceWithRawResponse> _cloudfs;
    public ICloudfServiceWithRawResponse Cloudfs {
        get { return _cloudfs.Value; }
    }

    readonly Lazy<ISqldbServiceWithRawResponse> _sqldbs;
    public ISqldbServiceWithRawResponse Sqldbs { get { return _sqldbs.Value; } }

    /// <inheritdoc/>
    public async Task<HttpResponse<StorageListMigrationSourceCoverageResponse>> ListMigrationSourceCoverage(
        StorageListMigrationSourceCoverageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<StorageListMigrationSourceCoverageParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<StorageListMigrationSourceCoverageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}