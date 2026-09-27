using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Whatsapp.PhoneNumbers;
using Telnyx.Sdk.Services.Whatsapp.PhoneNumbers;

namespace Telnyx.Sdk.Services.Whatsapp;

/// <inheritdoc/>
public sealed class PhoneNumberService : IPhoneNumberService
{
    readonly Lazy<IPhoneNumberServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPhoneNumberServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPhoneNumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new PhoneNumberService(this._client.WithOptions(modifier)); }

    public PhoneNumberService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PhoneNumberServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _callingSettings =new(() => new CallingSettingService(client)) ;
        _profile =new(() => new ProfileService(client)) ;
        _conversationalComponents =new(
            () => new ConversationalComponentService(client)
        ) ;
    }

    readonly Lazy<ICallingSettingService> _callingSettings;
    public ICallingSettingService CallingSettings {
        get { return _callingSettings.Value; }
    }

    readonly Lazy<IProfileService> _profile;
    public IProfileService Profile { get { return _profile.Value; } }

    readonly Lazy<IConversationalComponentService> _conversationalComponents;
    public IConversationalComponentService ConversationalComponents {
        get { return _conversationalComponents.Value; }
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberListPage> List(
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        PhoneNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string phoneNumber,
        PhoneNumberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberGetResponse> Get(
        PhoneNumberGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Get(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task ResendVerification(
        PhoneNumberResendVerificationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ResendVerification(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task ResendVerification(
        string phoneNumber,
        PhoneNumberResendVerificationParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.ResendVerification(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberRetrieveConversationWindowResponse> RetrieveConversationWindow(
        PhoneNumberRetrieveConversationWindowParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveConversationWindow(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberRetrieveConversationWindowResponse> RetrieveConversationWindow(
        string phoneNumber,
        PhoneNumberRetrieveConversationWindowParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveConversationWindow(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberRetrievePhoneNumberResponse> RetrievePhoneNumber(
        PhoneNumberRetrievePhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrievePhoneNumber(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberRetrievePhoneNumberResponse> RetrievePhoneNumber(
        string phoneNumber,
        PhoneNumberRetrievePhoneNumberParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrievePhoneNumber(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Verify(
        PhoneNumberVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Verify(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Verify(
        string phoneNumber,
        PhoneNumberVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Verify(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PhoneNumberServiceWithRawResponse : IPhoneNumberServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhoneNumberServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PhoneNumberServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _callingSettings =new(
            () => new CallingSettingServiceWithRawResponse(client)
        ) ;
        _profile =new(() => new ProfileServiceWithRawResponse(client)) ;
        _conversationalComponents =new(
            () => new ConversationalComponentServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<ICallingSettingServiceWithRawResponse> _callingSettings;
    public ICallingSettingServiceWithRawResponse CallingSettings {
        get { return _callingSettings.Value; }
    }

    readonly Lazy<IProfileServiceWithRawResponse> _profile;
    public IProfileServiceWithRawResponse Profile {
        get { return _profile.Value; }
    }

    readonly Lazy<IConversationalComponentServiceWithRawResponse> _conversationalComponents;
    public IConversationalComponentServiceWithRawResponse ConversationalComponents {
        get { return _conversationalComponents.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberListPage>> List(
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PhoneNumberListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PhoneNumberListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new PhoneNumberListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        PhoneNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<PhoneNumberDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string phoneNumber,
        PhoneNumberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberGetResponse>> Get(
        PhoneNumberGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PhoneNumberGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var phoneNumber = await response.Deserialize<PhoneNumberGetResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                phoneNumber.Validate();
            }
            return phoneNumber;
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ResendVerification(
        PhoneNumberResendVerificationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<PhoneNumberResendVerificationParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> ResendVerification(
        string phoneNumber,
        PhoneNumberResendVerificationParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ResendVerification(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberRetrieveConversationWindowResponse>> RetrieveConversationWindow(
        PhoneNumberRetrieveConversationWindowParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<PhoneNumberRetrieveConversationWindowParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<PhoneNumberRetrieveConversationWindowResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberRetrieveConversationWindowResponse>> RetrieveConversationWindow(
        string phoneNumber,
        PhoneNumberRetrieveConversationWindowParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveConversationWindow(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberRetrievePhoneNumberResponse>> RetrievePhoneNumber(
        PhoneNumberRetrievePhoneNumberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<PhoneNumberRetrievePhoneNumberParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<PhoneNumberRetrievePhoneNumberResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberRetrievePhoneNumberResponse>> RetrievePhoneNumber(
        string phoneNumber,
        PhoneNumberRetrievePhoneNumberParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrievePhoneNumber(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Verify(
        PhoneNumberVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<PhoneNumberVerifyParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Verify(
        string phoneNumber,
        PhoneNumberVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Verify(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}