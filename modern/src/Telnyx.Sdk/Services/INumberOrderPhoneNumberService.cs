using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.NumberOrderPhoneNumbers;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface INumberOrderPhoneNumberService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INumberOrderPhoneNumberServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumberOrderPhoneNumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Get an existing phone number in number order.
/// </summary>
    Task<NumberOrderPhoneNumberRetrieveResponse> Retrieve(
        NumberOrderPhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NumberOrderPhoneNumberRetrieveParams, CancellationToken)"/>
    Task<NumberOrderPhoneNumberRetrieveResponse> Retrieve(
        string numberOrderPhoneNumberID,
        NumberOrderPhoneNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get a list of phone numbers associated to orders.
/// </summary>
    Task<NumberOrderPhoneNumberListResponse> List(
        NumberOrderPhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Associates an existing requirement group with a phone number in a number order.
/// The response contains the updated number-order phone-number details.
/// </summary>
    Task<NumberOrderPhoneNumberUpdateRequirementGroupResponse> UpdateRequirementGroup(
        NumberOrderPhoneNumberUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateRequirementGroup(NumberOrderPhoneNumberUpdateRequirementGroupParams, CancellationToken)"/>
    Task<NumberOrderPhoneNumberUpdateRequirementGroupResponse> UpdateRequirementGroup(
        string id,
        NumberOrderPhoneNumberUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates requirements for a single phone number within a number order.
/// </summary>
    Task<NumberOrderPhoneNumberUpdateRequirementsResponse> UpdateRequirements(
        NumberOrderPhoneNumberUpdateRequirementsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateRequirements(NumberOrderPhoneNumberUpdateRequirementsParams, CancellationToken)"/>
    Task<NumberOrderPhoneNumberUpdateRequirementsResponse> UpdateRequirements(
        string numberOrderPhoneNumberID,
        NumberOrderPhoneNumberUpdateRequirementsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="INumberOrderPhoneNumberService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INumberOrderPhoneNumberServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INumberOrderPhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /number_order_phone_numbers/{number_order_phone_number_id}</c>, but is otherwise the
/// same as <see cref="INumberOrderPhoneNumberService.Retrieve(NumberOrderPhoneNumberRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberOrderPhoneNumberRetrieveResponse>> Retrieve(
        NumberOrderPhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(NumberOrderPhoneNumberRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<NumberOrderPhoneNumberRetrieveResponse>> Retrieve(
        string numberOrderPhoneNumberID,
        NumberOrderPhoneNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /number_order_phone_numbers</c>, but is otherwise the
/// same as <see cref="INumberOrderPhoneNumberService.List(NumberOrderPhoneNumberListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberOrderPhoneNumberListResponse>> List(
        NumberOrderPhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /number_order_phone_numbers/{id}/requirement_group</c>, but is otherwise the
/// same as <see cref="INumberOrderPhoneNumberService.UpdateRequirementGroup(NumberOrderPhoneNumberUpdateRequirementGroupParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberOrderPhoneNumberUpdateRequirementGroupResponse>> UpdateRequirementGroup(
        NumberOrderPhoneNumberUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateRequirementGroup(NumberOrderPhoneNumberUpdateRequirementGroupParams, CancellationToken)"/>
    Task<HttpResponse<NumberOrderPhoneNumberUpdateRequirementGroupResponse>> UpdateRequirementGroup(
        string id,
        NumberOrderPhoneNumberUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /number_order_phone_numbers/{number_order_phone_number_id}</c>, but is otherwise the
/// same as <see cref="INumberOrderPhoneNumberService.UpdateRequirements(NumberOrderPhoneNumberUpdateRequirementsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<NumberOrderPhoneNumberUpdateRequirementsResponse>> UpdateRequirements(
        NumberOrderPhoneNumberUpdateRequirementsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateRequirements(NumberOrderPhoneNumberUpdateRequirementsParams, CancellationToken)"/>
    Task<HttpResponse<NumberOrderPhoneNumberUpdateRequirementsResponse>> UpdateRequirements(
        string numberOrderPhoneNumberID,
        NumberOrderPhoneNumberUpdateRequirementsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}