using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls;

[JsonConverter(typeof(JsonModelConverter<CustomSipHeader, CustomSipHeaderFromRaw>))]
public sealed record class CustomSipHeader : JsonModel
{
    /// <summary>
    /// The name of the header to add.
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The value of the header.
    /// </summary>
    public required string Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Value;
    }

    public CustomSipHeader ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomSipHeader (CustomSipHeader customSipHeader) : base(
        customSipHeader
    )
    {  }
    #pragma warning restore CS8618

    public CustomSipHeader (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomSipHeader (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CustomSipHeaderFromRaw.FromRawUnchecked"/>
    public static CustomSipHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CustomSipHeaderFromRaw : IFromRawJson<CustomSipHeader>
{
    /// <inheritdoc/>
    public CustomSipHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CustomSipHeader.FromRawUnchecked(rawData);
}