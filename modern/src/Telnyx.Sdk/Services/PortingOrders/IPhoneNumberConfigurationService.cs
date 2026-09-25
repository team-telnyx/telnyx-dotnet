using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PortingOrders.PhoneNumberConfigurations;

namespace Telnyx.Sdk.Services.PortingOrders;

/// <summary>
/// Endpoints related to porting orders management.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPhoneNumberConfigurationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPhoneNumberConfigurationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberConfigurationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a list of phone number configurations.
/// </summary>
    Task<PhoneNumberConfigurationCreateResponse> Create(
        PhoneNumberConfigurationCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of phone number configurations paginated.
/// </summary>
    Task<PhoneNumberConfigurationListPage> List(
        PhoneNumberConfigurationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPhoneNumberConfigurationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPhoneNumberConfigurationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberConfigurationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /porting_orders/phone_number_configurations</c>, but is otherwise the
/// same as <see cref="IPhoneNumberConfigurationService.Create(PhoneNumberConfigurationCreateParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberConfigurationCreateResponse>> Create(
        PhoneNumberConfigurationCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting_orders/phone_number_configurations</c>, but is otherwise the
/// same as <see cref="IPhoneNumberConfigurationService.List(PhoneNumberConfigurationListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberConfigurationListPage>> List(
        PhoneNumberConfigurationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}