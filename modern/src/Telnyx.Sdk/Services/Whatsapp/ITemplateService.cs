using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Whatsapp.Templates;

namespace Telnyx.Sdk.Services.Whatsapp;

/// <summary>
/// Manage Whatsapp message templates
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITemplateService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITemplateServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITemplateService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates a WhatsApp message template for review and subsequent use in template
/// messages.
/// </summary>
    Task<TemplateCreateResponse> Create(
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns WhatsApp message templates owned by the authenticated account, including
/// their current review state.
/// </summary>
    Task<TemplateListPage> List(
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ITemplateService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITemplateServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITemplateServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /v2/whatsapp/message_templates</c>, but is otherwise the
/// same as <see cref="ITemplateService.Create(TemplateCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TemplateCreateResponse>> Create(
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /v2/whatsapp/message_templates</c>, but is otherwise the
/// same as <see cref="ITemplateService.List(TemplateListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TemplateListPage>> List(
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}