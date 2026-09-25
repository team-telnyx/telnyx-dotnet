using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Enterprises.Reputation;
using Telnyx.Sdk.Services.Enterprises.Reputation;

namespace Telnyx.Sdk.Services.Enterprises;

/// <summary>
/// Phone-number reputation monitoring (spam-score lookup and tracking).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IReputationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IReputationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReputationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    INumberService Numbers { get; }

    ILoaService Loa { get; }

    IRemediationService Remediation { get; }

    /// <summary>
/// Phone Number Reputation tracks how your outbound caller-IDs are perceived (spam
/// risk, engagement, etc.) across the call-screening ecosystem. This endpoint reads
/// the enterprise-level settings: whether the product is enabled, the refresh
/// cadence, and the stored Letter of Authorization document id.
/// 
/// <para>Returns `404` if reputation has never been enabled for this enterprise.</para>
/// </summary>
    Task<EnterpriseReputationPublicWrapped> Retrieve(
        ReputationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ReputationRetrieveParams, CancellationToken)"/>
    Task<EnterpriseReputationPublicWrapped> Retrieve(
        string enterpriseID,
        ReputationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Disable Phone Number Reputation. All registered numbers are de-registered as a
/// cascade. The enterprise itself is unaffected. Returns `204` on success, `404` if
/// reputation is not enabled for this enterprise.
/// </summary>
    Task Disable(
        ReputationDisableParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Disable(ReputationDisableParams, CancellationToken)"/>
    Task Disable(
        string enterpriseID,
        ReputationDisableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Activate Phone Number Reputation for the given enterprise. Requires an uploaded
/// Letter of Authorization document (the `loa_document_id` references the Telnyx
/// Documents API) and a refresh-frequency selection. After activation, individual
/// phone numbers can be registered via `POST .../reputation/numbers`.
/// 
/// <para>**Prerequisite**: the calling user must have agreed to the Phone Number
/// Reputation Terms of Service (`POST /terms_of_service/number_reputation/agree`).</para>
/// 
/// <para>Failure modes: - `403` - Phone Number Reputation Terms of Service not
/// accepted. - `404` - enterprise does not exist or does not belong to your
/// account. - `400` - reputation already enabled for this enterprise. - `422` -
/// `loa_document_id` missing or `check_frequency` invalid.</para>
/// 
/// <para>**Pricing:** This is a billable action. See
/// https://telnyx.com/pricing/numbers for current pricing.</para>
/// </summary>
    Task<EnterpriseReputationPublicWrapped> Enable(
        ReputationEnableParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Enable(ReputationEnableParams, CancellationToken)"/>
    Task<EnterpriseReputationPublicWrapped> Enable(
        string enterpriseID,
        ReputationEnableParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update how often Telnyx refreshes the reputation data for this enterprise's
/// registered numbers. The new frequency takes effect on the next scheduled
/// refresh.
/// 
/// <para>The enterprise's reputation must be in `approved` status. A request made
/// while the status is `pending` is rejected with `400 Bad Request`.</para>
/// </summary>
    Task<EnterpriseReputationPublicWrapped> UpdateFrequency(
        ReputationUpdateFrequencyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateFrequency(ReputationUpdateFrequencyParams, CancellationToken)"/>
    Task<EnterpriseReputationPublicWrapped> UpdateFrequency(
        string enterpriseID,
        ReputationUpdateFrequencyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IReputationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IReputationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReputationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    INumberServiceWithRawResponse Numbers { get; }

    ILoaServiceWithRawResponse Loa { get; }

    IRemediationServiceWithRawResponse Remediation { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>get /enterprises/{enterprise_id}/reputation</c>, but is otherwise the
/// same as <see cref="IReputationService.Retrieve(ReputationRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EnterpriseReputationPublicWrapped>> Retrieve(
        ReputationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ReputationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EnterpriseReputationPublicWrapped>> Retrieve(
        string enterpriseID,
        ReputationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /enterprises/{enterprise_id}/reputation</c>, but is otherwise the
/// same as <see cref="IReputationService.Disable(ReputationDisableParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Disable(
        ReputationDisableParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Disable(ReputationDisableParams, CancellationToken)"/>
    Task<HttpResponse> Disable(
        string enterpriseID,
        ReputationDisableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /enterprises/{enterprise_id}/reputation</c>, but is otherwise the
/// same as <see cref="IReputationService.Enable(ReputationEnableParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EnterpriseReputationPublicWrapped>> Enable(
        ReputationEnableParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Enable(ReputationEnableParams, CancellationToken)"/>
    Task<HttpResponse<EnterpriseReputationPublicWrapped>> Enable(
        string enterpriseID,
        ReputationEnableParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /enterprises/{enterprise_id}/reputation/frequency</c>, but is otherwise the
/// same as <see cref="IReputationService.UpdateFrequency(ReputationUpdateFrequencyParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<EnterpriseReputationPublicWrapped>> UpdateFrequency(
        ReputationUpdateFrequencyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateFrequency(ReputationUpdateFrequencyParams, CancellationToken)"/>
    Task<HttpResponse<EnterpriseReputationPublicWrapped>> UpdateFrequency(
        string enterpriseID,
        ReputationUpdateFrequencyParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}