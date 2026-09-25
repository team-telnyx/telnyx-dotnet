using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.VerifiedNumbers;
using Telnyx.Sdk.Models.VerifiedNumbers.Actions;

namespace Telnyx.Sdk.Services.VerifiedNumbers;

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
    public async Task<VerifiedNumberDataWrapper> SubmitVerificationCode(
        ActionSubmitVerificationCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.SubmitVerificationCode(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VerifiedNumberDataWrapper> SubmitVerificationCode(
        string phoneNumber,
        ActionSubmitVerificationCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SubmitVerificationCode(parameters with{
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
    public async Task<HttpResponse<VerifiedNumberDataWrapper>> SubmitVerificationCode(
        ActionSubmitVerificationCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<ActionSubmitVerificationCodeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var verifiedNumberDataWrapper = await response.Deserialize<VerifiedNumberDataWrapper>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                verifiedNumberDataWrapper.Validate();
            }
            return verifiedNumberDataWrapper;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VerifiedNumberDataWrapper>> SubmitVerificationCode(
        string phoneNumber,
        ActionSubmitVerificationCodeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SubmitVerificationCode(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}