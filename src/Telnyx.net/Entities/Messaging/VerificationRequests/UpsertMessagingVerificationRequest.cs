namespace Telnyx.net.Entities.Messaging.VerificationRequests
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a request to create or update messaging verification.
    /// </summary>
    public class UpsertMessagingVerificationRequest : BaseOptions
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
        public string MessageVolume { get; set; } // Placeholder for actual enum type

        [JsonProperty("phoneNumbers")]
        public List<string> PhoneNumbers { get; set; } // Assuming it's a list of strings

        [JsonProperty("useCase")]
        public string UseCase { get; set; } // Placeholder for actual enum type

        [JsonProperty("useCaseSummary")]
        public string UseCaseSummary { get; set; }

        [JsonProperty("productionMessageContent")]
        public string ProductionMessageContent { get; set; }

        [JsonProperty("optInWorkflow")]
        public string OptInWorkflow { get; set; } // Placeholder for actual type

        [JsonProperty("optInWorkflowImageURLs")]
        public List<string> OptInWorkflowImageURLs { get; set; } // Assuming list of strings

        [JsonProperty("additionalInformation")]
        public string AdditionalInformation { get; set; }

        [JsonProperty("isvReseller")]
        public bool IsvReseller { get; set; }

        [JsonProperty("webhookUrl")]
        public string WebhookUrl { get; set; }
    }

}
