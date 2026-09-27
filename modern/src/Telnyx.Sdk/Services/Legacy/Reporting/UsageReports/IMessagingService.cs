using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Legacy.Reporting.UsageReports.Messaging;

namespace Telnyx.Sdk.Services.Legacy.Reporting.UsageReports;

/// <summary>
/// Messaging usage reports
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMessagingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessagingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates a new legacy usage V2 MDR report request with the specified filters
/// </summary>
    Task<MessagingCreateResponse> Create(
        MessagingCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a single MDR (Message Detail Record) usage report by its identifier,
/// including its parameters and current status.
/// </summary>
    Task<MessagingRetrieveResponse> Retrieve(
        MessagingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MessagingRetrieveParams, CancellationToken)"/>
    Task<MessagingRetrieveResponse> Retrieve(
        string id,
        MessagingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Fetch all previous requests for MDR usage reports.
/// </summary>
    Task<MessagingListPage> List(
        MessagingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes a specific V2 legacy usage MDR report request by ID
/// </summary>
    Task<MessagingDeleteResponse> Delete(
        MessagingDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MessagingDeleteParams, CancellationToken)"/>
    Task<MessagingDeleteResponse> Delete(
        string id,
        MessagingDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMessagingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessagingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /legacy/reporting/usage_reports/messaging</c>, but is otherwise the
/// same as <see cref="IMessagingService.Create(MessagingCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingCreateResponse>> Create(
        MessagingCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /legacy/reporting/usage_reports/messaging/{id}</c>, but is otherwise the
/// same as <see cref="IMessagingService.Retrieve(MessagingRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingRetrieveResponse>> Retrieve(
        MessagingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MessagingRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MessagingRetrieveResponse>> Retrieve(
        string id,
        MessagingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /legacy/reporting/usage_reports/messaging</c>, but is otherwise the
/// same as <see cref="IMessagingService.List(MessagingListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingListPage>> List(
        MessagingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /legacy/reporting/usage_reports/messaging/{id}</c>, but is otherwise the
/// same as <see cref="IMessagingService.Delete(MessagingDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingDeleteResponse>> Delete(
        MessagingDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MessagingDeleteParams, CancellationToken)"/>
    Task<HttpResponse<MessagingDeleteResponse>> Delete(
        string id,
        MessagingDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}