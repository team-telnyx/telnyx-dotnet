using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPAssignmentsUsage;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class GlobalIPAssignmentsUsageService : IGlobalIPAssignmentsUsageService
{
    readonly Lazy<IGlobalIPAssignmentsUsageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGlobalIPAssignmentsUsageServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IGlobalIPAssignmentsUsageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GlobalIPAssignmentsUsageService(this._client.WithOptions(modifier));
    }

    public GlobalIPAssignmentsUsageService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new GlobalIPAssignmentsUsageServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<GlobalIPAssignmentsUsageRetrieveResponse> Retrieve(
        GlobalIPAssignmentsUsageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class GlobalIPAssignmentsUsageServiceWithRawResponse : IGlobalIPAssignmentsUsageServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGlobalIPAssignmentsUsageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GlobalIPAssignmentsUsageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GlobalIPAssignmentsUsageServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<GlobalIPAssignmentsUsageRetrieveResponse>> Retrieve(
        GlobalIPAssignmentsUsageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<GlobalIPAssignmentsUsageRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var globalIPAssignmentsUsage = await response.Deserialize<GlobalIPAssignmentsUsageRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                globalIPAssignmentsUsage.Validate();
            }
            return globalIPAssignmentsUsage;
        });
    }
}