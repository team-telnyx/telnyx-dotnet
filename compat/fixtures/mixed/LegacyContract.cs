using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telnyx;

// Unchanged source must compile with 3.1.0 and every candidate asset group.
public class CustomerMessageService : MessageService
{
    public CustomerMessageService() : base("dummy-service") { }
    public override string BasePath { get { return "/messages"; } }
}
public static class LegacyContract
{
    public static NewMessage Options()
    {
        return new NewMessage { From = "+15555550100", To = "+15555550101", Text = "compatibility",
            MessagingProfileId = Guid.Empty, MediaUrls = new List<string>(), UseProfileWebhooks = false,
            ValidityPeriodSecs = 60m, IgnoreWireType = false };
    }
    public static async Task<OutboundMessage> Send(CancellationToken cancellationToken)
    {
        var service = new CustomerMessageService();
        var request = new RequestOptions { ApiKey = "dummy-request", IdempotencyKey = "fixed-test-key" };
        var oldModel = new OutboundMessage { Type = OutboundMessage.TypeEnum.SmsEnum };
        OutboundMessage.TypeEnum? oldType = oldModel.Type;
        ICreatable<OutboundMessage, NewMessage> create = service;
        IRetrievable<OutboundMessage> get = service;
        return await service.CreateAsync(Options(), requestOptions: request, cancellationToken: cancellationToken);
    }
}

