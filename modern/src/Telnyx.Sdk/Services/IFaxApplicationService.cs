using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.FaxApplications;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Fax Applications operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IFaxApplicationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFaxApplicationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFaxApplicationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a new Fax Application based on the parameters sent in the request. The
/// application name and webhook URL are required. Once created, you can assign
/// phone numbers to your application using the `/phone_numbers` endpoint.
/// </summary>
    Task<FaxApplicationCreateResponse> Create(
        FaxApplicationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Return the details of an existing Fax Application inside the 'data' attribute of
/// the response.
/// </summary>
    Task<FaxApplicationRetrieveResponse> Retrieve(
        FaxApplicationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(FaxApplicationRetrieveParams, CancellationToken)"/>
    Task<FaxApplicationRetrieveResponse> Retrieve(
        string id,
        FaxApplicationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates settings of an existing Fax Application based on the parameters of the
/// request.
/// </summary>
    Task<FaxApplicationUpdateResponse> Update(
        FaxApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(FaxApplicationUpdateParams, CancellationToken)"/>
    Task<FaxApplicationUpdateResponse> Update(
        string id,
        FaxApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// This endpoint returns a list of your Fax Applications inside the 'data'
/// attribute of the response. You can adjust which applications are listed by using
/// filters. Fax Applications are used to configure how you send and receive faxes
/// using the Programmable Fax API with Telnyx.
/// </summary>
    Task<FaxApplicationListPage> List(
        FaxApplicationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes a Fax Application. Deletion may be prevented if the
/// application is in use by phone numbers.
/// </summary>
    Task<FaxApplicationDeleteResponse> Delete(
        FaxApplicationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(FaxApplicationDeleteParams, CancellationToken)"/>
    Task<FaxApplicationDeleteResponse> Delete(
        string id,
        FaxApplicationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IFaxApplicationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFaxApplicationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFaxApplicationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /fax_applications</c>, but is otherwise the
/// same as <see cref="IFaxApplicationService.Create(FaxApplicationCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FaxApplicationCreateResponse>> Create(
        FaxApplicationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /fax_applications/{id}</c>, but is otherwise the
/// same as <see cref="IFaxApplicationService.Retrieve(FaxApplicationRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FaxApplicationRetrieveResponse>> Retrieve(
        FaxApplicationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(FaxApplicationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<FaxApplicationRetrieveResponse>> Retrieve(
        string id,
        FaxApplicationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /fax_applications/{id}</c>, but is otherwise the
/// same as <see cref="IFaxApplicationService.Update(FaxApplicationUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FaxApplicationUpdateResponse>> Update(
        FaxApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(FaxApplicationUpdateParams, CancellationToken)"/>
    Task<HttpResponse<FaxApplicationUpdateResponse>> Update(
        string id,
        FaxApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /fax_applications</c>, but is otherwise the
/// same as <see cref="IFaxApplicationService.List(FaxApplicationListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FaxApplicationListPage>> List(
        FaxApplicationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /fax_applications/{id}</c>, but is otherwise the
/// same as <see cref="IFaxApplicationService.Delete(FaxApplicationDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<FaxApplicationDeleteResponse>> Delete(
        FaxApplicationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(FaxApplicationDeleteParams, CancellationToken)"/>
    Task<HttpResponse<FaxApplicationDeleteResponse>> Delete(
        string id,
        FaxApplicationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}