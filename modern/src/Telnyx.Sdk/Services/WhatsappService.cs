using System;
using Telnyx.Sdk.Core;
using Whatsapp = Telnyx.Sdk.Services.Whatsapp;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class WhatsappService : IWhatsappService
{
    readonly Lazy<IWhatsappServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWhatsappServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IWhatsappService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new WhatsappService(this._client.WithOptions(modifier)); }

    public WhatsappService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new WhatsappServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _businessAccounts =new(
            () => new Whatsapp::BusinessAccountService(client)
        ) ;
        _templates =new(() => new Whatsapp::TemplateService(client)) ;
        _phoneNumbers =new(() => new Whatsapp::PhoneNumberService(client)) ;
        _userData =new(() => new Whatsapp::UserDataService(client)) ;
    }

    readonly Lazy<Whatsapp::IBusinessAccountService> _businessAccounts;
    public Whatsapp::IBusinessAccountService BusinessAccounts {
        get { return _businessAccounts.Value; }
    }

    readonly Lazy<Whatsapp::ITemplateService> _templates;
    public Whatsapp::ITemplateService Templates {
        get { return _templates.Value; }
    }

    readonly Lazy<Whatsapp::IPhoneNumberService> _phoneNumbers;
    public Whatsapp::IPhoneNumberService PhoneNumbers {
        get { return _phoneNumbers.Value; }
    }

    readonly Lazy<Whatsapp::IUserDataService> _userData;
    public Whatsapp::IUserDataService UserData {
        get { return _userData.Value; }
    }
}

/// <inheritdoc/>
public sealed class WhatsappServiceWithRawResponse : IWhatsappServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWhatsappServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WhatsappServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WhatsappServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _businessAccounts =new(
            () => new Whatsapp::BusinessAccountServiceWithRawResponse(client)
        ) ;
        _templates =new(
            () => new Whatsapp::TemplateServiceWithRawResponse(client)
        ) ;
        _phoneNumbers =new(
            () => new Whatsapp::PhoneNumberServiceWithRawResponse(client)
        ) ;
        _userData =new(
            () => new Whatsapp::UserDataServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<Whatsapp::IBusinessAccountServiceWithRawResponse> _businessAccounts;
    public Whatsapp::IBusinessAccountServiceWithRawResponse BusinessAccounts {
        get { return _businessAccounts.Value; }
    }

    readonly Lazy<Whatsapp::ITemplateServiceWithRawResponse> _templates;
    public Whatsapp::ITemplateServiceWithRawResponse Templates {
        get { return _templates.Value; }
    }

    readonly Lazy<Whatsapp::IPhoneNumberServiceWithRawResponse> _phoneNumbers;
    public Whatsapp::IPhoneNumberServiceWithRawResponse PhoneNumbers {
        get { return _phoneNumbers.Value; }
    }

    readonly Lazy<Whatsapp::IUserDataServiceWithRawResponse> _userData;
    public Whatsapp::IUserDataServiceWithRawResponse UserData {
        get { return _userData.Value; }
    }
}