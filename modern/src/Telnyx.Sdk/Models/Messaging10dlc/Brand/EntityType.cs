using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messaging10dlc.Brand;

/// <summary>
/// Entity type behind the brand. This is the form of business establishment.
/// </summary>
[JsonConverter(typeof(EntityTypeConverter))]
public enum EntityType
{
    PrivateProfit, PublicProfit, NonProfit, Government, SoleProprietor
}

sealed class EntityTypeConverter : JsonConverter<EntityType>
{
    public override EntityType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PRIVATE_PROFIT"=>EntityType.PrivateProfit,
            "PUBLIC_PROFIT"=>EntityType.PublicProfit,
            "NON_PROFIT"=>EntityType.NonProfit,
            "GOVERNMENT"=>EntityType.Government,
            "SOLE_PROPRIETOR"=>EntityType.SoleProprietor,
            _ =>(EntityType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, EntityType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EntityType.PrivateProfit=>"PRIVATE_PROFIT",
            EntityType.PublicProfit=>"PUBLIC_PROFIT",
            EntityType.NonProfit=>"NON_PROFIT",
            EntityType.Government=>"GOVERNMENT",
            EntityType.SoleProprietor=>"SOLE_PROPRIETOR",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}