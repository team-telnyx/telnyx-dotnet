using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.SessionAnalysis.Metadata;

namespace Telnyx.Sdk.Services.SessionAnalysis;

/// <inheritdoc/>
public sealed class MetadataService : IMetadataService
{
    readonly Lazy<IMetadataServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMetadataServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMetadataService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MetadataService(this._client.WithOptions(modifier)); }

    public MetadataService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MetadataServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<MetadataRetrieveResponse> Retrieve(
        MetadataRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MetadataRetrieveRecordTypeResponse> RetrieveRecordType(
        MetadataRetrieveRecordTypeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveRecordType(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MetadataRetrieveRecordTypeResponse> RetrieveRecordType(
        string recordType,
        MetadataRetrieveRecordTypeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveRecordType(parameters with{
            RecordType = recordType
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MetadataServiceWithRawResponse : IMetadataServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMetadataServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MetadataServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MetadataServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<MetadataRetrieveResponse>> Retrieve(
        MetadataRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MetadataRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var metadata = await response.Deserialize<MetadataRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                metadata.Validate();
            }
            return metadata;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MetadataRetrieveRecordTypeResponse>> RetrieveRecordType(
        MetadataRetrieveRecordTypeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RecordType == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RecordType' cannot be null"
            );
        }

        HttpRequest<MetadataRetrieveRecordTypeParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MetadataRetrieveRecordTypeResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MetadataRetrieveRecordTypeResponse>> RetrieveRecordType(
        string recordType,
        MetadataRetrieveRecordTypeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveRecordType(parameters with{
            RecordType = recordType
        }, cancellationToken);
    }
}