using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Dir.Comments;

/// <summary>
/// Comment categorisation. Customers post `customer_inquiry`. The Telnyx team posts
/// `vetting_comment`, `rejection_reason`, `notification`, `status_update`, or `admin_response`.
/// `internal_note` is filtered out of customer-visible responses.
/// </summary>
[JsonConverter(typeof(CommentTypeConverter))]
public enum CommentType
{
    VettingComment,
    RejectionReason,
    InternalNote,
    Notification,
    StatusUpdate,
    CustomerInquiry,
    AdminResponse
}

sealed class CommentTypeConverter : JsonConverter<CommentType>
{
    public override CommentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "vetting_comment"=>CommentType.VettingComment,
            "rejection_reason"=>CommentType.RejectionReason,
            "internal_note"=>CommentType.InternalNote,
            "notification"=>CommentType.Notification,
            "status_update"=>CommentType.StatusUpdate,
            "customer_inquiry"=>CommentType.CustomerInquiry,
            "admin_response"=>CommentType.AdminResponse,
            _ =>(CommentType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, CommentType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CommentType.VettingComment=>"vetting_comment",
            CommentType.RejectionReason=>"rejection_reason",
            CommentType.InternalNote=>"internal_note",
            CommentType.Notification=>"notification",
            CommentType.StatusUpdate=>"status_update",
            CommentType.CustomerInquiry=>"customer_inquiry",
            CommentType.AdminResponse=>"admin_response",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}