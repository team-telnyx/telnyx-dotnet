using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Telnyx.net.Entities.Calls.CallControlApplications
{
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum AnchorsiteOverride
    {
        /// <summary>
        /// Enum LatencyEnum for Latency
        /// </summary>
        [EnumMember(Value = "Latency")]
        LatencyEnum = 0,

        /// <summary>
        /// Enum ChicagoILEnum for Chicago, IL
        /// </summary>
        [EnumMember(Value = "Chicago, IL")]
        ChicagoILEnum = 1,

        /// <summary>
        /// Enum AshburnVAEnum for Ashburn, VA
        /// </summary>
        [EnumMember(Value = "Ashburn, VA")]
        AshburnVAEnum = 2,

        /// <summary>
        /// Enum SanJoseCAEnum for San Jose, CA
        /// </summary>
        [EnumMember(Value = "San Jose, CA")]
        SanJoseCAEnum = 3,

        /// <summary>
        /// Enum SydneyAustraliaEnum for Sydney, Australia
        /// </summary>
        [EnumMember(Value = "Sydney, Australia")]
        SydneyAustraliaEnum = 4,

        /// <summary>
        /// Enum AmsterdamNetherlandsEnum for Amsterdam, Netherlands
        /// </summary>
        [EnumMember(Value = "Amsterdam, Netherlands")]
        AmsterdamNetherlandsEnum = 5,

        /// <summary>
        /// Enum LondonUKEnum for London, UK
        /// </summary>
        [EnumMember(Value = "London, UK")]
        LondonUKEnum = 6,

        /// <summary>
        /// Enum TorontoCanadaEnum for Toronto, Canada
        /// </summary>
        [EnumMember(Value = "Toronto, Canada")]
        TorontoCanadaEnum = 7,

        /// <summary>
        /// Enum VancouverCanadaEnum for Vancouver, Canada
        /// </summary>
        [EnumMember(Value = "Vancouver, Canada")]
        VancouverCanadaEnum = 8,

        /// <summary>
        /// Enum FrankfurtGermanyEnum for Frankfurt, Germany
        /// </summary>
        [EnumMember(Value = "Frankfurt, Germany")]
        FrankfurtGermanyEnum = 9,
    }
}
