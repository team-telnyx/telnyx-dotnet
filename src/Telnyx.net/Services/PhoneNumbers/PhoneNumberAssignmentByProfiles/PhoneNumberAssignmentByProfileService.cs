using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.PhoneNumbers.PhoneNumberAssignmentByProfiles;

namespace Telnyx.net.Services.PhoneNumbers.PhoneNumberAssignmentByProfiles
{
   public class PhoneNumberAssignmentByProfileService : Service<PhoneNumberAssignmentByProfile>
    {
        public override string BasePath => "/phoneNumberAssignmentByProfile/:taskId";

        public async Task<PhoneNumberAssignmentByProfile> GetPhoneNumberAssignmentByProfileAsync(string id, BaseOptions options = null, RequestOptions reqOpts = null, CancellationToken cancellationToken = default)
        {
            return await this.GetEntityAsync(id, options, reqOpts, parentToken: "data", cancellationToken);
        }

        public PhoneNumberAssignmentByProfile GetPhoneNumberAssignmentByProfile(string id, BaseOptions options = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, options, reqOpts, parentToken: "data");
        }
    }
}
