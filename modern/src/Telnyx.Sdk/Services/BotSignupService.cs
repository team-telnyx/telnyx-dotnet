using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.BotSignup;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class BotSignupService : IBotSignupService
{
    readonly Lazy<IBotSignupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBotSignupServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IBotSignupService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new BotSignupService(this._client.WithOptions(modifier)); }

    public BotSignupService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new BotSignupServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<SuccessResponse> Create(
        BotSignupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SuccessResponse> ResendMagicLink(
        BotSignupResendMagicLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ResendMagicLink(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BotSignupServiceWithRawResponse : IBotSignupServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBotSignupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BotSignupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BotSignupServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<SuccessResponse>> Create(
        BotSignupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BotSignupCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var successResponse = await response.Deserialize<SuccessResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                successResponse.Validate();
            }
            return successResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SuccessResponse>> ResendMagicLink(
        BotSignupResendMagicLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BotSignupResendMagicLinkParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var successResponse = await response.Deserialize<SuccessResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                successResponse.Validate();
            }
            return successResponse;
        });
    }
}