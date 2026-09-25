using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailDomains.Webhooks;

namespace Telnyx.Sdk.Models.EmailDomains;

[JsonConverter(typeof(JsonModelConverter<EmailDomainListPageResponse, EmailDomainListPageResponseFromRaw>))]
public sealed record class EmailDomainListPageResponse : JsonModel
{
    public required IReadOnlyList<EmailDomain> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmailDomain>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmailDomain>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Meta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Meta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public EmailDomainListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainListPageResponse (
        EmailDomainListPageResponse emailDomainListPageResponse
    ) : base(emailDomainListPageResponse)
    {  }
    #pragma warning restore CS8618

    public EmailDomainListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainListPageResponseFromRaw.FromRawUnchecked"/>
    public static EmailDomainListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailDomainListPageResponseFromRaw : IFromRawJson<EmailDomainListPageResponse>
{
    /// <inheritdoc/>
    public EmailDomainListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailDomainListPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MetaConverter))]
public record class Meta : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public long PageSize {
        get {
            return Match(offsetPagination: ( x )=>x.PageSize,
            emailCursorPagination: ( x )=>x.PageSize);
        }
    }

    public Meta (OffsetPaginationMeta value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Meta (EmailCursorPaginationMeta value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Meta (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="OffsetPaginationMeta"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickOffsetPagination(out var value)) {
///     // `value` is of type `OffsetPaginationMeta`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickOffsetPagination(
        [NotNullWhen(true)] out OffsetPaginationMeta? value
    )
    {
        value =this.Value as OffsetPaginationMeta ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="EmailCursorPaginationMeta"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickEmailCursorPagination(out var value)) {
///     // `value` is of type `EmailCursorPaginationMeta`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickEmailCursorPagination(
        [NotNullWhen(true)] out EmailCursorPaginationMeta? value
    )
    {
        value =this.Value as EmailCursorPaginationMeta ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (OffsetPaginationMeta value) =&gt; {...},
///     (EmailCursorPaginationMeta value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<OffsetPaginationMeta> offsetPagination,
        System::Action<EmailCursorPaginationMeta> emailCursorPagination
    )
    {
        switch (this.Value)
        {
            case OffsetPaginationMeta value:
                offsetPagination(value);
                break;
            case EmailCursorPaginationMeta value:
                emailCursorPagination(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Meta");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (OffsetPaginationMeta value) =&gt; {...},
///     (EmailCursorPaginationMeta value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<OffsetPaginationMeta, T> offsetPagination,
        System::Func<EmailCursorPaginationMeta, T> emailCursorPagination
    )
    {
        return this.Value switch
        {
            OffsetPaginationMeta value=>offsetPagination(value),
            EmailCursorPaginationMeta value=>emailCursorPagination(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Meta")
        } ;
    }

    public static implicit operator Meta (
        OffsetPaginationMeta value
    )=> new(value) ;

    public static implicit operator Meta (
        EmailCursorPaginationMeta value
    )=> new(value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of Meta");
        }
        this.Switch((offsetPagination) => offsetPagination.Validate(),
        (emailCursorPagination) => emailCursorPagination.Validate());
    }

    public virtual bool Equals(Meta? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        { OffsetPaginationMeta _=>0, EmailCursorPaginationMeta _=>1, _ =>-1 } ;
    }
}sealed class MetaConverter : JsonConverter<Meta>
{
    public override Meta? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<OffsetPaginationMeta>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<EmailCursorPaginationMeta>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, Meta value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}[JsonConverter(typeof(JsonModelConverter<EmailCursorPaginationMeta, EmailCursorPaginationMetaFromRaw>))]
public sealed record class EmailCursorPaginationMeta : JsonModel
{
    public required bool HasNext {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "has_next"
            );
        }
        init { this._rawData.Set("has_next", value); }
    }

    public required bool HasPrevious {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "has_previous"
            );
        }
        init { this._rawData.Set("has_previous", value); }
    }

    public required long PageSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "page_size"
            );
        }
        init { this._rawData.Set("page_size", value); }
    }

    /// <summary>
    /// Opaque cursor to fetch the next page
    /// </summary>
    public string? NextCursor {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "next_cursor"
            );
        }
        init { this._rawData.Set("next_cursor", value); }
    }

    /// <summary>
    /// Opaque cursor to fetch the previous page
    /// </summary>
    public string? PreviousCursor {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "previous_cursor"
            );
        }
        init { this._rawData.Set("previous_cursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasNext;
        _ = this.HasPrevious;
        _ = this.PageSize;
        _ = this.NextCursor;
        _ = this.PreviousCursor;
    }

    public EmailCursorPaginationMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailCursorPaginationMeta (
        EmailCursorPaginationMeta emailCursorPaginationMeta
    ) : base(emailCursorPaginationMeta)
    {  }
    #pragma warning restore CS8618

    public EmailCursorPaginationMeta (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailCursorPaginationMeta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailCursorPaginationMetaFromRaw.FromRawUnchecked"/>
    public static EmailCursorPaginationMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class EmailCursorPaginationMetaFromRaw : IFromRawJson<EmailCursorPaginationMeta>
{
    /// <inheritdoc/>
    public EmailCursorPaginationMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailCursorPaginationMeta.FromRawUnchecked(rawData);
}