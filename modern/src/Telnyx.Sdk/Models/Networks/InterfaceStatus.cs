using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Networks;

/// <summary>
/// The current status of the interface deployment.
/// </summary>
[JsonConverter(typeof(InterfaceStatusConverter))]
public enum InterfaceStatus
{
    Created, Provisioning, Provisioned, Deleting
}

sealed class InterfaceStatusConverter : JsonConverter<InterfaceStatus>
{
    public override InterfaceStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created"=>InterfaceStatus.Created,
            "provisioning"=>InterfaceStatus.Provisioning,
            "provisioned"=>InterfaceStatus.Provisioned,
            "deleting"=>InterfaceStatus.Deleting,
            _ =>(InterfaceStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InterfaceStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InterfaceStatus.Created=>"created",
            InterfaceStatus.Provisioning=>"provisioning",
            InterfaceStatus.Provisioned=>"provisioned",
            InterfaceStatus.Deleting=>"deleting",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}