using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Actions.Purchase;

[JsonConverter(typeof(JsonModelConverter<WirelessErrorC5290d5308, WirelessErrorC5290d5308FromRaw>))]
public sealed record class WirelessErrorC5290d5308 : JsonModel
{
    public required string Code {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "code"
            );
        }
        init { this._rawData.Set("code", value); }
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

    public IReadOnlyDictionary<string, JsonElement>? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "meta",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public Source? Source {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Source>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Title;
        _ = this.Detail;
        _ = this.Meta;
        this.Source?.Validate();
    }

    public WirelessErrorC5290d5308 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WirelessErrorC5290d5308 (
        WirelessErrorC5290d5308 wirelessErrorC5290d5308
    ) : base(wirelessErrorC5290d5308)
    {  }
    #pragma warning restore CS8618

    public WirelessErrorC5290d5308 (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WirelessErrorC5290d5308 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WirelessErrorC5290d5308FromRaw.FromRawUnchecked"/>
    public static WirelessErrorC5290d5308 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WirelessErrorC5290d5308FromRaw : IFromRawJson<WirelessErrorC5290d5308>
{
    /// <inheritdoc/>
    public WirelessErrorC5290d5308 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WirelessErrorC5290d5308.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Source, SourceFromRaw>))]
public sealed record class Source : JsonModel
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

    public Source ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Source (Source source) : base(source)
    {  }
    #pragma warning restore CS8618

    public Source (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Source (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SourceFromRaw.FromRawUnchecked"/>
    public static Source FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SourceFromRaw : IFromRawJson<Source>
{
    /// <inheritdoc/>
    public Source FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Source.FromRawUnchecked(rawData);
}