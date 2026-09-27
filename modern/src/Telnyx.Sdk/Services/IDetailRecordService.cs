using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.DetailRecords;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Detail Records operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IDetailRecordService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDetailRecordServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDetailRecordService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Search for any detail record across the Telnyx Platform
/// </summary>
    Task<DetailRecordListPage> List(
        DetailRecordListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IDetailRecordService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDetailRecordServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDetailRecordServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /detail_records</c>, but is otherwise the
/// same as <see cref="IDetailRecordService.List(DetailRecordListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DetailRecordListPage>> List(
        DetailRecordListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}