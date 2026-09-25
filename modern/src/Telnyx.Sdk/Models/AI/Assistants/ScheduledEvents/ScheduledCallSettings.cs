using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants.ScheduledEvents;

/// <summary>
/// Per-call telephony overrides applied when a scheduled phone-call event dispatches.
/// Phone-call events only. New per-call dispatch options should be added here rather
/// than as top-level event fields.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ScheduledCallSettings, ScheduledCallSettingsFromRaw>))]
public sealed record class ScheduledCallSettings : JsonModel
{
    /// <summary>
    /// SIP region passed to Telnyx when initiating an outbound call. Values match
    /// the Telnyx TeXML `SipRegion` parameter exactly. Telnyx defaults to `US` when omitted.
    /// </summary>
    public ApiEnum<string, SipRegion>? SipRegion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SipRegion>>(
                "sip_region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_region", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.SipRegion?.Validate(); }

    public ScheduledCallSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScheduledCallSettings (
        ScheduledCallSettings scheduledCallSettings
    ) : base(scheduledCallSettings)
    {  }
    #pragma warning restore CS8618

    public ScheduledCallSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ScheduledCallSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ScheduledCallSettingsFromRaw.FromRawUnchecked"/>
    public static ScheduledCallSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ScheduledCallSettingsFromRaw : IFromRawJson<ScheduledCallSettings>
{
    /// <inheritdoc/>
    public ScheduledCallSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ScheduledCallSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// SIP region passed to Telnyx when initiating an outbound call. Values match the
/// Telnyx TeXML `SipRegion` parameter exactly. Telnyx defaults to `US` when omitted.
/// </summary>
[JsonConverter(typeof(SipRegionConverter))]
public enum SipRegion
{
    Us, Europe, Canada, Australia, MiddleEast
}sealed class SipRegionConverter : JsonConverter<SipRegion>
{
    public override SipRegion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "US"=>SipRegion.Us,
            "Europe"=>SipRegion.Europe,
            "Canada"=>SipRegion.Canada,
            "Australia"=>SipRegion.Australia,
            "Middle East"=>SipRegion.MiddleEast,
            _ =>(SipRegion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, SipRegion value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SipRegion.Us=>"US",
            SipRegion.Europe=>"Europe",
            SipRegion.Canada=>"Canada",
            SipRegion.Australia=>"Australia",
            SipRegion.MiddleEast=>"Middle East",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}