using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Verifications.Actions;
using Actions = Telnyx.Sdk.Models.Verifications.ByPhoneNumber.Actions;

namespace Telnyx.Sdk.Services.Verifications;

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
    public async Task<Actions::VerifyVerificationCodeResponse> Verify(
        ActionVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Verify(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<Actions::VerifyVerificationCodeResponse> Verify(
        string verificationID,
        ActionVerifyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Verify(parameters with{
            VerificationID = verificationID
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
    public async Task<HttpResponse<Actions::VerifyVerificationCodeResponse>> Verify(
        ActionVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VerificationID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.VerificationID' cannot be null"
            );
        }

        HttpRequest<ActionVerifyParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var verifyVerificationCodeResponse = await response.Deserialize<Actions::VerifyVerificationCodeResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                verifyVerificationCodeResponse.Validate();
            }
            return verifyVerificationCodeResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<Actions::VerifyVerificationCodeResponse>> Verify(
        string verificationID,
        ActionVerifyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Verify(parameters with{
            VerificationID = verificationID
        }, cancellationToken);
    }
}