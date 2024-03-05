using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Reports.ReportMdrUsageReports;

namespace Telnyx.net.Services.Reports.ReportMdrUsageReports
{
    public class ReportMdrUsageReportService : Service<ReportMdrUsageReport>
    {
        public override string BasePath => "/reports/mdr_usage_reports";

        public async Task<TelnyxList<ReportMdrUsageReport>> ListReportMdrUsageReportAsync(ReportMdrUsageReportOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<ReportMdrUsageReport> ListReportMdrUsageReport(ReportMdrUsageReportOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<ReportMdrUsageReport> GetReportMdrUsageReportAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public ReportMdrUsageReport GetReportMdrUsageReport(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }

        public ReportMdrUsageReport DeleteReportMdrUsageReport(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        public async Task<ReportMdrUsageReport> DeleteReportMdrUsageReportAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        public async Task<ReportMdrUsageReport> CreateReportMdrUsageReportAsync(UpsertReportMdrUsageReport options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public ReportMdrUsageReport CreateReportMdrUsageReport(UpsertReportMdrUsageReport options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }

    }
}
