using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Sqldbs.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionQueryResponse, ActionQueryResponseFromRaw>))]
public sealed record class ActionQueryResponse : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
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

    public ActionQueryResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionQueryResponse (ActionQueryResponse actionQueryResponse) : base(
        actionQueryResponse
    )
    {  }
    #pragma warning restore CS8618

    public ActionQueryResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionQueryResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionQueryResponseFromRaw.FromRawUnchecked"/>
    public static ActionQueryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionQueryResponseFromRaw : IFromRawJson<ActionQueryResponse>
{
    /// <inheritdoc/>
    public ActionQueryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionQueryResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Number of rows returned.
    /// </summary>
    public long? Count {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("count", value);
        }
    }

    /// <summary>
    /// Wall-clock duration of the request, in milliseconds.
    /// </summary>
    public double? Duration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "duration"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("duration", value);
        }
    }

    public Meta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Meta>(
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

    /// <summary>
    /// The result rows, each a map of column name to value. Empty for statements
    /// that return no rows.
    /// </summary>
    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? Results {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "results"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "results",
                value == null ? null : ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)))
            );
        }
    }

    public bool? Success {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "success"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        _ = this.Duration;
        this.Meta?.Validate();
        _ = this.Results;
        _ = this.Success;
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    /// <summary>
    /// Number of rows added, changed, or removed by the statement.
    /// </summary>
    public long? Changes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "changes"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("changes", value);
        }
    }

    /// <summary>
    /// Wall-clock duration of the statement, in milliseconds.
    /// </summary>
    public double? Duration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "duration"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("duration", value);
        }
    }

    /// <summary>
    /// Rowid of the last inserted row, when applicable.
    /// </summary>
    public long? LastRowID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "last_row_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("last_row_id", value);
        }
    }

    public long? RowsRead {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "rows_read"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rows_read", value);
        }
    }

    public long? RowsWritten {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "rows_written"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rows_written", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Changes;
        _ = this.Duration;
        _ = this.LastRowID;
        _ = this.RowsRead;
        _ = this.RowsWritten;
    }

    public Meta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meta (Meta meta) : base(meta)
    {  }
    #pragma warning restore CS8618

    public Meta (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Meta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MetaFromRaw.FromRawUnchecked"/>
    public static Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Meta.FromRawUnchecked(rawData);
}