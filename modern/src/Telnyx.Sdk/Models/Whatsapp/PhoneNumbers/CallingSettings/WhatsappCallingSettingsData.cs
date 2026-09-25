using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Whatsapp.PhoneNumbers.CallingSettings;

[JsonConverter(typeof(JsonModelConverter<WhatsappCallingSettingsData, WhatsappCallingSettingsDataFromRaw>))]
public sealed record class WhatsappCallingSettingsData : JsonModel
{
    /// <summary>
    /// True if calling is enabled on the phone
    /// </summary>
    public bool? Enabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enabled", value);
        }
    }

    /// <summary>
    /// Phone number in E164 format
    /// </summary>
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

    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enabled;
        _ = this.PhoneNumber;
        _ = this.RecordType;
        _ = this.UpdatedAt;
    }

    public WhatsappCallingSettingsData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappCallingSettingsData (
        WhatsappCallingSettingsData whatsappCallingSettingsData
    ) : base(whatsappCallingSettingsData)
    {  }
    #pragma warning restore CS8618

    public WhatsappCallingSettingsData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappCallingSettingsData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappCallingSettingsDataFromRaw.FromRawUnchecked"/>
    public static WhatsappCallingSettingsData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WhatsappCallingSettingsDataFromRaw : IFromRawJson<WhatsappCallingSettingsData>
{
    /// <inheritdoc/>
    public WhatsappCallingSettingsData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappCallingSettingsData.FromRawUnchecked(rawData);
}