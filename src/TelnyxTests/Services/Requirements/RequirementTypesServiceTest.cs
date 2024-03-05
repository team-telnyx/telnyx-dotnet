using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Requirements;
using Telnyx.net.Services.Requirements;
using Xunit;

namespace TelnyxTests.Services.Requirements
{
    public class RequirementTypesServiceTest : BaseTelnyxTest
    {
        private readonly RequirementTypesService service;
        private readonly RequirementTypeOption listOptions;
        private readonly RequestOptions requestOptions;
        private readonly BaseOptions baseOptions;
        private object options;
        private const string Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        public RequirementTypesServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new RequirementTypesService();

            this.listOptions = new RequirementTypeOption()
            {
            };


            this.baseOptions = new BaseOptions();

            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void List()
        {
            var result = this.service.ListRequirementType(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<RequirementType>), result.GetType());
        }

        [Fact]
        public async Task ListAsync()
        {
            var cts = new CancellationTokenSource();
            var result = await this.service.ListRequirementTypeAsync(this.listOptions, this.requestOptions);
            Assert.NotNull(result);
            Assert.Equal(typeof(TelnyxList<RequirementType>), result.GetType());
        }

        [Fact]
        public void Retrieve()
        {
            var message = this.service.GetRequirementType(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(RequirementType), message.GetType());
        }

        [Fact]
        public async Task RetrieveAsync()
        {
            var message = await this.service.GetRequirementTypeAsync(Id);
            //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
            Assert.NotNull(message);
            Assert.Equal(typeof(RequirementType), message.GetType());
        }

    }
}
