using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Enterprises;
using Enterprises = Telnyx.Sdk.Services.Enterprises;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Manage the legal-entity record that owns your DIRs and phone numbers.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IEnterpriseService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEnterpriseServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEnterpriseService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    Enterprises::IReputationService Reputation { get; }

    Enterprises::IDirService Dir { get; }

    /// <summary>
/// Create the legal entity (enterprise) that represents your business on the Telnyx
/// platform.
/// 
/// <para>The response carries a server-assigned `id` you use for every subsequent
/// call. An enterprise is created once and reused; the API collects all required
/// fields up front.</para>
/// 
/// <para>Common failure modes: - `422` - a required field is missing or malformed
/// (the response `errors[].source.pointer` names the field). - `409` - an
/// enterprise with the same identifying details already exists under your account.</para>
/// </summary>
    Task<EnterprisePublicWrapped> Create(
        EnterpriseCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a single enterprise by id. Returns `404` if the id does not exist or
/// does not belong to your account.
/// </summary>
    Task<EnterprisePublicWrapped> Retrieve(
        EnterpriseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EnterpriseRetrieveParams, CancellationToken)"/>
    Task<EnterprisePublicWrapped> Retrieve(
        string enterpriseID,
        EnterpriseRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Replace the enterprise's mutable fields. Only mutable fields may be sent.
/// Server-assigned and immutable fields (`id`, `record_type`, `created_at`,
/// `updated_at`, status fields, `organization_type`, `country_code`, `role_type`)
/// cannot be changed: including any of them in the body is rejected with `400 Bad
/// Request` (`Field 'X' is not allowed in this request`).
/// </summary>
    Task<EnterprisePublicWrapped> Update(
        EnterpriseUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(EnterpriseUpdateParams, CancellationToken)"/>
    Task<EnterprisePublicWrapped> Update(
        string enterpriseID,
        EnterpriseUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Return the enterprises you own, paginated. The default page size is 20; the
/// maximum is 250.
/// </summary>
    Task<EnterpriseListPage> List(
        EnterpriseListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Soft-delete an enterprise.
/// 
/// <para>Failure modes: - `400` - the enterprise still has dependent resources in a
/// non-deletable state. Remove those first; the response `detail` identifies what
/// is blocking the delete. - `409` - the enterprise has a dependent resource with
/// an unresolved claim. Resolve it before deleting. - `404` - the enterprise does
/// not exist or does not belong to your account.</para>
/// </summary>
    Task Delete(
        EnterpriseDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(EnterpriseDeleteParams, CancellationToken)"/>
    Task Delete(
        string enterpriseID,
        EnterpriseDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Branded Calling is a paid product that must be activated on each enterprise.
/// Activation is idempotent: - First call: marks the enterprise as activated and
/// begins onboarding it with the Branded Calling platform asynchronously. Returns
/// `200` with `branded_calling_enabled: true`. - Re-call after success: no-op,
/// returns the same enterprise body. - Re-call after a prior failure: re-queues
/// onboarding, returns `200`.
/// 
/// <para>Prerequisite: the calling user must have agreed to the Branded Calling
/// Terms of Service (`POST /terms_of_service/branded_calling/agree`). Without that,
/// this endpoint returns `403 terms_of_service_not_accepted`.</para>
/// 
/// <para>Failure modes: - `403` - Branded Calling Terms of Service not accepted. -
/// `404` - enterprise does not exist or does not belong to your account.</para>
/// 
/// <para>**Pricing:** This is a billable action. See
/// https://telnyx.com/pricing/numbers for current pricing.</para>
/// </summary>
    Task<EnterprisePublicWrapped> BrandedCalling(
        EnterpriseBrandedCallingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="BrandedCalling(EnterpriseBrandedCallingParams, CancellationToken)"/>
    Task<EnterprisePublicWrapped> BrandedCalling(
        string enterpriseID,
        EnterpriseBrandedCallingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IEnterpriseService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEnterpriseServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEnterpriseServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    Enterprises::IReputationServiceWithRawResponse Reputation { get; }

    Enterprises::IDirServiceWithRawResponse Dir { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /enterprises</c>, but is otherwise the
/// same as <see cref="IEnterpriseService.Create(EnterpriseCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EnterprisePublicWrapped>> Create(
        EnterpriseCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /enterprises/{enterprise_id}</c>, but is otherwise the
/// same as <see cref="IEnterpriseService.Retrieve(EnterpriseRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EnterprisePublicWrapped>> Retrieve(
        EnterpriseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(EnterpriseRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EnterprisePublicWrapped>> Retrieve(
        string enterpriseID,
        EnterpriseRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /enterprises/{enterprise_id}</c>, but is otherwise the
/// same as <see cref="IEnterpriseService.Update(EnterpriseUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EnterprisePublicWrapped>> Update(
        EnterpriseUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(EnterpriseUpdateParams, CancellationToken)"/>
    Task<HttpResponse<EnterprisePublicWrapped>> Update(
        string enterpriseID,
        EnterpriseUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /enterprises</c>, but is otherwise the
/// same as <see cref="IEnterpriseService.List(EnterpriseListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EnterpriseListPage>> List(
        EnterpriseListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /enterprises/{enterprise_id}</c>, but is otherwise the
/// same as <see cref="IEnterpriseService.Delete(EnterpriseDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        EnterpriseDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(EnterpriseDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string enterpriseID,
        EnterpriseDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /enterprises/{enterprise_id}/branded_calling</c>, but is otherwise the
/// same as <see cref="IEnterpriseService.BrandedCalling(EnterpriseBrandedCallingParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EnterprisePublicWrapped>> BrandedCalling(
        EnterpriseBrandedCallingParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="BrandedCalling(EnterpriseBrandedCallingParams, CancellationToken)"/>
    Task<HttpResponse<EnterprisePublicWrapped>> BrandedCalling(
        string enterpriseID,
        EnterpriseBrandedCallingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}