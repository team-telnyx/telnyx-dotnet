using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Dir.PhoneNumbers;

/// <summary>
/// Bulk-delete partial-success response. `data` is the list of phone numbers that
/// were soft-deleted. `meta.errors` holds per-number failures (e.g. number not associated
/// with this DIR). When EVERY number in the request fails, the endpoint instead
/// returns 400 with the canonical Telnyx error envelope and `data`/`meta` are absent.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PhoneNumberRemoveResponse, PhoneNumberRemoveResponseFromRaw>))]
public sealed record class PhoneNumberRemoveResponse : JsonModel
{
    /// <summary>
    /// Phone numbers that were successfully soft-deleted. Bare E.164 strings.
    /// </summary>
    public required IReadOnlyList<string> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
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
        _ = this.Data;
        this.Meta.Validate();
    }

    public PhoneNumberRemoveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberRemoveResponse (
        PhoneNumberRemoveResponse phoneNumberRemoveResponse
    ) : base(phoneNumberRemoveResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberRemoveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberRemoveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberRemoveResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberRemoveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberRemoveResponseFromRaw : IFromRawJson<PhoneNumberRemoveResponse>
{
    /// <inheritdoc/>
    public PhoneNumberRemoveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberRemoveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    /// <summary>
    /// Per-number failures that did not block the call. Each entry has `phone_number`,
    /// `code`, `title`, `detail`.
    /// </summary>
    public required IReadOnlyList<Error> Errors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Error>>(
                "errors"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Error>>(
                "errors",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Errors)
        {
            item.Validate();
        }
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

    [SetsRequiredMembers]
    public Meta (IReadOnlyList<Error> errors) : this()
    { this.Errors = errors; }
}class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Meta.FromRawUnchecked(rawData);
}/// <summary>
/// Per-number error returned by the bulk-delete endpoint. Bulk-add does not use this
/// shape - it returns a 400 with the canonical envelope grouping numbers by failure category.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Error, ErrorFromRaw>))]
public sealed record class Error : JsonModel
{
    /// <summary>
    /// Stable per-number error code. Currently only `not_associated` is emitted,
    /// when the number is not attached to this DIR.
    /// </summary>
    public required ApiEnum<string, Code> Code {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Code>>(
                "code"
            );
        }
        init { this._rawData.Set("code", value); }
    }

    public required string Detail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "detail"
            );
        }
        init { this._rawData.Set("detail", value); }
    }

    public required string PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phone_number"
            );
        }
        init { this._rawData.Set("phone_number", value); }
    }

    public required string Title {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "title"
            );
        }
        init { this._rawData.Set("title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Code.Validate();
        _ = this.Detail;
        _ = this.PhoneNumber;
        _ = this.Title;
    }

    public Error ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Error (Error error) : base(error)
    {  }
    #pragma warning restore CS8618

    public Error (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Error (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ErrorFromRaw.FromRawUnchecked"/>
    public static Error FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ErrorFromRaw : IFromRawJson<Error>
{
    /// <inheritdoc/>
    public Error FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Error.FromRawUnchecked(rawData);
}/// <summary>
/// Stable per-number error code. Currently only `not_associated` is emitted, when
/// the number is not attached to this DIR.
/// </summary>
[JsonConverter(typeof(CodeConverter))]
public enum Code
{
    NotAssociated
}sealed class CodeConverter : JsonConverter<Code>
{
    public override Code Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "not_associated"=>Code.NotAssociated, _ =>(Code)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Code value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Code.NotAssociated=>"not_associated",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}