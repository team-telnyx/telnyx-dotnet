using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Embeddings;

/// <summary>
/// Status of an embeddings task.
/// </summary>
[JsonConverter(typeof(BackgroundTaskStatusConverter))]
public enum BackgroundTaskStatus
{
    Queued, Processing, Success, Failure, PartialSuccess
}

sealed class BackgroundTaskStatusConverter : JsonConverter<BackgroundTaskStatus>
{
    public override BackgroundTaskStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued"=>BackgroundTaskStatus.Queued,
            "processing"=>BackgroundTaskStatus.Processing,
            "success"=>BackgroundTaskStatus.Success,
            "failure"=>BackgroundTaskStatus.Failure,
            "partial_success"=>BackgroundTaskStatus.PartialSuccess,
            _ =>(BackgroundTaskStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BackgroundTaskStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BackgroundTaskStatus.Queued=>"queued",
            BackgroundTaskStatus.Processing=>"processing",
            BackgroundTaskStatus.Success=>"success",
            BackgroundTaskStatus.Failure=>"failure",
            BackgroundTaskStatus.PartialSuccess=>"partial_success",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}