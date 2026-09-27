using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailMessages.Recipients;

namespace Telnyx.Sdk.Services.EmailMessages;

/// <summary>
/// Send and manage email messages. Legacy `/v2/emails` routes are aliases for these endpoints.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRecipientService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRecipientServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRecipientService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns the current delivery state of a single recipient, including status,
/// billable flag, SMTP detail, and lifecycle timestamps. BCC recipient addresses
/// are redacted (returned as null).
/// </summary>
    Task<RecipientRetrieveResponse> Retrieve(
        RecipientRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RecipientRetrieveParams, CancellationToken)"/>
    Task<RecipientRetrieveResponse> Retrieve(
        string recipientID,
        RecipientRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists per-recipient delivery states for a single message with cursor pagination.
/// Each recipient has an independent status, billable flag, and lifecycle
/// timestamps. BCC recipient addresses are redacted (returned as null) to protect
/// BCC privacy. Default page size is 25, maximum is 100.
/// </summary>
    Task<RecipientListPage> List(
        RecipientListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(RecipientListParams, CancellationToken)"/>
    Task<RecipientListPage> List(
        string emailID,
        RecipientListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRecipientService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRecipientServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRecipientServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_messages/{email_id}/recipients/{recipient_id}</c>, but is otherwise the
/// same as <see cref="IRecipientService.Retrieve(RecipientRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RecipientRetrieveResponse>> Retrieve(
        RecipientRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RecipientRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RecipientRetrieveResponse>> Retrieve(
        string recipientID,
        RecipientRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_messages/{email_id}/recipients</c>, but is otherwise the
/// same as <see cref="IRecipientService.List(RecipientListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RecipientListPage>> List(
        RecipientListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(RecipientListParams, CancellationToken)"/>
    Task<HttpResponse<RecipientListPage>> List(
        string emailID,
        RecipientListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}