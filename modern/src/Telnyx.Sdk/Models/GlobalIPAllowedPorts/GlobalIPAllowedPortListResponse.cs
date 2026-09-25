using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.GlobalIPAllowedPorts;

[JsonConverter(typeof(JsonModelConverter<GlobalIPAllowedPortListResponse, GlobalIPAllowedPortListResponseFromRaw>))]
public sealed record class GlobalIPAllowedPortListResponse : JsonModel
{
    public IReadOnlyList<Data>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Data>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Data>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public GlobalIPAllowedPortListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPAllowedPortListResponse (
        GlobalIPAllowedPortListResponse globalIPAllowedPortListResponse
    ) : base(globalIPAllowedPortListResponse)
    {  }
    #pragma warning restore CS8618

    public GlobalIPAllowedPortListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPAllowedPortListResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPAllowedPortListResponseFromRaw.FromRawUnchecked"/>
    public static GlobalIPAllowedPortListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPAllowedPortListResponseFromRaw : IFromRawJson<GlobalIPAllowedPortListResponse>
{
    /// <inheritdoc/>
    public GlobalIPAllowedPortListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPAllowedPortListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Identifies the resource.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// First port of a range.
    /// </summary>
    public long? FirstPort {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "first_port"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("first_port", value);
        }
    }

    /// <summary>
    /// Last port of a range.
    /// </summary>
    public long? LastPort {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "last_port"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("last_port", value);
        }
    }

    /// <summary>
    /// A name for the Global IP ports range.
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The Global IP Protocol code.
    /// </summary>
    public string? ProtocolCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "protocol_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("protocol_code", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.FirstPort;
        _ = this.LastPort;
        _ = this.Name;
        _ = this.ProtocolCode;
        _ = this.RecordType;
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
}