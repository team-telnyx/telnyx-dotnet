namespace TelnyxTests.Services.Wireless.SimCards
{
    using System;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Wireless.SimCards;
    using Telnyx.net.Services.Wireless.SimCards.SimCardDataUsageNotifications;
    using Xunit;

    public class SimCardDataUsageNotificationServiceTest : BaseTelnyxTest
    {
        private readonly string credConnId = "1234";
        private readonly SimCardDataUsageNotificationService service;
        private readonly SimCardDataUsageNotificationOption listOptions;
        private readonly UpsertSIMCardDataUsageNotification createOptions;

        public SimCardDataUsageNotificationServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
            this.service = new SimCardDataUsageNotificationService();

            this.listOptions = new SimCardDataUsageNotificationOption()
            {
                SimCardId = Guid.Parse("SimCardId001")
            };
            this.createOptions = new UpsertSIMCardDataUsageNotification()
            {
                SimCardId = Guid.Parse("SimCardId001"),
                Threshold = new DataUsageThreshold()
                {
                    Amount = 5000,
                    Unit = "150"
                }
        };
    }

    [Fact]
    public void List()
    {
        var list = this.service.ListSimCardDataUsageNotification(this.listOptions);
        //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
        Assert.NotNull(list);
        Assert.Equal(typeof(TelnyxList<SimCardDataUsageNotification>), list.GetType());
        Assert.Collection(list, message => AssertResponse(message));
    }

    [Fact]
    public async Task ListAsync()
    {
        var list = await this.service.ListSimCardDataUsageNotificationAsync(this.listOptions);
        //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
        Assert.NotNull(list);
        Assert.Equal(typeof(TelnyxList<SimCardDataUsageNotification>), list.GetType());
        Assert.Collection(list, message => AssertResponse(message));
    }

    [Fact]
    public void Create()
    {
        var message = this.service.CreateSimCardDataUsageNotification(this.createOptions);
        //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
        AssertResponse(message);
    }

    [Fact]
    public async Task CreateAsync()
    {
        var message = await this.service.CreateSimCardDataUsageNotificationAsync(this.createOptions);
        //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
        AssertResponse(message);
    }

    [Fact]
    public void Delete()
    {
        var message = this.service.DeleteSimCardDataUsageNotification(this.credConnId);
        //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
        AssertResponse(message);
    }

    [Fact]
    public async Task DeleteAsync()
    {
        var message = await this.service.DeleteSimCardDataUsageNotificationAsync(this.credConnId);
        //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
        AssertResponse(message);
    }

    [Fact]
    public void Update()
    {
        var message = this.service.UpdateSimCardDataUsageNotification(this.credConnId, this.createOptions);
        //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
        AssertResponse(message);
    }

    [Fact]
    public async Task UpdateAsync()
    {
        var message = await this.service.UpdateSimCardDataUsageNotificationAsync(this.credConnId, this.createOptions);
        //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
        AssertResponse(message);
    }

    [Fact]
    public void Get()
    {
        var message = this.service.GetSimCardDataUsageNotification(this.credConnId);
        //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
        AssertResponse(message);
    }

    [Fact]
    public async Task GetAsync()
    {
        var message = await this.service.GetSimCardDataUsageNotificationAsync(this.credConnId);
        //this.AssertRequest(HttpMethod.Post, $"/v2/calls/{CallControllId}/actions/answer");
        AssertResponse(message);
    }

    private static void AssertResponse(SimCardDataUsageNotification message)
    {
        Assert.NotNull(message);
        Assert.Equal(typeof(SimCardDataUsageNotification), message.GetType());
    }
}
}
