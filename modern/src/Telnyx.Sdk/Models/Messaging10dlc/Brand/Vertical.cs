using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messaging10dlc.Brand;

/// <summary>
/// Vertical or industry segment of the brand or campaign.
/// </summary>
[JsonConverter(typeof(VerticalConverter))]
public enum Vertical
{
    Agriculture,
    Communication,
    Construction,
    Education,
    Energy,
    Entertainment,
    Financial,
    Gambling,
    Government,
    Healthcare,
    Hospitality,
    HumanResources,
    Insurance,
    Legal,
    Manufacturing,
    Ngo,
    Political,
    Postal,
    Professional,
    RealEstate,
    Retail,
    Technology,
    Transportation
}

sealed class VerticalConverter : JsonConverter<Vertical>
{
    public override Vertical Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AGRICULTURE"=>Vertical.Agriculture,
            "COMMUNICATION"=>Vertical.Communication,
            "CONSTRUCTION"=>Vertical.Construction,
            "EDUCATION"=>Vertical.Education,
            "ENERGY"=>Vertical.Energy,
            "ENTERTAINMENT"=>Vertical.Entertainment,
            "FINANCIAL"=>Vertical.Financial,
            "GAMBLING"=>Vertical.Gambling,
            "GOVERNMENT"=>Vertical.Government,
            "HEALTHCARE"=>Vertical.Healthcare,
            "HOSPITALITY"=>Vertical.Hospitality,
            "HUMAN_RESOURCES"=>Vertical.HumanResources,
            "INSURANCE"=>Vertical.Insurance,
            "LEGAL"=>Vertical.Legal,
            "MANUFACTURING"=>Vertical.Manufacturing,
            "NGO"=>Vertical.Ngo,
            "POLITICAL"=>Vertical.Political,
            "POSTAL"=>Vertical.Postal,
            "PROFESSIONAL"=>Vertical.Professional,
            "REAL_ESTATE"=>Vertical.RealEstate,
            "RETAIL"=>Vertical.Retail,
            "TECHNOLOGY"=>Vertical.Technology,
            "TRANSPORTATION"=>Vertical.Transportation,
            _ =>(Vertical)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Vertical value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Vertical.Agriculture=>"AGRICULTURE",
            Vertical.Communication=>"COMMUNICATION",
            Vertical.Construction=>"CONSTRUCTION",
            Vertical.Education=>"EDUCATION",
            Vertical.Energy=>"ENERGY",
            Vertical.Entertainment=>"ENTERTAINMENT",
            Vertical.Financial=>"FINANCIAL",
            Vertical.Gambling=>"GAMBLING",
            Vertical.Government=>"GOVERNMENT",
            Vertical.Healthcare=>"HEALTHCARE",
            Vertical.Hospitality=>"HOSPITALITY",
            Vertical.HumanResources=>"HUMAN_RESOURCES",
            Vertical.Insurance=>"INSURANCE",
            Vertical.Legal=>"LEGAL",
            Vertical.Manufacturing=>"MANUFACTURING",
            Vertical.Ngo=>"NGO",
            Vertical.Political=>"POLITICAL",
            Vertical.Postal=>"POSTAL",
            Vertical.Professional=>"PROFESSIONAL",
            Vertical.RealEstate=>"REAL_ESTATE",
            Vertical.Retail=>"RETAIL",
            Vertical.Technology=>"TECHNOLOGY",
            Vertical.Transportation=>"TRANSPORTATION",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}