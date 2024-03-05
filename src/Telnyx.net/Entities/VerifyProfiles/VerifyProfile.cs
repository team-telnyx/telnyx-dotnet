using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.VerifyProfiles
{
    public class VerifyProfile : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }

        [JsonProperty("webhook_failover_url")]
        public string WebhookFailoverUrl { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; } = "verification_profile";

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("sms")]
        public SmsSettings Sms { get; set; }

        [JsonProperty("psd2")]
        public Psd2Settings Psd2 { get; set; }

        [JsonProperty("whatsapp")]
        public WhatsappSettings Whatsapp { get; set; }

        [JsonProperty("app_name")]
        public string AppName { get; set; }

        [JsonProperty("call")]
        public CallSettings Call { get; set; }

        [JsonProperty("flashcall")]
        public FlashcallSettings Flashcall { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }
    public class FlashcallSettings
    {
        [JsonProperty("default_verification_timeout_secs")]
        public int DefaultVerificationTimeoutSecs { get; set; }
    }
    public class CallSettings
    {
        [JsonProperty("messaging_template")]
        public string MessagingTemplate { get; set; }

        [JsonProperty("default_verification_timeout_secs")]
        public int DefaultVerificationTimeoutSecs { get; set; }

        [JsonProperty("default_call_timeout_secs")]
        public int DefaultCallTimeoutSecs { get; set; } = 45;
    }

    public class SmsSettings
    {
        [JsonProperty("messaging_enabled")]
        public bool MessagingEnabled { get; set; }

        [JsonProperty("rcs_enabled")]
        public bool RcsEnabled { get; set; }

        [JsonProperty("messaging_template")]
        public string MessagingTemplate { get; set; }

        [JsonProperty("default_verification_timeout_secs")]
        public int DefaultVerificationTimeoutSecs { get; set; }

        [JsonProperty("vsms_enabled")]
        public bool VsmsEnabled { get; set; }
    }

    public class Psd2Settings
    {
        [JsonProperty("default_verification_timeout_secs")]
        public int DefaultVerificationTimeoutSecs { get; set; }
    }

    public class WhatsappSettings
    {
        [JsonProperty("app_name")]
        public string AppName { get; set; }

        [JsonProperty("default_verification_timeout_secs")]
        public int DefaultVerificationTimeoutSecs { get; set; }
    }

}
