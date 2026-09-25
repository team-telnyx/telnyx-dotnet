using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Rcs.Agents;

[JsonConverter(typeof(AgentUseCaseConverter))]
public enum AgentUseCase
{
    MultiUse, Promotional, Transactional, Otp
}

sealed class AgentUseCaseConverter : JsonConverter<AgentUseCase>
{
    public override AgentUseCase Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MULTI_USE"=>AgentUseCase.MultiUse,
            "PROMOTIONAL"=>AgentUseCase.Promotional,
            "TRANSACTIONAL"=>AgentUseCase.Transactional,
            "OTP"=>AgentUseCase.Otp,
            _ =>(AgentUseCase)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, AgentUseCase value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AgentUseCase.MultiUse=>"MULTI_USE",
            AgentUseCase.Promotional=>"PROMOTIONAL",
            AgentUseCase.Transactional=>"TRANSACTIONAL",
            AgentUseCase.Otp=>"OTP",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}