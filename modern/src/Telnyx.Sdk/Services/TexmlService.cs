using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Texml;
using Texml = Telnyx.Sdk.Services.Texml;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class TexmlService : ITexmlService
{
    readonly Lazy<ITexmlServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITexmlServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ITexmlService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new TexmlService(this._client.WithOptions(modifier)); }

    public TexmlService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new TexmlServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _calls =new(() => new Texml::CallService(client)) ;
        _accounts =new(() => new Texml::AccountService(client)) ;
    }

    readonly Lazy<Texml::ICallService> _calls;
    public Texml::ICallService Calls { get { return _calls.Value; } }

    readonly Lazy<Texml::IAccountService> _accounts;
    public Texml::IAccountService Accounts { get { return _accounts.Value; } }

    /// <inheritdoc/>
    public async Task<TexmlInitiateAICallResponse> InitiateAICall(
        TexmlInitiateAICallParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.InitiateAICall(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TexmlInitiateAICallResponse> InitiateAICall(
        string connectionID,
        TexmlInitiateAICallParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.InitiateAICall(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TexmlSecretsResponse> Secrets(
        TexmlSecretsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Secrets(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TexmlServiceWithRawResponse : ITexmlServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITexmlServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TexmlServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TexmlServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _calls =new(() => new Texml::CallServiceWithRawResponse(client)) ;
        _accounts =new(() => new Texml::AccountServiceWithRawResponse(client)) ;
    }

    readonly Lazy<Texml::ICallServiceWithRawResponse> _calls;
    public Texml::ICallServiceWithRawResponse Calls {
        get { return _calls.Value; }
    }

    readonly Lazy<Texml::IAccountServiceWithRawResponse> _accounts;
    public Texml::IAccountServiceWithRawResponse Accounts {
        get { return _accounts.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TexmlInitiateAICallResponse>> InitiateAICall(
        TexmlInitiateAICallParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConnectionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConnectionID' cannot be null"
            );
        }

        HttpRequest<TexmlInitiateAICallParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<TexmlInitiateAICallResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TexmlInitiateAICallResponse>> InitiateAICall(
        string connectionID,
        TexmlInitiateAICallParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.InitiateAICall(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TexmlSecretsResponse>> Secrets(
        TexmlSecretsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TexmlSecretsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<TexmlSecretsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}