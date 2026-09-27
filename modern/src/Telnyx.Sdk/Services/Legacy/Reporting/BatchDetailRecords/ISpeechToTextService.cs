using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Legacy.Reporting.BatchDetailRecords.SpeechToText;

namespace Telnyx.Sdk.Services.Legacy.Reporting.BatchDetailRecords;

/// <summary>
/// Speech to text batch detail records
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISpeechToTextService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISpeechToTextServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpeechToTextService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a new Speech to Text batch report request with the specified filters
/// </summary>
    Task<SpeechToTextCreateResponse> Create(
        SpeechToTextCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves a specific Speech to Text batch report request by ID
/// </summary>
    Task<SpeechToTextRetrieveResponse> Retrieve(
        SpeechToTextRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SpeechToTextRetrieveParams, CancellationToken)"/>
    Task<SpeechToTextRetrieveResponse> Retrieve(
        string id,
        SpeechToTextRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves all Speech to Text batch report requests for the authenticated user
/// </summary>
    Task<SpeechToTextListResponse> List(
        SpeechToTextListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes a specific Speech to Text batch report request by ID
/// </summary>
    Task<SpeechToTextDeleteResponse> Delete(
        SpeechToTextDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SpeechToTextDeleteParams, CancellationToken)"/>
    Task<SpeechToTextDeleteResponse> Delete(
        string id,
        SpeechToTextDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ISpeechToTextService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISpeechToTextServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpeechToTextServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /legacy/reporting/batch_detail_records/speech_to_text</c>, but is otherwise the
/// same as <see cref="ISpeechToTextService.Create(SpeechToTextCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SpeechToTextCreateResponse>> Create(
        SpeechToTextCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /legacy/reporting/batch_detail_records/speech_to_text/{id}</c>, but is otherwise the
/// same as <see cref="ISpeechToTextService.Retrieve(SpeechToTextRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SpeechToTextRetrieveResponse>> Retrieve(
        SpeechToTextRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(SpeechToTextRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SpeechToTextRetrieveResponse>> Retrieve(
        string id,
        SpeechToTextRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /legacy/reporting/batch_detail_records/speech_to_text</c>, but is otherwise the
/// same as <see cref="ISpeechToTextService.List(SpeechToTextListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SpeechToTextListResponse>> List(
        SpeechToTextListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /legacy/reporting/batch_detail_records/speech_to_text/{id}</c>, but is otherwise the
/// same as <see cref="ISpeechToTextService.Delete(SpeechToTextDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<SpeechToTextDeleteResponse>> Delete(
        SpeechToTextDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(SpeechToTextDeleteParams, CancellationToken)"/>
    Task<HttpResponse<SpeechToTextDeleteResponse>> Delete(
        string id,
        SpeechToTextDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}