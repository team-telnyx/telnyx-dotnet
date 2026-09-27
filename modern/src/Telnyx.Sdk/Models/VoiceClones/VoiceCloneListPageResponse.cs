using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.VoiceClones;

/// <summary>
/// Paginated list of voice clones.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceCloneListPageResponse, VoiceCloneListPageResponseFromRaw>))]
public sealed record class VoiceCloneListPageResponse : JsonModel
{
    /// <summary>
    /// Array of voice clone objects.
    /// </summary>
    public IReadOnlyList<VoiceCloneData>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<VoiceCloneData>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<VoiceCloneData>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata returned with list responses.
    /// </summary>
    public VoiceDesignsPaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoiceDesignsPaginationMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public VoiceCloneListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceCloneListPageResponse (
        VoiceCloneListPageResponse voiceCloneListPageResponse
    ) : base(voiceCloneListPageResponse)
    {  }
    #pragma warning restore CS8618

    public VoiceCloneListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceCloneListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceCloneListPageResponseFromRaw.FromRawUnchecked"/>
    public static VoiceCloneListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceCloneListPageResponseFromRaw : IFromRawJson<VoiceCloneListPageResponse>
{
    /// <inheritdoc/>
    public VoiceCloneListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceCloneListPageResponse.FromRawUnchecked(rawData);
}