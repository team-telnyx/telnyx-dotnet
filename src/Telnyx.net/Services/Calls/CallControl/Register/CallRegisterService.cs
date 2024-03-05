using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.PhoneNumbers.CallRegisters;

namespace Telnyx.net.Services.PhoneNumbers.CallRegisters
{
    public class CallRegisterService : Service<CallRegister>
    {
        public override string BasePath => "/calls/register";

        public async Task<CallRegister> CreateCallRegisterAsync(UpsertCallRegister options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public CallRegister CreateCallRegister(UpsertCallRegister options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }
    }
}
