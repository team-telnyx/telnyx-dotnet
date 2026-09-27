using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.SessionAnalysis;
using Telnyx.Sdk.Services.SessionAnalysis;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class SessionAnalysisService : ISessionAnalysisService
{
    readonly Lazy<ISessionAnalysisServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISessionAnalysisServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISessionAnalysisService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new SessionAnalysisService(this._client.WithOptions(modifier)); }

    public SessionAnalysisService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SessionAnalysisServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _metadata =new(() => new MetadataService(client)) ;
    }

    readonly Lazy<IMetadataService> _metadata;
    public IMetadataService Metadata { get { return _metadata.Value; } }

    /// <inheritdoc/>
    public async Task<SessionAnalysisRetrieveResponse> Retrieve(
        SessionAnalysisRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SessionAnalysisRetrieveResponse> Retrieve(
        string eventID,
        SessionAnalysisRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            EventID = eventID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SessionAnalysisServiceWithRawResponse : ISessionAnalysisServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISessionAnalysisServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SessionAnalysisServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SessionAnalysisServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _metadata =new(() => new MetadataServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IMetadataServiceWithRawResponse> _metadata;
    public IMetadataServiceWithRawResponse Metadata {
        get { return _metadata.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SessionAnalysisRetrieveResponse>> Retrieve(
        SessionAnalysisRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EventID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EventID' cannot be null"
            );
        }

        HttpRequest<SessionAnalysisRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var sessionAnalysis = await response.Deserialize<SessionAnalysisRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                sessionAnalysis.Validate();
            }
            return sessionAnalysis;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SessionAnalysisRetrieveResponse>> Retrieve(
        string eventID,
        SessionAnalysisRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            EventID = eventID
        }, cancellationToken);
    }
}