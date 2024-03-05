using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.PhoneNumbers.PhoneNumberBlocksJobs
{
    public class PhoneNumberblockJob : TelnyxEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; } = "pending";

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("etc")]
        public DateTime EstimatedCompletionTime { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("successful_operations")]
        public PhoneNumberBlocksJobSuccessfulOperation[] SuccessfulOperations { get; set; }

        [JsonProperty("failed_operations")]
        public PhoneNumberBlocksJobFailedOperation[] FailedOperations { get; set; }

        [JsonProperty("errors")]
        public Error[] Errors { get; set; }
    }

    public class PhoneNumberBlocksJobSuccessfulOperation
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public class PhoneNumberBlocksJobFailedOperation
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("errors")]
        public Error[] Errors { get; set; }
    }

    public class Error
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("source")]
        public ErrorSource Source { get; set; }

        [JsonProperty("meta")]
        public ErrorMeta Meta { get; set; }
    }

    public class ErrorSource
    {
        [JsonProperty("pointer")]
        public string Pointer { get; set; }

        [JsonProperty("parameter")]
        public string Parameter { get; set; }
    }

    public class ErrorMeta
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}