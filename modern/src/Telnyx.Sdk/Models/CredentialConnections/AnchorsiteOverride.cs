using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.CredentialConnections;

/// <summary>
/// `Latency` directs Telnyx to route media through the site with the lowest round-trip
/// time to the user's connection. Telnyx calculates this time using ICMP ping messages.
/// This can be disabled by specifying a site to handle all media.
/// </summary>
[JsonConverter(typeof(AnchorsiteOverrideConverter))]
public enum AnchorsiteOverride
{
    Latency,
    ChicagoIl,
    AshburnVa,
    SanJoseCa,
    SydneyAustralia,
    AmsterdamNetherlands,
    LondonUk,
    TorontoCanada,
    VancouverCanada,
    FrankfurtGermany
}

sealed class AnchorsiteOverrideConverter : JsonConverter<AnchorsiteOverride>
{
    public override AnchorsiteOverride Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Latency"=>AnchorsiteOverride.Latency,
            "Chicago, IL"=>AnchorsiteOverride.ChicagoIl,
            "Ashburn, VA"=>AnchorsiteOverride.AshburnVa,
            "San Jose, CA"=>AnchorsiteOverride.SanJoseCa,
            "Sydney, Australia"=>AnchorsiteOverride.SydneyAustralia,
            "Amsterdam, Netherlands"=>AnchorsiteOverride.AmsterdamNetherlands,
            "London, UK"=>AnchorsiteOverride.LondonUk,
            "Toronto, Canada"=>AnchorsiteOverride.TorontoCanada,
            "Vancouver, Canada"=>AnchorsiteOverride.VancouverCanada,
            "Frankfurt, Germany"=>AnchorsiteOverride.FrankfurtGermany,
            _ =>(AnchorsiteOverride)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AnchorsiteOverride value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AnchorsiteOverride.Latency=>"Latency",
            AnchorsiteOverride.ChicagoIl=>"Chicago, IL",
            AnchorsiteOverride.AshburnVa=>"Ashburn, VA",
            AnchorsiteOverride.SanJoseCa=>"San Jose, CA",
            AnchorsiteOverride.SydneyAustralia=>"Sydney, Australia",
            AnchorsiteOverride.AmsterdamNetherlands=>"Amsterdam, Netherlands",
            AnchorsiteOverride.LondonUk=>"London, UK",
            AnchorsiteOverride.TorontoCanada=>"Toronto, Canada",
            AnchorsiteOverride.VancouverCanada=>"Vancouver, Canada",
            AnchorsiteOverride.FrankfurtGermany=>"Frankfurt, Germany",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}