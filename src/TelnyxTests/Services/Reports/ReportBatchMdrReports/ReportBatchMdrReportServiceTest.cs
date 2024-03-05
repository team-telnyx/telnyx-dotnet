namespace TelnyxTests.Services.Reports.ReportBatchMdrReports
{
    using System;
    using System.Threading;
	using System.Threading.Tasks;
	using Telnyx;
	using Telnyx.net.Entities;
    using Telnyx.net.Entities.Reports.ReportBatchMdrReports;
    using Telnyx.net.Services.Reports.ReportBatchMdrReports;
	using Xunit;

	/// <summary>
	/// Test class for DetailRecord.
	/// </summary>
	public class ReportBatchMdrReportServiceTest : BaseTelnyxTest
	{
		private readonly ReportBatchMdrReportService service;
		private readonly ReportBatchMdrReportOption listOptions;
		private readonly UpsertReportBatchMdrReport createOptions;
		private readonly RequestOptions requestOptions;
		private readonly BaseOptions baseOptions;
        private object options;
        private const string Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

		public ReportBatchMdrReportServiceTest(MockHttpClientFixture mockHttpClientFixture)
			: base(mockHttpClientFixture)
		{
			this.service = new ReportBatchMdrReportService();

			this.listOptions = new ReportBatchMdrReportOption()
			{
			};
            this.createOptions = new UpsertReportBatchMdrReport()
            {
                StartDate = DateTime.Parse("2020-07-01T00:00:00-06:00"),
                EndDate = DateTime.Parse("2020-07-01T00:00:00-06:00"),
                Directions = new string[] { "INBOUND" },
                RecordTypes = new string[] { "INCOMPLETE" },
                Connections = new long[] { 0 },
                ReportName = "string",
                IncludeMessageBody = true,
                Filters = null,
                Profiles = "My profile"
            };


            this.baseOptions = new BaseOptions();

			this.requestOptions = new RequestOptions();
		}

		[Fact]
		public void List()
		{
			var result = this.service.ListReportBatchMdrReport(this.listOptions, this.requestOptions);
			Assert.NotNull(result);
			Assert.Equal(typeof(TelnyxList<ReportBatchMdrReport>), result.GetType());
		}

		[Fact]
		public async Task ListAsync()
		{
			var cts = new CancellationTokenSource();
			var result = await this.service.ListReportBatchMdrReportAsync(this.listOptions, this.requestOptions);
			Assert.NotNull(result);
			Assert.Equal(typeof(TelnyxList<ReportBatchMdrReport>), result.GetType());
		}

		[Fact]
		public void Retrieve()
		{
			var message = this.service.GetReportBatchMdrReport(Id);
			//this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
			Assert.NotNull(message);
			Assert.Equal(typeof(ReportBatchMdrReport), message.GetType());
		}

		[Fact]
		public async Task RetrieveAsync()
		{
			var message = await this.service.GetReportBatchMdrReportAsync(Id);
			//this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
			Assert.NotNull(message);
			Assert.Equal(typeof(ReportBatchMdrReport), message.GetType());
		}

		[Fact]
		public void Create()
		{
			var result = this.service.CreateReportBatchMdrReport(this.createOptions);
			Assert.NotNull(result);
			Assert.Equal(typeof(ReportBatchMdrReport), result.GetType());
		}

		[Fact]
		public async Task CreateAsync()
		{
			var result = await this.service.CreateReportBatchMdrReportAsync(this.createOptions);
			Assert.NotNull(result);
			Assert.Equal(typeof(ReportBatchMdrReport), result.GetType());
		}

		[Fact]
		public void Delete()
		{
			var message = this.service.DeleteReportBatchMdrReport(Id);
			Assert.NotNull(message);
			Assert.Equal(typeof(ReportBatchMdrReport), message.GetType());
		}

		[Fact]
		public async Task DeleteAsync()
		{
			var message = await this.service.DeleteReportBatchMdrReportAsync(Id);
			Assert.NotNull(message);
			Assert.Equal(typeof(ReportBatchMdrReport), message.GetType());
		}
	}
}