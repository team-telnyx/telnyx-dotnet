using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailEvents;

/// <summary>
/// Bare stored event names returned by message history. In addition to the normal
/// send and delivery lifecycle, polling can expose suppression, scan, and quarantine
/// lifecycle rows. Sharp canonical names gw_reject, injection_timeout, and expired
/// distinguish gateway rejection, ambiguous injection timeout, and MTA expiration.
/// The failed and bounced names remain valid for system/admin failures and hard
/// bounces respectively. Existing stored rows retain their original names.
/// </summary>
[JsonConverter(typeof(EmailEventTypeConverter))]
public enum EmailEventType
{
    Queued,
    Deferred,
    Scheduled,
    Cancelled,
    Sandbox,
    Sending,
    Sent,
    Failed,
    Delivered,
    Bounced,
    Complained,
    Suppressed,
    Rejected,
    Opened,
    Clicked,
    Unsubscribed,
    DailyLimitExceeded,
    ScanDeferred,
    Quarantined,
    QuarantineReleased,
    QuarantineReleaseDispatched,
    QuarantineRejected,
    QuarantineExpired,
    GwReject,
    InjectionTimeout,
    Expired
}

sealed class EmailEventTypeConverter : JsonConverter<EmailEventType>
{
    public override EmailEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued"=>EmailEventType.Queued,
            "deferred"=>EmailEventType.Deferred,
            "scheduled"=>EmailEventType.Scheduled,
            "cancelled"=>EmailEventType.Cancelled,
            "sandbox"=>EmailEventType.Sandbox,
            "sending"=>EmailEventType.Sending,
            "sent"=>EmailEventType.Sent,
            "failed"=>EmailEventType.Failed,
            "delivered"=>EmailEventType.Delivered,
            "bounced"=>EmailEventType.Bounced,
            "complained"=>EmailEventType.Complained,
            "suppressed"=>EmailEventType.Suppressed,
            "rejected"=>EmailEventType.Rejected,
            "opened"=>EmailEventType.Opened,
            "clicked"=>EmailEventType.Clicked,
            "unsubscribed"=>EmailEventType.Unsubscribed,
            "daily_limit_exceeded"=>EmailEventType.DailyLimitExceeded,
            "scan_deferred"=>EmailEventType.ScanDeferred,
            "quarantined"=>EmailEventType.Quarantined,
            "quarantine_released"=>EmailEventType.QuarantineReleased,
            "quarantine_release_dispatched"=>EmailEventType.QuarantineReleaseDispatched,
            "quarantine_rejected"=>EmailEventType.QuarantineRejected,
            "quarantine_expired"=>EmailEventType.QuarantineExpired,
            "gw_reject"=>EmailEventType.GwReject,
            "injection_timeout"=>EmailEventType.InjectionTimeout,
            "expired"=>EmailEventType.Expired,
            _ =>(EmailEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmailEventType.Queued=>"queued",
            EmailEventType.Deferred=>"deferred",
            EmailEventType.Scheduled=>"scheduled",
            EmailEventType.Cancelled=>"cancelled",
            EmailEventType.Sandbox=>"sandbox",
            EmailEventType.Sending=>"sending",
            EmailEventType.Sent=>"sent",
            EmailEventType.Failed=>"failed",
            EmailEventType.Delivered=>"delivered",
            EmailEventType.Bounced=>"bounced",
            EmailEventType.Complained=>"complained",
            EmailEventType.Suppressed=>"suppressed",
            EmailEventType.Rejected=>"rejected",
            EmailEventType.Opened=>"opened",
            EmailEventType.Clicked=>"clicked",
            EmailEventType.Unsubscribed=>"unsubscribed",
            EmailEventType.DailyLimitExceeded=>"daily_limit_exceeded",
            EmailEventType.ScanDeferred=>"scan_deferred",
            EmailEventType.Quarantined=>"quarantined",
            EmailEventType.QuarantineReleased=>"quarantine_released",
            EmailEventType.QuarantineReleaseDispatched=>"quarantine_release_dispatched",
            EmailEventType.QuarantineRejected=>"quarantine_rejected",
            EmailEventType.QuarantineExpired=>"quarantine_expired",
            EmailEventType.GwReject=>"gw_reject",
            EmailEventType.InjectionTimeout=>"injection_timeout",
            EmailEventType.Expired=>"expired",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}