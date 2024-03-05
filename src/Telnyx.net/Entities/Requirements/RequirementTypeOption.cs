using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Requirements
{
    public class RequirementTypeOption : ListOptions
    {
        [JsonProperty("sort")]
        public string[] Sort { get; set; }

        [JsonProperty("name")]
        public FilterCriteria<string> Name { get; set; }
    }

    public class FilterCriteria<T>
    {
        [JsonProperty("contains")]
        public T Contains { get; set; }
    }
}
