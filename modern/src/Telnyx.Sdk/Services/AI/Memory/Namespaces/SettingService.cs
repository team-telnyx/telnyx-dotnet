using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Memory.Namespaces.Settings;

namespace Telnyx.Sdk.Services.AI.Memory.Namespaces;

/// <inheritdoc/>
public sealed class SettingService : ISettingService
{
    readonly Lazy<ISettingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISettingServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISettingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new SettingService(this._client.WithOptions(modifier)); }

    public SettingService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SettingServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<NamespaceSettingsResponse> List(
        SettingListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NamespaceSettingsResponse> List(
        string namespace_,
        SettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            Namespace = namespace_
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NamespaceSettingsResponse> PatchAll(
        SettingPatchAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.PatchAll(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NamespaceSettingsResponse> PatchAll(
        string namespace_,
        SettingPatchAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.PatchAll(parameters with{
            Namespace = namespace_
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SettingServiceWithRawResponse : ISettingServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISettingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SettingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SettingServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<NamespaceSettingsResponse>> List(
        SettingListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Namespace == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Namespace' cannot be null"
            );
        }

        HttpRequest<SettingListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var namespaceSettingsResponse = await response.Deserialize<NamespaceSettingsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                namespaceSettingsResponse.Validate();
            }
            return namespaceSettingsResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NamespaceSettingsResponse>> List(
        string namespace_,
        SettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            Namespace = namespace_
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NamespaceSettingsResponse>> PatchAll(
        SettingPatchAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Namespace == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Namespace' cannot be null"
            );
        }

        HttpRequest<SettingPatchAllParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var namespaceSettingsResponse = await response.Deserialize<NamespaceSettingsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                namespaceSettingsResponse.Validate();
            }
            return namespaceSettingsResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NamespaceSettingsResponse>> PatchAll(
        string namespace_,
        SettingPatchAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.PatchAll(parameters with{
            Namespace = namespace_
        }, cancellationToken);
    }
}