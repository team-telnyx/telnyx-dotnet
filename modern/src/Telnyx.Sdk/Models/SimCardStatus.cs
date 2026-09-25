using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<SimCardStatus, SimCardStatusFromRaw>))]
public sealed record class SimCardStatus : JsonModel
{
    /// <summary>
    /// It describes why the SIM card is in the current status.
    /// </summary>
    public string? Reason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    /// <summary>
    /// The current status of the SIM card. It will be one of the following: &lt;br/&gt;
    /// &lt;ul&gt;  &lt;li&gt;&lt;code&gt;registering&lt;/code&gt; - the card is being
    /// registered&lt;/li&gt;  &lt;li&gt;&lt;code&gt;enabling&lt;/code&gt; - the
    /// card is being enabled&lt;/li&gt;  &lt;li&gt;&lt;code&gt;enabled&lt;/code&gt;
    /// - the card is enabled and ready for use&lt;/li&gt;  &lt;li&gt;&lt;code&gt;disabling&lt;/code&gt;
    /// - the card is being disabled&lt;/li&gt;  &lt;li&gt;&lt;code&gt;disabled&lt;/code&gt;
    /// - the card has been disabled and cannot be used&lt;/li&gt;  &lt;li&gt;&lt;code&gt;data_limit_exceeded&lt;/code&gt;
    /// - the card has exceeded its data consumption limit&lt;/li&gt;  &lt;li&gt;&lt;code&gt;setting_standby&lt;/code&gt;
    /// - the process to set the card in stand by is in progress&lt;/li&gt;  &lt;li&gt;&lt;code&gt;standby&lt;/code&gt;
    /// - the card is in stand by&lt;/li&gt; &lt;/ul&gt; Transitioning between the
    /// enabled and disabled states may take a period of time.
    /// </summary>
    public ApiEnum<string, SimCardStatusValue>? Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SimCardStatusValue>>(
                "value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Reason;
        this.Value?.Validate();
    }

    public SimCardStatus ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardStatus (SimCardStatus simCardStatus) : base(simCardStatus)
    {  }
    #pragma warning restore CS8618

    public SimCardStatus (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardStatus (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardStatusFromRaw.FromRawUnchecked"/>
    public static SimCardStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardStatusFromRaw : IFromRawJson<SimCardStatus>
{
    /// <inheritdoc/>
    public SimCardStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardStatus.FromRawUnchecked(rawData);
}

/// <summary>
/// The current status of the SIM card. It will be one of the following: &lt;br/&gt;
/// &lt;ul&gt;  &lt;li&gt;&lt;code&gt;registering&lt;/code&gt; - the card is being
/// registered&lt;/li&gt;  &lt;li&gt;&lt;code&gt;enabling&lt;/code&gt; - the card
/// is being enabled&lt;/li&gt;  &lt;li&gt;&lt;code&gt;enabled&lt;/code&gt; - the
/// card is enabled and ready for use&lt;/li&gt;  &lt;li&gt;&lt;code&gt;disabling&lt;/code&gt;
/// - the card is being disabled&lt;/li&gt;  &lt;li&gt;&lt;code&gt;disabled&lt;/code&gt;
/// - the card has been disabled and cannot be used&lt;/li&gt;  &lt;li&gt;&lt;code&gt;data_limit_exceeded&lt;/code&gt;
/// - the card has exceeded its data consumption limit&lt;/li&gt;  &lt;li&gt;&lt;code&gt;setting_standby&lt;/code&gt;
/// - the process to set the card in stand by is in progress&lt;/li&gt;  &lt;li&gt;&lt;code&gt;standby&lt;/code&gt;
/// - the card is in stand by&lt;/li&gt; &lt;/ul&gt; Transitioning between the enabled
/// and disabled states may take a period of time.
/// </summary>
[JsonConverter(typeof(SimCardStatusValueConverter))]
public enum SimCardStatusValue
{
    Registering,
    Enabling,
    Enabled,
    Disabling,
    Disabled,
    DataLimitExceeded,
    SettingStandby,
    Standby
}sealed class SimCardStatusValueConverter : JsonConverter<SimCardStatusValue>
{
    public override SimCardStatusValue Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "registering"=>SimCardStatusValue.Registering,
            "enabling"=>SimCardStatusValue.Enabling,
            "enabled"=>SimCardStatusValue.Enabled,
            "disabling"=>SimCardStatusValue.Disabling,
            "disabled"=>SimCardStatusValue.Disabled,
            "data_limit_exceeded"=>SimCardStatusValue.DataLimitExceeded,
            "setting_standby"=>SimCardStatusValue.SettingStandby,
            "standby"=>SimCardStatusValue.Standby,
            _ =>(SimCardStatusValue)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SimCardStatusValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SimCardStatusValue.Registering=>"registering",
            SimCardStatusValue.Enabling=>"enabling",
            SimCardStatusValue.Enabled=>"enabled",
            SimCardStatusValue.Disabling=>"disabling",
            SimCardStatusValue.Disabled=>"disabled",
            SimCardStatusValue.DataLimitExceeded=>"data_limit_exceeded",
            SimCardStatusValue.SettingStandby=>"setting_standby",
            SimCardStatusValue.Standby=>"standby",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}