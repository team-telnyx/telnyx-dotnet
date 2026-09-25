using System;
using Telnyx.Sdk.Core;
using ExternalRequirements = Telnyx.Sdk.Services.ExternalRequirements;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class ExternalRequirementService : IExternalRequirementService
{
    readonly Lazy<IExternalRequirementServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExternalRequirementServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IExternalRequirementService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ExternalRequirementService(this._client.WithOptions(modifier));
    }

    public ExternalRequirementService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ExternalRequirementServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _subNumberOrders =new(
            () => new ExternalRequirements::SubNumberOrderService(client)
        ) ;
    }

    readonly Lazy<ExternalRequirements::ISubNumberOrderService> _subNumberOrders;
    public ExternalRequirements::ISubNumberOrderService SubNumberOrders {
        get { return _subNumberOrders.Value; }
    }
}

/// <inheritdoc/>
public sealed class ExternalRequirementServiceWithRawResponse : IExternalRequirementServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExternalRequirementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ExternalRequirementServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExternalRequirementServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _subNumberOrders =new(
            () => new ExternalRequirements::SubNumberOrderServiceWithRawResponse(
                client
            )
        ) ;
    }

    readonly Lazy<ExternalRequirements::ISubNumberOrderServiceWithRawResponse> _subNumberOrders;
    public ExternalRequirements::ISubNumberOrderServiceWithRawResponse SubNumberOrders {
        get { return _subNumberOrders.Value; }
    }
}