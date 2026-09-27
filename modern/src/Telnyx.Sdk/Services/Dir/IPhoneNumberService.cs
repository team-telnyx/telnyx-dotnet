using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Dir.PhoneNumbers;

namespace Telnyx.Sdk.Services.Dir;

/// <summary>
/// Associate phone numbers with a verified DIR so calls from those numbers carry
/// the DIR's display identity.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPhoneNumberService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPhoneNumberServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// List the phone numbers registered under a DIR. The enterprise is resolved
/// server-side from the DIR id.
/// </summary>
    Task<PhoneNumberListPage> List(
        PhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(PhoneNumberListParams, CancellationToken)"/>
    Task<PhoneNumberListPage> List(
        string dirID,
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Register phone numbers under a DIR. The enterprise is resolved server-side from
/// the DIR id. Same body, failure modes, and batch semantics whichever path form
/// you use.
/// 
/// <para>**Pricing:** This is a billable action. See
/// https://telnyx.com/pricing/numbers for current pricing.</para>
/// </summary>
    Task<PhoneNumberAddResponse> Add(
        PhoneNumberAddParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Add(PhoneNumberAddParams, CancellationToken)"/>
    Task<PhoneNumberAddResponse> Add(
        string dirID,
        PhoneNumberAddParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deregister phone numbers from a DIR. The enterprise is resolved server-side from
/// the DIR id. Returns a partial-success envelope.
/// </summary>
    Task<PhoneNumberRemoveResponse> Remove(
        PhoneNumberRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Remove(PhoneNumberRemoveParams, CancellationToken)"/>
    Task<PhoneNumberRemoveResponse> Remove(
        string dirID,
        PhoneNumberRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPhoneNumberService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPhoneNumberServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /dir/{dir_id}/phone_numbers</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.List(PhoneNumberListParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberListPage>> List(
        PhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="List(PhoneNumberListParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberListPage>> List(
        string dirID,
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /dir/{dir_id}/phone_numbers</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.Add(PhoneNumberAddParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberAddResponse>> Add(
        PhoneNumberAddParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Add(PhoneNumberAddParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberAddResponse>> Add(
        string dirID,
        PhoneNumberAddParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /dir/{dir_id}/phone_numbers</c>, but is otherwise the
/// same as <see cref="IPhoneNumberService.Remove(PhoneNumberRemoveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberRemoveResponse>> Remove(
        PhoneNumberRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Remove(PhoneNumberRemoveParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberRemoveResponse>> Remove(
        string dirID,
        PhoneNumberRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}