using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.ManagedAccounts;

namespace Telnyx.net.Services.ManagedAccounts
{
    class DisableManagedAccountService : Service<ManagedAccount>
    {
        public DisableManagedAccountService()
           : base(null) { }

        public DisableManagedAccountService(string apiKey)
            : base(apiKey) { }
        public override string BasePath => "/managed_accounts";
        public override string PostPath => "actions/disable";

        public ManagedAccount DisableManagedAccount(string id,  RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, null, requestOptions, this.PostPath);
        }

        public Task<ManagedAccount> DisableManagedAccountAsync(string id,  RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.CreateEntityAsync(id, null, requestOptions, cancellationToken, this.PostPath);
        }
    }
}
