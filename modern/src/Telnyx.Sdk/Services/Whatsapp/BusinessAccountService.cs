using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Whatsapp.BusinessAccounts;
using BusinessAccounts = Telnyx.Sdk.Services.Whatsapp.BusinessAccounts;

namespace Telnyx.Sdk.Services.Whatsapp;

/// <inheritdoc/>
public sealed class BusinessAccountService : IBusinessAccountService
{
    readonly Lazy<IBusinessAccountServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBusinessAccountServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IBusinessAccountService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new BusinessAccountService(this._client.WithOptions(modifier)); }

    public BusinessAccountService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new BusinessAccountServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _phoneNumbers =new(
            () => new BusinessAccounts::PhoneNumberService(client)
        ) ;
        _settings =new(() => new BusinessAccounts::SettingService(client)) ;
    }

    readonly Lazy<BusinessAccounts::IPhoneNumberService> _phoneNumbers;
    public BusinessAccounts::IPhoneNumberService PhoneNumbers {
        get { return _phoneNumbers.Value; }
    }

    readonly Lazy<BusinessAccounts::ISettingService> _settings;
    public BusinessAccounts::ISettingService Settings {
        get { return _settings.Value; }
    }

    /// <inheritdoc/>
    public async Task<BusinessAccountRetrieveResponse> Retrieve(
        BusinessAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<BusinessAccountRetrieveResponse> Retrieve(
        string id,
        BusinessAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BusinessAccountListPage> List(
        BusinessAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        BusinessAccountDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string id,
        BusinessAccountDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            ID = id
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BusinessAccountServiceWithRawResponse : IBusinessAccountServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBusinessAccountServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BusinessAccountServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BusinessAccountServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _phoneNumbers =new(
            () => new BusinessAccounts::PhoneNumberServiceWithRawResponse(
                client
            )
        ) ;
        _settings =new(
            () => new BusinessAccounts::SettingServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<BusinessAccounts::IPhoneNumberServiceWithRawResponse> _phoneNumbers;
    public BusinessAccounts::IPhoneNumberServiceWithRawResponse PhoneNumbers {
        get { return _phoneNumbers.Value; }
    }

    readonly Lazy<BusinessAccounts::ISettingServiceWithRawResponse> _settings;
    public BusinessAccounts::ISettingServiceWithRawResponse Settings {
        get { return _settings.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BusinessAccountRetrieveResponse>> Retrieve(
        BusinessAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<BusinessAccountRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var businessAccount = await response.Deserialize<BusinessAccountRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                businessAccount.Validate();
            }
            return businessAccount;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<BusinessAccountRetrieveResponse>> Retrieve(
        string id,
        BusinessAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BusinessAccountListPage>> List(
        BusinessAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BusinessAccountListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<BusinessAccountListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new BusinessAccountListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        BusinessAccountDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<BusinessAccountDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        BusinessAccountDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}