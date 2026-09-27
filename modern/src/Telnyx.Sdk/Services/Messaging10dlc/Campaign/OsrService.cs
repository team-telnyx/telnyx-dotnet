using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Messaging10dlc.Campaign.Osr;

namespace Telnyx.Sdk.Services.Messaging10dlc.Campaign;

/// <inheritdoc/>
public sealed class OsrService : IOsrService
{
    readonly Lazy<IOsrServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOsrServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IOsrService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new OsrService(this._client.WithOptions(modifier)); }

    public OsrService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new OsrServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, JsonElement>> GetAttributes(
        OsrGetAttributesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetAttributes(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<Dictionary<string, JsonElement>> GetAttributes(
        string campaignID,
        OsrGetAttributesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetAttributes(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class OsrServiceWithRawResponse : IOsrServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOsrServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new OsrServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OsrServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, JsonElement>>> GetAttributes(
        OsrGetAttributesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CampaignID' cannot be null"
            );
        }

        HttpRequest<OsrGetAttributesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<Dictionary<string, JsonElement>>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<Dictionary<string, JsonElement>>> GetAttributes(
        string campaignID,
        OsrGetAttributesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetAttributes(parameters with{
            CampaignID = campaignID
        }, cancellationToken);
    }
}