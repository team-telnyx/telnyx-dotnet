using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.CustomerServiceRecords;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Customer Service Record operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICustomerServiceRecordService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICustomerServiceRecordServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomerServiceRecordService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Create a new customer service record for the provided phone number.
/// </summary>
    Task<CustomerServiceRecordCreateResponse> Create(
        CustomerServiceRecordCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single customer service record (CSR) request, including
/// its status and any retrieved record data.
/// </summary>
    Task<CustomerServiceRecordRetrieveResponse> Retrieve(
        CustomerServiceRecordRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CustomerServiceRecordRetrieveParams, CancellationToken)"/>
    Task<CustomerServiceRecordRetrieveResponse> Retrieve(
        string customerServiceRecordID,
        CustomerServiceRecordRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of your customer service record (CSR) requests, with
/// support for filtering and sorting.
/// </summary>
    Task<CustomerServiceRecordListPage> List(
        CustomerServiceRecordListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Verify the coverage for a list of phone numbers.
/// </summary>
    Task<CustomerServiceRecordVerifyPhoneNumberCoverageResponse> VerifyPhoneNumberCoverage(
        CustomerServiceRecordVerifyPhoneNumberCoverageParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ICustomerServiceRecordService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICustomerServiceRecordServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomerServiceRecordServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /customer_service_records</c>, but is otherwise the
/// same as <see cref="ICustomerServiceRecordService.Create(CustomerServiceRecordCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CustomerServiceRecordCreateResponse>> Create(
        CustomerServiceRecordCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /customer_service_records/{customer_service_record_id}</c>, but is otherwise the
/// same as <see cref="ICustomerServiceRecordService.Retrieve(CustomerServiceRecordRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CustomerServiceRecordRetrieveResponse>> Retrieve(
        CustomerServiceRecordRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(CustomerServiceRecordRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CustomerServiceRecordRetrieveResponse>> Retrieve(
        string customerServiceRecordID,
        CustomerServiceRecordRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /customer_service_records</c>, but is otherwise the
/// same as <see cref="ICustomerServiceRecordService.List(CustomerServiceRecordListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CustomerServiceRecordListPage>> List(
        CustomerServiceRecordListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /customer_service_records/phone_number_coverages</c>, but is otherwise the
/// same as <see cref="ICustomerServiceRecordService.VerifyPhoneNumberCoverage(CustomerServiceRecordVerifyPhoneNumberCoverageParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<CustomerServiceRecordVerifyPhoneNumberCoverageResponse>> VerifyPhoneNumberCoverage(
        CustomerServiceRecordVerifyPhoneNumberCoverageParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}