using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Telnyx.net.Entities.Faxes
{
    public class UpsertFaxActionCancel : BaseOptions
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
