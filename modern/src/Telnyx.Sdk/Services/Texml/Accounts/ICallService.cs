using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Texml.Accounts.Calls;
using Calls = Telnyx.Sdk.Services.Texml.Accounts.Calls;

namespace Telnyx.Sdk.Services.Texml.Accounts;

/// <summary>
/// TeXML REST Commands
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICallService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICallServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Calls::IRecordingsJsonService RecordingsJson { get; }

    Calls::IRecordingService Recordings { get; }

    Calls::ISiprecService Siprec { get; }

    Calls::IStreamService Streams { get; }

    /// <summary>
/// Returns an individual call identified by its CallSid. This endpoint is
/// eventually consistent.
/// </summary>
    Task<CallResource> Retrieve(
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CallRetrieveParams, CancellationToken)"/>
    Task<CallResource> Retrieve(
        string callSid,
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update TeXML call. Please note that the keys present in the payload MUST BE
/// formatted in CamelCase as specified in the example.
/// </summary>
    Task<CallResource> Update(
        CallUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CallUpdateParams, CancellationToken)"/>
    Task<CallResource> Update(
        string callSid,
        CallUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Initiate an outbound TeXML call. Telnyx will request TeXML from the XML Request
/// URL configured for the connection in the Mission Control Portal.
/// </summary>
    Task<CallCallsResponse> Calls(
        CallCallsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Calls(CallCallsParams, CancellationToken)"/>
    Task<CallCallsResponse> Calls(
        string accountSid,
        CallCallsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns multiple call resouces for an account. This endpoint is eventually
/// consistent.
/// </summary>
    Task<CallRetrieveCallsResponse> RetrieveCalls(
        CallRetrieveCallsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveCalls(CallRetrieveCallsParams, CancellationToken)"/>
    Task<CallRetrieveCallsResponse> RetrieveCalls(
        string accountSid,
        CallRetrieveCallsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Starts siprec session with specified parameters for call idientified by
/// call_sid.
/// </summary>
    Task<CallSiprecJsonResponse> SiprecJson(
        CallSiprecJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SiprecJson(CallSiprecJsonParams, CancellationToken)"/>
    Task<CallSiprecJsonResponse> SiprecJson(
        string callSid,
        CallSiprecJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Starts streaming media from a call to a specific WebSocket address.
/// </summary>
    Task<CallStreamsJsonResponse> StreamsJson(
        CallStreamsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StreamsJson(CallStreamsJsonParams, CancellationToken)"/>
    Task<CallStreamsJsonResponse> StreamsJson(
        string callSid,
        CallStreamsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICallService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICallServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICallServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Calls::IRecordingsJsonServiceWithRawResponse RecordingsJson { get; }

    Calls::IRecordingServiceWithRawResponse Recordings { get; }

    Calls::ISiprecServiceWithRawResponse Siprec { get; }

    Calls::IStreamServiceWithRawResponse Streams { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /texml/Accounts/{account_sid}/Calls/{call_sid}</c>, but is otherwise the
/// same as <see cref="ICallService.Retrieve(CallRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallResource>> Retrieve(
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CallRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CallResource>> Retrieve(
        string callSid,
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /texml/Accounts/{account_sid}/Calls/{call_sid}</c>, but is otherwise the
/// same as <see cref="ICallService.Update(CallUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallResource>> Update(
        CallUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(CallUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CallResource>> Update(
        string callSid,
        CallUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /texml/Accounts/{account_sid}/Calls</c>, but is otherwise the
/// same as <see cref="ICallService.Calls(CallCallsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallCallsResponse>> Calls(
        CallCallsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Calls(CallCallsParams, CancellationToken)"/>
    Task<HttpResponse<CallCallsResponse>> Calls(
        string accountSid,
        CallCallsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /texml/Accounts/{account_sid}/Calls</c>, but is otherwise the
/// same as <see cref="ICallService.RetrieveCalls(CallRetrieveCallsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallRetrieveCallsResponse>> RetrieveCalls(
        CallRetrieveCallsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveCalls(CallRetrieveCallsParams, CancellationToken)"/>
    Task<HttpResponse<CallRetrieveCallsResponse>> RetrieveCalls(
        string accountSid,
        CallRetrieveCallsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /texml/Accounts/{account_sid}/Calls/{call_sid}/Siprec.json</c>, but is otherwise the
/// same as <see cref="ICallService.SiprecJson(CallSiprecJsonParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallSiprecJsonResponse>> SiprecJson(
        CallSiprecJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="SiprecJson(CallSiprecJsonParams, CancellationToken)"/>
    Task<HttpResponse<CallSiprecJsonResponse>> SiprecJson(
        string callSid,
        CallSiprecJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /texml/Accounts/{account_sid}/Calls/{call_sid}/Streams.json</c>, but is otherwise the
/// same as <see cref="ICallService.StreamsJson(CallStreamsJsonParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CallStreamsJsonResponse>> StreamsJson(
        CallStreamsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="StreamsJson(CallStreamsJsonParams, CancellationToken)"/>
    Task<HttpResponse<CallStreamsJsonResponse>> StreamsJson(
        string callSid,
        CallStreamsJsonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}