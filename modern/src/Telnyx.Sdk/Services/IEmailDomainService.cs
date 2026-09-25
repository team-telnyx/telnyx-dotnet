using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailDomains;
using EmailDomains = Telnyx.Sdk.Services.EmailDomains;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEmailDomainService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEmailDomainServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailDomainService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    EmailDomains::IWebhookService Webhooks { get; }

    /// <summary>
/// Registers a domain for email sending and optional inbound delivery. The response
/// includes the domain configuration and current verification state.
/// </summary>
    Task<EmailDomainResponse> Create(
        EmailDomainCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Shared (`type: shared`) Telnyx-managed domains are included/readable for every
/// account, in addition to the account's own custom domains.
/// </summary>
    Task<EmailDomainResponse> Retrieve(
        EmailDomainRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EmailDomainRetrieveParams, CancellationToken)"/>
    Task<EmailDomainResponse> Retrieve(
        string id,
        EmailDomainRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates mutable settings for an existing email domain, including inbound
/// delivery and tracking configuration. Shared domains are read-only for non-owner
/// accounts.
/// </summary>
    Task<EmailDomainResponse> Update(
        EmailDomainUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(EmailDomainUpdateParams, CancellationToken)"/>
    Task<EmailDomainResponse> Update(
        string id,
        EmailDomainUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Shared (`type: shared`) Telnyx-managed domains are included/readable for every
/// account, in addition to the account's own custom domains.
/// </summary>
    Task<EmailDomainListPage> List(
        EmailDomainListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes an email domain configuration. Verified domains require `force=true`,
/// and shared domains are read-only for non-owner accounts.
/// </summary>
    Task<EmailDomainResponse> Delete(
        EmailDomainDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(EmailDomainDeleteParams, CancellationToken)"/>
    Task<EmailDomainResponse> Delete(
        string id,
        EmailDomainDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the DNS records Telnyx generated for domain ownership and DKIM
/// verification, plus MX records when inbound delivery is enabled.
/// </summary>
    Task<EmailDomainRetrieveDnsRecordsResponse> RetrieveDnsRecords(
        EmailDomainRetrieveDnsRecordsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveDnsRecords(EmailDomainRetrieveDnsRecordsParams, CancellationToken)"/>
    Task<EmailDomainRetrieveDnsRecordsResponse> RetrieveDnsRecords(
        string domainID,
        EmailDomainRetrieveDnsRecordsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a summary of domain health including verification status and usability.
/// </summary>
    Task<EmailDomainRetrieveHealthResponse> RetrieveHealth(
        EmailDomainRetrieveHealthParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveHealth(EmailDomainRetrieveHealthParams, CancellationToken)"/>
    Task<EmailDomainRetrieveHealthResponse> RetrieveHealth(
        string id,
        EmailDomainRetrieveHealthParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Generates a new DKIM key for the domain, activates it, and retires the previous
/// key. The response includes the updated DKIM DNS records the customer must
/// publish. Selectors are fixed, so rotation replaces the TXT value at the existing
/// `&lt;selector&gt;._domainkey.&lt;domain&gt;` host rather than adding a second
/// record — `old_selector_retained` is false and the new TXT value must be
/// published promptly, since signing switches to the new key immediately and the
/// old TXT value will no longer match. The previous key is retired to a `retiring`
/// state (retained, not revoked) so it can be revoked after the DNS propagation
/// grace period.
/// </summary>
    Task<EmailDomainRotateDkimResponse> RotateDkim(
        EmailDomainRotateDkimParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RotateDkim(EmailDomainRotateDkimParams, CancellationToken)"/>
    Task<EmailDomainRotateDkimResponse> RotateDkim(
        string domainID,
        EmailDomainRotateDkimParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Checks the published DNS records against the records required for the email
/// domain and returns the latest verification results.
/// </summary>
    Task<EmailDomainResponse> Verify(
        EmailDomainVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Verify(EmailDomainVerifyParams, CancellationToken)"/>
    Task<EmailDomainResponse> Verify(
        string domainID,
        EmailDomainVerifyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IEmailDomainService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEmailDomainServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailDomainServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    EmailDomains::IWebhookServiceWithRawResponse Webhooks { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_domains</c>, but is otherwise the
/// same as <see cref="IEmailDomainService.Create(EmailDomainCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailDomainResponse>> Create(
        EmailDomainCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_domains/{id}</c>, but is otherwise the
/// same as <see cref="IEmailDomainService.Retrieve(EmailDomainRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailDomainResponse>> Retrieve(
        EmailDomainRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EmailDomainRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EmailDomainResponse>> Retrieve(
        string id,
        EmailDomainRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /email_domains/{id}</c>, but is otherwise the
/// same as <see cref="IEmailDomainService.Update(EmailDomainUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailDomainResponse>> Update(
        EmailDomainUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(EmailDomainUpdateParams, CancellationToken)"/>
    Task<HttpResponse<EmailDomainResponse>> Update(
        string id,
        EmailDomainUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_domains</c>, but is otherwise the
/// same as <see cref="IEmailDomainService.List(EmailDomainListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailDomainListPage>> List(
        EmailDomainListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /email_domains/{id}</c>, but is otherwise the
/// same as <see cref="IEmailDomainService.Delete(EmailDomainDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailDomainResponse>> Delete(
        EmailDomainDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(EmailDomainDeleteParams, CancellationToken)"/>
    Task<HttpResponse<EmailDomainResponse>> Delete(
        string id,
        EmailDomainDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_domains/{domain_id}/dns_records</c>, but is otherwise the
/// same as <see cref="IEmailDomainService.RetrieveDnsRecords(EmailDomainRetrieveDnsRecordsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailDomainRetrieveDnsRecordsResponse>> RetrieveDnsRecords(
        EmailDomainRetrieveDnsRecordsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveDnsRecords(EmailDomainRetrieveDnsRecordsParams, CancellationToken)"/>
    Task<HttpResponse<EmailDomainRetrieveDnsRecordsResponse>> RetrieveDnsRecords(
        string domainID,
        EmailDomainRetrieveDnsRecordsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /email_domains/{id}/health</c>, but is otherwise the
/// same as <see cref="IEmailDomainService.RetrieveHealth(EmailDomainRetrieveHealthParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailDomainRetrieveHealthResponse>> RetrieveHealth(
        EmailDomainRetrieveHealthParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveHealth(EmailDomainRetrieveHealthParams, CancellationToken)"/>
    Task<HttpResponse<EmailDomainRetrieveHealthResponse>> RetrieveHealth(
        string id,
        EmailDomainRetrieveHealthParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_domains/{domain_id}/rotate_dkim</c>, but is otherwise the
/// same as <see cref="IEmailDomainService.RotateDkim(EmailDomainRotateDkimParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailDomainRotateDkimResponse>> RotateDkim(
        EmailDomainRotateDkimParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RotateDkim(EmailDomainRotateDkimParams, CancellationToken)"/>
    Task<HttpResponse<EmailDomainRotateDkimResponse>> RotateDkim(
        string domainID,
        EmailDomainRotateDkimParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /email_domains/{domain_id}/verify</c>, but is otherwise the
/// same as <see cref="IEmailDomainService.Verify(EmailDomainVerifyParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EmailDomainResponse>> Verify(
        EmailDomainVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Verify(EmailDomainVerifyParams, CancellationToken)"/>
    Task<HttpResponse<EmailDomainResponse>> Verify(
        string domainID,
        EmailDomainVerifyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}