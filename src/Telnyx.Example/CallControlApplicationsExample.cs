using Newtonsoft.Json;
using System;
using Telnyx.net.Entities;
using Telnyx.net.Entities.Calls.CallControlApplications;
using Telnyx.net.Entities.Enum;
using Telnyx.net.Services.Calls.CallControlApplications;

namespace Telnyx.Example
{
    public class CallControlApplicationsExample
    {
        private readonly CallControlApplicationService callControlApplicationService = new CallControlApplicationService();

        public TelnyxList<CallControlApplication> List()
        {
            TelnyxList<CallControlApplication> callControlApplications = new TelnyxList<CallControlApplication>();
            ListCallControlApplicationOptions listCallControlApplicationOptions = new ListCallControlApplicationOptions
            {
                PageNumber = 1,
                PageSize = 20
            };
            Console.WriteLine(JsonConvert.SerializeObject(listCallControlApplicationOptions));

            try
            {
                callControlApplications = callControlApplicationService.List(listCallControlApplicationOptions);
                Console.WriteLine(JsonConvert.SerializeObject(callControlApplications));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return callControlApplications;
        }

        public CallControlApplication Create()
        {
            CallControlApplication callControlApplication = new CallControlApplication();
            CreateCallControlApplicationOptions listCallControlApplicationOptions = new CreateCallControlApplicationOptions
            {
                Active = false,
                AnchorsiteOverride = AnchorsiteOverride.AmsterdamNetherlands
            };
            Console.WriteLine(JsonConvert.SerializeObject(listCallControlApplicationOptions));

            try
            {
                callControlApplication = callControlApplicationService.Create(listCallControlApplicationOptions);
                Console.WriteLine(JsonConvert.SerializeObject(callControlApplication));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return callControlApplication;
        }

        public CallControlApplication Update()
        {
            string id = "1293384261075731499";
            CallControlApplication callControlApplication = new CallControlApplication();
            CreateCallControlApplicationOptions listCallControlApplicationOptions = new CreateCallControlApplicationOptions
            {
                Active = false,
                AnchorsiteOverride = AnchorsiteOverride.AmsterdamNetherlands
            };
            Console.WriteLine(JsonConvert.SerializeObject(listCallControlApplicationOptions));

            try
            {
                callControlApplication = callControlApplicationService.Update(id, listCallControlApplicationOptions);
                Console.WriteLine(JsonConvert.SerializeObject(callControlApplication));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return callControlApplication;
        }

        public CallControlApplication Delete()
        {
            string id = "1293384261075731499";
            CallControlApplication callControlApplication = new CallControlApplication();
            Console.WriteLine(id);

            try
            {
                callControlApplication = callControlApplicationService.Delete(id);
                Console.WriteLine(JsonConvert.SerializeObject(callControlApplication));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return callControlApplication;
        }

        public CallControlApplication Get()
        {
            string id = "1293384261075731499";
            CallControlApplication callControlApplication = new CallControlApplication();
            Console.WriteLine(id);

            try
            {
                callControlApplication = callControlApplicationService.Get(id);
                Console.WriteLine(JsonConvert.SerializeObject(callControlApplication));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return callControlApplication;
        }

    }
}
