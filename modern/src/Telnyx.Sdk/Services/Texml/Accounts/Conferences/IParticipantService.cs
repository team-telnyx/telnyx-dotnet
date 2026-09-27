using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Texml.Accounts.Conferences.Participants;

namespace Telnyx.Sdk.Services.Texml.Accounts.Conferences;

/// <summary>
/// TeXML REST Commands
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IParticipantService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IParticipantServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IParticipantService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Returns a single conference participant resource by call SID or participant
/// label.
/// </summary>
    Task<ParticipantResource> Retrieve(
        ParticipantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ParticipantRetrieveParams, CancellationToken)"/>
    Task<ParticipantResource> Retrieve(
        string callSidOrParticipantLabel,
        ParticipantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified conference participant, for example muting or holding
/// them, and returns the updated participant.
/// </summary>
    Task<ParticipantResource> Update(
        ParticipantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ParticipantUpdateParams, CancellationToken)"/>
    Task<ParticipantResource> Update(
        string callSidOrParticipantLabel,
        ParticipantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Removes the specified participant from the conference, ending their leg of the
/// call.
/// </summary>
    Task Delete(
        ParticipantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(ParticipantDeleteParams, CancellationToken)"/>
    Task Delete(
        string callSidOrParticipantLabel,
        ParticipantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Dials a new participant into the specified conference and returns the created
/// participant resource.
/// </summary>
    Task<ParticipantParticipantsResponse> Participants(
        ParticipantParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Participants(ParticipantParticipantsParams, CancellationToken)"/>
    Task<ParticipantParticipantsResponse> Participants(
        string conferenceSid,
        ParticipantParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the list of participants currently in the specified conference.
/// </summary>
    Task<ParticipantRetrieveParticipantsResponse> RetrieveParticipants(
        ParticipantRetrieveParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveParticipants(ParticipantRetrieveParticipantsParams, CancellationToken)"/>
    Task<ParticipantRetrieveParticipantsResponse> RetrieveParticipants(
        string conferenceSid,
        ParticipantRetrieveParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IParticipantService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IParticipantServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IParticipantServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /texml/Accounts/{account_sid}/Conferences/{conference_sid}/Participants/{call_sid_or_participant_label}</c>, but is otherwise the
/// same as <see cref="IParticipantService.Retrieve(ParticipantRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ParticipantResource>> Retrieve(
        ParticipantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ParticipantRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ParticipantResource>> Retrieve(
        string callSidOrParticipantLabel,
        ParticipantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /texml/Accounts/{account_sid}/Conferences/{conference_sid}/Participants/{call_sid_or_participant_label}</c>, but is otherwise the
/// same as <see cref="IParticipantService.Update(ParticipantUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ParticipantResource>> Update(
        ParticipantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ParticipantUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ParticipantResource>> Update(
        string callSidOrParticipantLabel,
        ParticipantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /texml/Accounts/{account_sid}/Conferences/{conference_sid}/Participants/{call_sid_or_participant_label}</c>, but is otherwise the
/// same as <see cref="IParticipantService.Delete(ParticipantDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        ParticipantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(ParticipantDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string callSidOrParticipantLabel,
        ParticipantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /texml/Accounts/{account_sid}/Conferences/{conference_sid}/Participants</c>, but is otherwise the
/// same as <see cref="IParticipantService.Participants(ParticipantParticipantsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ParticipantParticipantsResponse>> Participants(
        ParticipantParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Participants(ParticipantParticipantsParams, CancellationToken)"/>
    Task<HttpResponse<ParticipantParticipantsResponse>> Participants(
        string conferenceSid,
        ParticipantParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /texml/Accounts/{account_sid}/Conferences/{conference_sid}/Participants</c>, but is otherwise the
/// same as <see cref="IParticipantService.RetrieveParticipants(ParticipantRetrieveParticipantsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ParticipantRetrieveParticipantsResponse>> RetrieveParticipants(
        ParticipantRetrieveParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveParticipants(ParticipantRetrieveParticipantsParams, CancellationToken)"/>
    Task<HttpResponse<ParticipantRetrieveParticipantsResponse>> RetrieveParticipants(
        string conferenceSid,
        ParticipantRetrieveParticipantsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}