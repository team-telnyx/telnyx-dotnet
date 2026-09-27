using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.FqdnConnections.FqdnAuthentication;

namespace Telnyx.Sdk.Services.FqdnConnections;

/// <inheritdoc/>
public sealed class FqdnAuthenticationService : IFqdnAuthenticationService
{
    readonly Lazy<IFqdnAuthenticationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFqdnAuthenticationServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IFqdnAuthenticationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new FqdnAuthenticationService(this._client.WithOptions(modifier));
    }

    public FqdnAuthenticationService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new FqdnAuthenticationServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<FqdnAuthenticationListResponse> List(
        FqdnAuthenticationListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FqdnAuthenticationListResponse> List(
        string fqdnConnectionID,
        FqdnAuthenticationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            FqdnConnectionID = fqdnConnectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FqdnAuthenticationPatchAllResponse> PatchAll(
        FqdnAuthenticationPatchAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.PatchAll(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FqdnAuthenticationPatchAllResponse> PatchAll(
        string fqdnConnectionID,
        FqdnAuthenticationPatchAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.PatchAll(parameters with{
            FqdnConnectionID = fqdnConnectionID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class FqdnAuthenticationServiceWithRawResponse : IFqdnAuthenticationServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFqdnAuthenticationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new FqdnAuthenticationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FqdnAuthenticationServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<FqdnAuthenticationListResponse>> List(
        FqdnAuthenticationListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FqdnConnectionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.FqdnConnectionID' cannot be null"
            );
        }

        HttpRequest<FqdnAuthenticationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var fqdnAuthentications = await response.Deserialize<FqdnAuthenticationListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                fqdnAuthentications.Validate();
            }
            return fqdnAuthentications;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FqdnAuthenticationListResponse>> List(
        string fqdnConnectionID,
        FqdnAuthenticationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            FqdnConnectionID = fqdnConnectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FqdnAuthenticationPatchAllResponse>> PatchAll(
        FqdnAuthenticationPatchAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FqdnConnectionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.FqdnConnectionID' cannot be null"
            );
        }

        HttpRequest<FqdnAuthenticationPatchAllParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<FqdnAuthenticationPatchAllResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FqdnAuthenticationPatchAllResponse>> PatchAll(
        string fqdnConnectionID,
        FqdnAuthenticationPatchAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.PatchAll(parameters with{
            FqdnConnectionID = fqdnConnectionID
        }, cancellationToken);
    }
}