using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Collections.Settings;

namespace Telnyx.Sdk.Services.AI.Collections;

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
    public async Task<SettingsEnvelope> Create(
        SettingCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SettingsEnvelope> Create(
        string uuid,
        SettingCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            Uuid = uuid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SettingsEnvelope> List(
        SettingListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SettingsEnvelope> List(
        string uuid,
        SettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            Uuid = uuid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SettingsEnvelope> PatchAll(
        SettingPatchAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.PatchAll(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SettingsEnvelope> PatchAll(
        string uuid,
        SettingPatchAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.PatchAll(parameters with{
            Uuid = uuid
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
    public async Task<HttpResponse<SettingsEnvelope>> Create(
        SettingCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Uuid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Uuid' cannot be null"
            );
        }

        HttpRequest<SettingCreateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var settingsEnvelope = await response.Deserialize<SettingsEnvelope>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                settingsEnvelope.Validate();
            }
            return settingsEnvelope;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SettingsEnvelope>> Create(
        string uuid,
        SettingCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            Uuid = uuid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SettingsEnvelope>> List(
        SettingListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Uuid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Uuid' cannot be null"
            );
        }

        HttpRequest<SettingListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var settingsEnvelope = await response.Deserialize<SettingsEnvelope>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                settingsEnvelope.Validate();
            }
            return settingsEnvelope;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SettingsEnvelope>> List(
        string uuid,
        SettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            Uuid = uuid
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SettingsEnvelope>> PatchAll(
        SettingPatchAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Uuid == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Uuid' cannot be null"
            );
        }

        HttpRequest<SettingPatchAllParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var settingsEnvelope = await response.Deserialize<SettingsEnvelope>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                settingsEnvelope.Validate();
            }
            return settingsEnvelope;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SettingsEnvelope>> PatchAll(
        string uuid,
        SettingPatchAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.PatchAll(parameters with{
            Uuid = uuid
        }, cancellationToken);
    }
}