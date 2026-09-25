using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Payment.AutoRechargePrefs;

[JsonConverter(typeof(JsonModelConverter<AutoRechargePref, AutoRechargePrefFromRaw>))]
public sealed record class AutoRechargePref : JsonModel
{
    /// <summary>
    /// The unique identifier for the auto recharge preference.
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
    /// Whether auto recharge is enabled.
    /// </summary>
    public bool? Enabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enabled", value);
        }
    }

    public bool? InvoiceEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "invoice_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("invoice_enabled", value);
        }
    }

    /// <summary>
    /// The payment preference for auto recharge.
    /// </summary>
    public ApiEnum<string, AutoRechargePrefPreference>? Preference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AutoRechargePrefPreference>>(
                "preference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("preference", value);
        }
    }

    /// <summary>
    /// The amount to recharge the account, the actual recharge amount will be the
    /// amount necessary to reach the threshold amount plus the recharge amount.
    /// </summary>
    public string? RechargeAmount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "recharge_amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("recharge_amount", value);
        }
    }

    /// <summary>
    /// The record type.
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

    /// <summary>
    /// The threshold amount at which the account will be recharged.
    /// </summary>
    public string? ThresholdAmount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "threshold_amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("threshold_amount", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Enabled;
        _ = this.InvoiceEnabled;
        this.Preference?.Validate();
        _ = this.RechargeAmount;
        _ = this.RecordType;
        _ = this.ThresholdAmount;
    }

    public AutoRechargePref ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutoRechargePref (AutoRechargePref autoRechargePref) : base(
        autoRechargePref
    )
    {  }
    #pragma warning restore CS8618

    public AutoRechargePref (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AutoRechargePref (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AutoRechargePrefFromRaw.FromRawUnchecked"/>
    public static AutoRechargePref FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AutoRechargePrefFromRaw : IFromRawJson<AutoRechargePref>
{
    /// <inheritdoc/>
    public AutoRechargePref FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AutoRechargePref.FromRawUnchecked(rawData);
}

/// <summary>
/// The payment preference for auto recharge.
/// </summary>
[JsonConverter(typeof(AutoRechargePrefPreferenceConverter))]
public enum AutoRechargePrefPreference
{
    CreditPaypal, Ach
}sealed class AutoRechargePrefPreferenceConverter : JsonConverter<AutoRechargePrefPreference>
{
    public override AutoRechargePrefPreference Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit_paypal"=>AutoRechargePrefPreference.CreditPaypal,
            "ach"=>AutoRechargePrefPreference.Ach,
            _ =>(AutoRechargePrefPreference)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AutoRechargePrefPreference value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AutoRechargePrefPreference.CreditPaypal=>"credit_paypal",
            AutoRechargePrefPreference.Ach=>"ach",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}