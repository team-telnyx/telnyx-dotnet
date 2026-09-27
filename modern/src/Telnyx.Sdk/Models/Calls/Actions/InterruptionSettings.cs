using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

/// <summary>
/// Settings for handling user interruptions during assistant speech
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InterruptionSettings, InterruptionSettingsFromRaw>))]
public sealed record class InterruptionSettings : JsonModel
{
    /// <summary>
    /// When true, allows users to interrupt the assistant while speaking
    /// </summary>
    public bool? Enable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enable"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enable", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Enable; }

    public InterruptionSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InterruptionSettings (
        InterruptionSettings interruptionSettings
    ) : base(interruptionSettings)
    {  }
    #pragma warning restore CS8618

    public InterruptionSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InterruptionSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InterruptionSettingsFromRaw.FromRawUnchecked"/>
    public static InterruptionSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InterruptionSettingsFromRaw : IFromRawJson<InterruptionSettings>
{
    /// <inheritdoc/>
    public InterruptionSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InterruptionSettings.FromRawUnchecked(rawData);
}