using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortabilityChecks;

[JsonConverter(typeof(JsonModelConverter<PortabilityCheckRunResponse, PortabilityCheckRunResponseFromRaw>))]
public sealed record class PortabilityCheckRunResponse : JsonModel
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

    public PortabilityCheckRunResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortabilityCheckRunResponse (
        PortabilityCheckRunResponse portabilityCheckRunResponse
    ) : base(portabilityCheckRunResponse)
    {  }
    #pragma warning restore CS8618

    public PortabilityCheckRunResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortabilityCheckRunResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortabilityCheckRunResponseFromRaw.FromRawUnchecked"/>
    public static PortabilityCheckRunResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortabilityCheckRunResponseFromRaw : IFromRawJson<PortabilityCheckRunResponse>
{
    /// <inheritdoc/>
    public PortabilityCheckRunResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortabilityCheckRunResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Indicates whether this phone number is FastPort eligible
    /// </summary>
    public bool? FastPortable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "fast_portable"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("fast_portable", value);
        }
    }

    /// <summary>
    /// If this phone number is not portable, explains why. Empty string if the number
    /// is portable.
    /// </summary>
    public string? NotPortableReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "not_portable_reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("not_portable_reason", value);
        }
    }

    /// <summary>
    /// The +E.164 formatted phone number this result is about
    /// </summary>
    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <summary>
    /// Indicates whether this phone number is portable
    /// </summary>
    public bool? Portable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "portable"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("portable", value);
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
        _ = this.FastPortable;
        _ = this.NotPortableReason;
        _ = this.PhoneNumber;
        _ = this.Portable;
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