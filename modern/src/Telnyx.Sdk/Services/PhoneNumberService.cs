using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.PhoneNumbers;
using PhoneNumbers = Telnyx.Sdk.Services.PhoneNumbers;

namespace Telnyx.Sdk.Services;

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
        _actions =new(() => new PhoneNumbers::ActionService(client)) ;
        _csvDownloads =new(() => new PhoneNumbers::CsvDownloadService(client)) ;
        _jobs =new(() => new PhoneNumbers::JobService(client)) ;
        _messaging =new(() => new PhoneNumbers::MessagingService(client)) ;
        _voice =new(() => new PhoneNumbers::VoiceService(client)) ;
        _voicemail =new(() => new PhoneNumbers::VoicemailService(client)) ;
    }

    readonly Lazy<PhoneNumbers::IActionService> _actions;
    public PhoneNumbers::IActionService Actions {
        get { return _actions.Value; }
    }

    readonly Lazy<PhoneNumbers::ICsvDownloadService> _csvDownloads;
    public PhoneNumbers::ICsvDownloadService CsvDownloads {
        get { return _csvDownloads.Value; }
    }

    readonly Lazy<PhoneNumbers::IJobService> _jobs;
    public PhoneNumbers::IJobService Jobs { get { return _jobs.Value; } }

    readonly Lazy<PhoneNumbers::IMessagingService> _messaging;
    public PhoneNumbers::IMessagingService Messaging {
        get { return _messaging.Value; }
    }

    readonly Lazy<PhoneNumbers::IVoiceService> _voice;
    public PhoneNumbers::IVoiceService Voice { get { return _voice.Value; } }

    readonly Lazy<PhoneNumbers::IVoicemailService> _voicemail;
    public PhoneNumbers::IVoicemailService Voicemail {
        get { return _voicemail.Value; }
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberRetrieveResponse> Retrieve(
        PhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberRetrieveResponse> Retrieve(
        string id,
        PhoneNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberUpdateResponse> Update(
        PhoneNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberUpdateResponse> Update(
        string phoneNumberID,
        PhoneNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            PhoneNumberID = phoneNumberID
        }, cancellationToken);
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
    public async Task<PhoneNumberDeleteResponse> Delete(
        PhoneNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberDeleteResponse> Delete(
        string id,
        PhoneNumberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberSlimListPage> SlimList(
        PhoneNumberSlimListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.SlimList(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
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

        _actions =new(
            () => new PhoneNumbers::ActionServiceWithRawResponse(client)
        ) ;
        _csvDownloads =new(
            () => new PhoneNumbers::CsvDownloadServiceWithRawResponse(client)
        ) ;
        _jobs =new(() => new PhoneNumbers::JobServiceWithRawResponse(client)) ;
        _messaging =new(
            () => new PhoneNumbers::MessagingServiceWithRawResponse(client)
        ) ;
        _voice =new(
            () => new PhoneNumbers::VoiceServiceWithRawResponse(client)
        ) ;
        _voicemail =new(
            () => new PhoneNumbers::VoicemailServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<PhoneNumbers::IActionServiceWithRawResponse> _actions;
    public PhoneNumbers::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    readonly Lazy<PhoneNumbers::ICsvDownloadServiceWithRawResponse> _csvDownloads;
    public PhoneNumbers::ICsvDownloadServiceWithRawResponse CsvDownloads {
        get { return _csvDownloads.Value; }
    }

    readonly Lazy<PhoneNumbers::IJobServiceWithRawResponse> _jobs;
    public PhoneNumbers::IJobServiceWithRawResponse Jobs {
        get { return _jobs.Value; }
    }

    readonly Lazy<PhoneNumbers::IMessagingServiceWithRawResponse> _messaging;
    public PhoneNumbers::IMessagingServiceWithRawResponse Messaging {
        get { return _messaging.Value; }
    }

    readonly Lazy<PhoneNumbers::IVoiceServiceWithRawResponse> _voice;
    public PhoneNumbers::IVoiceServiceWithRawResponse Voice {
        get { return _voice.Value; }
    }

    readonly Lazy<PhoneNumbers::IVoicemailServiceWithRawResponse> _voicemail;
    public PhoneNumbers::IVoicemailServiceWithRawResponse Voicemail {
        get { return _voicemail.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberRetrieveResponse>> Retrieve(
        PhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PhoneNumberRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var phoneNumber = await response.Deserialize<PhoneNumberRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                phoneNumber.Validate();
            }
            return phoneNumber;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberRetrieveResponse>> Retrieve(
        string id,
        PhoneNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberUpdateResponse>> Update(
        PhoneNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumberID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumberID' cannot be null"
            );
        }

        HttpRequest<PhoneNumberUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var phoneNumber = await response.Deserialize<PhoneNumberUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                phoneNumber.Validate();
            }
            return phoneNumber;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberUpdateResponse>> Update(
        string phoneNumberID,
        PhoneNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            PhoneNumberID = phoneNumberID
        }, cancellationToken);
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
    public async Task<HttpResponse<PhoneNumberDeleteResponse>> Delete(
        PhoneNumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PhoneNumberDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var phoneNumber = await response.Deserialize<PhoneNumberDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                phoneNumber.Validate();
            }
            return phoneNumber;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberDeleteResponse>> Delete(
        string id,
        PhoneNumberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberSlimListPage>> SlimList(
        PhoneNumberSlimListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PhoneNumberSlimListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PhoneNumberSlimListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new PhoneNumberSlimListPage(this, parameters, page);
        });
    }
}