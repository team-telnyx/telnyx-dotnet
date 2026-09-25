using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PhoneNumbersRegulatoryRequirements;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Regulatory Requirements
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPhoneNumbersRegulatoryRequirementService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPhoneNumbersRegulatoryRequirementServiceWithRawResponse WithRawResponse {
        get;
    }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumbersRegulatoryRequirementService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns the regulatory requirements that apply to the supplied comma-separated
/// phone numbers. The response includes the matching requirement records and
/// pagination metadata.
/// </summary>
    Task<PhoneNumbersRegulatoryRequirementRetrieveResponse> Retrieve(
        PhoneNumbersRegulatoryRequirementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPhoneNumbersRegulatoryRequirementService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPhoneNumbersRegulatoryRequirementServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumbersRegulatoryRequirementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /phone_numbers_regulatory_requirements</c>, but is otherwise the
/// same as <see cref="IPhoneNumbersRegulatoryRequirementService.Retrieve(PhoneNumbersRegulatoryRequirementRetrieveParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumbersRegulatoryRequirementRetrieveResponse>> Retrieve(
        PhoneNumbersRegulatoryRequirementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}