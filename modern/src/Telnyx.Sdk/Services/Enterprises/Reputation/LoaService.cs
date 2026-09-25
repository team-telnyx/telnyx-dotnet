using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Enterprises.Reputation;
using Telnyx.Sdk.Models.Enterprises.Reputation.Loa;

namespace Telnyx.Sdk.Services.Enterprises.Reputation;

/// <inheritdoc/>
public sealed class LoaService : ILoaService
{
    readonly Lazy<ILoaServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILoaServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ILoaService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new LoaService(this._client.WithOptions(modifier)); }

    public LoaService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new LoaServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<EnterpriseReputationPublicWrapped> Update(
        LoaUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EnterpriseReputationPublicWrapped> Update(
        string enterpriseID,
        LoaUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Render(
        LoaRenderParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Render(parameters, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Render(
        string enterpriseID,
        LoaRenderParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Render(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class LoaServiceWithRawResponse : ILoaServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILoaServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new LoaServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LoaServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<EnterpriseReputationPublicWrapped>> Update(
        LoaUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnterpriseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EnterpriseID' cannot be null"
            );
        }

        HttpRequest<LoaUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var enterpriseReputationPublicWrapped = await response.Deserialize<EnterpriseReputationPublicWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                enterpriseReputationPublicWrapped.Validate();
            }
            return enterpriseReputationPublicWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EnterpriseReputationPublicWrapped>> Update(
        string enterpriseID,
        LoaUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Render(
        LoaRenderParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnterpriseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EnterpriseID' cannot be null"
            );
        }

        HttpRequest<LoaRenderParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Render(
        string enterpriseID,
        LoaRenderParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Render(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }
}