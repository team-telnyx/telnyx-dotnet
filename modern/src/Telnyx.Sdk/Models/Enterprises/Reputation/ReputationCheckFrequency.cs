using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Enterprises.Reputation;

/// <summary>
/// How often Telnyx refreshes the stored reputation data for this enterprise's registered numbers.
/// </summary>
[JsonConverter(typeof(ReputationCheckFrequencyConverter))]
public enum ReputationCheckFrequency
{
    BusinessDaily, Daily, Weekly, Biweekly, Monthly, Never
}

sealed class ReputationCheckFrequencyConverter : JsonConverter<ReputationCheckFrequency>
{
    public override ReputationCheckFrequency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "business_daily"=>ReputationCheckFrequency.BusinessDaily,
            "daily"=>ReputationCheckFrequency.Daily,
            "weekly"=>ReputationCheckFrequency.Weekly,
            "biweekly"=>ReputationCheckFrequency.Biweekly,
            "monthly"=>ReputationCheckFrequency.Monthly,
            "never"=>ReputationCheckFrequency.Never,
            _ =>(ReputationCheckFrequency)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReputationCheckFrequency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ReputationCheckFrequency.BusinessDaily=>"business_daily",
            ReputationCheckFrequency.Daily=>"daily",
            ReputationCheckFrequency.Weekly=>"weekly",
            ReputationCheckFrequency.Biweekly=>"biweekly",
            ReputationCheckFrequency.Monthly=>"monthly",
            ReputationCheckFrequency.Never=>"never",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}