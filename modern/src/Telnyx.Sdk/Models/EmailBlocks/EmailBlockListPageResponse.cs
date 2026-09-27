using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailBlocks;

[JsonConverter(typeof(EmailBlockListPageResponseConverter))]
public record class EmailBlockListPageResponse : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public EmailBlockListPageResponse (
        EmailBlockListOffsetResponse value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EmailBlockListPageResponse (
        EmailBlockListCursorResponse value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public EmailBlockListPageResponse (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="EmailBlockListOffsetResponse"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickOffset(out var value)) {
///     // `value` is of type `EmailBlockListOffsetResponse`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickOffset(
        [NotNullWhen(true)] out EmailBlockListOffsetResponse? value
    )
    {
        value =this.Value as EmailBlockListOffsetResponse ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="EmailBlockListCursorResponse"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCursor(out var value)) {
///     // `value` is of type `EmailBlockListCursorResponse`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCursor(
        [NotNullWhen(true)] out EmailBlockListCursorResponse? value
    )
    {
        value =this.Value as EmailBlockListCursorResponse ;
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
///     (EmailBlockListOffsetResponse value) =&gt; {...},
///     (EmailBlockListCursorResponse value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<EmailBlockListOffsetResponse> offset,
        System::Action<EmailBlockListCursorResponse> cursor
    )
    {
        switch (this.Value)
        {
            case EmailBlockListOffsetResponse value:
                offset(value);
                break;
            case EmailBlockListCursorResponse value:
                cursor(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of EmailBlockListPageResponse");

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
///     (EmailBlockListOffsetResponse value) =&gt; {...},
///     (EmailBlockListCursorResponse value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<EmailBlockListOffsetResponse, T> offset,
        System::Func<EmailBlockListCursorResponse, T> cursor
    )
    {
        return this.Value switch
        {
            EmailBlockListOffsetResponse value=>offset(value),
            EmailBlockListCursorResponse value=>cursor(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of EmailBlockListPageResponse")
        } ;
    }

    public static implicit operator EmailBlockListPageResponse (
        EmailBlockListOffsetResponse value
    )=> new(value) ;

    public static implicit operator EmailBlockListPageResponse (
        EmailBlockListCursorResponse value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of EmailBlockListPageResponse");
        }
        this.Switch((offset) => offset.Validate(),
        (cursor) => cursor.Validate());
    }

    public virtual bool Equals(EmailBlockListPageResponse? other)
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
        {
            EmailBlockListOffsetResponse _=>0,
            EmailBlockListCursorResponse _=>1,
            _ =>-1
        } ;
    }
}

sealed class EmailBlockListPageResponseConverter : JsonConverter<EmailBlockListPageResponse>
{
    public override EmailBlockListPageResponse? Read(
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
            var deserialized = JsonSerializer.Deserialize<EmailBlockListOffsetResponse>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<EmailBlockListCursorResponse>(element, options);
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
        Utf8JsonWriter writer,
        EmailBlockListPageResponse value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(JsonModelConverter<EmailBlockListOffsetResponse, EmailBlockListOffsetResponseFromRaw>))]
public sealed record class EmailBlockListOffsetResponse : JsonModel
{
    public required IReadOnlyList<EmailBlock> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmailBlock>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmailBlock>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required OffsetMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<OffsetMeta>(
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

    public EmailBlockListOffsetResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailBlockListOffsetResponse (
        EmailBlockListOffsetResponse emailBlockListOffsetResponse
    ) : base(emailBlockListOffsetResponse)
    {  }
    #pragma warning restore CS8618

    public EmailBlockListOffsetResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailBlockListOffsetResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailBlockListOffsetResponseFromRaw.FromRawUnchecked"/>
    public static EmailBlockListOffsetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class EmailBlockListOffsetResponseFromRaw : IFromRawJson<EmailBlockListOffsetResponse>
{
    /// <inheritdoc/>
    public EmailBlockListOffsetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailBlockListOffsetResponse.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<EmailBlockListCursorResponse, EmailBlockListCursorResponseFromRaw>))]
public sealed record class EmailBlockListCursorResponse : JsonModel
{
    public required IReadOnlyList<EmailBlock> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmailBlock>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmailBlock>>(
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

    public EmailBlockListCursorResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailBlockListCursorResponse (
        EmailBlockListCursorResponse emailBlockListCursorResponse
    ) : base(emailBlockListCursorResponse)
    {  }
    #pragma warning restore CS8618

    public EmailBlockListCursorResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailBlockListCursorResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailBlockListCursorResponseFromRaw.FromRawUnchecked"/>
    public static EmailBlockListCursorResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class EmailBlockListCursorResponseFromRaw : IFromRawJson<EmailBlockListCursorResponse>
{
    /// <inheritdoc/>
    public EmailBlockListCursorResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailBlockListCursorResponse.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
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
    /// Omitted when `has_next` is false.
    /// </summary>
    public string? NextCursor {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "next_cursor"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("next_cursor", value);
        }
    }

    /// <summary>
    /// Omitted when `has_previous` is false.
    /// </summary>
    public string? PreviousCursor {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "previous_cursor"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("previous_cursor", value);
        }
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

    public Meta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meta (Meta meta) : base(meta)
    {  }
    #pragma warning restore CS8618

    public Meta (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Meta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MetaFromRaw.FromRawUnchecked"/>
    public static Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Meta.FromRawUnchecked(rawData);
}