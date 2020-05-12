using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Telnyx.net.Services.Calls.Models
{
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum AnsweringMachineEnum
    {
        [EnumMember(Value = "disabled")]
        Disabled = 0,

        [EnumMember(Value = "detect")]
        Detect = 1,

        [EnumMember(Value = "detect_beep")]
        DetectBeep = 2,

        [EnumMember(Value = "detect_words")]
        DetectWords = 3,

        [EnumMember(Value = "greeting_end")]
        GreetingEnd = 4,
    }
}
