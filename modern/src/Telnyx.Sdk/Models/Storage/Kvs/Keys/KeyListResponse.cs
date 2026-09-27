using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Kvs.Keys;

[JsonConverter(typeof(JsonModelConverter<KeyListResponse, KeyListResponseFromRaw>))]
public sealed record class KeyListResponse : JsonModel
{
    public string? Key {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("key", value);
        }
    }

    /// <summary>
    /// Size of the stored value in bytes.
    /// </summary>
    public long? SizeBytes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "size_bytes"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("size_bytes", value);
        }
    }

    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Key;
        _ = this.SizeBytes;
        _ = this.UpdatedAt;
    }

    public KeyListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public KeyListResponse (KeyListResponse keyListResponse) : base(
        keyListResponse
    )
    {  }
    #pragma warning restore CS8618

    public KeyListResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    KeyListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="KeyListResponseFromRaw.FromRawUnchecked"/>
    public static KeyListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class KeyListResponseFromRaw : IFromRawJson<KeyListResponse>
{
    /// <inheritdoc/>
    public KeyListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>KeyListResponse.FromRawUnchecked(rawData);
}