using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AlphanumericSenderIds;

namespace Telnyx.Sdk.Models.MessagingProfiles.AutorespConfigs;

/// <summary>
/// List of Auto-Response Settings
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AutorespConfigListResponse, AutorespConfigListResponseFromRaw>))]
public sealed record class AutorespConfigListResponse : JsonModel
{
    public required IReadOnlyList<AutoRespConfig> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AutoRespConfig>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<AutoRespConfig>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required MessagingPaginationMeta0b38e7044b Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MessagingPaginationMeta0b38e7044b>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public AutorespConfigListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutorespConfigListResponse (
        AutorespConfigListResponse autorespConfigListResponse
    ) : base(autorespConfigListResponse)
    {  }
    #pragma warning restore CS8618

    public AutorespConfigListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AutorespConfigListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AutorespConfigListResponseFromRaw.FromRawUnchecked"/>
    public static AutorespConfigListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AutorespConfigListResponseFromRaw : IFromRawJson<AutorespConfigListResponse>
{
    /// <inheritdoc/>
    public AutorespConfigListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AutorespConfigListResponse.FromRawUnchecked(rawData);
}