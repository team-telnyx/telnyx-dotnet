namespace Telnyx.net.Entities.Messaging.VerificationRequests
{
    using System;
    using Newtonsoft.Json;

    public class MessagingVerificationRequest : TelnyxEntity
    {
        [JsonProperty("businessName")]
        public string BusinessName { get; set; }

        [JsonProperty("corporateWebsite")]
        public string CorporateWebsite { get; set; }

        [JsonProperty("businessAddr1")]
        public string BusinessAddr1 { get; set; }

        [JsonProperty("businessAddr2")]
        public string BusinessAddr2 { get; set; }

        [JsonProperty("businessCity")]
        public string BusinessCity { get; set; }

        [JsonProperty("businessState")]
        public string BusinessState { get; set; }

        [JsonProperty("businessZip")]
        public string BusinessZip { get; set; }

        [JsonProperty("businessContactFirstName")]
        public string BusinessContactFirstName { get; set; }

        [JsonProperty("businessContactLastName")]
        public string BusinessContactLastName { get; set; }

        [JsonProperty("businessContactEmail")]
        public string BusinessContactEmail { get; set; }

        [JsonProperty("businessContactPhone")]
        public string BusinessContactPhone { get; set; }

        [JsonProperty("messageVolume")]
        public object MessageVolume { get; set; } // Type to be replaced with the actual enum type

        [JsonProperty("phoneNumbers")]
        public string[] PhoneNumbers { get; set; } // Assuming this to be an array of strings

        [JsonProperty("useCase")]
        public object UseCase { get; set; } // Type to be replaced with the actual enum type

        [JsonProperty("useCaseSummary")]
        public string UseCaseSummary { get; set; }

        [JsonProperty("productionMessageContent")]
        public string ProductionMessageContent { get; set; }

        [JsonProperty("optInWorkflow")]
        public object OptInWorkflow { get; set; } // Type to be replaced with the actual enum or object type

        [JsonProperty("optInWorkflowImageURLs")]
        public string[] OptInWorkflowImageURLs { get; set; }

        [JsonProperty("additionalInformation")]
        public string AdditionalInformation { get; set; }

        [JsonProperty("isvReseller")]
        public bool IsvReseller { get; set; }

        [JsonProperty("webhookUrl")]
        public string WebhookUrl { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("verificationRequestId")]
        public Guid VerificationRequestId { get; set; }

        [JsonProperty("verificationStatus")]
        public object VerificationStatus { get; set; } // Type to be replaced with the actual enum or object type
    }

}
