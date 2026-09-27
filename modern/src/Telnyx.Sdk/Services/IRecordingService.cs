using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Recordings;
using Recordings = Telnyx.Sdk.Services.Recordings;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Call Recordings operations.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRecordingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRecordingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRecordingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Recordings::IActionService Actions { get; }

    /// <summary>
/// Retrieves the details of an existing call recording.
/// </summary>
    Task<RecordingResponse> Retrieve(
        RecordingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RecordingRetrieveParams, CancellationToken)"/>
    Task<RecordingResponse> Retrieve(
        string recordingID,
        RecordingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of your call recordings, with support for filtering to
/// locate specific recordings.
/// </summary>
    Task<RecordingListPage> List(
        RecordingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified call recording and returns the deleted
/// recording resource. The media is removed and can no longer be downloaded.
/// </summary>
    Task<RecordingResponse> Delete(
        RecordingDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(RecordingDeleteParams, CancellationToken)"/>
    Task<RecordingResponse> Delete(
        string recordingID,
        RecordingDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IRecordingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRecordingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRecordingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Recordings::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /recordings/{recording_id}</c>, but is otherwise the
/// same as <see cref="IRecordingService.Retrieve(RecordingRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RecordingResponse>> Retrieve(
        RecordingRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(RecordingRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RecordingResponse>> Retrieve(
        string recordingID,
        RecordingRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /recordings</c>, but is otherwise the
/// same as <see cref="IRecordingService.List(RecordingListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RecordingListPage>> List(
        RecordingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /recordings/{recording_id}</c>, but is otherwise the
/// same as <see cref="IRecordingService.Delete(RecordingDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<RecordingResponse>> Delete(
        RecordingDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(RecordingDeleteParams, CancellationToken)"/>
    Task<HttpResponse<RecordingResponse>> Delete(
        string recordingID,
        RecordingDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}