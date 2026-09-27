using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Connections;

[JsonConverter(typeof(JsonModelConverter<ConnectionListActiveCallsPageResponse, ConnectionListActiveCallsPageResponseFromRaw>))]
public sealed record class ConnectionListActiveCallsPageResponse : JsonModel
{
    public IReadOnlyList<ConnectionListActiveCallsResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ConnectionListActiveCallsResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ConnectionListActiveCallsResponse>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public ConnectionListActiveCallsPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConnectionListActiveCallsPageResponse (
        ConnectionListActiveCallsPageResponse connectionListActiveCallsPageResponse
    ) : base(connectionListActiveCallsPageResponse)
    {  }
    #pragma warning restore CS8618

    public ConnectionListActiveCallsPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConnectionListActiveCallsPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConnectionListActiveCallsPageResponseFromRaw.FromRawUnchecked"/>
    public static ConnectionListActiveCallsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConnectionListActiveCallsPageResponseFromRaw : IFromRawJson<ConnectionListActiveCallsPageResponse>
{
    /// <inheritdoc/>
    public ConnectionListActiveCallsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConnectionListActiveCallsPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    public Cursor? Cursors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Cursor>(
                "cursors"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cursors", value);
        }
    }

    /// <summary>
    /// Path to next page.
    /// </summary>
    public string? Next {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "next"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("next", value);
        }
    }

    /// <summary>
    /// Path to previous page.
    /// </summary>
    public string? Previous {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "previous"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("previous", value);
        }
    }

    public long? TotalItems {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "total_items"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("total_items", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cursors?.Validate();
        _ = this.Next;
        _ = this.Previous;
        _ = this.TotalItems;
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