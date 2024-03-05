namespace Telnyx.net.Entities.Enum
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum AnchorsiteOverride
    {
        /// <summary>
        /// Enum Latency for Latency
        /// </summary>
        [EnumMember(Value = "\"Latency\"")]
        Latency = 0,

        /// <summary>
        /// Enum ChicagoIL for Chicago, IL
        /// </summary>
        [EnumMember(Value = "Chicago, IL")]
        ChicagoIL = 1,

        /// <summary>
        /// Enum AshburnVA for Ashburn, VA
        /// </summary>
        [EnumMember(Value = "Ashburn, VA")]
        AshburnVA = 2,

        /// <summary>
        /// Enum SanJoseCA for San Jose, CA
        /// </summary>
        [EnumMember(Value = "San Jose, CA")]
        SanJoseCA = 3,

        /// <summary>
        /// Enum SydneyAustralia for Sydney, Australia
        /// </summary>
        [EnumMember(Value = "Sydney, Australia")]
        SydneyAustralia = 4,

        /// <summary>
        /// Enum AmsterdamNetherlands for Amsterdam, Netherlands
        /// </summary>
        [EnumMember(Value = "Amsterdam, Netherlands")]
        AmsterdamNetherlands = 5,

        /// <summary>
        /// Enum LondonUK for London, UK
        /// </summary>
        [EnumMember(Value = "London, UK")]
        LondonUK = 6,

        /// <summary>
        /// Enum TorontoCanada for Toronto, Canada
        /// </summary>
        [EnumMember(Value = "Toronto, Canada")]
        TorontoCanada = 7,

        /// <summary>
        /// Enum VancouverCanada for Vancouver, Canada
        /// </summary>
        [EnumMember(Value = "Vancouver, Canada")]
        VancouverCanada = 8,

        /// <summary>
        /// Enum FrankfurtGermany for Frankfurt, Germany
        /// </summary>
        [EnumMember(Value = "Frankfurt, Germany")]
        FrankfurtGermany = 9,
    }
}
