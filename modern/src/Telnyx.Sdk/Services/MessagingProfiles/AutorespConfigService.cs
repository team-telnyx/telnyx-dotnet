using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.MessagingProfiles.AutorespConfigs;

namespace Telnyx.Sdk.Services.MessagingProfiles;

/// <inheritdoc/>
public sealed class AutorespConfigService : IAutorespConfigService
{
    readonly Lazy<IAutorespConfigServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAutorespConfigServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAutorespConfigService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new AutorespConfigService(this._client.WithOptions(modifier)); }

    public AutorespConfigService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AutorespConfigServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<AutoRespConfigResponse> Create(
        AutorespConfigCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AutoRespConfigResponse> Create(
        string profileID,
        AutorespConfigCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ProfileID = profileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AutoRespConfigResponse> Retrieve(
        AutorespConfigRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AutoRespConfigResponse> Retrieve(
        string autorespCfgID,
        AutorespConfigRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            AutorespCfgID = autorespCfgID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AutoRespConfigResponse> Update(
        AutorespConfigUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AutoRespConfigResponse> Update(
        string autorespCfgID,
        AutorespConfigUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            AutorespCfgID = autorespCfgID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AutorespConfigListResponse> List(
        AutorespConfigListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AutorespConfigListResponse> List(
        string profileID,
        AutorespConfigListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ProfileID = profileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<string> Delete(
        AutorespConfigDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<string> Delete(
        string autorespCfgID,
        AutorespConfigDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            AutorespCfgID = autorespCfgID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AutorespConfigServiceWithRawResponse : IAutorespConfigServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAutorespConfigServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AutorespConfigServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AutorespConfigServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<AutoRespConfigResponse>> Create(
        AutorespConfigCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProfileID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ProfileID' cannot be null"
            );
        }

        HttpRequest<AutorespConfigCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var autoRespConfigResponse = await response.Deserialize<AutoRespConfigResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                autoRespConfigResponse.Validate();
            }
            return autoRespConfigResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AutoRespConfigResponse>> Create(
        string profileID,
        AutorespConfigCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ProfileID = profileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AutoRespConfigResponse>> Retrieve(
        AutorespConfigRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AutorespCfgID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AutorespCfgID' cannot be null"
            );
        }

        HttpRequest<AutorespConfigRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var autoRespConfigResponse = await response.Deserialize<AutoRespConfigResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                autoRespConfigResponse.Validate();
            }
            return autoRespConfigResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AutoRespConfigResponse>> Retrieve(
        string autorespCfgID,
        AutorespConfigRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            AutorespCfgID = autorespCfgID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AutoRespConfigResponse>> Update(
        AutorespConfigUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AutorespCfgID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AutorespCfgID' cannot be null"
            );
        }

        HttpRequest<AutorespConfigUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var autoRespConfigResponse = await response.Deserialize<AutoRespConfigResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                autoRespConfigResponse.Validate();
            }
            return autoRespConfigResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AutoRespConfigResponse>> Update(
        string autorespCfgID,
        AutorespConfigUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            AutorespCfgID = autorespCfgID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AutorespConfigListResponse>> List(
        AutorespConfigListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProfileID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ProfileID' cannot be null"
            );
        }

        HttpRequest<AutorespConfigListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var autorespConfigs = await response.Deserialize<AutorespConfigListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                autorespConfigs.Validate();
            }
            return autorespConfigs;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AutorespConfigListResponse>> List(
        string profileID,
        AutorespConfigListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ProfileID = profileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<string>> Delete(
        AutorespConfigDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AutorespCfgID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AutorespCfgID' cannot be null"
            );
        }

        HttpRequest<AutorespConfigDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<string>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<string>> Delete(
        string autorespCfgID,
        AutorespConfigDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            AutorespCfgID = autorespCfgID
        }, cancellationToken);
    }
}