using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPAssignmentHealth;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class GlobalIPAssignmentHealthService : IGlobalIPAssignmentHealthService
{
    readonly Lazy<IGlobalIPAssignmentHealthServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGlobalIPAssignmentHealthServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IGlobalIPAssignmentHealthService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GlobalIPAssignmentHealthService(this._client.WithOptions(modifier));
    }

    public GlobalIPAssignmentHealthService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new GlobalIPAssignmentHealthServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<GlobalIPAssignmentHealthRetrieveResponse> Retrieve(
        GlobalIPAssignmentHealthRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class GlobalIPAssignmentHealthServiceWithRawResponse : IGlobalIPAssignmentHealthServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGlobalIPAssignmentHealthServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GlobalIPAssignmentHealthServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GlobalIPAssignmentHealthServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<GlobalIPAssignmentHealthRetrieveResponse>> Retrieve(
        GlobalIPAssignmentHealthRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<GlobalIPAssignmentHealthRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var globalIPAssignmentHealth = await response.Deserialize<GlobalIPAssignmentHealthRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                globalIPAssignmentHealth.Validate();
            }
            return globalIPAssignmentHealth;
        });
    }
}