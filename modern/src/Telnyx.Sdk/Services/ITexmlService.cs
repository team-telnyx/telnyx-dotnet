using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Texml;
using Texml = Telnyx.Sdk.Services.Texml;

namespace Telnyx.Sdk.Services;

/// <summary>
/// TeXML REST Commands
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITexmlService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITexmlServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITexmlService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Texml::ICallService Calls { get; }

    Texml::IAccountService Accounts { get; }

    /// <summary>
/// Initiate an outbound AI call with warm-up support. Validates parameters, builds
/// an internal TeXML with an AI Assistant configuration, encodes instructions into
/// client state, and calls the dial API. The Twiml, Texml, and Url parameters are
/// not allowed and will result in a 422 error.
/// 
/// <para>**Expected callback events:**</para>
/// 
/// <para>Status callbacks: `initiated`, `ringing`, `answered`, one terminal status
/// (`completed`, `no-answer`, `busy`, `canceled`, or `failed`), then `analyzed`
/// after post-call processing completes.</para>
/// 
/// <para>Conversation callbacks: `conversation_created` and `conversation_ended`.</para>
/// 
/// <para>Recording, AMD, transcription, and deepfake detection callbacks are only
/// sent when those features are enabled. </para>
/// </summary>
    Task<TexmlInitiateAICallResponse> InitiateAICall(
        TexmlInitiateAICallParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="InitiateAICall(TexmlInitiateAICallParams, CancellationToken)"/>
    Task<TexmlInitiateAICallResponse> InitiateAICall(
        string connectionID,
        TexmlInitiateAICallParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Create a TeXML secret which can be later used as a Dynamic Parameter for TeXML
/// when using Mustache Templates in your TeXML. In your TeXML you will be able to
/// use your secret name, and this name will be replaced by the actual secret value
/// when processing the TeXML on Telnyx side.  The secrets are not visible in any logs.
/// </summary>
    Task<TexmlSecretsResponse> Secrets(
        TexmlSecretsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ITexmlService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITexmlServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITexmlServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Texml::ICallServiceWithRawResponse Calls { get; }

    Texml::IAccountServiceWithRawResponse Accounts { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /texml/ai_calls/{connection_id}</c>, but is otherwise the
/// same as <see cref="ITexmlService.InitiateAICall(TexmlInitiateAICallParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TexmlInitiateAICallResponse>> InitiateAICall(
        TexmlInitiateAICallParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="InitiateAICall(TexmlInitiateAICallParams, CancellationToken)"/>
    Task<HttpResponse<TexmlInitiateAICallResponse>> InitiateAICall(
        string connectionID,
        TexmlInitiateAICallParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /texml/secrets</c>, but is otherwise the
/// same as <see cref="ITexmlService.Secrets(TexmlSecretsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TexmlSecretsResponse>> Secrets(
        TexmlSecretsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}