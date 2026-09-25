using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Dir.PhoneNumberBatches;

/// <summary>
/// Phone-number lifecycle status. - `submitted` / `in_review` - Telnyx is reviewing
/// the batch this number belongs to. - `verified` - approved; the DIR's display
/// identity will be shown on outbound calls from this number. - `unsuccessful` -
/// Telnyx rejected this submission; the customer may re-add to retry. - `suspended`
/// - temporarily disabled (e.g. by an active infringement claim on the DIR). - `expired`
/// - verification expired; re-add to renew. - `permanently_rejected` - terminal;
/// cannot be re-added on this or any other DIR you own.
/// </summary>
[JsonConverter(typeof(DirPhoneNumberStatusConverter))]
public enum DirPhoneNumberStatus
{
    Submitted,
    InReview,
    Verified,
    Unsuccessful,
    Suspended,
    Expired,
    PermanentlyRejected
}

sealed class DirPhoneNumberStatusConverter : JsonConverter<DirPhoneNumberStatus>
{
    public override DirPhoneNumberStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "submitted"=>DirPhoneNumberStatus.Submitted,
            "in_review"=>DirPhoneNumberStatus.InReview,
            "verified"=>DirPhoneNumberStatus.Verified,
            "unsuccessful"=>DirPhoneNumberStatus.Unsuccessful,
            "suspended"=>DirPhoneNumberStatus.Suspended,
            "expired"=>DirPhoneNumberStatus.Expired,
            "permanently_rejected"=>DirPhoneNumberStatus.PermanentlyRejected,
            _ =>(DirPhoneNumberStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DirPhoneNumberStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DirPhoneNumberStatus.Submitted=>"submitted",
            DirPhoneNumberStatus.InReview=>"in_review",
            DirPhoneNumberStatus.Verified=>"verified",
            DirPhoneNumberStatus.Unsuccessful=>"unsuccessful",
            DirPhoneNumberStatus.Suspended=>"suspended",
            DirPhoneNumberStatus.Expired=>"expired",
            DirPhoneNumberStatus.PermanentlyRejected=>"permanently_rejected",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}