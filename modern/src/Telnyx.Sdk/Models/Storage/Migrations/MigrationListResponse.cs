using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Storage.Buckets.Usage;

namespace Telnyx.Sdk.Models.Storage.Migrations;

[JsonConverter(typeof(JsonModelConverter<MigrationListResponse, MigrationListResponseFromRaw>))]
public sealed record class MigrationListResponse : JsonModel
{
    public IReadOnlyList<MigrationParams>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MigrationParams>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MigrationParams>?>(
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

    public MigrationListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MigrationListResponse (
        MigrationListResponse migrationListResponse
    ) : base(migrationListResponse)
    {  }
    #pragma warning restore CS8618

    public MigrationListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MigrationListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MigrationListResponseFromRaw.FromRawUnchecked"/>
    public static MigrationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MigrationListResponseFromRaw : IFromRawJson<MigrationListResponse>
{
    /// <inheritdoc/>
    public MigrationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MigrationListResponse.FromRawUnchecked(rawData);
}