using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<PrivacySettings, PrivacySettingsFromRaw>))]
public sealed record class PrivacySettings : JsonModel
{
    /// <summary>
    /// If true, conversation history and insights will be stored. If false, they
    /// will not be stored. This in‑tool toggle governs solely the retention of conversation
    /// history and insights via the AI assistant. It has no effect on any separate
    /// recording, transcription, or storage configuration that you have set at the
    /// account, number, or application level. All such external settings remain
    /// in force regardless of your selection here.
    /// </summary>
    public bool? DataRetention {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "data_retention"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data_retention", value);
        }
    }

    /// <summary>
    /// Requires every model call made for a web chat turn to be received and served
    /// inside your organization's data-locality region, rather than only stored
    /// there. Applies to web chat only — voice and messaging assistants are unaffected.
    /// Enabling it requires a data-locality region with in-region inference (USA,
    /// EU, AUS, UAE; see [Inference regions](https://developers.telnyx.com/docs/inference/models/regions))
    /// and Telnyx-hosted models for the assistant, its fallback, and any conversation-flow
    /// node that overrides the model; the request is rejected otherwise. Once enabled,
    /// send chat requests to your region's API hostname: a request entering the
    /// platform in another region is rejected rather than forwarded, because forwarding
    /// it would already have moved the content across the border. Defaults to false.
    /// </summary>
    public bool? InTransitDataLocality {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "in_transit_data_locality"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("in_transit_data_locality", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DataRetention;
        _ = this.InTransitDataLocality;
    }

    public PrivacySettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PrivacySettings (PrivacySettings privacySettings) : base(
        privacySettings
    )
    {  }
    #pragma warning restore CS8618

    public PrivacySettings (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PrivacySettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PrivacySettingsFromRaw.FromRawUnchecked"/>
    public static PrivacySettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PrivacySettingsFromRaw : IFromRawJson<PrivacySettings>
{
    /// <inheritdoc/>
    public PrivacySettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PrivacySettings.FromRawUnchecked(rawData);
}