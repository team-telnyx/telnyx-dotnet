using System;
using Telnyx.Sdk.Core;
using ExternalRequirements = Telnyx.Sdk.Services.ExternalRequirements;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IExternalRequirementService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExternalRequirementServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalRequirementService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    ExternalRequirements::ISubNumberOrderService SubNumberOrders { get; }
}

/// <summary>
/// A view of <see cref="IExternalRequirementService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExternalRequirementServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalRequirementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    ExternalRequirements::ISubNumberOrderServiceWithRawResponse SubNumberOrders {
        get;
    }
}