using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberListPageResponse, PhoneNumberListPageResponseFromRaw>))]
public sealed record class PhoneNumberListPageResponse : JsonModel
{
    public required IReadOnlyList<NumbersPhoneNumberDetailed> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<NumbersPhoneNumberDetailed>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<NumbersPhoneNumberDetailed>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required PaginationMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PaginationMeta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    public IReadOnlyList<Error>? Errors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Error>>(
                "errors"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Error>?>(
                "errors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
        foreach (var item in this.Errors ?? [])
        {
            item.Validate();
        }
    }

    public PhoneNumberListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberListPageResponse (
        PhoneNumberListPageResponse phoneNumberListPageResponse
    ) : base(phoneNumberListPageResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberListPageResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberListPageResponseFromRaw : IFromRawJson<PhoneNumberListPageResponse>
{
    /// <inheritdoc/>
    public PhoneNumberListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberListPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Error, ErrorFromRaw>))]
public sealed record class Error : JsonModel
{
    public string? Code {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    public string? Detail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "detail"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("detail", value);
        }
    }

    public Meta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Meta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    public ErrorSource? Source {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ErrorSource>(
                "source"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    public string? Title {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "title"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Detail;
        this.Meta?.Validate();
        this.Source?.Validate();
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
}[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    /// <summary>
    /// URL with additional information on the error.
    /// </summary>
    public string? Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Url; }

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
}[JsonConverter(typeof(JsonModelConverter<ErrorSource, ErrorSourceFromRaw>))]
public sealed record class ErrorSource : JsonModel
{
    /// <summary>
    /// Indicates which query parameter caused the error.
    /// </summary>
    public string? Parameter {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "parameter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("parameter", value);
        }
    }

    /// <summary>
    /// JSON pointer (RFC6901) to the offending entity.
    /// </summary>
    public string? Pointer {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "pointer"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pointer", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Parameter;
        _ = this.Pointer;
    }

    public ErrorSource ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ErrorSource (ErrorSource errorSource) : base(errorSource)
    {  }
    #pragma warning restore CS8618

    public ErrorSource (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ErrorSource (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ErrorSourceFromRaw.FromRawUnchecked"/>
    public static ErrorSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ErrorSourceFromRaw : IFromRawJson<ErrorSource>
{
    /// <inheritdoc/>
    public ErrorSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ErrorSource.FromRawUnchecked(rawData);
}