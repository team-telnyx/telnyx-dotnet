using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.MessagingProfiles;
using MessagingProfiles = Telnyx.Sdk.Services.MessagingProfiles;

namespace Telnyx.Sdk.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMessagingProfileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessagingProfileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingProfileService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    MessagingProfiles::IAutorespConfigService AutorespConfigs { get; }

    MessagingProfiles::IActionService Actions { get; }

    /// <summary>
/// Creates a messaging profile that controls outbound sender selection, webhook
/// delivery, and inbound message handling for associated numbers and short codes.
/// </summary>
    Task<MessagingProfileCreateResponse> Create(
        MessagingProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the complete configuration of the specified messaging profile, including
/// webhook and sender-selection settings.
/// </summary>
    Task<MessagingProfileRetrieveResponse> Retrieve(
        MessagingProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MessagingProfileRetrieveParams, CancellationToken)"/>
    Task<MessagingProfileRetrieveResponse> Retrieve(
        string messagingProfileID,
        MessagingProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the supplied settings on the specified messaging profile. Settings
/// omitted from the request remain unchanged.
/// </summary>
    Task<MessagingProfileUpdateResponse> Update(
        MessagingProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(MessagingProfileUpdateParams, CancellationToken)"/>
    Task<MessagingProfileUpdateResponse> Update(
        string messagingProfileID,
        MessagingProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Lists messaging profiles owned by the authenticated account. Apply the
/// documented filters and pagination parameters to narrow the result set.
/// </summary>
    Task<MessagingProfileListPage> List(
        MessagingProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the specified messaging profile and returns the profile's final
/// configuration.
/// </summary>
    Task<MessagingProfileDeleteResponse> Delete(
        MessagingProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MessagingProfileDeleteParams, CancellationToken)"/>
    Task<MessagingProfileDeleteResponse> Delete(
        string messagingProfileID,
        MessagingProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// List all alphanumeric sender IDs associated with a specific messaging profile.
/// </summary>
    Task<MessagingProfileListAlphanumericSenderIdsPage> ListAlphanumericSenderIds(
        MessagingProfileListAlphanumericSenderIdsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListAlphanumericSenderIds(MessagingProfileListAlphanumericSenderIdsParams, CancellationToken)"/>
    Task<MessagingProfileListAlphanumericSenderIdsPage> ListAlphanumericSenderIds(
        string id,
        MessagingProfileListAlphanumericSenderIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the phone numbers currently associated with the specified messaging
/// profile.
/// </summary>
    Task<MessagingProfileListPhoneNumbersPage> ListPhoneNumbers(
        MessagingProfileListPhoneNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListPhoneNumbers(MessagingProfileListPhoneNumbersParams, CancellationToken)"/>
    Task<MessagingProfileListPhoneNumbersPage> ListPhoneNumbers(
        string messagingProfileID,
        MessagingProfileListPhoneNumbersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the short codes currently associated with the specified messaging
/// profile.
/// </summary>
    Task<MessagingProfileListShortCodesPage> ListShortCodes(
        MessagingProfileListShortCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListShortCodes(MessagingProfileListShortCodesParams, CancellationToken)"/>
    Task<MessagingProfileListShortCodesPage> ListShortCodes(
        string messagingProfileID,
        MessagingProfileListShortCodesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get detailed metrics for a specific messaging profile, broken down by time
/// interval.
/// </summary>
    Task<MessagingProfileRetrieveMetricsResponse> RetrieveMetrics(
        MessagingProfileRetrieveMetricsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveMetrics(MessagingProfileRetrieveMetricsParams, CancellationToken)"/>
    Task<MessagingProfileRetrieveMetricsResponse> RetrieveMetrics(
        string id,
        MessagingProfileRetrieveMetricsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMessagingProfileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessagingProfileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessagingProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    MessagingProfiles::IAutorespConfigServiceWithRawResponse AutorespConfigs {
        get;
    }

    MessagingProfiles::IActionServiceWithRawResponse Actions { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /messaging_profiles</c>, but is otherwise the
/// same as <see cref="IMessagingProfileService.Create(MessagingProfileCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingProfileCreateResponse>> Create(
        MessagingProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_profiles/{id}</c>, but is otherwise the
/// same as <see cref="IMessagingProfileService.Retrieve(MessagingProfileRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingProfileRetrieveResponse>> Retrieve(
        MessagingProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MessagingProfileRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MessagingProfileRetrieveResponse>> Retrieve(
        string messagingProfileID,
        MessagingProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /messaging_profiles/{id}</c>, but is otherwise the
/// same as <see cref="IMessagingProfileService.Update(MessagingProfileUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingProfileUpdateResponse>> Update(
        MessagingProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(MessagingProfileUpdateParams, CancellationToken)"/>
    Task<HttpResponse<MessagingProfileUpdateResponse>> Update(
        string messagingProfileID,
        MessagingProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_profiles</c>, but is otherwise the
/// same as <see cref="IMessagingProfileService.List(MessagingProfileListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingProfileListPage>> List(
        MessagingProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /messaging_profiles/{id}</c>, but is otherwise the
/// same as <see cref="IMessagingProfileService.Delete(MessagingProfileDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingProfileDeleteResponse>> Delete(
        MessagingProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MessagingProfileDeleteParams, CancellationToken)"/>
    Task<HttpResponse<MessagingProfileDeleteResponse>> Delete(
        string messagingProfileID,
        MessagingProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_profiles/{id}/alphanumeric_sender_ids</c>, but is otherwise the
/// same as <see cref="IMessagingProfileService.ListAlphanumericSenderIds(MessagingProfileListAlphanumericSenderIdsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingProfileListAlphanumericSenderIdsPage>> ListAlphanumericSenderIds(
        MessagingProfileListAlphanumericSenderIdsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListAlphanumericSenderIds(MessagingProfileListAlphanumericSenderIdsParams, CancellationToken)"/>
    Task<HttpResponse<MessagingProfileListAlphanumericSenderIdsPage>> ListAlphanumericSenderIds(
        string id,
        MessagingProfileListAlphanumericSenderIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_profiles/{id}/phone_numbers</c>, but is otherwise the
/// same as <see cref="IMessagingProfileService.ListPhoneNumbers(MessagingProfileListPhoneNumbersParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingProfileListPhoneNumbersPage>> ListPhoneNumbers(
        MessagingProfileListPhoneNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListPhoneNumbers(MessagingProfileListPhoneNumbersParams, CancellationToken)"/>
    Task<HttpResponse<MessagingProfileListPhoneNumbersPage>> ListPhoneNumbers(
        string messagingProfileID,
        MessagingProfileListPhoneNumbersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_profiles/{id}/short_codes</c>, but is otherwise the
/// same as <see cref="IMessagingProfileService.ListShortCodes(MessagingProfileListShortCodesParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingProfileListShortCodesPage>> ListShortCodes(
        MessagingProfileListShortCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListShortCodes(MessagingProfileListShortCodesParams, CancellationToken)"/>
    Task<HttpResponse<MessagingProfileListShortCodesPage>> ListShortCodes(
        string messagingProfileID,
        MessagingProfileListShortCodesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /messaging_profiles/{id}/metrics</c>, but is otherwise the
/// same as <see cref="IMessagingProfileService.RetrieveMetrics(MessagingProfileRetrieveMetricsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessagingProfileRetrieveMetricsResponse>> RetrieveMetrics(
        MessagingProfileRetrieveMetricsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveMetrics(MessagingProfileRetrieveMetricsParams, CancellationToken)"/>
    Task<HttpResponse<MessagingProfileRetrieveMetricsResponse>> RetrieveMetrics(
        string id,
        MessagingProfileRetrieveMetricsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}