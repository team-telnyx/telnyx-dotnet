using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingOrders;

/// <summary>
/// Information about messaging porting process.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PortingOrderMessaging, PortingOrderMessagingFromRaw>))]
public sealed record class PortingOrderMessaging : JsonModel
{
    /// <summary>
    /// Indicates whether Telnyx will port messaging capabilities from the losing
    /// carrier. If false, any messaging capabilities will stay with their current provider.
    /// </summary>
    public bool? EnableMessaging {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enable_messaging"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enable_messaging", value);
        }
    }

    /// <summary>
    /// Indicates whether the porting order can also port messaging capabilities.
    /// </summary>
    public bool? MessagingCapable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "messaging_capable"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_capable", value);
        }
    }

    /// <summary>
    /// Indicates whether the messaging porting has been completed.
    /// </summary>
    public bool? MessagingPortCompleted {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "messaging_port_completed"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_port_completed", value);
        }
    }

    /// <summary>
    /// The current status of the messaging porting.
    /// </summary>
    public ApiEnum<string, MessagingPortStatus>? MessagingPortStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessagingPortStatus>>(
                "messaging_port_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_port_status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EnableMessaging;
        _ = this.MessagingCapable;
        _ = this.MessagingPortCompleted;
        this.MessagingPortStatus?.Validate();
    }

    public PortingOrderMessaging ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderMessaging (
        PortingOrderMessaging portingOrderMessaging
    ) : base(portingOrderMessaging)
    {  }
    #pragma warning restore CS8618

    public PortingOrderMessaging (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderMessaging (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderMessagingFromRaw.FromRawUnchecked"/>
    public static PortingOrderMessaging FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderMessagingFromRaw : IFromRawJson<PortingOrderMessaging>
{
    /// <inheritdoc/>
    public PortingOrderMessaging FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderMessaging.FromRawUnchecked(rawData);
}

/// <summary>
/// The current status of the messaging porting.
/// </summary>
[JsonConverter(typeof(MessagingPortStatusConverter))]
public enum MessagingPortStatus
{
    NotApplicable,
    Pending,
    Activating,
    Exception,
    Canceled,
    PartialPortComplete,
    Ported
}sealed class MessagingPortStatusConverter : JsonConverter<MessagingPortStatus>
{
    public override MessagingPortStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_applicable"=>MessagingPortStatus.NotApplicable,
            "pending"=>MessagingPortStatus.Pending,
            "activating"=>MessagingPortStatus.Activating,
            "exception"=>MessagingPortStatus.Exception,
            "canceled"=>MessagingPortStatus.Canceled,
            "partial_port_complete"=>MessagingPortStatus.PartialPortComplete,
            "ported"=>MessagingPortStatus.Ported,
            _ =>(MessagingPortStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessagingPortStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessagingPortStatus.NotApplicable=>"not_applicable",
            MessagingPortStatus.Pending=>"pending",
            MessagingPortStatus.Activating=>"activating",
            MessagingPortStatus.Exception=>"exception",
            MessagingPortStatus.Canceled=>"canceled",
            MessagingPortStatus.PartialPortComplete=>"partial_port_complete",
            MessagingPortStatus.Ported=>"ported",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}