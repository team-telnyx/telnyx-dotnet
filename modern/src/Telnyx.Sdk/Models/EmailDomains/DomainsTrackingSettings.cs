using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailDomains;

[JsonConverter(typeof(JsonModelConverter<DomainsTrackingSettings, DomainsTrackingSettingsFromRaw>))]
public sealed record class DomainsTrackingSettings : JsonModel
{
    /// <summary>
    /// Rewrite HTML links through a tracking redirect to record click events.
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
    /// Inject a tracking pixel into HTML messages to record open events.
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

    /// <summary>
    /// Add RFC 8058 List-Unsubscribe headers with a signed one-click unsubscribe
    /// URL. Enabled by default; Gmail/Yahoo bulk-sender rules require one-click unsubscribe support.
    /// </summary>
    public bool? UnsubscribeTracking {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "unsubscribe_tracking"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("unsubscribe_tracking", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClickTracking;
        _ = this.OpenTracking;
        _ = this.UnsubscribeTracking;
    }

    public DomainsTrackingSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DomainsTrackingSettings (
        DomainsTrackingSettings domainsTrackingSettings
    ) : base(domainsTrackingSettings)
    {  }
    #pragma warning restore CS8618

    public DomainsTrackingSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DomainsTrackingSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DomainsTrackingSettingsFromRaw.FromRawUnchecked"/>
    public static DomainsTrackingSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DomainsTrackingSettingsFromRaw : IFromRawJson<DomainsTrackingSettings>
{
    /// <inheritdoc/>
    public DomainsTrackingSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DomainsTrackingSettings.FromRawUnchecked(rawData);
}