using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Messaging.Rcs;
using Telnyx.Sdk.Services.Messaging.Rcs;

namespace Telnyx.Sdk.Services.Messaging;

/// <inheritdoc/>
public sealed class RcService : IRcService
{
    readonly Lazy<IRcServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRcServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRcService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new RcService(this._client.WithOptions(modifier)); }

    public RcService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RcServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _agents =new(() => new AgentService(client)) ;
    }

    readonly Lazy<IAgentService> _agents;
    public IAgentService Agents { get { return _agents.Value; } }

    /// <inheritdoc/>
    public async Task<RcInviteTestNumberResponse> InviteTestNumber(
        RcInviteTestNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.InviteTestNumber(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RcInviteTestNumberResponse> InviteTestNumber(
        string phoneNumber,
        RcInviteTestNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.InviteTestNumber(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RcListBulkCapabilitiesResponse> ListBulkCapabilities(
        RcListBulkCapabilitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListBulkCapabilities(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RcRetrieveCapabilitiesResponse> RetrieveCapabilities(
        RcRetrieveCapabilitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveCapabilities(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RcRetrieveCapabilitiesResponse> RetrieveCapabilities(
        string phoneNumber,
        RcRetrieveCapabilitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveCapabilities(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class RcServiceWithRawResponse : IRcServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRcServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new RcServiceWithRawResponse(this._client.WithOptions(modifier)); }

    public RcServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _agents =new(() => new AgentServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IAgentServiceWithRawResponse> _agents;
    public IAgentServiceWithRawResponse Agents { get { return _agents.Value; } }

    /// <inheritdoc/>
    public async Task<HttpResponse<RcInviteTestNumberResponse>> InviteTestNumber(
        RcInviteTestNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<RcInviteTestNumberParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<RcInviteTestNumberResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RcInviteTestNumberResponse>> InviteTestNumber(
        string phoneNumber,
        RcInviteTestNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.InviteTestNumber(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RcListBulkCapabilitiesResponse>> ListBulkCapabilities(
        RcListBulkCapabilitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RcListBulkCapabilitiesParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<RcListBulkCapabilitiesResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RcRetrieveCapabilitiesResponse>> RetrieveCapabilities(
        RcRetrieveCapabilitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<RcRetrieveCapabilitiesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<RcRetrieveCapabilitiesResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RcRetrieveCapabilitiesResponse>> RetrieveCapabilities(
        string phoneNumber,
        RcRetrieveCapabilitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveCapabilities(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}