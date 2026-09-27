using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<WhatsappLocation, WhatsappLocationFromRaw>))]
public sealed record class WhatsappLocation : JsonModel
{
    public string? Address {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    public string? Latitude {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "latitude"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("latitude", value);
        }
    }

    public string? Longitude {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "longitude"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("longitude", value);
        }
    }

    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Address;
        _ = this.Latitude;
        _ = this.Longitude;
        _ = this.Name;
    }

    public WhatsappLocation ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappLocation (WhatsappLocation whatsappLocation) : base(
        whatsappLocation
    )
    {  }
    #pragma warning restore CS8618

    public WhatsappLocation (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappLocation (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappLocationFromRaw.FromRawUnchecked"/>
    public static WhatsappLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WhatsappLocationFromRaw : IFromRawJson<WhatsappLocation>
{
    /// <inheritdoc/>
    public WhatsappLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappLocation.FromRawUnchecked(rawData);
}