using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<RcsToItem, RcsToItemFromRaw>))]
public sealed record class RcsToItem : JsonModel
{
    public string? Carrier {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "carrier"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("carrier", value);
        }
    }

    public string? LineType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "line_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("line_type", value);
        }
    }

    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    public string? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Carrier;
        _ = this.LineType;
        _ = this.PhoneNumber;
        _ = this.Status;
    }

    public RcsToItem ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RcsToItem (RcsToItem rcsToItem) : base(rcsToItem)
    {  }
    #pragma warning restore CS8618

    public RcsToItem (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RcsToItem (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RcsToItemFromRaw.FromRawUnchecked"/>
    public static RcsToItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RcsToItemFromRaw : IFromRawJson<RcsToItem>
{
    /// <inheritdoc/>
    public RcsToItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RcsToItem.FromRawUnchecked(rawData);
}