using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// Whether to auto-publish the assistant's instructions as a Langfuse prompt.
///
/// <para>When ENABLED + prompt_name set, every assistant create/update pushes `instructions`
/// to Langfuse via create_prompt and stores the returned version in prompt_version.</para>
/// </summary>
[JsonConverter(typeof(PromptSyncStatusConverter))]
public enum PromptSyncStatus
{
    Enabled, Disabled
}

sealed class PromptSyncStatusConverter : JsonConverter<PromptSyncStatus>
{
    public override PromptSyncStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "enabled"=>PromptSyncStatus.Enabled,
            "disabled"=>PromptSyncStatus.Disabled,
            _ =>(PromptSyncStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PromptSyncStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PromptSyncStatus.Enabled=>"enabled",
            PromptSyncStatus.Disabled=>"disabled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}