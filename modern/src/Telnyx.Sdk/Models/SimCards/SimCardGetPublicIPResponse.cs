using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.SimCards;

[JsonConverter(typeof(JsonModelConverter<SimCardGetPublicIPResponse, SimCardGetPublicIPResponseFromRaw>))]
public sealed record class SimCardGetPublicIPResponse : JsonModel
{
    public SimCardGetPublicIPResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SimCardGetPublicIPResponseData>(
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

    public SimCardGetPublicIPResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardGetPublicIPResponse (
        SimCardGetPublicIPResponse simCardGetPublicIPResponse
    ) : base(simCardGetPublicIPResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardGetPublicIPResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardGetPublicIPResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardGetPublicIPResponseFromRaw.FromRawUnchecked"/>
    public static SimCardGetPublicIPResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardGetPublicIPResponseFromRaw : IFromRawJson<SimCardGetPublicIPResponse>
{
    /// <inheritdoc/>
    public SimCardGetPublicIPResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardGetPublicIPResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SimCardGetPublicIPResponseData, SimCardGetPublicIPResponseDataFromRaw>))]
public sealed record class SimCardGetPublicIPResponseData : JsonModel
{
    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// The provisioned IP address. This attribute will only be available when underlying
    /// resource status is in a "provisioned" status.
    /// </summary>
    public string? IP {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ip"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ip", value);
        }
    }

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

    public string? RegionCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "region_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region_code", value);
        }
    }

    public string? SimCardID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sim_card_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sim_card_id", value);
        }
    }

    public ApiEnum<string, SimCardGetPublicIPResponseDataType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SimCardGetPublicIPResponseDataType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
        _ = this.CreatedAt;
        _ = this.IP;
        _ = this.RecordType;
        _ = this.RegionCode;
        _ = this.SimCardID;
        this.Type?.Validate();
        _ = this.UpdatedAt;
    }

    public SimCardGetPublicIPResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardGetPublicIPResponseData (
        SimCardGetPublicIPResponseData simCardGetPublicIPResponseData
    ) : base(simCardGetPublicIPResponseData)
    {  }
    #pragma warning restore CS8618

    public SimCardGetPublicIPResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardGetPublicIPResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardGetPublicIPResponseDataFromRaw.FromRawUnchecked"/>
    public static SimCardGetPublicIPResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SimCardGetPublicIPResponseDataFromRaw : IFromRawJson<SimCardGetPublicIPResponseData>
{
    /// <inheritdoc/>
    public SimCardGetPublicIPResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardGetPublicIPResponseData.FromRawUnchecked(rawData);
}[JsonConverter(typeof(SimCardGetPublicIPResponseDataTypeConverter))]
public enum SimCardGetPublicIPResponseDataType
{
    Ipv4
}sealed class SimCardGetPublicIPResponseDataTypeConverter : JsonConverter<SimCardGetPublicIPResponseDataType>
{
    public override SimCardGetPublicIPResponseDataType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ipv4"=>SimCardGetPublicIPResponseDataType.Ipv4,
            _ =>(SimCardGetPublicIPResponseDataType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SimCardGetPublicIPResponseDataType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SimCardGetPublicIPResponseDataType.Ipv4=>"ipv4",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}