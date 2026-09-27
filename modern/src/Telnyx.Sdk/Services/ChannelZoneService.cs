using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.ChannelZones;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class ChannelZoneService : IChannelZoneService
{
    readonly Lazy<IChannelZoneServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IChannelZoneServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IChannelZoneService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ChannelZoneService(this._client.WithOptions(modifier)); }

    public ChannelZoneService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ChannelZoneServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<GcbChannelZone> Update(
        ChannelZoneUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<GcbChannelZone> Update(
        string channelZoneID,
        ChannelZoneUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ChannelZoneID = channelZoneID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ChannelZoneListPage> List(
        ChannelZoneListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ChannelZoneServiceWithRawResponse : IChannelZoneServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IChannelZoneServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ChannelZoneServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ChannelZoneServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<GcbChannelZone>> Update(
        ChannelZoneUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ChannelZoneID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ChannelZoneID' cannot be null"
            );
        }

        HttpRequest<ChannelZoneUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var gcbChannelZone = await response.Deserialize<GcbChannelZone>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                gcbChannelZone.Validate();
            }
            return gcbChannelZone;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<GcbChannelZone>> Update(
        string channelZoneID,
        ChannelZoneUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ChannelZoneID = channelZoneID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChannelZoneListPage>> List(
        ChannelZoneListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ChannelZoneListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<ChannelZoneListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ChannelZoneListPage(this, parameters, page);
        });
    }
}