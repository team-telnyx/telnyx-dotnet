using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Rcs.Agents;

[JsonConverter(typeof(AgentSubmissionStatusConverter))]
public enum AgentSubmissionStatus
{
    Submitted, Approved, Rejected
}

sealed class AgentSubmissionStatusConverter : JsonConverter<AgentSubmissionStatus>
{
    public override AgentSubmissionStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SUBMITTED"=>AgentSubmissionStatus.Submitted,
            "APPROVED"=>AgentSubmissionStatus.Approved,
            "REJECTED"=>AgentSubmissionStatus.Rejected,
            _ =>(AgentSubmissionStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentSubmissionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AgentSubmissionStatus.Submitted=>"SUBMITTED",
            AgentSubmissionStatus.Approved=>"APPROVED",
            AgentSubmissionStatus.Rejected=>"REJECTED",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}