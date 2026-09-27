using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Verifications;
using Verifications = Telnyx.Sdk.Services.Verifications;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class VerificationService : IVerificationService
{
    readonly Lazy<IVerificationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVerificationServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IVerificationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new VerificationService(this._client.WithOptions(modifier)); }

    public VerificationService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new VerificationServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _byPhoneNumber =new(
            () => new Verifications::ByPhoneNumberService(client)
        ) ;
        _actions =new(() => new Verifications::ActionService(client)) ;
    }

    readonly Lazy<Verifications::IByPhoneNumberService> _byPhoneNumber;
    public Verifications::IByPhoneNumberService ByPhoneNumber {
        get { return _byPhoneNumber.Value; }
    }

    readonly Lazy<Verifications::IActionService> _actions;
    public Verifications::IActionService Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<VerificationRetrieveResponse> Retrieve(
        VerificationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VerificationRetrieveResponse> Retrieve(
        string verificationID,
        VerificationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            VerificationID = verificationID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CreateVerificationResponse> TriggerCall(
        VerificationTriggerCallParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.TriggerCall(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CreateVerificationResponse> TriggerFlashcall(
        VerificationTriggerFlashcallParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.TriggerFlashcall(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CreateVerificationResponse> TriggerSms(
        VerificationTriggerSmsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.TriggerSms(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CreateVerificationResponse> TriggerWhatsappVerification(
        VerificationTriggerWhatsappVerificationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.TriggerWhatsappVerification(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class VerificationServiceWithRawResponse : IVerificationServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVerificationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new VerificationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VerificationServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _byPhoneNumber =new(
            () => new Verifications::ByPhoneNumberServiceWithRawResponse(client)
        ) ;
        _actions =new(
            () => new Verifications::ActionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<Verifications::IByPhoneNumberServiceWithRawResponse> _byPhoneNumber;
    public Verifications::IByPhoneNumberServiceWithRawResponse ByPhoneNumber {
        get { return _byPhoneNumber.Value; }
    }

    readonly Lazy<Verifications::IActionServiceWithRawResponse> _actions;
    public Verifications::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VerificationRetrieveResponse>> Retrieve(
        VerificationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.VerificationID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.VerificationID' cannot be null"
            );
        }

        HttpRequest<VerificationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var verification = await response.Deserialize<VerificationRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                verification.Validate();
            }
            return verification;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VerificationRetrieveResponse>> Retrieve(
        string verificationID,
        VerificationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            VerificationID = verificationID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreateVerificationResponse>> TriggerCall(
        VerificationTriggerCallParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VerificationTriggerCallParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var createVerificationResponse = await response.Deserialize<CreateVerificationResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                createVerificationResponse.Validate();
            }
            return createVerificationResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreateVerificationResponse>> TriggerFlashcall(
        VerificationTriggerFlashcallParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VerificationTriggerFlashcallParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var createVerificationResponse = await response.Deserialize<CreateVerificationResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                createVerificationResponse.Validate();
            }
            return createVerificationResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreateVerificationResponse>> TriggerSms(
        VerificationTriggerSmsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VerificationTriggerSmsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var createVerificationResponse = await response.Deserialize<CreateVerificationResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                createVerificationResponse.Validate();
            }
            return createVerificationResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreateVerificationResponse>> TriggerWhatsappVerification(
        VerificationTriggerWhatsappVerificationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VerificationTriggerWhatsappVerificationParams> request = new(

        )
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var createVerificationResponse = await response.Deserialize<CreateVerificationResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                createVerificationResponse.Validate();
            }
            return createVerificationResponse;
        });
    }
}