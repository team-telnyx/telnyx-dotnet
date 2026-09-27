using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Whatsapp.BusinessAccounts.Settings;

[JsonConverter(typeof(JsonModelConverter<WabaSettings, WabaSettingsFromRaw>))]
public sealed record class WabaSettings : JsonModel
{
    /// <summary>
    /// Internal ID of Whatsapp business account
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
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

    public string? Timezone {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "timezone"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("timezone", value);
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

    /// <summary>
    /// Enable/disable receiving Whatsapp events
    /// </summary>
    public bool? WebhookEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "webhook_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_enabled", value);
        }
    }

    public IReadOnlyList<string>? WebhookEvents {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "webhook_events"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "webhook_events",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Failover URL to receive Whatsapp events
    /// </summary>
    public string? WebhookFailoverUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_failover_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_failover_url", value);
        }
    }

    /// <summary>
    /// URL to receive Whatsapp events
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.RecordType;
        _ = this.Timezone;
        _ = this.UpdatedAt;
        _ = this.WebhookEnabled;
        _ = this.WebhookEvents;
        _ = this.WebhookFailoverUrl;
        _ = this.WebhookUrl;
    }

    public WabaSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WabaSettings (WabaSettings wabaSettings) : base(wabaSettings)
    {  }
    #pragma warning restore CS8618

    public WabaSettings (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WabaSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WabaSettingsFromRaw.FromRawUnchecked"/>
    public static WabaSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WabaSettingsFromRaw : IFromRawJson<WabaSettings>
{
    /// <inheritdoc/>
    public WabaSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WabaSettings.FromRawUnchecked(rawData);
}