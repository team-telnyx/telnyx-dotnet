using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.Messaging.MessageMMS;

namespace Telnyx.net.Services.Messaging
{
    public class GroupMMSMessageService : Service<GroupMMSMessage>
    {
        public override string BasePath => "/messages/group_mms"; // Adjust to the actual API endpoint as needed

        // Method to create a new Group MMS Message
        public async Task<GroupMMSMessage> CreateGroupMMSMessageAsync(CreateGroupMMSMessage createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.CreateEntityAsync(createOptions, requestOptions, parentToken: "data", cancellationToken: cancellationToken);
        }

        public GroupMMSMessage CreateGroupMMSMessage(CreateGroupMMSMessage createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(createOptions, requestOptions, parentToken: "data");
        }

    }
}
