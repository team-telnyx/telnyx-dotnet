using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PortingPhoneNumbers;

namespace Telnyx.Sdk.Models.PortingOrders;

[JsonConverter(typeof(JsonModelConverter<PortingOrderActivationSettings, PortingOrderActivationSettingsFromRaw>))]
public sealed record class PortingOrderActivationSettings : JsonModel
{
    /// <summary>
    /// Activation status
    /// </summary>
    public ApiEnum<string, PortingOrderActivationStatus>? ActivationStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingOrderActivationStatus>>(
                "activation_status"
            );
        }
        init { this._rawData.Set("activation_status", value); }
    }

    /// <summary>
    /// Indicates whether this porting order is eligible for FastPort
    /// </summary>
    public bool? FastPortEligible {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "fast_port_eligible"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("fast_port_eligible", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted Date/Time of the FOC date
    /// </summary>
    public DateTimeOffset? FocDatetimeActual {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "foc_datetime_actual"
            );
        }
        init { this._rawData.Set("foc_datetime_actual", value); }
    }

    /// <summary>
    /// ISO 8601 formatted Date/Time requested for the FOC date
    /// </summary>
    public DateTimeOffset? FocDatetimeRequested {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "foc_datetime_requested"
            );
        }
        init { this._rawData.Set("foc_datetime_requested", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ActivationStatus?.Validate();
        _ = this.FastPortEligible;
        _ = this.FocDatetimeActual;
        _ = this.FocDatetimeRequested;
    }

    public PortingOrderActivationSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderActivationSettings (
        PortingOrderActivationSettings portingOrderActivationSettings
    ) : base(portingOrderActivationSettings)
    {  }
    #pragma warning restore CS8618

    public PortingOrderActivationSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderActivationSettings (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderActivationSettingsFromRaw.FromRawUnchecked"/>
    public static PortingOrderActivationSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderActivationSettingsFromRaw : IFromRawJson<PortingOrderActivationSettings>
{
    /// <inheritdoc/>
    public PortingOrderActivationSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderActivationSettings.FromRawUnchecked(rawData);
}