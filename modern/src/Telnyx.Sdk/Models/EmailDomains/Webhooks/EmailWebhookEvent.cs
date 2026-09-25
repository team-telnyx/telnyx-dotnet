using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailDomains.Webhooks;

/// <summary>
/// Event types accepted by domain webhook subscriptions. Allowlists match the legacy
/// event_type, not canonical_event_type. Of the 22 accepted types, email.sending
/// is stored but intentionally not published. Cancellation, daily-limit failures,
/// and system failures publish after commit when a matching domain webhook is configured.
/// </summary>
[JsonConverter(typeof(EmailWebhookEventConverter))]
public enum EmailWebhookEvent
{
    EmailScheduled,
    EmailSandbox,
    EmailQueued,
    EmailSending,
    EmailSent,
    EmailDelivered,
    EmailDeferred,
    EmailBounced,
    EmailFailed,
    EmailComplained,
    EmailOpened,
    EmailClicked,
    EmailUnsubscribed,
    EmailReceived,
    EmailCancelled,
    EmailDailyLimitExceeded,
    EmailDomainCreated,
    EmailDomainVerified,
    EmailDomainDegraded,
    EmailDomainSuspended,
    EmailDomainDeleted,
    EmailDomainDkimRotated
}

sealed class EmailWebhookEventConverter : JsonConverter<EmailWebhookEvent>
{
    public override EmailWebhookEvent Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email.scheduled"=>EmailWebhookEvent.EmailScheduled,
            "email.sandbox"=>EmailWebhookEvent.EmailSandbox,
            "email.queued"=>EmailWebhookEvent.EmailQueued,
            "email.sending"=>EmailWebhookEvent.EmailSending,
            "email.sent"=>EmailWebhookEvent.EmailSent,
            "email.delivered"=>EmailWebhookEvent.EmailDelivered,
            "email.deferred"=>EmailWebhookEvent.EmailDeferred,
            "email.bounced"=>EmailWebhookEvent.EmailBounced,
            "email.failed"=>EmailWebhookEvent.EmailFailed,
            "email.complained"=>EmailWebhookEvent.EmailComplained,
            "email.opened"=>EmailWebhookEvent.EmailOpened,
            "email.clicked"=>EmailWebhookEvent.EmailClicked,
            "email.unsubscribed"=>EmailWebhookEvent.EmailUnsubscribed,
            "email.received"=>EmailWebhookEvent.EmailReceived,
            "email.cancelled"=>EmailWebhookEvent.EmailCancelled,
            "email.daily_limit_exceeded"=>EmailWebhookEvent.EmailDailyLimitExceeded,
            "email_domain.created"=>EmailWebhookEvent.EmailDomainCreated,
            "email_domain.verified"=>EmailWebhookEvent.EmailDomainVerified,
            "email_domain.degraded"=>EmailWebhookEvent.EmailDomainDegraded,
            "email_domain.suspended"=>EmailWebhookEvent.EmailDomainSuspended,
            "email_domain.deleted"=>EmailWebhookEvent.EmailDomainDeleted,
            "email_domain.dkim_rotated"=>EmailWebhookEvent.EmailDomainDkimRotated,
            _ =>(EmailWebhookEvent)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmailWebhookEvent.EmailScheduled=>"email.scheduled",
            EmailWebhookEvent.EmailSandbox=>"email.sandbox",
            EmailWebhookEvent.EmailQueued=>"email.queued",
            EmailWebhookEvent.EmailSending=>"email.sending",
            EmailWebhookEvent.EmailSent=>"email.sent",
            EmailWebhookEvent.EmailDelivered=>"email.delivered",
            EmailWebhookEvent.EmailDeferred=>"email.deferred",
            EmailWebhookEvent.EmailBounced=>"email.bounced",
            EmailWebhookEvent.EmailFailed=>"email.failed",
            EmailWebhookEvent.EmailComplained=>"email.complained",
            EmailWebhookEvent.EmailOpened=>"email.opened",
            EmailWebhookEvent.EmailClicked=>"email.clicked",
            EmailWebhookEvent.EmailUnsubscribed=>"email.unsubscribed",
            EmailWebhookEvent.EmailReceived=>"email.received",
            EmailWebhookEvent.EmailCancelled=>"email.cancelled",
            EmailWebhookEvent.EmailDailyLimitExceeded=>"email.daily_limit_exceeded",
            EmailWebhookEvent.EmailDomainCreated=>"email_domain.created",
            EmailWebhookEvent.EmailDomainVerified=>"email_domain.verified",
            EmailWebhookEvent.EmailDomainDegraded=>"email_domain.degraded",
            EmailWebhookEvent.EmailDomainSuspended=>"email_domain.suspended",
            EmailWebhookEvent.EmailDomainDeleted=>"email_domain.deleted",
            EmailWebhookEvent.EmailDomainDkimRotated=>"email_domain.dkim_rotated",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}