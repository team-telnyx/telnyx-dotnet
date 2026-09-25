using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingPhoneNumbers;

/// <summary>
/// Activation status
/// </summary>
[JsonConverter(typeof(PortingOrderActivationStatusConverter))]
public enum PortingOrderActivationStatus
{
    New,
    Pending,
    Conflict,
    CancelPending,
    Failed,
    Concurred,
    ActivateRdy,
    DisconnectPending,
    ConcurrenceSent,
    Old,
    Sending,
    Active,
    Cancelled
}

sealed class PortingOrderActivationStatusConverter : JsonConverter<PortingOrderActivationStatus>
{
    public override PortingOrderActivationStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "New"=>PortingOrderActivationStatus.New,
            "Pending"=>PortingOrderActivationStatus.Pending,
            "Conflict"=>PortingOrderActivationStatus.Conflict,
            "Cancel Pending"=>PortingOrderActivationStatus.CancelPending,
            "Failed"=>PortingOrderActivationStatus.Failed,
            "Concurred"=>PortingOrderActivationStatus.Concurred,
            "Activate RDY"=>PortingOrderActivationStatus.ActivateRdy,
            "Disconnect Pending"=>PortingOrderActivationStatus.DisconnectPending,
            "Concurrence Sent"=>PortingOrderActivationStatus.ConcurrenceSent,
            "Old"=>PortingOrderActivationStatus.Old,
            "Sending"=>PortingOrderActivationStatus.Sending,
            "Active"=>PortingOrderActivationStatus.Active,
            "Cancelled"=>PortingOrderActivationStatus.Cancelled,
            _ =>(PortingOrderActivationStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingOrderActivationStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingOrderActivationStatus.New=>"New",
            PortingOrderActivationStatus.Pending=>"Pending",
            PortingOrderActivationStatus.Conflict=>"Conflict",
            PortingOrderActivationStatus.CancelPending=>"Cancel Pending",
            PortingOrderActivationStatus.Failed=>"Failed",
            PortingOrderActivationStatus.Concurred=>"Concurred",
            PortingOrderActivationStatus.ActivateRdy=>"Activate RDY",
            PortingOrderActivationStatus.DisconnectPending=>"Disconnect Pending",
            PortingOrderActivationStatus.ConcurrenceSent=>"Concurrence Sent",
            PortingOrderActivationStatus.Old=>"Old",
            PortingOrderActivationStatus.Sending=>"Sending",
            PortingOrderActivationStatus.Active=>"Active",
            PortingOrderActivationStatus.Cancelled=>"Cancelled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}