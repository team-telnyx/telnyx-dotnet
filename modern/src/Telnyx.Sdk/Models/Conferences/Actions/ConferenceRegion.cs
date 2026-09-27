using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Conferences.Actions;

/// <summary>
/// Region where the conference data is located. Defaults to the region defined in
/// user's data locality settings (Europe or US).
/// </summary>
[JsonConverter(typeof(ConferenceRegionConverter))]
public enum ConferenceRegion
{
    Australia, Europe, MiddleEast, Us
}

sealed class ConferenceRegionConverter : JsonConverter<ConferenceRegion>
{
    public override ConferenceRegion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Australia"=>ConferenceRegion.Australia,
            "Europe"=>ConferenceRegion.Europe,
            "Middle East"=>ConferenceRegion.MiddleEast,
            "US"=>ConferenceRegion.Us,
            _ =>(ConferenceRegion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceRegion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceRegion.Australia=>"Australia",
            ConferenceRegion.Europe=>"Europe",
            ConferenceRegion.MiddleEast=>"Middle East",
            ConferenceRegion.Us=>"US",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}