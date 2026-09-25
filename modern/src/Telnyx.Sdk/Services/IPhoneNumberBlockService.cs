using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.PhoneNumberBlocks;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPhoneNumberBlockService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPhoneNumberBlockServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberBlockService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IJobService Jobs { get; }
}

/// <summary>
/// A view of <see cref="IPhoneNumberBlockService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPhoneNumberBlockServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberBlockServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    IJobServiceWithRawResponse Jobs { get; }
}