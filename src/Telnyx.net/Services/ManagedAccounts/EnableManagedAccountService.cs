using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.ManagedAccounts;

namespace Telnyx.net.Services.ManagedAccounts
{
    public class EnableManagedAccountService : Service<ManagedAccount>
    {
        public EnableManagedAccountService()
           : base(null) { }

        public EnableManagedAccountService(string apiKey)
            : base(apiKey) { }
        public override string BasePath => "/managed_accounts";
        public override string PostPath => "actions/enable";

        public ManagedAccount CreateManagedAccount(string id, CreateManagedAccountOptions createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, createOptions, requestOptions, this.PostPath);
        }

        public Task<ManagedAccount> CreateManagedAccountAsync(string id, CreateManagedAccountOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.CreateEntityAsync(id, createOptions, requestOptions, cancellationToken, this.PostPath);
        }
    }
}