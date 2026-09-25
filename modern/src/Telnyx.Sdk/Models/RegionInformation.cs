using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<RegionInformation, RegionInformationFromRaw>))]
public sealed record class RegionInformation : JsonModel
{
    public string? RegionName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "region_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region_name", value);
        }
    }

    public ApiEnum<string, RegionType>? RegionType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RegionType>>(
                "region_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RegionName;
        this.RegionType?.Validate();
    }

    public RegionInformation ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegionInformation (RegionInformation regionInformation) : base(
        regionInformation
    )
    {  }
    #pragma warning restore CS8618

    public RegionInformation (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RegionInformation (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RegionInformationFromRaw.FromRawUnchecked"/>
    public static RegionInformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RegionInformationFromRaw : IFromRawJson<RegionInformation>
{
    /// <inheritdoc/>
    public RegionInformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RegionInformation.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RegionTypeConverter))]
public enum RegionType
{
    CountryCode, RateCenter, State, Location
}sealed class RegionTypeConverter : JsonConverter<RegionType>
{
    public override RegionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "country_code"=>RegionType.CountryCode,
            "rate_center"=>RegionType.RateCenter,
            "state"=>RegionType.State,
            "location"=>RegionType.Location,
            _ =>(RegionType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RegionType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RegionType.CountryCode=>"country_code",
            RegionType.RateCenter=>"rate_center",
            RegionType.State=>"state",
            RegionType.Location=>"location",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}