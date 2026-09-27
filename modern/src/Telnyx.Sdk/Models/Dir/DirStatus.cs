using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Dir;

/// <summary>
/// DIR lifecycle status. - `draft` - newly created; editable; not yet submitted.
/// - `submitted` / `in_review` - Telnyx is reviewing. - `verified` - approved; phone
/// numbers may be attached. - `rejected` - Telnyx rejected this submission; `rejection_reasons`
/// is populated; customer can edit and resubmit. - `unsuccessful` - system-side
/// error during processing; customer can edit and resubmit. - `suspended` - temporarily
/// disabled (e.g. by an active infringement claim). - `expired` - verification expired;
/// customer must resubmit. - `infringement_claimed` - a trademark/impersonation
/// claim is open against this DIR. - `permanently_rejected` - terminal; cannot be resubmitted.
/// </summary>
[JsonConverter(typeof(DirStatusConverter))]
public enum DirStatus
{
    Draft,
    Submitted,
    InReview,
    Verified,
    Rejected,
    Unsuccessful,
    Suspended,
    Expired,
    InfringementClaimed,
    PermanentlyRejected
}

sealed class DirStatusConverter : JsonConverter<DirStatus>
{
    public override DirStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "draft"=>DirStatus.Draft,
            "submitted"=>DirStatus.Submitted,
            "in_review"=>DirStatus.InReview,
            "verified"=>DirStatus.Verified,
            "rejected"=>DirStatus.Rejected,
            "unsuccessful"=>DirStatus.Unsuccessful,
            "suspended"=>DirStatus.Suspended,
            "expired"=>DirStatus.Expired,
            "infringement_claimed"=>DirStatus.InfringementClaimed,
            "permanently_rejected"=>DirStatus.PermanentlyRejected,
            _ =>(DirStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, DirStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DirStatus.Draft=>"draft",
            DirStatus.Submitted=>"submitted",
            DirStatus.InReview=>"in_review",
            DirStatus.Verified=>"verified",
            DirStatus.Rejected=>"rejected",
            DirStatus.Unsuccessful=>"unsuccessful",
            DirStatus.Suspended=>"suspended",
            DirStatus.Expired=>"expired",
            DirStatus.InfringementClaimed=>"infringement_claimed",
            DirStatus.PermanentlyRejected=>"permanently_rejected",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}