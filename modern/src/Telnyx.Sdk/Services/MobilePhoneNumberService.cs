using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.MobilePhoneNumbers;
using MobilePhoneNumbers = Telnyx.Sdk.Services.MobilePhoneNumbers;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class MobilePhoneNumberService : IMobilePhoneNumberService
{
    readonly Lazy<IMobilePhoneNumberServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMobilePhoneNumberServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMobilePhoneNumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MobilePhoneNumberService(this._client.WithOptions(modifier)); }

    public MobilePhoneNumberService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MobilePhoneNumberServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _messaging =new(
            () => new MobilePhoneNumbers::MessagingService(client)
        ) ;
    }

    readonly Lazy<MobilePhoneNumbers::IMessagingService> _messaging;
    public MobilePhoneNumbers::IMessagingService Messaging {
        get { return _messaging.Value; }
    }

    /// <inheritdoc/>
    public async Task<MobilePhoneNumberRetrieveResponse> Retrieve(
        MobilePhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MobilePhoneNumberRetrieveResponse> Retrieve(
        string id,
        MobilePhoneNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MobilePhoneNumberUpdateResponse> Update(
        MobilePhoneNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MobilePhoneNumberUpdateResponse> Update(
        string id,
        MobilePhoneNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MobilePhoneNumberListPage> List(
        MobilePhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MobilePhoneNumberServiceWithRawResponse : IMobilePhoneNumberServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMobilePhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MobilePhoneNumberServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MobilePhoneNumberServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _messaging =new(
            () => new MobilePhoneNumbers::MessagingServiceWithRawResponse(
                client
            )
        ) ;
    }

    readonly Lazy<MobilePhoneNumbers::IMessagingServiceWithRawResponse> _messaging;
    public MobilePhoneNumbers::IMessagingServiceWithRawResponse Messaging {
        get { return _messaging.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MobilePhoneNumberRetrieveResponse>> Retrieve(
        MobilePhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MobilePhoneNumberRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var mobilePhoneNumber = await response.Deserialize<MobilePhoneNumberRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                mobilePhoneNumber.Validate();
            }
            return mobilePhoneNumber;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MobilePhoneNumberRetrieveResponse>> Retrieve(
        string id,
        MobilePhoneNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MobilePhoneNumberUpdateResponse>> Update(
        MobilePhoneNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MobilePhoneNumberUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var mobilePhoneNumber = await response.Deserialize<MobilePhoneNumberUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                mobilePhoneNumber.Validate();
            }
            return mobilePhoneNumber;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MobilePhoneNumberUpdateResponse>> Update(
        string id,
        MobilePhoneNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MobilePhoneNumberListPage>> List(
        MobilePhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MobilePhoneNumberListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MobilePhoneNumberListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MobilePhoneNumberListPage(this, parameters, page);
        });
    }
}