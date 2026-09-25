using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingProfiles;

/// <summary>
/// Telnyx product features the messaging customer can enable on the messaging profile.
/// Keys map to individual feature flags; unknown keys are accepted and preserved
/// for forward compatibility with rolling deployments.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessagingProfileFeatures, MessagingProfileFeaturesFromRaw>))]
public sealed record class MessagingProfileFeatures : JsonModel
{
    /// <summary>
    /// Enables AI detection of inbound opt-out messages that do not follow the standard
    /// STOP/UNSTOP/HELP opt-out keyword pattern. When enabled, the messaging platform
    /// applies an AI model to identify non-standard opt-out requests (e.g. natural-language
    /// phrases) and treats them as opt-outs.
    /// </summary>
    public bool? AIOptOutDetectionEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "ai_opt_out_detection_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ai_opt_out_detection_enabled", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.AIOptOutDetectionEnabled; }

    public MessagingProfileFeatures ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingProfileFeatures (
        MessagingProfileFeatures messagingProfileFeatures
    ) : base(messagingProfileFeatures)
    {  }
    #pragma warning restore CS8618

    public MessagingProfileFeatures (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingProfileFeatures (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingProfileFeaturesFromRaw.FromRawUnchecked"/>
    public static MessagingProfileFeatures FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingProfileFeaturesFromRaw : IFromRawJson<MessagingProfileFeatures>
{
    /// <inheritdoc/>
    public MessagingProfileFeatures FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingProfileFeatures.FromRawUnchecked(rawData);
}