using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailValidations.Batch;

[JsonConverter(typeof(EmailValidationBatchStatusConverter))]
public enum EmailValidationBatchStatus
{
    Pending, Processing, Completed, Failed
}

sealed class EmailValidationBatchStatusConverter : JsonConverter<EmailValidationBatchStatus>
{
    public override EmailValidationBatchStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>EmailValidationBatchStatus.Pending,
            "processing"=>EmailValidationBatchStatus.Processing,
            "completed"=>EmailValidationBatchStatus.Completed,
            "failed"=>EmailValidationBatchStatus.Failed,
            _ =>(EmailValidationBatchStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailValidationBatchStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmailValidationBatchStatus.Pending=>"pending",
            EmailValidationBatchStatus.Processing=>"processing",
            EmailValidationBatchStatus.Completed=>"completed",
            EmailValidationBatchStatus.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}