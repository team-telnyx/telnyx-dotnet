using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Rcs.Brands;

[JsonConverter(typeof(BrandOrganizationTypeConverter))]
public enum BrandOrganizationType
{
    PrivateProfit, PublicProfit, NonProfit, Government, Unknown
}

sealed class BrandOrganizationTypeConverter : JsonConverter<BrandOrganizationType>
{
    public override BrandOrganizationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PRIVATE_PROFIT"=>BrandOrganizationType.PrivateProfit,
            "PUBLIC_PROFIT"=>BrandOrganizationType.PublicProfit,
            "NON_PROFIT"=>BrandOrganizationType.NonProfit,
            "GOVERNMENT"=>BrandOrganizationType.Government,
            "UNKNOWN"=>BrandOrganizationType.Unknown,
            _ =>(BrandOrganizationType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BrandOrganizationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BrandOrganizationType.PrivateProfit=>"PRIVATE_PROFIT",
            BrandOrganizationType.PublicProfit=>"PUBLIC_PROFIT",
            BrandOrganizationType.NonProfit=>"NON_PROFIT",
            BrandOrganizationType.Government=>"GOVERNMENT",
            BrandOrganizationType.Unknown=>"UNKNOWN",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}