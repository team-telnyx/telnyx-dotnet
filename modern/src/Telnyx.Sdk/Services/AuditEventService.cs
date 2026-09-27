using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuditEvents;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class AuditEventService : IAuditEventService
{
    readonly Lazy<IAuditEventServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAuditEventServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAuditEventService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new AuditEventService(this._client.WithOptions(modifier)); }

    public AuditEventService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AuditEventServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<AuditEventListPage> List(
        AuditEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AuditEventServiceWithRawResponse : IAuditEventServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAuditEventServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AuditEventServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AuditEventServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<AuditEventListPage>> List(
        AuditEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AuditEventListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<AuditEventListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new AuditEventListPage(this, parameters, page);
        });
    }
}