using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.BillingReports;

namespace Telnyx.net.Services.BillingReports
{
    public class LedgerBillingGroupReportService : Service<LedgerBillingGroupReport>
    {
        public override string BasePath => "/ledger_billing_group_reports"; 

        // Method to create a new Ledger Billing Group Report
        public async Task<LedgerBillingGroupReport> CreateBillingGroupReportAsync(CreateLedgerBillingGroupReport options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.CreateEntityAsync(options, requestOptions, parentToken: "data", cancellationToken);
        }

        public LedgerBillingGroupReport CreateBillingGroupReport(CreateLedgerBillingGroupReport options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions, parentToken: "data");
        }

        public async Task<LedgerBillingGroupReport> GetBillingGroupReportAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, null, requestOptions, parentToken: "data", cancellationToken);
        }

        public LedgerBillingGroupReport GetBillingGroupReport(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, null, requestOptions, parentToken: "data");
        }
    }
}
