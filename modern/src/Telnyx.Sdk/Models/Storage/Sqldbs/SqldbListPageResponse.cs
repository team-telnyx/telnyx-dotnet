using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Storage.Kvs;

namespace Telnyx.Sdk.Models.Storage.Sqldbs;

[JsonConverter(typeof(JsonModelConverter<SqldbListPageResponse, SqldbListPageResponseFromRaw>))]
public sealed record class SqldbListPageResponse : JsonModel
{
    public IReadOnlyList<SqlDatabase>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SqlDatabase>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<SqlDatabase>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public EdgeComputePaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EdgeComputePaginationMeta>(
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

    public SqldbListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SqldbListPageResponse (
        SqldbListPageResponse sqldbListPageResponse
    ) : base(sqldbListPageResponse)
    {  }
    #pragma warning restore CS8618

    public SqldbListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SqldbListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SqldbListPageResponseFromRaw.FromRawUnchecked"/>
    public static SqldbListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SqldbListPageResponseFromRaw : IFromRawJson<SqldbListPageResponse>
{
    /// <inheritdoc/>
    public SqldbListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SqldbListPageResponse.FromRawUnchecked(rawData);
}