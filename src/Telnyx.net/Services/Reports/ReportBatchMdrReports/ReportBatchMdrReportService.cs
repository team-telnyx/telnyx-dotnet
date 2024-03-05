using System;
using System.Collections.Generic;
using System.Linq;
using Telnyx.net.Entities;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Reports.ReportBatchMdrReports;

namespace Telnyx.net.Services.Reports.ReportBatchMdrReports
{
    public class ReportBatchMdrReportService : Service<ReportBatchMdrReport>
    {
        public override string BasePath => "/reports/batch_mdr_reports";

        public async Task<TelnyxList<ReportBatchMdrReport>> ListReportBatchMdrReportAsync(ReportBatchMdrReportOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.ListEntitiesAsync(options, reqOpts, string.Empty, cancellationToken);
        }

        public TelnyxList<ReportBatchMdrReport> ListReportBatchMdrReport(ReportBatchMdrReportOption options, RequestOptions reqOpts = null)
        {
            return this.ListEntities(options, reqOpts);
        }

        public async Task<ReportBatchMdrReport> GetReportBatchMdrReportAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public ReportBatchMdrReport GetReportBatchMdrReport(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }

        public ReportBatchMdrReport DeleteReportBatchMdrReport(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, null, requestOptions, parentToken: "data");
        }

        public async Task<ReportBatchMdrReport> DeleteReportBatchMdrReportAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.DeleteEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        public async Task<ReportBatchMdrReport> CreateReportBatchMdrReportAsync(UpsertReportBatchMdrReport options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.CreateEntityAsync(options, reqOpts, parentToken: "data", cancellationToken: ct);
        }

        public ReportBatchMdrReport CreateReportBatchMdrReport(UpsertReportBatchMdrReport options, RequestOptions reqOpts = null)
        {
            return this.CreateEntity(options, reqOpts, parentToken: "data");
        }
    }
}
