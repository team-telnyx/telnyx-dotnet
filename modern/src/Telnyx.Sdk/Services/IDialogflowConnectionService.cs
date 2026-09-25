using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.DialogflowConnections;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Dialogflow Connection Operations.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IDialogflowConnectionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDialogflowConnectionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDialogflowConnectionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Save Dialogflow Credentiails to Telnyx, so it can be used with other Telnyx
/// services.
/// </summary>
    Task<DialogflowConnectionResponse> Create(
        DialogflowConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(DialogflowConnectionCreateParams, CancellationToken)"/>
    Task<DialogflowConnectionResponse> Create(
        string connectionID,
        DialogflowConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Return details of the Dialogflow connection associated with the given
/// CallControl connection.
/// </summary>
    Task<DialogflowConnectionResponse> Retrieve(
        DialogflowConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(DialogflowConnectionRetrieveParams, CancellationToken)"/>
    Task<DialogflowConnectionResponse> Retrieve(
        string connectionID,
        DialogflowConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the stored Dialogflow connection for the specified connection and
/// returns the updated configuration.
/// </summary>
    Task<DialogflowConnectionResponse> Update(
        DialogflowConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(DialogflowConnectionUpdateParams, CancellationToken)"/>
    Task<DialogflowConnectionResponse> Update(
        string connectionID,
        DialogflowConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the stored Dialogflow connection for the specified connection.
/// </summary>
    Task Delete(
        DialogflowConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(DialogflowConnectionDeleteParams, CancellationToken)"/>
    Task Delete(
        string connectionID,
        DialogflowConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IDialogflowConnectionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDialogflowConnectionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDialogflowConnectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /dialogflow_connections/{connection_id}</c>, but is otherwise the
/// same as <see cref="IDialogflowConnectionService.Create(DialogflowConnectionCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DialogflowConnectionResponse>> Create(
        DialogflowConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Create(DialogflowConnectionCreateParams, CancellationToken)"/>
    Task<HttpResponse<DialogflowConnectionResponse>> Create(
        string connectionID,
        DialogflowConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /dialogflow_connections/{connection_id}</c>, but is otherwise the
/// same as <see cref="IDialogflowConnectionService.Retrieve(DialogflowConnectionRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DialogflowConnectionResponse>> Retrieve(
        DialogflowConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(DialogflowConnectionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<DialogflowConnectionResponse>> Retrieve(
        string connectionID,
        DialogflowConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /dialogflow_connections/{connection_id}</c>, but is otherwise the
/// same as <see cref="IDialogflowConnectionService.Update(DialogflowConnectionUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<DialogflowConnectionResponse>> Update(
        DialogflowConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(DialogflowConnectionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<DialogflowConnectionResponse>> Update(
        string connectionID,
        DialogflowConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /dialogflow_connections/{connection_id}</c>, but is otherwise the
/// same as <see cref="IDialogflowConnectionService.Delete(DialogflowConnectionDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        DialogflowConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(DialogflowConnectionDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string connectionID,
        DialogflowConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}