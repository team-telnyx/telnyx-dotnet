using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PrivateWirelessGateways;

/// <summary>
/// The current status or failure details of the Private Wireless Gateway.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PrivateWirelessGatewayStatus, PrivateWirelessGatewayStatusFromRaw>))]
public sealed record class PrivateWirelessGatewayStatus : JsonModel
{
    /// <summary>
    /// This attribute is an [error code](https://developers.telnyx.com/docs/development/api-fundamentals/api-errors)
    /// related to the failure reason.
    /// </summary>
    public string? ErrorCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error_code"
            );
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <summary>
    /// This attribute provides a human-readable explanation of why a failure happened.
    /// </summary>
    public string? ErrorDescription {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error_description"
            );
        }
        init { this._rawData.Set("error_description", value); }
    }

    /// <summary>
    /// The current status or failure details of the Private Wireless Gateway. &lt;ul&gt;
    ///  &lt;li&gt;&lt;code&gt;provisioning&lt;/code&gt; - the Private Wireless Gateway
    /// is being provisioned.&lt;/li&gt;  &lt;li&gt;&lt;code&gt;provisioned&lt;/code&gt;
    /// - the Private Wireless Gateway was provisioned and able to receive connections.&lt;/li&gt;
    ///  &lt;li&gt;&lt;code&gt;failed&lt;/code&gt; - the provisioning had failed
    /// for a reason and it requires an intervention.&lt;/li&gt;  &lt;li&gt;&lt;code&gt;decommissioning&lt;/code&gt;
    /// - the Private Wireless Gateway is being removed from the network.&lt;/li&gt;
    ///  &lt;/ul&gt;  Transitioning between the provisioning and provisioned states
    /// may take some time.
    /// </summary>
    public ApiEnum<string, Value>? Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Value>>(
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
        _ = this.ErrorCode;
        _ = this.ErrorDescription;
        this.Value?.Validate();
    }

    public PrivateWirelessGatewayStatus ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PrivateWirelessGatewayStatus (
        PrivateWirelessGatewayStatus privateWirelessGatewayStatus
    ) : base(privateWirelessGatewayStatus)
    {  }
    #pragma warning restore CS8618

    public PrivateWirelessGatewayStatus (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PrivateWirelessGatewayStatus (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PrivateWirelessGatewayStatusFromRaw.FromRawUnchecked"/>
    public static PrivateWirelessGatewayStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PrivateWirelessGatewayStatusFromRaw : IFromRawJson<PrivateWirelessGatewayStatus>
{
    /// <inheritdoc/>
    public PrivateWirelessGatewayStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PrivateWirelessGatewayStatus.FromRawUnchecked(rawData);
}

/// <summary>
/// The current status or failure details of the Private Wireless Gateway. &lt;ul&gt;
///  &lt;li&gt;&lt;code&gt;provisioning&lt;/code&gt; - the Private Wireless Gateway
/// is being provisioned.&lt;/li&gt;  &lt;li&gt;&lt;code&gt;provisioned&lt;/code&gt;
/// - the Private Wireless Gateway was provisioned and able to receive connections.&lt;/li&gt;
///  &lt;li&gt;&lt;code&gt;failed&lt;/code&gt; - the provisioning had failed for a
/// reason and it requires an intervention.&lt;/li&gt;  &lt;li&gt;&lt;code&gt;decommissioning&lt;/code&gt;
/// - the Private Wireless Gateway is being removed from the network.&lt;/li&gt;
///  &lt;/ul&gt;  Transitioning between the provisioning and provisioned states may
/// take some time.
/// </summary>
[JsonConverter(typeof(ValueConverter))]
public enum Value
{
    Provisioning, Provisioned, Failed, Decommissioning
}sealed class ValueConverter : JsonConverter<Value>
{
    public override Value Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "provisioning"=>Value.Provisioning,
            "provisioned"=>Value.Provisioned,
            "failed"=>Value.Failed,
            "decommissioning"=>Value.Decommissioning,
            _ =>(Value)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Value value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Value.Provisioning=>"provisioning",
            Value.Provisioned=>"provisioned",
            Value.Failed=>"failed",
            Value.Decommissioning=>"decommissioning",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}