using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.NumbersFeatures;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface INumbersFeatureService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INumbersFeatureServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumbersFeatureService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Retrieve the features for a list of numbers
/// </summary>
    Task<NumbersFeatureCreateResponse> Create(
        NumbersFeatureCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="INumbersFeatureService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INumbersFeatureServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumbersFeatureServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /numbers_features</c>, but is otherwise the
/// same as <see cref="INumbersFeatureService.Create(NumbersFeatureCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumbersFeatureCreateResponse>> Create(
        NumbersFeatureCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}