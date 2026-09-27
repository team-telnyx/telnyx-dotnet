using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Verifications.ByPhoneNumber;
using ByPhoneNumber = Telnyx.Sdk.Services.Verifications.ByPhoneNumber;

namespace Telnyx.Sdk.Services.Verifications;

/// <inheritdoc/>
public sealed class ByPhoneNumberService : IByPhoneNumberService
{
    readonly Lazy<IByPhoneNumberServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IByPhoneNumberServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IByPhoneNumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ByPhoneNumberService(this._client.WithOptions(modifier)); }

    public ByPhoneNumberService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ByPhoneNumberServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _actions =new(() => new ByPhoneNumber::ActionService(client)) ;
    }

    readonly Lazy<ByPhoneNumber::IActionService> _actions;
    public ByPhoneNumber::IActionService Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<ByPhoneNumberListResponse> List(
        ByPhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ByPhoneNumberListResponse> List(
        string phoneNumber,
        ByPhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ByPhoneNumberServiceWithRawResponse : IByPhoneNumberServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IByPhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ByPhoneNumberServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ByPhoneNumberServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _actions =new(
            () => new ByPhoneNumber::ActionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<ByPhoneNumber::IActionServiceWithRawResponse> _actions;
    public ByPhoneNumber::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ByPhoneNumberListResponse>> List(
        ByPhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<ByPhoneNumberListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var byPhoneNumbers = await response.Deserialize<ByPhoneNumberListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                byPhoneNumbers.Validate();
            }
            return byPhoneNumbers;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ByPhoneNumberListResponse>> List(
        string phoneNumber,
        ByPhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}