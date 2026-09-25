using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Texml.Accounts.Calls.RecordingsJson;
using Telnyx.Sdk.Models.Texml.Accounts.Conferences;
using Telnyx.Sdk.Services.Texml.Accounts.Conferences;

namespace Telnyx.Sdk.Services.Texml.Accounts;

/// <summary>
/// TeXML REST Commands
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

    IParticipantService Participants { get; }

    /// <summary>
/// Returns a single conference resource for the account by its ConferenceSid.
/// </summary>
    Task<ConferenceResource> Retrieve(
        ConferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ConferenceRetrieveParams, CancellationToken)"/>
    Task<ConferenceResource> Retrieve(
        string conferenceSid,
        ConferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified conference resource, for example to modify its status, and
/// returns the updated conference.
/// </summary>
    Task<ConferenceResource> Update(
        ConferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ConferenceUpdateParams, CancellationToken)"/>
    Task<ConferenceResource> Update(
        string conferenceSid,
        ConferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of conference resources for the account, with support
/// for filtering by friendly name, status, and creation or update dates.
/// </summary>
    Task<ConferenceRetrieveConferencesResponse> RetrieveConferences(
        ConferenceRetrieveConferencesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveConferences(ConferenceRetrieveConferencesParams, CancellationToken)"/>
    Task<ConferenceRetrieveConferencesResponse> RetrieveConferences(
        string accountSid,
        ConferenceRetrieveConferencesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the list of recordings made for the specified conference.
/// </summary>
    Task<ConferenceRetrieveRecordingsResponse> RetrieveRecordings(
        ConferenceRetrieveRecordingsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRecordings(ConferenceRetrieveRecordingsParams, CancellationToken)"/>
    Task<ConferenceRetrieveRecordingsResponse> RetrieveRecordings(
        string conferenceSid,
        ConferenceRetrieveRecordingsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns recordings for a conference identified by conference_sid.
/// </summary>
    Task<TexmlGetCallRecordingsResponseBody> RetrieveRecordingsJson(
        ConferenceRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRecordingsJson(ConferenceRetrieveRecordingsJsonParams, CancellationToken)"/>
    Task<TexmlGetCallRecordingsResponseBody> RetrieveRecordingsJson(
        string conferenceSid,
        ConferenceRetrieveRecordingsJsonParams parameters,
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

    IParticipantServiceWithRawResponse Participants { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /texml/Accounts/{account_sid}/Conferences/{conference_sid}</c>, but is otherwise the
/// same as <see cref="IConferenceService.Retrieve(ConferenceRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConferenceResource>> Retrieve(
        ConferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ConferenceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ConferenceResource>> Retrieve(
        string conferenceSid,
        ConferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /texml/Accounts/{account_sid}/Conferences/{conference_sid}</c>, but is otherwise the
/// same as <see cref="IConferenceService.Update(ConferenceUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConferenceResource>> Update(
        ConferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ConferenceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ConferenceResource>> Update(
        string conferenceSid,
        ConferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /texml/Accounts/{account_sid}/Conferences</c>, but is otherwise the
/// same as <see cref="IConferenceService.RetrieveConferences(ConferenceRetrieveConferencesParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConferenceRetrieveConferencesResponse>> RetrieveConferences(
        ConferenceRetrieveConferencesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveConferences(ConferenceRetrieveConferencesParams, CancellationToken)"/>
    Task<HttpResponse<ConferenceRetrieveConferencesResponse>> RetrieveConferences(
        string accountSid,
        ConferenceRetrieveConferencesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /texml/Accounts/{account_sid}/Conferences/{conference_sid}/Recordings</c>, but is otherwise the
/// same as <see cref="IConferenceService.RetrieveRecordings(ConferenceRetrieveRecordingsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConferenceRetrieveRecordingsResponse>> RetrieveRecordings(
        ConferenceRetrieveRecordingsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRecordings(ConferenceRetrieveRecordingsParams, CancellationToken)"/>
    Task<HttpResponse<ConferenceRetrieveRecordingsResponse>> RetrieveRecordings(
        string conferenceSid,
        ConferenceRetrieveRecordingsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /texml/Accounts/{account_sid}/Conferences/{conference_sid}/Recordings.json</c>, but is otherwise the
/// same as <see cref="IConferenceService.RetrieveRecordingsJson(ConferenceRetrieveRecordingsJsonParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TexmlGetCallRecordingsResponseBody>> RetrieveRecordingsJson(
        ConferenceRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRecordingsJson(ConferenceRetrieveRecordingsJsonParams, CancellationToken)"/>
    Task<HttpResponse<TexmlGetCallRecordingsResponseBody>> RetrieveRecordingsJson(
        string conferenceSid,
        ConferenceRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}