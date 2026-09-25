using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Messaging10dlc.PhoneNumberAssignmentByProfile;

namespace Telnyx.Sdk.Services.Messaging10dlc;

/// <summary>
/// Phone number campaign bulk assignment
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPhoneNumberAssignmentByProfileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPhoneNumberAssignmentByProfileServiceWithRawResponse WithRawResponse {
        get;
    }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberAssignmentByProfileService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// This endpoint allows you to link all phone numbers associated with a Messaging
/// Profile to a campaign. **Please note:** if you want to assign phone numbers to a
/// campaign that you did not create with Telnyx 10DLC services, this endpoint
/// allows that provided that you've shared the campaign with Telnyx. In this case,
/// only provide the parameter, `tcrCampaignId`, and not `campaignId`. In all other
/// cases (where the campaign you're assigning was created with Telnyx 10DLC
/// services), only provide `campaignId`, not `tcrCampaignId`.
/// </summary>
    Task<PhoneNumberAssignmentByProfileAssignResponse> Assign(
        PhoneNumberAssignmentByProfileAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Check the status of the individual phone number/campaign assignments associated
/// with the supplied `taskId`.
/// </summary>
    Task<PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse> ListPhoneNumberStatus(
        PhoneNumberAssignmentByProfileListPhoneNumberStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListPhoneNumberStatus(PhoneNumberAssignmentByProfileListPhoneNumberStatusParams, CancellationToken)"/>
    Task<PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse> ListPhoneNumberStatus(
        string taskID,
        PhoneNumberAssignmentByProfileListPhoneNumberStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Check the status of the individual phone number/campaign assignments associated
/// with the supplied `taskId`.
/// </summary>
    Task<PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse> RetrievePhoneNumberStatus(
        PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrievePhoneNumberStatus(PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusParams, CancellationToken)"/>
    Task<PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse> RetrievePhoneNumberStatus(
        string taskID,
        PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Check the status of the task associated with assigning all phone numbers on a
/// messaging profile to a campaign by `taskId`.
/// </summary>
    Task<PhoneNumberAssignmentByProfileRetrieveStatusResponse> RetrieveStatus(
        PhoneNumberAssignmentByProfileRetrieveStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveStatus(PhoneNumberAssignmentByProfileRetrieveStatusParams, CancellationToken)"/>
    Task<PhoneNumberAssignmentByProfileRetrieveStatusResponse> RetrieveStatus(
        string taskID,
        PhoneNumberAssignmentByProfileRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPhoneNumberAssignmentByProfileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPhoneNumberAssignmentByProfileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberAssignmentByProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /10dlc/phoneNumberAssignmentByProfile</c>, but is otherwise the
/// same as <see cref="IPhoneNumberAssignmentByProfileService.Assign(PhoneNumberAssignmentByProfileAssignParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberAssignmentByProfileAssignResponse>> Assign(
        PhoneNumberAssignmentByProfileAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/phoneNumberAssignmentByProfile/{taskId}/phoneNumbers</c>, but is otherwise the
/// same as <see cref="IPhoneNumberAssignmentByProfileService.ListPhoneNumberStatus(PhoneNumberAssignmentByProfileListPhoneNumberStatusParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse>> ListPhoneNumberStatus(
        PhoneNumberAssignmentByProfileListPhoneNumberStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListPhoneNumberStatus(PhoneNumberAssignmentByProfileListPhoneNumberStatusParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse>> ListPhoneNumberStatus(
        string taskID,
        PhoneNumberAssignmentByProfileListPhoneNumberStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/phoneNumberAssignmentByProfile/{taskId}/phoneNumbers</c>, but is otherwise the
/// same as <see cref="IPhoneNumberAssignmentByProfileService.RetrievePhoneNumberStatus(PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse>> RetrievePhoneNumberStatus(
        PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrievePhoneNumberStatus(PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse>> RetrievePhoneNumberStatus(
        string taskID,
        PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /10dlc/phoneNumberAssignmentByProfile/{taskId}</c>, but is otherwise the
/// same as <see cref="IPhoneNumberAssignmentByProfileService.RetrieveStatus(PhoneNumberAssignmentByProfileRetrieveStatusParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PhoneNumberAssignmentByProfileRetrieveStatusResponse>> RetrieveStatus(
        PhoneNumberAssignmentByProfileRetrieveStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="RetrieveStatus(PhoneNumberAssignmentByProfileRetrieveStatusParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberAssignmentByProfileRetrieveStatusResponse>> RetrieveStatus(
        string taskID,
        PhoneNumberAssignmentByProfileRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}