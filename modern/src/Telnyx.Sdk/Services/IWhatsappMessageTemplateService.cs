using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.WhatsappMessageTemplates;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Manage Whatsapp message templates
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IWhatsappMessageTemplateService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWhatsappMessageTemplateServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWhatsappMessageTemplateService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns the content, components, language, and current review state of the
/// specified WhatsApp message template.
/// </summary>
    Task<WhatsappMessageTemplateRetrieveResponse> Retrieve(
        WhatsappMessageTemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(WhatsappMessageTemplateRetrieveParams, CancellationToken)"/>
    Task<WhatsappMessageTemplateRetrieveResponse> Retrieve(
        string id,
        WhatsappMessageTemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the editable fields of the specified WhatsApp message template.
/// </summary>
    Task<WhatsappMessageTemplateUpdateResponse> Update(
        WhatsappMessageTemplateUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(WhatsappMessageTemplateUpdateParams, CancellationToken)"/>
    Task<WhatsappMessageTemplateUpdateResponse> Update(
        string id,
        WhatsappMessageTemplateUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the specified WhatsApp message template.
/// </summary>
    Task Delete(
        WhatsappMessageTemplateDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(WhatsappMessageTemplateDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        WhatsappMessageTemplateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IWhatsappMessageTemplateService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWhatsappMessageTemplateServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWhatsappMessageTemplateServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /v2/whatsapp_message_templates/{id}</c>, but is otherwise the
/// same as <see cref="IWhatsappMessageTemplateService.Retrieve(WhatsappMessageTemplateRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WhatsappMessageTemplateRetrieveResponse>> Retrieve(
        WhatsappMessageTemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(WhatsappMessageTemplateRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<WhatsappMessageTemplateRetrieveResponse>> Retrieve(
        string id,
        WhatsappMessageTemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /v2/whatsapp_message_templates/{id}</c>, but is otherwise the
/// same as <see cref="IWhatsappMessageTemplateService.Update(WhatsappMessageTemplateUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<WhatsappMessageTemplateUpdateResponse>> Update(
        WhatsappMessageTemplateUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(WhatsappMessageTemplateUpdateParams, CancellationToken)"/>
    Task<HttpResponse<WhatsappMessageTemplateUpdateResponse>> Update(
        string id,
        WhatsappMessageTemplateUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /v2/whatsapp_message_templates/{id}</c>, but is otherwise the
/// same as <see cref="IWhatsappMessageTemplateService.Delete(WhatsappMessageTemplateDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        WhatsappMessageTemplateDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(WhatsappMessageTemplateDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        WhatsappMessageTemplateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}