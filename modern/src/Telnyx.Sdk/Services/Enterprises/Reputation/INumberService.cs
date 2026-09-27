using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Enterprises.Reputation.Numbers;

namespace Telnyx.Sdk.Services.Enterprises.Reputation;

/// <summary>
/// Phone-number reputation monitoring (spam-score lookup and tracking).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface INumberService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INumberServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumberService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Retrieve one registered number with its latest reputation snapshot. The
/// `phone_number` path parameter is in E.164 format and must be URL-encoded (e.g.
/// `%2B19493253498`).
/// </summary>
    Task<ReputationPhoneNumberWithReputation> Retrieve(
        NumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NumberRetrieveParams, CancellationToken)"/>
    Task<ReputationPhoneNumberWithReputation> Retrieve(
        string phoneNumber,
        NumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Paginated list of phone numbers registered for reputation monitoring under this
/// enterprise. The response includes the latest reputation snapshot per number
/// where one has been collected.
/// </summary>
    Task<NumberListPage> List(
        NumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(NumberListParams, CancellationToken)"/>
    Task<NumberListPage> List(
        string enterpriseID,
        NumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Add up to 100 phone numbers to reputation monitoring on this enterprise. Each
/// must be in E.164 format (`+1NPANXXXXXX` for US/CA) and belong to your Telnyx
/// phone-number inventory.
/// 
/// <para>**Prerequisite**: reputation must already be enabled on this enterprise
/// (see `POST .../reputation`).</para>
/// 
/// <para>**Pricing:** This is a billable action. See
/// https://telnyx.com/pricing/numbers for current pricing.</para>
/// </summary>
    Task<ReputationPhoneNumberList> Associate(
        NumberAssociateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Associate(NumberAssociateParams, CancellationToken)"/>
    Task<ReputationPhoneNumberList> Associate(
        string enterpriseID,
        NumberAssociateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Stop tracking the reputation of this phone number. The number itself remains in
/// your inventory; only the reputation registration is removed.
/// </summary>
    Task Disassociate(
        NumberDisassociateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Disassociate(NumberDisassociateParams, CancellationToken)"/>
    Task Disassociate(
        string phoneNumber,
        NumberDisassociateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Immediately refresh the stored reputation data for the listed numbers. This is
/// in addition to the periodic refresh determined by `check_frequency`. Up to 100
/// numbers per call. The response carries the kicked-off jobs; the actual refresh
/// runs asynchronously.
/// 
/// <para>**Pricing:** Forcing a refresh performs live reputation lookups, which are
/// billable. See https://telnyx.com/pricing/numbers for current pricing.</para>
/// </summary>
    Task<NumberRefreshResponse> Refresh(
        NumberRefreshParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Refresh(NumberRefreshParams, CancellationToken)"/>
    Task<NumberRefreshResponse> Refresh(
        string enterpriseID,
        NumberRefreshParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="INumberService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INumberServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /enterprises/{enterprise_id}/reputation/numbers/{phone_number}</c>, but is otherwise the
/// same as <see cref="INumberService.Retrieve(NumberRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ReputationPhoneNumberWithReputation>> Retrieve(
        NumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NumberRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ReputationPhoneNumberWithReputation>> Retrieve(
        string phoneNumber,
        NumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /enterprises/{enterprise_id}/reputation/numbers</c>, but is otherwise the
/// same as <see cref="INumberService.List(NumberListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberListPage>> List(
        NumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(NumberListParams, CancellationToken)"/>
    Task<HttpResponse<NumberListPage>> List(
        string enterpriseID,
        NumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /enterprises/{enterprise_id}/reputation/numbers</c>, but is otherwise the
/// same as <see cref="INumberService.Associate(NumberAssociateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ReputationPhoneNumberList>> Associate(
        NumberAssociateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Associate(NumberAssociateParams, CancellationToken)"/>
    Task<HttpResponse<ReputationPhoneNumberList>> Associate(
        string enterpriseID,
        NumberAssociateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /enterprises/{enterprise_id}/reputation/numbers/{phone_number}</c>, but is otherwise the
/// same as <see cref="INumberService.Disassociate(NumberDisassociateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Disassociate(
        NumberDisassociateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Disassociate(NumberDisassociateParams, CancellationToken)"/>
    Task<HttpResponse> Disassociate(
        string phoneNumber,
        NumberDisassociateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /enterprises/{enterprise_id}/reputation/numbers/refresh</c>, but is otherwise the
/// same as <see cref="INumberService.Refresh(NumberRefreshParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberRefreshResponse>> Refresh(
        NumberRefreshParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Refresh(NumberRefreshParams, CancellationToken)"/>
    Task<HttpResponse<NumberRefreshResponse>> Refresh(
        string enterpriseID,
        NumberRefreshParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}