using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Whatsapp.BusinessAccounts.Settings;

namespace Telnyx.Sdk.Services.Whatsapp.BusinessAccounts;

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
    public async Task<SettingRetrieveResponse> Retrieve(
        SettingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SettingRetrieveResponse> Retrieve(
        string id,
        SettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SettingUpdateResponse> Update(
        SettingUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SettingUpdateResponse> Update(
        string id,
        SettingUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
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
    public async Task<HttpResponse<SettingRetrieveResponse>> Retrieve(
        SettingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SettingRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var setting = await response.Deserialize<SettingRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                setting.Validate();
            }
            return setting;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SettingRetrieveResponse>> Retrieve(
        string id,
        SettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SettingUpdateResponse>> Update(
        SettingUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SettingUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var setting = await response.Deserialize<SettingUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                setting.Validate();
            }
            return setting;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SettingUpdateResponse>> Update(
        string id,
        SettingUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }
}