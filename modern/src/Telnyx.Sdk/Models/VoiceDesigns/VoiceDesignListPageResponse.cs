using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.VoiceClones;

namespace Telnyx.Sdk.Models.VoiceDesigns;

/// <summary>
/// Paginated list of voice designs.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceDesignListPageResponse, VoiceDesignListPageResponseFromRaw>))]
public sealed record class VoiceDesignListPageResponse : JsonModel
{
    /// <summary>
    /// Array of voice design summary objects.
    /// </summary>
    public IReadOnlyList<VoiceDesignSummaryData>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<VoiceDesignSummaryData>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<VoiceDesignSummaryData>?>(
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

    public VoiceDesignListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceDesignListPageResponse (
        VoiceDesignListPageResponse voiceDesignListPageResponse
    ) : base(voiceDesignListPageResponse)
    {  }
    #pragma warning restore CS8618

    public VoiceDesignListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceDesignListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceDesignListPageResponseFromRaw.FromRawUnchecked"/>
    public static VoiceDesignListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceDesignListPageResponseFromRaw : IFromRawJson<VoiceDesignListPageResponse>
{
    /// <inheritdoc/>
    public VoiceDesignListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceDesignListPageResponse.FromRawUnchecked(rawData);
}