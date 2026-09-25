using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PronunciationDicts;

namespace Telnyx.Sdk.Services;

/// <summary>
/// Manage pronunciation dictionaries for text-to-speech synthesis. Dictionaries contain
/// alias items (text replacement) and phoneme items (IPA pronunciation notation)
/// that control how specific words are spoken.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPronunciationDictService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPronunciationDictServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPronunciationDictService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Create a new pronunciation dictionary for the authenticated organization. Each
/// dictionary contains a list of items that control how specific words are spoken.
/// Items can be alias type (text replacement) or phoneme type (IPA pronunciation
/// notation).
/// 
/// <para>As an alternative to providing items directly as JSON, you can upload a
/// dictionary file (PLS/XML or plain text format, max 1MB) using
/// multipart/form-data. PLS files use the standard W3C Pronunciation Lexicon
/// Specification XML format. Text files use a line-based format: `word=alias` for
/// aliases, `word:/phoneme/` for IPA phonemes.</para>
/// 
/// <para>Limits: - Maximum 50 dictionaries per organization - Maximum 100 items per
/// dictionary - Text: max 200 characters - Alias/phoneme value: max 500 characters
/// - File upload: max 1MB (1,048,576 bytes)</para>
/// </summary>
    Task<PronunciationDictResponse> Create(
        PronunciationDictCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve a single pronunciation dictionary by ID.
/// </summary>
    Task<PronunciationDictResponse> Retrieve(
        PronunciationDictRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PronunciationDictRetrieveParams, CancellationToken)"/>
    Task<PronunciationDictResponse> Retrieve(
        string id,
        PronunciationDictRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update the name and/or items of an existing pronunciation dictionary. Uses
/// optimistic locking — if the dictionary was modified concurrently, the request
/// returns 409 Conflict.
/// </summary>
    Task<PronunciationDictResponse> Update(
        PronunciationDictUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(PronunciationDictUpdateParams, CancellationToken)"/>
    Task<PronunciationDictResponse> Update(
        string id,
        PronunciationDictUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// List all pronunciation dictionaries for the authenticated organization. Results
/// are paginated using offset-based pagination.
/// </summary>
    Task<PronunciationDictListPage> List(
        PronunciationDictListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently delete a pronunciation dictionary.
/// </summary>
    Task Delete(
        PronunciationDictDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PronunciationDictDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        PronunciationDictDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPronunciationDictService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPronunciationDictServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPronunciationDictServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /pronunciation_dicts</c>, but is otherwise the
/// same as <see cref="IPronunciationDictService.Create(PronunciationDictCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PronunciationDictResponse>> Create(
        PronunciationDictCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /pronunciation_dicts/{id}</c>, but is otherwise the
/// same as <see cref="IPronunciationDictService.Retrieve(PronunciationDictRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PronunciationDictResponse>> Retrieve(
        PronunciationDictRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(PronunciationDictRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PronunciationDictResponse>> Retrieve(
        string id,
        PronunciationDictRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /pronunciation_dicts/{id}</c>, but is otherwise the
/// same as <see cref="IPronunciationDictService.Update(PronunciationDictUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PronunciationDictResponse>> Update(
        PronunciationDictUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(PronunciationDictUpdateParams, CancellationToken)"/>
    Task<HttpResponse<PronunciationDictResponse>> Update(
        string id,
        PronunciationDictUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /pronunciation_dicts</c>, but is otherwise the
/// same as <see cref="IPronunciationDictService.List(PronunciationDictListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PronunciationDictListPage>> List(
        PronunciationDictListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /pronunciation_dicts/{id}</c>, but is otherwise the
/// same as <see cref="IPronunciationDictService.Delete(PronunciationDictDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        PronunciationDictDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(PronunciationDictDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        PronunciationDictDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}