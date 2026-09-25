using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Integrations;
using Integrations = Telnyx.Sdk.Services.AI.Integrations;

namespace Telnyx.Sdk.Services.AI;

/// <inheritdoc/>
public sealed class IntegrationService : IIntegrationService
{
    readonly Lazy<IIntegrationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IIntegrationServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IIntegrationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new IntegrationService(this._client.WithOptions(modifier)); }

    public IntegrationService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new IntegrationServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _connections =new(() => new Integrations::ConnectionService(client)) ;
    }

    readonly Lazy<Integrations::IConnectionService> _connections;
    public Integrations::IConnectionService Connections {
        get { return _connections.Value; }
    }

    /// <inheritdoc/>
    public async Task<Integration> Retrieve(
        IntegrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<Integration> Retrieve(
        string integrationID,
        IntegrationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            IntegrationID = integrationID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<IntegrationListResponse> List(
        IntegrationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class IntegrationServiceWithRawResponse : IIntegrationServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IIntegrationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new IntegrationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public IntegrationServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _connections =new(
            () => new Integrations::ConnectionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<Integrations::IConnectionServiceWithRawResponse> _connections;
    public Integrations::IConnectionServiceWithRawResponse Connections {
        get { return _connections.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Integration>> Retrieve(
        IntegrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.IntegrationID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.IntegrationID' cannot be null"
            );
        }

        HttpRequest<IntegrationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var integration = await response.Deserialize<Integration>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                integration.Validate();
            }
            return integration;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<Integration>> Retrieve(
        string integrationID,
        IntegrationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            IntegrationID = integrationID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IntegrationListResponse>> List(
        IntegrationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<IntegrationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var integrations = await response.Deserialize<IntegrationListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                integrations.Validate();
            }
            return integrations;
        });
    }
}