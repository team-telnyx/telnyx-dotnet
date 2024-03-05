using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Wireless.WDRReports;

namespace Telnyx.net.Services.Wireless.WDRReports
{
    public class WDRReportService : Service<ReportWdr>
    {
        public override string BasePath => "/reports/wdrs";

        public async Task<TelnyxList<ReportWdr>> ListReportWdrAsync(ReportWdrOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<ReportWdr> ListReportWdr(ReportWdrOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }
    }
}
