using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MessagingTollfree.Verification.Requests;

/// <summary>
/// Tollfree verification status
/// </summary>
[JsonConverter(typeof(TfVerificationStatusConverter))]
public enum TfVerificationStatus
{
    Verified,
    Rejected,
    WaitingForVendor,
    WaitingForCustomer,
    WaitingForTelnyx,
    InProgress
}

sealed class TfVerificationStatusConverter : JsonConverter<TfVerificationStatus>
{
    public override TfVerificationStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Verified"=>TfVerificationStatus.Verified,
            "Rejected"=>TfVerificationStatus.Rejected,
            "Waiting For Vendor"=>TfVerificationStatus.WaitingForVendor,
            "Waiting For Customer"=>TfVerificationStatus.WaitingForCustomer,
            "Waiting For Telnyx"=>TfVerificationStatus.WaitingForTelnyx,
            "In Progress"=>TfVerificationStatus.InProgress,
            _ =>(TfVerificationStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TfVerificationStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TfVerificationStatus.Verified=>"Verified",
            TfVerificationStatus.Rejected=>"Rejected",
            TfVerificationStatus.WaitingForVendor=>"Waiting For Vendor",
            TfVerificationStatus.WaitingForCustomer=>"Waiting For Customer",
            TfVerificationStatus.WaitingForTelnyx=>"Waiting For Telnyx",
            TfVerificationStatus.InProgress=>"In Progress",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}