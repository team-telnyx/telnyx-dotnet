using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.VerifyProfiles;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Two factor authentication API
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IVerifyProfileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVerifyProfileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVerifyProfileService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Creates a new Verify profile to associate verifications with.
/// </summary>
    Task<VerifyProfileData> Create(
        VerifyProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns the details of a single Verify profile by its ID, including its
/// verification channel configuration.
/// </summary>
    Task<VerifyProfileData> Retrieve(
        VerifyProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VerifyProfileRetrieveParams, CancellationToken)"/>
    Task<VerifyProfileData> Retrieve(
        string verifyProfileID,
        VerifyProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified Verify profile's name, webhook destinations, language,
/// daily spend limits, or channel-specific settings. Returns the updated profile.
/// </summary>
    Task<VerifyProfileData> Update(
        VerifyProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(VerifyProfileUpdateParams, CancellationToken)"/>
    Task<VerifyProfileData> Update(
        string verifyProfileID,
        VerifyProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Gets a paginated list of Verify profiles.
/// </summary>
    Task<VerifyProfileListPage> List(
        VerifyProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Deletes the specified Verify profile and returns the deleted profile record.
/// </summary>
    Task<VerifyProfileData> Delete(
        VerifyProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(VerifyProfileDeleteParams, CancellationToken)"/>
    Task<VerifyProfileData> Delete(
        string verifyProfileID,
        VerifyProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Create a new Verify profile message template.
/// </summary>
    Task<MessageTemplate> CreateTemplate(
        VerifyProfileCreateTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// List all Verify profile message templates.
/// </summary>
    Task<VerifyProfileRetrieveTemplatesResponse> RetrieveTemplates(
        VerifyProfileRetrieveTemplatesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update an existing Verify profile message template.
/// </summary>
    Task<MessageTemplate> UpdateTemplate(
        VerifyProfileUpdateTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateTemplate(VerifyProfileUpdateTemplateParams, CancellationToken)"/>
    Task<MessageTemplate> UpdateTemplate(
        string templateID,
        VerifyProfileUpdateTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IVerifyProfileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVerifyProfileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVerifyProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /verify_profiles</c>, but is otherwise the
/// same as <see cref="IVerifyProfileService.Create(VerifyProfileCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VerifyProfileData>> Create(
        VerifyProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /verify_profiles/{verify_profile_id}</c>, but is otherwise the
/// same as <see cref="IVerifyProfileService.Retrieve(VerifyProfileRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VerifyProfileData>> Retrieve(
        VerifyProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(VerifyProfileRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<VerifyProfileData>> Retrieve(
        string verifyProfileID,
        VerifyProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /verify_profiles/{verify_profile_id}</c>, but is otherwise the
/// same as <see cref="IVerifyProfileService.Update(VerifyProfileUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VerifyProfileData>> Update(
        VerifyProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(VerifyProfileUpdateParams, CancellationToken)"/>
    Task<HttpResponse<VerifyProfileData>> Update(
        string verifyProfileID,
        VerifyProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /verify_profiles</c>, but is otherwise the
/// same as <see cref="IVerifyProfileService.List(VerifyProfileListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VerifyProfileListPage>> List(
        VerifyProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /verify_profiles/{verify_profile_id}</c>, but is otherwise the
/// same as <see cref="IVerifyProfileService.Delete(VerifyProfileDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VerifyProfileData>> Delete(
        VerifyProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(VerifyProfileDeleteParams, CancellationToken)"/>
    Task<HttpResponse<VerifyProfileData>> Delete(
        string verifyProfileID,
        VerifyProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /verify_profiles/templates</c>, but is otherwise the
/// same as <see cref="IVerifyProfileService.CreateTemplate(VerifyProfileCreateTemplateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessageTemplate>> CreateTemplate(
        VerifyProfileCreateTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /verify_profiles/templates</c>, but is otherwise the
/// same as <see cref="IVerifyProfileService.RetrieveTemplates(VerifyProfileRetrieveTemplatesParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<VerifyProfileRetrieveTemplatesResponse>> RetrieveTemplates(
        VerifyProfileRetrieveTemplatesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /verify_profiles/templates/{template_id}</c>, but is otherwise the
/// same as <see cref="IVerifyProfileService.UpdateTemplate(VerifyProfileUpdateTemplateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MessageTemplate>> UpdateTemplate(
        VerifyProfileUpdateTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="UpdateTemplate(VerifyProfileUpdateTemplateParams, CancellationToken)"/>
    Task<HttpResponse<MessageTemplate>> UpdateTemplate(
        string templateID,
        VerifyProfileUpdateTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}