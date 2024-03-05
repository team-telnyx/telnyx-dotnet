using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.VerifyProfiles
{
    public class UpsertVerifyProfile : BaseOptions
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }

        [JsonProperty("webhook_failover_url")]
        public string WebhookFailoverUrl { get; set; }

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

}
