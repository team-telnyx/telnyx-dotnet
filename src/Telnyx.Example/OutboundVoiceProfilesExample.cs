using Newtonsoft.Json;
using System;
using Telnyx.net.Entities;
using Telnyx.net.Entities.OutboundVoiceProfiles;
using Telnyx.net.Services.OutboundVoiceProfiles;

namespace Telnyx.Example
{
    public class OutboundVoiceProfilesExample
    {
        private readonly OutboundVoiceProfileService outboundVoiceProfileService = new OutboundVoiceProfileService();

        public TelnyxList<OutboundVoiceProfile> List()
        {
            TelnyxList<OutboundVoiceProfile> outboundVoiceProfiles = new TelnyxList<OutboundVoiceProfile>();
            ListOutboundVoiceProfileOptions listOutboundVoiceProfileOptions = new ListOutboundVoiceProfileOptions
            {
                PageNumber = 1,
                PageSize = 20
            };
            Console.WriteLine(JsonConvert.SerializeObject(listOutboundVoiceProfileOptions));

            try
            {
                outboundVoiceProfiles = outboundVoiceProfileService.List(listOutboundVoiceProfileOptions);
                Console.WriteLine(JsonConvert.SerializeObject(outboundVoiceProfiles));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return outboundVoiceProfiles;
        }

        public OutboundVoiceProfile Create()
        {
            OutboundVoiceProfile outboundVoiceProfile = new OutboundVoiceProfile();
            CreateOutboundVoiceProfileOptions createOutboundVoiceProfileOptions = new CreateOutboundVoiceProfileOptions
            {
                BillingGroupId = new Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                ConcurrentCallLimit = 10
            };
            Console.WriteLine(JsonConvert.SerializeObject(createOutboundVoiceProfileOptions));

            try
            {
                outboundVoiceProfile = outboundVoiceProfileService.Create(createOutboundVoiceProfileOptions);
                Console.WriteLine(JsonConvert.SerializeObject(outboundVoiceProfile));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return outboundVoiceProfile;
        }

        public OutboundVoiceProfile Update()
        {
            string id = "1293384261075731499";
            OutboundVoiceProfile outboundVoiceProfile = new OutboundVoiceProfile();
            CreateOutboundVoiceProfileOptions createOutboundVoiceProfileOptions = new CreateOutboundVoiceProfileOptions
            {
                BillingGroupId = new Guid("6a09cdc3-8948-47f0-aa62-74ac943d6c58"),
                ConcurrentCallLimit = 10
            };
            Console.WriteLine(JsonConvert.SerializeObject(createOutboundVoiceProfileOptions));

            try
            {
                outboundVoiceProfile = outboundVoiceProfileService.Update(id, createOutboundVoiceProfileOptions);
                Console.WriteLine(JsonConvert.SerializeObject(outboundVoiceProfile));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return outboundVoiceProfile;
        }

        public OutboundVoiceProfile Delete()
        {
            string id = "1293384261075731499";
            OutboundVoiceProfile outboundVoiceProfile = new OutboundVoiceProfile();
            Console.WriteLine(id);

            try
            {
                outboundVoiceProfile = outboundVoiceProfileService.Delete(id);
                Console.WriteLine(JsonConvert.SerializeObject(outboundVoiceProfile));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return outboundVoiceProfile;
        }

        public OutboundVoiceProfile Get()
        {
            string id = "1293384261075731499";
            OutboundVoiceProfile outboundVoiceProfile = new OutboundVoiceProfile();
            Console.WriteLine(id);

            try
            {
                outboundVoiceProfile = outboundVoiceProfileService.Get(id);
                Console.WriteLine(JsonConvert.SerializeObject(outboundVoiceProfile));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return outboundVoiceProfile;
        }

    }
}
