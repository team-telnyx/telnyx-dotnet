using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AvailablePhoneNumberBlocks;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Number search
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAvailablePhoneNumberBlockService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAvailablePhoneNumberBlockServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAvailablePhoneNumberBlockService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Searches the Telnyx inventory for available contiguous phone-number blocks.
/// Results can be filtered by locality, country, national destination code, and
/// number type.
/// </summary>
    Task<AvailablePhoneNumberBlockListResponse> List(
        AvailablePhoneNumberBlockListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAvailablePhoneNumberBlockService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAvailablePhoneNumberBlockServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAvailablePhoneNumberBlockServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /available_phone_number_blocks</c>, but is otherwise the
/// same as <see cref="IAvailablePhoneNumberBlockService.List(AvailablePhoneNumberBlockListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AvailablePhoneNumberBlockListResponse>> List(
        AvailablePhoneNumberBlockListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}