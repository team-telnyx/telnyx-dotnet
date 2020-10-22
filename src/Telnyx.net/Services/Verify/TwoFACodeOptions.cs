using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Entities.Enum;

namespace Telnyx.net.Services.Verify
{
    public class TwoFACodeOptions : BaseOptions
    {
        public string Code { get; set; }
    }
}
