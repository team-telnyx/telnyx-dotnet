using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.SimCardDataUsageNotifications;

/// <summary>
/// The SIM card individual data usage notification information.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SimCardDataUsageNotification, SimCardDataUsageNotificationFromRaw>))]
public sealed record class SimCardDataUsageNotification : JsonModel
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

    /// <summary>
    /// Data usage threshold that will trigger the notification.
    /// </summary>
    public SimCardDataUsageNotificationThreshold? Threshold {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SimCardDataUsageNotificationThreshold>(
                "threshold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("threshold", value);
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
        _ = this.SimCardID;
        this.Threshold?.Validate();
        _ = this.UpdatedAt;
    }

    public SimCardDataUsageNotification ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardDataUsageNotification (
        SimCardDataUsageNotification simCardDataUsageNotification
    ) : base(simCardDataUsageNotification)
    {  }
    #pragma warning restore CS8618

    public SimCardDataUsageNotification (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardDataUsageNotification (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardDataUsageNotificationFromRaw.FromRawUnchecked"/>
    public static SimCardDataUsageNotification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardDataUsageNotificationFromRaw : IFromRawJson<SimCardDataUsageNotification>
{
    /// <inheritdoc/>
    public SimCardDataUsageNotification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardDataUsageNotification.FromRawUnchecked(rawData);
}

/// <summary>
/// Data usage threshold that will trigger the notification.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SimCardDataUsageNotificationThreshold, SimCardDataUsageNotificationThresholdFromRaw>))]
public sealed record class SimCardDataUsageNotificationThreshold : JsonModel
{
    public string? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    public ApiEnum<string, SimCardDataUsageNotificationThresholdUnit>? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SimCardDataUsageNotificationThresholdUnit>>(
                "unit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("unit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Unit?.Validate();
    }

    public SimCardDataUsageNotificationThreshold ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardDataUsageNotificationThreshold (
        SimCardDataUsageNotificationThreshold simCardDataUsageNotificationThreshold
    ) : base(simCardDataUsageNotificationThreshold)
    {  }
    #pragma warning restore CS8618

    public SimCardDataUsageNotificationThreshold (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardDataUsageNotificationThreshold (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardDataUsageNotificationThresholdFromRaw.FromRawUnchecked"/>
    public static SimCardDataUsageNotificationThreshold FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SimCardDataUsageNotificationThresholdFromRaw : IFromRawJson<SimCardDataUsageNotificationThreshold>
{
    /// <inheritdoc/>
    public SimCardDataUsageNotificationThreshold FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardDataUsageNotificationThreshold.FromRawUnchecked(rawData);
}[JsonConverter(typeof(SimCardDataUsageNotificationThresholdUnitConverter))]
public enum SimCardDataUsageNotificationThresholdUnit
{
    MB, GB
}sealed class SimCardDataUsageNotificationThresholdUnitConverter : JsonConverter<SimCardDataUsageNotificationThresholdUnit>
{
    public override SimCardDataUsageNotificationThresholdUnit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MB"=>SimCardDataUsageNotificationThresholdUnit.MB,
            "GB"=>SimCardDataUsageNotificationThresholdUnit.GB,
            _ =>(SimCardDataUsageNotificationThresholdUnit)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SimCardDataUsageNotificationThresholdUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SimCardDataUsageNotificationThresholdUnit.MB=>"MB",
            SimCardDataUsageNotificationThresholdUnit.GB=>"GB",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}