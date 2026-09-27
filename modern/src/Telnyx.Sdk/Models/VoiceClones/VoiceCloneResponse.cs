using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.VoiceClones;

/// <summary>
/// Response envelope for a single voice clone.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceCloneResponse, VoiceCloneResponseFromRaw>))]
public sealed record class VoiceCloneResponse : JsonModel
{
    /// <summary>
    /// A voice clone object.
    /// </summary>
    public VoiceCloneData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceCloneData>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public VoiceCloneResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceCloneResponse (VoiceCloneResponse voiceCloneResponse) : base(
        voiceCloneResponse
    )
    {  }
    #pragma warning restore CS8618

    public VoiceCloneResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceCloneResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceCloneResponseFromRaw.FromRawUnchecked"/>
    public static VoiceCloneResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceCloneResponseFromRaw : IFromRawJson<VoiceCloneResponse>
{
    /// <inheritdoc/>
    public VoiceCloneResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceCloneResponse.FromRawUnchecked(rawData);
}