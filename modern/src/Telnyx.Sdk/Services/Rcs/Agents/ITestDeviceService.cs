using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Rcs.Agents.TestDevices;

namespace Telnyx.Sdk.Services.Rcs.Agents;

/// <summary>
/// Manage RCS agent registration, testing, verification, and launch.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITestDeviceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITestDeviceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITestDeviceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Adds an RCS-capable test number after provider agent creation. Repeating the
/// request for a number already attached to the agent returns the existing test
/// device.
/// </summary>
    Task<TestDeviceResponse> Create(
        TestDeviceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(TestDeviceCreateParams, CancellationToken)"/>
    Task<TestDeviceResponse> Create(
        string id,
        TestDeviceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists test devices attached to an RCS agent.
/// </summary>
    Task<List<TestDeviceResponse>> List(
        TestDeviceListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(TestDeviceListParams, CancellationToken)"/>
    Task<List<TestDeviceResponse>> List(
        string id,
        TestDeviceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Removes a test device from an RCS agent and its provider registration.
/// </summary>
    Task Delete(
        TestDeviceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(TestDeviceDeleteParams, CancellationToken)"/>
    Task Delete(
        string testDeviceID,
        TestDeviceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ITestDeviceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITestDeviceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITestDeviceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /rcs/agents/{id}/test_devices</c>, but is otherwise the
/// same as <see cref="ITestDeviceService.Create(TestDeviceCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TestDeviceResponse>> Create(
        TestDeviceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(TestDeviceCreateParams, CancellationToken)"/>
    Task<HttpResponse<TestDeviceResponse>> Create(
        string id,
        TestDeviceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /rcs/agents/{id}/test_devices</c>, but is otherwise the
/// same as <see cref="ITestDeviceService.List(TestDeviceListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<List<TestDeviceResponse>>> List(
        TestDeviceListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(TestDeviceListParams, CancellationToken)"/>
    Task<HttpResponse<List<TestDeviceResponse>>> List(
        string id,
        TestDeviceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /rcs/agents/{id}/test_devices/{test_device_id}</c>, but is otherwise the
/// same as <see cref="ITestDeviceService.Delete(TestDeviceDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        TestDeviceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(TestDeviceDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string testDeviceID,
        TestDeviceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}