using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Messaging.MessageMMS
{
    public class GroupMMSMessage : TelnyxEntity
    {
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("messaging_profile_id")]
        public string MessagingProfileId { get; set; }

        [JsonProperty("organization_id")]
        public Guid OrganizationId { get; set; }

        [JsonProperty("from")]
        public MessageParticipant From { get; set; }

        [JsonProperty("to")]
        public List<MessageParticipant> To { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("media")]
        public List<MediaInfo> Media { get; set; }

        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }

        [JsonProperty("webhook_failover_url")]
        public string WebhookFailoverUrl { get; set; }

        [JsonProperty("encoding")]
        public string Encoding { get; set; }

        [JsonProperty("parts")]
        public int Parts { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("cost")]
        public CostInfo Cost { get; set; }

        [JsonProperty("received_at")]
        public DateTime ReceivedAt { get; set; }

        [JsonProperty("sent_at")]
        public DateTime SentAt { get; set; }

        [JsonProperty("completed_at")]
        public DateTime CompletedAt { get; set; }

        [JsonProperty("valid_until")]
        public DateTime ValidUntil { get; set; }
    }
}
