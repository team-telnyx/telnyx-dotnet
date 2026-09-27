using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Assistants.Instructions;

namespace Telnyx.Sdk.Services.AI.Assistants;

/// <summary>
/// Configure AI assistant specifications
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IInstructionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInstructionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInstructionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Enhance an assistant's instructions using an LLM. The endpoint reads the
/// assistant's current instructions and tools, then streams back improved
/// instructions as they are generated.
/// 
/// <para>Optionally provide an `enhancement_prompt` to steer the changes (for
/// example, "make the instructions more concise" or "add error handling guidance").
/// When omitted, the assistant's existing instructions are used as the basis for
/// the enhancement.</para>
/// 
/// <para>The enhancement focuses on tool-calling reliability, clarity and
/// precision, completeness and error handling, tool schema alignment, and
/// conversation flow structure.</para>
/// 
/// <para>The response is streamed as `text/plain` using chunked transfer encoding;
/// consume the body incrementally to render the enhanced instructions as they
/// arrive.</para>
/// </summary>
    Task<string> Enhance(
        InstructionEnhanceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Enhance(InstructionEnhanceParams, CancellationToken)"/>
    Task<string> Enhance(
        string assistantID,
        InstructionEnhanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IInstructionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInstructionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInstructionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/assistants/{assistant_id}/instructions/enhance</c>, but is otherwise the
/// same as <see cref="IInstructionService.Enhance(InstructionEnhanceParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<string>> Enhance(
        InstructionEnhanceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Enhance(InstructionEnhanceParams, CancellationToken)"/>
    Task<HttpResponse<string>> Enhance(
        string assistantID,
        InstructionEnhanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}