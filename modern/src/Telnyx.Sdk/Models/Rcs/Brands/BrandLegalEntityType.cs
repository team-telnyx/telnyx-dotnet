using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Rcs.Brands;

[JsonConverter(typeof(BrandLegalEntityTypeConverter))]
public enum BrandLegalEntityType
{
    LimitedLiabilityCompany,
    SoleProprietorship,
    Partnership,
    Corporation,
    SCorporation
}

sealed class BrandLegalEntityTypeConverter : JsonConverter<BrandLegalEntityType>
{
    public override BrandLegalEntityType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "LIMITED_LIABILITY_COMPANY"=>BrandLegalEntityType.LimitedLiabilityCompany,
            "SOLE_PROPRIETORSHIP"=>BrandLegalEntityType.SoleProprietorship,
            "PARTNERSHIP"=>BrandLegalEntityType.Partnership,
            "CORPORATION"=>BrandLegalEntityType.Corporation,
            "S_CORPORATION"=>BrandLegalEntityType.SCorporation,
            _ =>(BrandLegalEntityType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BrandLegalEntityType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BrandLegalEntityType.LimitedLiabilityCompany=>"LIMITED_LIABILITY_COMPANY",
            BrandLegalEntityType.SoleProprietorship=>"SOLE_PROPRIETORSHIP",
            BrandLegalEntityType.Partnership=>"PARTNERSHIP",
            BrandLegalEntityType.Corporation=>"CORPORATION",
            BrandLegalEntityType.SCorporation=>"S_CORPORATION",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}