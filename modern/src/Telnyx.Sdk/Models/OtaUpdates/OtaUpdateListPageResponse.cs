using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.OtaUpdates;

[JsonConverter(typeof(JsonModelConverter<OtaUpdateListPageResponse, OtaUpdateListPageResponseFromRaw>))]
public sealed record class OtaUpdateListPageResponse : JsonModel
{
    public IReadOnlyList<OtaUpdateListResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<OtaUpdateListResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<OtaUpdateListResponse>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
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

    public OtaUpdateListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OtaUpdateListPageResponse (
        OtaUpdateListPageResponse otaUpdateListPageResponse
    ) : base(otaUpdateListPageResponse)
    {  }
    #pragma warning restore CS8618

    public OtaUpdateListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OtaUpdateListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OtaUpdateListPageResponseFromRaw.FromRawUnchecked"/>
    public static OtaUpdateListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OtaUpdateListPageResponseFromRaw : IFromRawJson<OtaUpdateListPageResponse>
{
    /// <inheritdoc/>
    public OtaUpdateListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OtaUpdateListPageResponse.FromRawUnchecked(rawData);
}