using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telnyx.Infrastructure;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Reports.ReportCdrUsageReportSyncs;

namespace Telnyx.net.Services.Reports.ReportCdrUsageReportSyncs
{
    public class ReportCdrUsageReportSyncService : Service<ReportCdrUsageReportSync>
    {
        public override string BasePath => "/reports/cdr_usage_reports/sync";

        public async Task<TelnyxList<ReportCdrUsageReportSync>> ListReportCdrUsageReportSyncAsync(ReportCdrUsageReportSyncOption options, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            var response = await Requestor.GetStringAsync(
                this.ApplyAllParameters(options, this.ClassUrl(), true),
                this.SetupRequestOptions(reqOpts), cancellationToken).ConfigureAwait(false);
            var page = MapReport(response, out var arrayShape);
            var reports = page.Data;
            var count = 1;
            // Preserve explicit legacy array paging without inventing pages for the
            // current singleton-object contract. Each item retains its own page response.
            while (arrayShape && page.HasMore && options != null && count < options.NumberOfPagesToFetch)
            {
                options.PageNumber = page.PageInfo.NextPage;
                response = await Requestor.GetStringAsync(
                    this.ApplyAllParameters(options, this.ClassUrl(), true),
                    this.SetupRequestOptions(reqOpts), cancellationToken).ConfigureAwait(false);
                page = MapReport(response, out arrayShape);
                if (page.Data != null) reports.AddRange(page.Data);
                count++;
            }

            page.Data = reports;
            return page;
        }

        public TelnyxList<ReportCdrUsageReportSync> ListReportCdrUsageReportSync(ReportCdrUsageReportSyncOption options, RequestOptions reqOpts = null)
        {
            return this.ListReportCdrUsageReportSyncAsync(options, reqOpts).GetAwaiter().GetResult();
        }

        private static TelnyxList<ReportCdrUsageReportSync> MapReport(TelnyxResponse response, out bool arrayShape)
        {
            // Ref: pinned openapi/spec3.json, CdrGetSyncUsageReportResponse.data is
            // one CdrUsageReportResponse, not a page. Arrays remain legacy compatibility.
            // Keep original bytes authoritative for arbitrary numeric lexemes in Result.
            using (var reader = new JsonTextReader(new StringReader(response.ResponseJson)) { DateParseHandling = DateParseHandling.None })
            {
                var envelope = JObject.Load(reader);
                var data = envelope["data"];
                arrayShape = data is JArray;
                envelope.Remove("data");
                var serializer = JsonSerializer.CreateDefault(new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
                var list = envelope.ToObject<TelnyxList<ReportCdrUsageReportSync>>(serializer);
                response.ObjectJson = response.ResponseJson;
                list.TelnyxResponse = response;
                if (data == null || data.Type == JTokenType.Null)
                {
                    return list;
                }

                var items = data is JObject ? new JArray(data) : data as JArray;
                if (items == null)
                {
                    throw new JsonSerializationException("CDR report data must be an object or a legacy array.");
                }

                list.Data = new List<ReportCdrUsageReportSync>();
                foreach (var token in items)
                {
                    var item = token.ToObject<ReportCdrUsageReportSync>(serializer);
                    if (item != null)
                    {
                        // Mapper mutates ObjectJson on a shared response. Give each item
                        // its own metadata instead, retaining the complete raw envelope.
                        item.TelnyxResponse = new TelnyxResponse
                        {
                            ResponseJson = response.ResponseJson,
                            ObjectJson = token.ToString(Formatting.None),
                            RequestId = response.RequestId,
                            RequestDate = response.RequestDate,
                            Url = response.Url,
                        };
                    }

                    list.Data.Add(item);
                }

                return list;
            }
        }
    }
}
