using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.PhoneNumbers.Voicemail;

namespace Telnyx.Sdk.Services.PhoneNumbers;

/// <inheritdoc/>
public sealed class VoicemailService : IVoicemailService
{
    readonly Lazy<IVoicemailServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVoicemailServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IVoicemailService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new VoicemailService(this._client.WithOptions(modifier)); }

    public VoicemailService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new VoicemailServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<VoicemailCreateResponse> Create(
        VoicemailCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VoicemailCreateResponse> Create(
        string phoneNumberID,
        VoicemailCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            PhoneNumberID = phoneNumberID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VoicemailRetrieveResponse> Retrieve(
        VoicemailRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VoicemailRetrieveResponse> Retrieve(
        string phoneNumberID,
        VoicemailRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            PhoneNumberID = phoneNumberID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<VoicemailUpdateResponse> Update(
        VoicemailUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<VoicemailUpdateResponse> Update(
        string phoneNumberID,
        VoicemailUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            PhoneNumberID = phoneNumberID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class VoicemailServiceWithRawResponse : IVoicemailServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVoicemailServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new VoicemailServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VoicemailServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<VoicemailCreateResponse>> Create(
        VoicemailCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumberID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumberID' cannot be null"
            );
        }

        HttpRequest<VoicemailCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var voicemail = await response.Deserialize<VoicemailCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                voicemail.Validate();
            }
            return voicemail;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VoicemailCreateResponse>> Create(
        string phoneNumberID,
        VoicemailCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            PhoneNumberID = phoneNumberID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VoicemailRetrieveResponse>> Retrieve(
        VoicemailRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumberID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumberID' cannot be null"
            );
        }

        HttpRequest<VoicemailRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var voicemail = await response.Deserialize<VoicemailRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                voicemail.Validate();
            }
            return voicemail;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VoicemailRetrieveResponse>> Retrieve(
        string phoneNumberID,
        VoicemailRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            PhoneNumberID = phoneNumberID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<VoicemailUpdateResponse>> Update(
        VoicemailUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumberID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumberID' cannot be null"
            );
        }

        HttpRequest<VoicemailUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var voicemail = await response.Deserialize<VoicemailUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                voicemail.Validate();
            }
            return voicemail;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<VoicemailUpdateResponse>> Update(
        string phoneNumberID,
        VoicemailUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            PhoneNumberID = phoneNumberID
        }, cancellationToken);
    }
}