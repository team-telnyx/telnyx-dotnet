using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Payment.AutoRechargePrefs;

namespace Telnyx.Sdk.Services.Payment;

/// <inheritdoc/>
public sealed class AutoRechargePrefService : IAutoRechargePrefService
{
    readonly Lazy<IAutoRechargePrefServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAutoRechargePrefServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAutoRechargePrefService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new AutoRechargePrefService(this._client.WithOptions(modifier)); }

    public AutoRechargePrefService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AutoRechargePrefServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<AutoRechargePrefUpdateResponse> Update(
        AutoRechargePrefUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AutoRechargePrefListResponse> List(
        AutoRechargePrefListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AutoRechargePrefServiceWithRawResponse : IAutoRechargePrefServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAutoRechargePrefServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AutoRechargePrefServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AutoRechargePrefServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<AutoRechargePrefUpdateResponse>> Update(
        AutoRechargePrefUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutoRechargePrefUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var autoRechargePref = await response.Deserialize<AutoRechargePrefUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                autoRechargePref.Validate();
            }
            return autoRechargePref;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AutoRechargePrefListResponse>> List(
        AutoRechargePrefListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutoRechargePrefListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var autoRechargePrefs = await response.Deserialize<AutoRechargePrefListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                autoRechargePrefs.Validate();
            }
            return autoRechargePrefs;
        });
    }
}