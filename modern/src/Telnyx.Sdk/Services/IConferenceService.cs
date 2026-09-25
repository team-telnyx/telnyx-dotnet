using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Conferences;
using Conferences = Telnyx.Sdk.Services.Conferences;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Conference command operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IConferenceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IConferenceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Conferences::IActionService Actions { get; }

    /// <summary>
/// Create a conference from an existing call leg using a `call_control_id` and a
/// conference name. Upon creating the conference, the call will be automatically
/// bridged to the conference. Conferences will expire after all participants have
/// left the conference or after 4 hours regardless of the number of active
/// participants.
/// 
/// <para>**Expected Webhooks:**</para>
/// 
/// <para>- `conference.created` - `conference.participant.joined` -
/// `conference.participant.left` - `conference.ended` -
/// `conference.recording.saved` - `conference.floor.changed` </para>
/// </summary>
    Task<ConferenceCreateResponse> Create(
        ConferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of an existing conference, including its current status.
/// </summary>
    Task<ConferenceRetrieveResponse> Retrieve(
        ConferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ConferenceRetrieveParams, CancellationToken)"/>
    Task<ConferenceRetrieveResponse> Retrieve(
        string id,
        ConferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists conferences. Conferences are created on demand, and will expire after all
/// participants have left the conference or after 4 hours regardless of the number
/// of active participants. Conferences are listed in descending order by
/// `expires_at`.
/// </summary>
    Task<ConferenceListPage> List(
        ConferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of participants in the specified conference, with
/// support for filtering.
/// </summary>
    Task<ConferenceListParticipantsPage> ListParticipants(
        ConferenceListParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListParticipants(ConferenceListParticipantsParams, CancellationToken)"/>
    Task<ConferenceListParticipantsPage> ListParticipants(
        string conferenceID,
        ConferenceListParticipantsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve details of a specific conference participant by their ID or label.
/// </summary>
    Task<ConferenceParticipantResource> RetrieveParticipant(
        ConferenceRetrieveParticipantParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveParticipant(ConferenceRetrieveParticipantParams, CancellationToken)"/>
    Task<ConferenceParticipantResource> RetrieveParticipant(
        string participantID,
        ConferenceRetrieveParticipantParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update properties of a conference participant.
/// </summary>
    Task<ConferenceParticipantResource> UpdateParticipant(
        ConferenceUpdateParticipantParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateParticipant(ConferenceUpdateParticipantParams, CancellationToken)"/>
    Task<ConferenceParticipantResource> UpdateParticipant(
        string participantID,
        ConferenceUpdateParticipantParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IConferenceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IConferenceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConferenceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Conferences::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /conferences</c>, but is otherwise the
/// same as <see cref="IConferenceService.Create(ConferenceCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConferenceCreateResponse>> Create(
        ConferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /conferences/{id}</c>, but is otherwise the
/// same as <see cref="IConferenceService.Retrieve(ConferenceRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConferenceRetrieveResponse>> Retrieve(
        ConferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ConferenceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ConferenceRetrieveResponse>> Retrieve(
        string id,
        ConferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /conferences</c>, but is otherwise the
/// same as <see cref="IConferenceService.List(ConferenceListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConferenceListPage>> List(
        ConferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /conferences/{conference_id}/participants</c>, but is otherwise the
/// same as <see cref="IConferenceService.ListParticipants(ConferenceListParticipantsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConferenceListParticipantsPage>> ListParticipants(
        ConferenceListParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListParticipants(ConferenceListParticipantsParams, CancellationToken)"/>
    Task<HttpResponse<ConferenceListParticipantsPage>> ListParticipants(
        string conferenceID,
        ConferenceListParticipantsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /conferences/{id}/participants/{participant_id}</c>, but is otherwise the
/// same as <see cref="IConferenceService.RetrieveParticipant(ConferenceRetrieveParticipantParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConferenceParticipantResource>> RetrieveParticipant(
        ConferenceRetrieveParticipantParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveParticipant(ConferenceRetrieveParticipantParams, CancellationToken)"/>
    Task<HttpResponse<ConferenceParticipantResource>> RetrieveParticipant(
        string participantID,
        ConferenceRetrieveParticipantParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /conferences/{id}/participants/{participant_id}</c>, but is otherwise the
/// same as <see cref="IConferenceService.UpdateParticipant(ConferenceUpdateParticipantParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConferenceParticipantResource>> UpdateParticipant(
        ConferenceUpdateParticipantParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateParticipant(ConferenceUpdateParticipantParams, CancellationToken)"/>
    Task<HttpResponse<ConferenceParticipantResource>> UpdateParticipant(
        string participantID,
        ConferenceUpdateParticipantParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}