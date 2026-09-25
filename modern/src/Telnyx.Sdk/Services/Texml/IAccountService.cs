using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Texml.Accounts;
using Telnyx.Sdk.Models.Texml.Accounts.Calls.RecordingsJson;
using Accounts = Telnyx.Sdk.Services.Texml.Accounts;

namespace Telnyx.Sdk.Services.Texml;

/// <summary>
/// TeXML REST Commands
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccountServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Accounts::ICallService Calls { get; }

    Accounts::IConferenceService Conferences { get; }

    Accounts::IRecordingService Recordings { get; }

    Accounts::ITranscriptionService Transcriptions { get; }

    Accounts::IQueueService Queues { get; }

    /// <summary>
/// Returns multiple recording resources for an account.
/// </summary>
    Task<TexmlGetCallRecordingsResponseBody> RetrieveRecordingsJson(
        AccountRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRecordingsJson(AccountRetrieveRecordingsJsonParams, CancellationToken)"/>
    Task<TexmlGetCallRecordingsResponseBody> RetrieveRecordingsJson(
        string accountSid,
        AccountRetrieveRecordingsJsonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns multiple recording transcription resources for an account.
/// </summary>
    Task<AccountRetrieveTranscriptionsJsonResponse> RetrieveTranscriptionsJson(
        AccountRetrieveTranscriptionsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveTranscriptionsJson(AccountRetrieveTranscriptionsJsonParams, CancellationToken)"/>
    Task<AccountRetrieveTranscriptionsJsonResponse> RetrieveTranscriptionsJson(
        string accountSid,
        AccountRetrieveTranscriptionsJsonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IAccountService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccountServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Accounts::ICallServiceWithRawResponse Calls { get; }

    Accounts::IConferenceServiceWithRawResponse Conferences { get; }

    Accounts::IRecordingServiceWithRawResponse Recordings { get; }

    Accounts::ITranscriptionServiceWithRawResponse Transcriptions { get; }

    Accounts::IQueueServiceWithRawResponse Queues { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /texml/Accounts/{account_sid}/Recordings.json</c>, but is otherwise the
/// same as <see cref="IAccountService.RetrieveRecordingsJson(AccountRetrieveRecordingsJsonParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TexmlGetCallRecordingsResponseBody>> RetrieveRecordingsJson(
        AccountRetrieveRecordingsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveRecordingsJson(AccountRetrieveRecordingsJsonParams, CancellationToken)"/>
    Task<HttpResponse<TexmlGetCallRecordingsResponseBody>> RetrieveRecordingsJson(
        string accountSid,
        AccountRetrieveRecordingsJsonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /texml/Accounts/{account_sid}/Transcriptions.json</c>, but is otherwise the
/// same as <see cref="IAccountService.RetrieveTranscriptionsJson(AccountRetrieveTranscriptionsJsonParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<AccountRetrieveTranscriptionsJsonResponse>> RetrieveTranscriptionsJson(
        AccountRetrieveTranscriptionsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveTranscriptionsJson(AccountRetrieveTranscriptionsJsonParams, CancellationToken)"/>
    Task<HttpResponse<AccountRetrieveTranscriptionsJsonResponse>> RetrieveTranscriptionsJson(
        string accountSid,
        AccountRetrieveTranscriptionsJsonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}