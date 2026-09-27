using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.ExternalConnections;
using ExternalConnections = Telnyx.Sdk.Services.ExternalConnections;

namespace Telnyx.Sdk.Services;

/// <summary>
/// External Connections operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IExternalConnectionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExternalConnectionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalConnectionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    ExternalConnections::ILogMessageService LogMessages { get; }

    ExternalConnections::ICivicAddressService CivicAddresses { get; }

    ExternalConnections::IPhoneNumberService PhoneNumbers { get; }

    ExternalConnections::IReleaseService Releases { get; }

    ExternalConnections::IUploadService Uploads { get; }

    /// <summary>
/// Creates a new External Connection based on the parameters sent in the request.
/// The external_sip_connection and outbound voice profile id are required. Once
/// created, you can assign phone numbers to your application using the
/// `/phone_numbers` endpoint.
/// </summary>
    Task<ExternalConnectionCreateResponse> Create(
        ExternalConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Return the details of an existing External Connection inside the 'data'
/// attribute of the response.
/// </summary>
    Task<ExternalConnectionRetrieveResponse> Retrieve(
        ExternalConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ExternalConnectionRetrieveParams, CancellationToken)"/>
    Task<ExternalConnectionRetrieveResponse> Retrieve(
        string id,
        ExternalConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates settings of an existing External Connection based on the parameters of
/// the request.
/// </summary>
    Task<ExternalConnectionUpdateResponse> Update(
        ExternalConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ExternalConnectionUpdateParams, CancellationToken)"/>
    Task<ExternalConnectionUpdateResponse> Update(
        string id,
        ExternalConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This endpoint returns a list of your External Connections inside the 'data'
/// attribute of the response. External Connections are used by Telnyx customers to
/// seamless configure SIP trunking integrations with Telnyx Partners, through
/// External Voice Integrations in Mission Control Portal.
/// </summary>
    Task<ExternalConnectionListPage> List(
        ExternalConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes an External Connection. Deletion may be prevented if the
/// application is in use by phone numbers, is active, or if it is an Operator
/// Connect connection. To remove an Operator Connect integration please contact
/// Telnyx support.
/// </summary>
    Task<ExternalConnectionDeleteResponse> Delete(
        ExternalConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(ExternalConnectionDeleteParams, CancellationToken)"/>
    Task<ExternalConnectionDeleteResponse> Delete(
        string id,
        ExternalConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update the static emergency address assigned to a specific location of an
/// external connection.
/// </summary>
    Task<ExternalConnectionUpdateLocationResponse> UpdateLocation(
        ExternalConnectionUpdateLocationParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateLocation(ExternalConnectionUpdateLocationParams, CancellationToken)"/>
    Task<ExternalConnectionUpdateLocationResponse> UpdateLocation(
        string locationID,
        ExternalConnectionUpdateLocationParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IExternalConnectionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExternalConnectionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalConnectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    ExternalConnections::ILogMessageServiceWithRawResponse LogMessages { get; }

    ExternalConnections::ICivicAddressServiceWithRawResponse CivicAddresses {
        get;
    }

    ExternalConnections::IPhoneNumberServiceWithRawResponse PhoneNumbers {
        get;
    }

    ExternalConnections::IReleaseServiceWithRawResponse Releases { get; }

    ExternalConnections::IUploadServiceWithRawResponse Uploads { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /external_connections</c>, but is otherwise the
/// same as <see cref="IExternalConnectionService.Create(ExternalConnectionCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ExternalConnectionCreateResponse>> Create(
        ExternalConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /external_connections/{id}</c>, but is otherwise the
/// same as <see cref="IExternalConnectionService.Retrieve(ExternalConnectionRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ExternalConnectionRetrieveResponse>> Retrieve(
        ExternalConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(ExternalConnectionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ExternalConnectionRetrieveResponse>> Retrieve(
        string id,
        ExternalConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /external_connections/{id}</c>, but is otherwise the
/// same as <see cref="IExternalConnectionService.Update(ExternalConnectionUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ExternalConnectionUpdateResponse>> Update(
        ExternalConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(ExternalConnectionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ExternalConnectionUpdateResponse>> Update(
        string id,
        ExternalConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /external_connections</c>, but is otherwise the
/// same as <see cref="IExternalConnectionService.List(ExternalConnectionListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ExternalConnectionListPage>> List(
        ExternalConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /external_connections/{id}</c>, but is otherwise the
/// same as <see cref="IExternalConnectionService.Delete(ExternalConnectionDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ExternalConnectionDeleteResponse>> Delete(
        ExternalConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(ExternalConnectionDeleteParams, CancellationToken)"/>
    Task<HttpResponse<ExternalConnectionDeleteResponse>> Delete(
        string id,
        ExternalConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /external_connections/{id}/locations/{location_id}</c>, but is otherwise the
/// same as <see cref="IExternalConnectionService.UpdateLocation(ExternalConnectionUpdateLocationParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ExternalConnectionUpdateLocationResponse>> UpdateLocation(
        ExternalConnectionUpdateLocationParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateLocation(ExternalConnectionUpdateLocationParams, CancellationToken)"/>
    Task<HttpResponse<ExternalConnectionUpdateLocationResponse>> UpdateLocation(
        string locationID,
        ExternalConnectionUpdateLocationParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}