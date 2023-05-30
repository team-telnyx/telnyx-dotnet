//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using Telnyx.net.Entities;
//using IC = Telnyx.net.Entities.InventoryCoverage.InventoryCoverage;

//namespace Telnyx.net.Services.InventoryCoverage
//{
//    public class InventoryCoverageService : Service<IC>
//    {
//        public override string BasePath => "/credential_connections";

//        public async Task<CallControlApplication> GetAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
//        {
//            return await this.GetEntityAsync(null, requestOptions, cancellationToken);
//        }
//    }
//}
