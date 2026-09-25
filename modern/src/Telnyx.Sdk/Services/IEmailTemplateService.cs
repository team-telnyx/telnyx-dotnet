using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailTemplates;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Create, list, retrieve, update, delete, and render Liquid email templates.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IEmailTemplateService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEmailTemplateServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailTemplateService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a Liquid email template. Variables are auto-extracted when omitted.
/// </summary>
    Task<EmailTemplateResponse> Create(
        EmailTemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the account-owned template identified by ID, including its Liquid
/// subject and bodies, declared variables, and timestamps.
/// </summary>
    Task<EmailTemplateResponse> Retrieve(
        EmailTemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EmailTemplateRetrieveParams, CancellationToken)"/>
    Task<EmailTemplateResponse> Retrieve(
        string id,
        EmailTemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates one or more fields of the specified email template and returns the
/// updated template.
/// </summary>
    Task<EmailTemplateResponse> Update(
        EmailTemplateUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(EmailTemplateUpdateParams, CancellationToken)"/>
    Task<EmailTemplateResponse> Update(
        string id,
        EmailTemplateUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists templates sorted newest first by `created_at desc, id desc`.
/// </summary>
    Task<EmailTemplateListPage> List(
        EmailTemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the account-owned template. The operation returns `204` with no body and
/// prevents future sends or renders from using the deleted template ID.
/// </summary>
    Task Delete(
        EmailTemplateDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(EmailTemplateDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        EmailTemplateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Renders a template using the provided Liquid variables. Missing
/// `template_variables` defaults to `{}`.
/// 
/// <para>When the template has `strict_variables` enabled and a required variable
/// (per `variable_schema`) is missing, returns 422 naming the variable. When the
/// template has `autoescape` enabled, the rendered `html_body` expression output is
/// HTML-escaped at the output boundary; `subject` and `text_body` are not
/// autoescaped.</para>
/// </summary>
    Task<EmailTemplateRenderResponse> Render(
        EmailTemplateRenderParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Render(EmailTemplateRenderParams, CancellationToken)"/>
    Task<EmailTemplateRenderResponse> Render(
        string id,
        EmailTemplateRenderParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Replaces template fields. Behaves identically to PATCH; provided for
/// compatibility with Phoenix resource routes.
/// </summary>
    Task<EmailTemplateResponse> Replace(
        EmailTemplateReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Replace(EmailTemplateReplaceParams, CancellationToken)"/>
    Task<EmailTemplateResponse> Replace(
        string id,
        EmailTemplateReplaceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IEmailTemplateService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEmailTemplateServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailTemplateServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_templates</c>, but is otherwise the
/// same as <see cref="IEmailTemplateService.Create(EmailTemplateCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailTemplateResponse>> Create(
        EmailTemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_templates/{id}</c>, but is otherwise the
/// same as <see cref="IEmailTemplateService.Retrieve(EmailTemplateRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailTemplateResponse>> Retrieve(
        EmailTemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EmailTemplateRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EmailTemplateResponse>> Retrieve(
        string id,
        EmailTemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /email_templates/{id}</c>, but is otherwise the
/// same as <see cref="IEmailTemplateService.Update(EmailTemplateUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailTemplateResponse>> Update(
        EmailTemplateUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(EmailTemplateUpdateParams, CancellationToken)"/>
    Task<HttpResponse<EmailTemplateResponse>> Update(
        string id,
        EmailTemplateUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_templates</c>, but is otherwise the
/// same as <see cref="IEmailTemplateService.List(EmailTemplateListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailTemplateListPage>> List(
        EmailTemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /email_templates/{id}</c>, but is otherwise the
/// same as <see cref="IEmailTemplateService.Delete(EmailTemplateDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        EmailTemplateDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(EmailTemplateDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        EmailTemplateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_templates/{id}/render</c>, but is otherwise the
/// same as <see cref="IEmailTemplateService.Render(EmailTemplateRenderParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailTemplateRenderResponse>> Render(
        EmailTemplateRenderParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Render(EmailTemplateRenderParams, CancellationToken)"/>
    Task<HttpResponse<EmailTemplateRenderResponse>> Render(
        string id,
        EmailTemplateRenderParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /email_templates/{id}</c>, but is otherwise the
/// same as <see cref="IEmailTemplateService.Replace(EmailTemplateReplaceParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailTemplateResponse>> Replace(
        EmailTemplateReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Replace(EmailTemplateReplaceParams, CancellationToken)"/>
    Task<HttpResponse<EmailTemplateResponse>> Replace(
        string id,
        EmailTemplateReplaceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}