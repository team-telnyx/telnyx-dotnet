using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.VoiceDesigns;

/// <summary>
/// Response envelope for a voice design after a rename operation (no version-specific fields).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceDesignRenameResponse, VoiceDesignRenameResponseFromRaw>))]
public sealed record class VoiceDesignRenameResponse : JsonModel
{
    /// <summary>
    /// A summarized voice design object (without version-specific fields).
    /// </summary>
    public VoiceDesignSummaryData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceDesignSummaryData>(
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

    public VoiceDesignRenameResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceDesignRenameResponse (
        VoiceDesignRenameResponse voiceDesignRenameResponse
    ) : base(voiceDesignRenameResponse)
    {  }
    #pragma warning restore CS8618

    public VoiceDesignRenameResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceDesignRenameResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceDesignRenameResponseFromRaw.FromRawUnchecked"/>
    public static VoiceDesignRenameResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceDesignRenameResponseFromRaw : IFromRawJson<VoiceDesignRenameResponse>
{
    /// <inheritdoc/>
    public VoiceDesignRenameResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceDesignRenameResponse.FromRawUnchecked(rawData);
}