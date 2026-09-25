using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Typesafe.V1;

namespace Telnyx.Sdk.Services.AI.Typesafe;

/// <summary>
/// Beta API for evaluating shared context with typed questions and structured answers
/// using Flash or Pro.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IV1Service
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IV1ServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// **Beta API.** Choose telnyx/decision-flash for the lowest cost and latency, or
/// telnyx/decision-pro for decisions that require long context, including inputs
/// beyond Jev’s 32k per-decision limit. Omitted model defaults to
/// telnyx/decision-flash.
/// 
/// <para>Evaluate shared context using named choice, noul (yes/no), and score
/// questions. Returns TypeSafe System One-compatible answer shapes, the selected
/// public model alias, and token usage. See the [decision model
/// guide](https://developers.telnyx.com/docs/inference/decision-models) for
/// examples and compatibility limits.</para>
/// 
/// <para>The supported request subset requires instructions for every question,
/// string descriptions for criteria (or null for choice descriptions), 1–64
/// questions, and 2–64 options for choice and score questions. The model field
/// accepts only telnyx/decision-flash or telnyx/decision-pro. Unsupported model
/// values and unknown fields are rejected. The endpoint is synchronous and does not
/// stream.</para>
/// 
/// <para>Use the TypeSafe Python SDK with base_url set to
/// https://api.telnyx.com/v2/ai/typesafe and a Telnyx API key. The SDK appends
/// /v1/systemone; explicitly set model to a supported Telnyx alias because its own
/// default model is not supported. Compatibility covers this operation and the
/// documented request subset; it does not include TypeSafe model listing. Scores
/// describe relative preference, not calibrated correctness.</para>
/// </summary>
    Task<V1SystemoneResponse> Systemone(
        V1SystemoneParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IV1Service"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IV1ServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1ServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/typesafe/v1/systemone</c>, but is otherwise the
/// same as <see cref="IV1Service.Systemone(V1SystemoneParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<V1SystemoneResponse>> Systemone(
        V1SystemoneParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}