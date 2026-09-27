using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Porting;
using Porting = Telnyx.Sdk.Services.Porting;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Endpoints related to porting orders management.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPortingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPortingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPortingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Porting::IEventService Events { get; }

    Porting::IReportService Reports { get; }

    Porting::ILoaConfigurationService LoaConfigurations { get; }

    /// <summary>
/// Returns the list of UK carriers available for porting, for use when preparing
/// porting orders for UK numbers.
/// </summary>
    Task<PortingListUkCarriersResponse> ListUkCarriers(
        PortingListUkCarriersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPortingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPortingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPortingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Porting::IEventServiceWithRawResponse Events { get; }

    Porting::IReportServiceWithRawResponse Reports { get; }

    Porting::ILoaConfigurationServiceWithRawResponse LoaConfigurations { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /porting/uk_carriers</c>, but is otherwise the
/// same as <see cref="IPortingService.ListUkCarriers(PortingListUkCarriersParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PortingListUkCarriersResponse>> ListUkCarriers(
        PortingListUkCarriersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}