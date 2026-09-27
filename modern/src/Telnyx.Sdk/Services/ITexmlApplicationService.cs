using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.TexmlApplications;

namespace Telnyx.Sdk.Services;

/// <summary>
/// TeXML Applications operations
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITexmlApplicationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITexmlApplicationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITexmlApplicationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a TeXML application, which defines the voice URLs and settings used to
/// serve TeXML instructions for calls, and returns the created application.
/// </summary>
    Task<TexmlApplicationCreateResponse> Create(
        TexmlApplicationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieves the details of an existing TeXML Application.
/// </summary>
    Task<TexmlApplicationRetrieveResponse> Retrieve(
        TexmlApplicationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(TexmlApplicationRetrieveParams, CancellationToken)"/>
    Task<TexmlApplicationRetrieveResponse> Retrieve(
        string id,
        TexmlApplicationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates settings of an existing TeXML Application.
/// </summary>
    Task<TexmlApplicationUpdateResponse> Update(
        TexmlApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(TexmlApplicationUpdateParams, CancellationToken)"/>
    Task<TexmlApplicationUpdateResponse> Update(
        string id,
        TexmlApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a list of your TeXML Applications.
/// </summary>
    Task<TexmlApplicationListPage> List(
        TexmlApplicationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified TeXML application from your account.
/// </summary>
    Task<TexmlApplicationDeleteResponse> Delete(
        TexmlApplicationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(TexmlApplicationDeleteParams, CancellationToken)"/>
    Task<TexmlApplicationDeleteResponse> Delete(
        string id,
        TexmlApplicationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ITexmlApplicationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITexmlApplicationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITexmlApplicationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /texml_applications</c>, but is otherwise the
/// same as <see cref="ITexmlApplicationService.Create(TexmlApplicationCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TexmlApplicationCreateResponse>> Create(
        TexmlApplicationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /texml_applications/{id}</c>, but is otherwise the
/// same as <see cref="ITexmlApplicationService.Retrieve(TexmlApplicationRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TexmlApplicationRetrieveResponse>> Retrieve(
        TexmlApplicationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(TexmlApplicationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TexmlApplicationRetrieveResponse>> Retrieve(
        string id,
        TexmlApplicationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /texml_applications/{id}</c>, but is otherwise the
/// same as <see cref="ITexmlApplicationService.Update(TexmlApplicationUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TexmlApplicationUpdateResponse>> Update(
        TexmlApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(TexmlApplicationUpdateParams, CancellationToken)"/>
    Task<HttpResponse<TexmlApplicationUpdateResponse>> Update(
        string id,
        TexmlApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /texml_applications</c>, but is otherwise the
/// same as <see cref="ITexmlApplicationService.List(TexmlApplicationListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TexmlApplicationListPage>> List(
        TexmlApplicationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /texml_applications/{id}</c>, but is otherwise the
/// same as <see cref="ITexmlApplicationService.Delete(TexmlApplicationDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TexmlApplicationDeleteResponse>> Delete(
        TexmlApplicationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(TexmlApplicationDeleteParams, CancellationToken)"/>
    Task<HttpResponse<TexmlApplicationDeleteResponse>> Delete(
        string id,
        TexmlApplicationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}