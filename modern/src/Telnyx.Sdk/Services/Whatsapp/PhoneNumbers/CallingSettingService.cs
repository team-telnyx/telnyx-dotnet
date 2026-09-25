using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Whatsapp.PhoneNumbers.CallingSettings;

namespace Telnyx.Sdk.Services.Whatsapp.PhoneNumbers;

/// <inheritdoc/>
public sealed class CallingSettingService : ICallingSettingService
{
    readonly Lazy<ICallingSettingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICallingSettingServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICallingSettingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new CallingSettingService(this._client.WithOptions(modifier)); }

    public CallingSettingService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CallingSettingServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<CallingSettingRetrieveResponse> Retrieve(
        CallingSettingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CallingSettingRetrieveResponse> Retrieve(
        string phoneNumber,
        CallingSettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CallingSettingUpdateResponse> Update(
        CallingSettingUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CallingSettingUpdateResponse> Update(
        string phoneNumber,
        CallingSettingUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CallingSettingServiceWithRawResponse : ICallingSettingServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICallingSettingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CallingSettingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CallingSettingServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallingSettingRetrieveResponse>> Retrieve(
        CallingSettingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<CallingSettingRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var callingSetting = await response.Deserialize<CallingSettingRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                callingSetting.Validate();
            }
            return callingSetting;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CallingSettingRetrieveResponse>> Retrieve(
        string phoneNumber,
        CallingSettingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallingSettingUpdateResponse>> Update(
        CallingSettingUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<CallingSettingUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var callingSetting = await response.Deserialize<CallingSettingUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                callingSetting.Validate();
            }
            return callingSetting;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CallingSettingUpdateResponse>> Update(
        string phoneNumber,
        CallingSettingUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}