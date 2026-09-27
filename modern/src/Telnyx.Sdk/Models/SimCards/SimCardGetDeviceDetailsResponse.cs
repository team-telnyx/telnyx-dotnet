using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCards;

[JsonConverter(typeof(JsonModelConverter<SimCardGetDeviceDetailsResponse, SimCardGetDeviceDetailsResponseFromRaw>))]
public sealed record class SimCardGetDeviceDetailsResponse : JsonModel
{
    public SimCardGetDeviceDetailsResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SimCardGetDeviceDetailsResponseData>(
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

    public SimCardGetDeviceDetailsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardGetDeviceDetailsResponse (
        SimCardGetDeviceDetailsResponse simCardGetDeviceDetailsResponse
    ) : base(simCardGetDeviceDetailsResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardGetDeviceDetailsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardGetDeviceDetailsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardGetDeviceDetailsResponseFromRaw.FromRawUnchecked"/>
    public static SimCardGetDeviceDetailsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardGetDeviceDetailsResponseFromRaw : IFromRawJson<SimCardGetDeviceDetailsResponse>
{
    /// <inheritdoc/>
    public SimCardGetDeviceDetailsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardGetDeviceDetailsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SimCardGetDeviceDetailsResponseData, SimCardGetDeviceDetailsResponseDataFromRaw>))]
public sealed record class SimCardGetDeviceDetailsResponseData : JsonModel
{
    /// <summary>
    /// Brand of the device where the SIM card is being used in.
    /// </summary>
    public string? BrandName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "brand_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("brand_name", value);
        }
    }

    /// <summary>
    /// Type of the device where the SIM card is being used in.
    /// </summary>
    public string? DeviceType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "device_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("device_type", value);
        }
    }

    /// <summary>
    /// IMEI of the device where the SIM card is being used in.
    /// </summary>
    public string? Imei {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "imei"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("imei", value);
        }
    }

    /// <summary>
    /// Brand of the device where the SIM card is being used in.
    /// </summary>
    public string? ModelName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "model_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("model_name", value);
        }
    }

    /// <summary>
    /// Operating system of the device where the SIM card is being used in.
    /// </summary>
    public string? OperatingSystem {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "operating_system"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("operating_system", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BrandName;
        _ = this.DeviceType;
        _ = this.Imei;
        _ = this.ModelName;
        _ = this.OperatingSystem;
        _ = this.RecordType;
    }

    public SimCardGetDeviceDetailsResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardGetDeviceDetailsResponseData (
        SimCardGetDeviceDetailsResponseData simCardGetDeviceDetailsResponseData
    ) : base(simCardGetDeviceDetailsResponseData)
    {  }
    #pragma warning restore CS8618

    public SimCardGetDeviceDetailsResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardGetDeviceDetailsResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardGetDeviceDetailsResponseDataFromRaw.FromRawUnchecked"/>
    public static SimCardGetDeviceDetailsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SimCardGetDeviceDetailsResponseDataFromRaw : IFromRawJson<SimCardGetDeviceDetailsResponseData>
{
    /// <inheritdoc/>
    public SimCardGetDeviceDetailsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardGetDeviceDetailsResponseData.FromRawUnchecked(rawData);
}