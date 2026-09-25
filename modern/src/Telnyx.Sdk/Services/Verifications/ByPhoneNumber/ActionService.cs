using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Verifications.ByPhoneNumber.Actions;

namespace Telnyx.Sdk.Services.Verifications.ByPhoneNumber;

/// <inheritdoc/>
public sealed class ActionService : IActionService
{
    readonly Lazy<IActionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IActionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IActionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ActionService(this._client.WithOptions(modifier)); }

    public ActionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ActionServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<VerifyVerificationCodeResponse> Verify(
        ActionVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Verify(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VerifyVerificationCodeResponse> Verify(
        string phoneNumber,
        ActionVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Verify(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ActionServiceWithRawResponse : IActionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IActionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ActionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ActionServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<VerifyVerificationCodeResponse>> Verify(
        ActionVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<ActionVerifyParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var verifyVerificationCodeResponse = await response.Deserialize<VerifyVerificationCodeResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                verifyVerificationCodeResponse.Validate();
            }
            return verifyVerificationCodeResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VerifyVerificationCodeResponse>> Verify(
        string phoneNumber,
        ActionVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Verify(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}