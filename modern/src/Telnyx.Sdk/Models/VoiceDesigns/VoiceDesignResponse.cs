using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.VoiceDesigns;

/// <summary>
/// Response envelope for a single voice design with full version detail.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceDesignResponse, VoiceDesignResponseFromRaw>))]
public sealed record class VoiceDesignResponse : JsonModel
{
    /// <summary>
    /// A voice design object with full version detail.
    /// </summary>
    public VoiceDesignData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceDesignData>(
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

    public VoiceDesignResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceDesignResponse (VoiceDesignResponse voiceDesignResponse) : base(
        voiceDesignResponse
    )
    {  }
    #pragma warning restore CS8618

    public VoiceDesignResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceDesignResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceDesignResponseFromRaw.FromRawUnchecked"/>
    public static VoiceDesignResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceDesignResponseFromRaw : IFromRawJson<VoiceDesignResponse>
{
    /// <inheritdoc/>
    public VoiceDesignResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceDesignResponse.FromRawUnchecked(rawData);
}