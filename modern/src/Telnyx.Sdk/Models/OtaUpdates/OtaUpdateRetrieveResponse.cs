using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.OtaUpdates;

[JsonConverter(typeof(JsonModelConverter<OtaUpdateRetrieveResponse, OtaUpdateRetrieveResponseFromRaw>))]
public sealed record class OtaUpdateRetrieveResponse : JsonModel
{
    /// <summary>
    /// This object represents an Over the Air (OTA) update request. It allows tracking
    /// the current status of a operation that apply settings in a particular SIM
    /// card. &lt;br/&gt;&lt;br/&gt;
    /// </summary>
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

    public OtaUpdateRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OtaUpdateRetrieveResponse (
        OtaUpdateRetrieveResponse otaUpdateRetrieveResponse
    ) : base(otaUpdateRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public OtaUpdateRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OtaUpdateRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OtaUpdateRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static OtaUpdateRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OtaUpdateRetrieveResponseFromRaw : IFromRawJson<OtaUpdateRetrieveResponse>
{
    /// <inheritdoc/>
    public OtaUpdateRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OtaUpdateRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// This object represents an Over the Air (OTA) update request. It allows tracking
/// the current status of a operation that apply settings in a particular SIM card. &lt;br/&gt;&lt;br/&gt;
/// </summary>
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

    /// <summary>
    /// A JSON object representation of the operation. The information present here
    /// will relate directly to the source of the OTA request.
    /// </summary>
    public Settings? Settings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Settings>(
                "settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("settings", value);
        }
    }

    /// <summary>
    /// The identification UUID of the related SIM card resource.
    /// </summary>
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

    public ApiEnum<string, DataStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataStatus>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// Represents the type of the operation requested. This will relate directly
    /// to the source of the request.
    /// </summary>
    public ApiEnum<string, DataType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataType>>(
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
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.RecordType;
        this.Settings?.Validate();
        _ = this.SimCardID;
        this.Status?.Validate();
        this.Type?.Validate();
        _ = this.UpdatedAt;
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
}/// <summary>
/// A JSON object representation of the operation. The information present here will
/// relate directly to the source of the OTA request.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Settings, SettingsFromRaw>))]
public sealed record class Settings : JsonModel
{
    /// <summary>
    /// A list of mobile network operators and the priority that should be applied
    /// when the SIM is connecting to the network.
    /// </summary>
    public IReadOnlyList<MobileNetworkOperatorsPreference>? MobileNetworkOperatorsPreferences {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<MobileNetworkOperatorsPreference>>(
                "mobile_network_operators_preferences"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<MobileNetworkOperatorsPreference>?>(
                "mobile_network_operators_preferences",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.MobileNetworkOperatorsPreferences ?? [])
        {
            item.Validate();
        }
    }

    public Settings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Settings (Settings settings) : base(settings)
    {  }
    #pragma warning restore CS8618

    public Settings (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Settings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SettingsFromRaw.FromRawUnchecked"/>
    public static Settings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SettingsFromRaw : IFromRawJson<Settings>
{
    /// <inheritdoc/>
    public Settings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Settings.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<MobileNetworkOperatorsPreference, MobileNetworkOperatorsPreferenceFromRaw>))]
public sealed record class MobileNetworkOperatorsPreference : JsonModel
{
    /// <summary>
    /// The mobile network operator resource identification UUID.
    /// </summary>
    public string? MobileNetworkOperatorID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mobile_network_operator_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mobile_network_operator_id", value);
        }
    }

    /// <summary>
    /// The mobile network operator resource name.
    /// </summary>
    public string? MobileNetworkOperatorName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mobile_network_operator_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mobile_network_operator_name", value);
        }
    }

    /// <summary>
    /// It determines what is the priority of a specific network operator that should
    /// be assumed by a SIM card when connecting to a network. The highest priority
    /// is 0, the second highest is 1 and so on.
    /// </summary>
    public long? Priority {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "priority"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("priority", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MobileNetworkOperatorID;
        _ = this.MobileNetworkOperatorName;
        _ = this.Priority;
    }

    public MobileNetworkOperatorsPreference ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobileNetworkOperatorsPreference (
        MobileNetworkOperatorsPreference mobileNetworkOperatorsPreference
    ) : base(mobileNetworkOperatorsPreference)
    {  }
    #pragma warning restore CS8618

    public MobileNetworkOperatorsPreference (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobileNetworkOperatorsPreference (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobileNetworkOperatorsPreferenceFromRaw.FromRawUnchecked"/>
    public static MobileNetworkOperatorsPreference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MobileNetworkOperatorsPreferenceFromRaw : IFromRawJson<MobileNetworkOperatorsPreference>
{
    /// <inheritdoc/>
    public MobileNetworkOperatorsPreference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobileNetworkOperatorsPreference.FromRawUnchecked(rawData);
}[JsonConverter(typeof(DataStatusConverter))]
public enum DataStatus
{
    InProgress, Completed, Failed
}sealed class DataStatusConverter : JsonConverter<DataStatus>
{
    public override DataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in-progress"=>DataStatus.InProgress,
            "completed"=>DataStatus.Completed,
            "failed"=>DataStatus.Failed,
            _ =>(DataStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, DataStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DataStatus.InProgress=>"in-progress",
            DataStatus.Completed=>"completed",
            DataStatus.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Represents the type of the operation requested. This will relate directly to
/// the source of the request.
/// </summary>
[JsonConverter(typeof(DataTypeConverter))]
public enum DataType
{
    SimCardNetworkPreferences
}sealed class DataTypeConverter : JsonConverter<DataType>
{
    public override DataType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sim_card_network_preferences"=>DataType.SimCardNetworkPreferences,
            _ =>(DataType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, DataType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DataType.SimCardNetworkPreferences=>"sim_card_network_preferences",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}