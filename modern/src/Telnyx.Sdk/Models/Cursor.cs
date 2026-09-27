using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<Cursor, CursorFromRaw>))]
public sealed record class Cursor : JsonModel
{
    /// <summary>
    /// Opaque identifier of next page.
    /// </summary>
    public string? After {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "after"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("after", value);
        }
    }

    /// <summary>
    /// Opaque identifier of previous page.
    /// </summary>
    public string? Before {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "before"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("before", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.After;
        _ = this.Before;
    }

    public Cursor ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cursor (Cursor cursor) : base(cursor)
    {  }
    #pragma warning restore CS8618

    public Cursor (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Cursor (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CursorFromRaw.FromRawUnchecked"/>
    public static Cursor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CursorFromRaw : IFromRawJson<Cursor>
{
    /// <inheritdoc/>
    public Cursor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Cursor.FromRawUnchecked(rawData);
}