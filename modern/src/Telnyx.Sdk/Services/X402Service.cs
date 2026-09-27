using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.X402;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class X402Service : IX402Service
{
    readonly Lazy<IX402ServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IX402ServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IX402Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new X402Service(this._client.WithOptions(modifier)); }

    public X402Service (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new X402ServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _creditAccount =new(() => new CreditAccountService(client)) ;
    }

    readonly Lazy<ICreditAccountService> _creditAccount;
    public ICreditAccountService CreditAccount {
        get { return _creditAccount.Value; }
    }
}

/// <inheritdoc/>
public sealed class X402ServiceWithRawResponse : IX402ServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IX402ServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new X402ServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public X402ServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _creditAccount =new(
            () => new CreditAccountServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<ICreditAccountServiceWithRawResponse> _creditAccount;
    public ICreditAccountServiceWithRawResponse CreditAccount {
        get { return _creditAccount.Value; }
    }
}