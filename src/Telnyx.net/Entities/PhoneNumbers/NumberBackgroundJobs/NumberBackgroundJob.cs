namespace Telnyx.net.Entities.PhoneNumbers.NumberBackgroundJobs
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Telnyx.net.Entities.Enum.PhoneNumbers.NumberBackgroundJobs;

    public class NumberBackgroundJob : TelnyxEntity
    {
        /// <summary>
        /// The date and time when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// The estimated time of completion of the background job.
        /// </summary>
        [JsonProperty("etc")]
        public DateTimeOffset ETC { get; set; }

        /// <summary>
        /// An array of failed operation objects.
        /// </summary>
        [JsonProperty("failed_operations")]
        public List<PhoneNumbersJobFailedOperation> FailedOperations { get; set; }

        /// <summary>
        /// Identifies the resource.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// An array of pending operation objects.
        /// </summary>
        [JsonProperty("pending_operations")]
        public List<PhoneNumbersJobPendingOperation> PendingOperations { get; set; }

        /// <summary>
        /// The type of the resource.
        /// </summary>
        [JsonProperty("record_type")]
        public string RecordType { get; set; }

        /// <summary>
        /// The completion status of the background update.
        /// </summary>
        [JsonProperty("status")]
        public BackgroundJobStatus Status { get; set; }

        /// <summary>
        /// An array of successful operation objects.
        /// </summary>
        [JsonProperty("successful_operations")]
        public List<PhoneNumbersJobSuccessfulOperation> SuccessfulOperations { get; set; }

        /// <summary>
        /// The type of the background job.
        /// </summary>
        [JsonProperty("type")]
        public BackgroundJobType Type { get; set; }

        /// <summary>
        /// The date and time when the resource was updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
