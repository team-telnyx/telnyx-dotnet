using System;
using Telnyx.Sdk.Core;
using Whatsapp = Telnyx.Sdk.Services.Whatsapp;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWhatsappService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWhatsappServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWhatsappService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Whatsapp::IBusinessAccountService BusinessAccounts { get; }

    Whatsapp::ITemplateService Templates { get; }

    Whatsapp::IPhoneNumberService PhoneNumbers { get; }

    Whatsapp::IUserDataService UserData { get; }
}

/// <summary>
/// A view of <see cref="IWhatsappService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWhatsappServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWhatsappServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Whatsapp::IBusinessAccountServiceWithRawResponse BusinessAccounts { get; }

    Whatsapp::ITemplateServiceWithRawResponse Templates { get; }

    Whatsapp::IPhoneNumberServiceWithRawResponse PhoneNumbers { get; }

    Whatsapp::IUserDataServiceWithRawResponse UserData { get; }
}