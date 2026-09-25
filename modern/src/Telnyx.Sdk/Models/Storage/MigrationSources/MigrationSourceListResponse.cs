using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Storage.Buckets.Usage;

namespace Telnyx.Sdk.Models.Storage.MigrationSources;

[JsonConverter(typeof(JsonModelConverter<MigrationSourceListResponse, MigrationSourceListResponseFromRaw>))]
public sealed record class MigrationSourceListResponse : JsonModel
{
    public IReadOnlyList<MigrationSourceParams>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MigrationSourceParams>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MigrationSourceParams>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMetaSimple? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMetaSimple>(
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

    public MigrationSourceListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MigrationSourceListResponse (
        MigrationSourceListResponse migrationSourceListResponse
    ) : base(migrationSourceListResponse)
    {  }
    #pragma warning restore CS8618

    public MigrationSourceListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MigrationSourceListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MigrationSourceListResponseFromRaw.FromRawUnchecked"/>
    public static MigrationSourceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MigrationSourceListResponseFromRaw : IFromRawJson<MigrationSourceListResponse>
{
    /// <inheritdoc/>
    public MigrationSourceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MigrationSourceListResponse.FromRawUnchecked(rawData);
}