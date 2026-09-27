using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Numbers = Telnyx.Sdk.Models.Enterprises.Reputation.Numbers;
using Telnyx.Sdk.Models.Reputation.Numbers;

namespace Telnyx.Sdk.Services.Reputation;

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
/// Convenience alias for `GET
/// /v2/enterprises/{enterprise_id}/reputation/numbers/{phone_number}`.
/// </summary>
    Task<Numbers::ReputationPhoneNumberWithReputation> Retrieve(
        NumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NumberRetrieveParams, CancellationToken)"/>
    Task<Numbers::ReputationPhoneNumberWithReputation> Retrieve(
        string phoneNumber,
        NumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Convenience alias for `GET /v2/enterprises/{enterprise_id}/reputation/numbers`
/// that returns numbers across every enterprise you own. Useful when you don't want
/// to look up the enterprise id first.
/// </summary>
    Task<NumberListPage> List(
        NumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Convenience alias for `DELETE
/// /v2/enterprises/{enterprise_id}/reputation/numbers/{phone_number}`.
/// </summary>
    Task Delete(
        NumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(NumberDeleteParams, CancellationToken)"/>
    Task Delete(
        string phoneNumber,
        NumberDeleteParams? parameters = null,
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
/// Returns a raw HTTP response for <c>get /reputation/numbers/{phone_number}</c>, but is otherwise the
/// same as <see cref="INumberService.Retrieve(NumberRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Numbers::ReputationPhoneNumberWithReputation>> Retrieve(
        NumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NumberRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Numbers::ReputationPhoneNumberWithReputation>> Retrieve(
        string phoneNumber,
        NumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /reputation/numbers</c>, but is otherwise the
/// same as <see cref="INumberService.List(NumberListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberListPage>> List(
        NumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /reputation/numbers/{phone_number}</c>, but is otherwise the
/// same as <see cref="INumberService.Delete(NumberDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        NumberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(NumberDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string phoneNumber,
        NumberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}