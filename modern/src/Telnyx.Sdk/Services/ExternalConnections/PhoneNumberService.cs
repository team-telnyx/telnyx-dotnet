using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.ExternalConnections.PhoneNumbers;

namespace Telnyx.Sdk.Services.ExternalConnections;

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
        string phoneNumberID,
        PhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            PhoneNumberID = phoneNumberID
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
        PhoneNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            PhoneNumberID = phoneNumberID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberListPage> List(
        PhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberListPage> List(
        string id,
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
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
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberRetrieveResponse>> Retrieve(
        PhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumberID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumberID' cannot be null"
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
        string phoneNumberID,
        PhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            PhoneNumberID = phoneNumberID
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
        PhoneNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            PhoneNumberID = phoneNumberID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberListPage>> List(
        PhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

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
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberListPage>> List(
        string id,
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }
}