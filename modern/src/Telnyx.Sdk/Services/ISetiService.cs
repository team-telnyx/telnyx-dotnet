using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Seti;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Observability into Telnyx platform stability and performance.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISetiService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISetiServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISetiService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the results of the various black box tests
/// </summary>
    Task<SetiRetrieveBlackBoxTestResultsResponse> RetrieveBlackBoxTestResults(
        SetiRetrieveBlackBoxTestResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISetiService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISetiServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISetiServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /seti/black_box_test_results</c>, but is otherwise the
/// same as <see cref="ISetiService.RetrieveBlackBoxTestResults(SetiRetrieveBlackBoxTestResultsParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SetiRetrieveBlackBoxTestResultsResponse>> RetrieveBlackBoxTestResults(
        SetiRetrieveBlackBoxTestResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}