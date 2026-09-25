using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailMessages;

/// <summary>
/// Per-send open and click tracking overrides. Omitted properties inherit the sender
/// domain's tracking settings.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TrackingSettings, TrackingSettingsFromRaw>))]
public sealed record class TrackingSettings : JsonModel
{
    /// <summary>
    /// Whether to rewrite links for click tracking in this message.
    /// </summary>
    public bool? ClickTracking {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "click_tracking"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("click_tracking", value);
        }
    }

    /// <summary>
    /// Whether to inject an open-tracking pixel for this message.
    /// </summary>
    public bool? OpenTracking {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "open_tracking"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("open_tracking", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClickTracking;
        _ = this.OpenTracking;
    }

    public TrackingSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrackingSettings (TrackingSettings trackingSettings) : base(
        trackingSettings
    )
    {  }
    #pragma warning restore CS8618

    public TrackingSettings (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TrackingSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TrackingSettingsFromRaw.FromRawUnchecked"/>
    public static TrackingSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TrackingSettingsFromRaw : IFromRawJson<TrackingSettings>
{
    /// <inheritdoc/>
    public TrackingSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TrackingSettings.FromRawUnchecked(rawData);
}