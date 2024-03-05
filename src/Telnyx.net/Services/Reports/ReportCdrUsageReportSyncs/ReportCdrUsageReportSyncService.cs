using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Reports.ReportCdrUsageReportSyncs;

namespace Telnyx.net.Services.Reports.ReportCdrUsageReportSyncs
{
    public class ReportCdrUsageReportSyncService : Service<ReportCdrUsageReportSync>
    {
        public override string BasePath => "/reports/cdr_usage_reports/sync";

        public async Task<TelnyxList<ReportCdrUsageReportSync>> ListReportCdrUsageReportSyncAsync(ReportCdrUsageReportSyncOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<ReportCdrUsageReportSync> ListReportCdrUsageReportSync(ReportCdrUsageReportSyncOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

    }
}
