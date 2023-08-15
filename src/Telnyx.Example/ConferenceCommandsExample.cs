using System;
using Telnyx.net.Entities;

namespace Telnyx.Example
{
    public class ConferenceCommandsExample
    {
        private readonly ConferenceCommandsService conferenceCommandsService = new ConferenceCommandsService();
        private readonly ListConferenceService listConferenceService = new ListConferenceService();
        public void SetCallControlId(string callControlId)
        {
            conferenceCommandsService.CallControlId = callControlId;
        }

        public CreateConferenceResponse Create()
        {
            try
            {

                CreateConferenceOptions options = new CreateConferenceOptions
                {
                    CallControlId = conferenceCommandsService.CallControlId
                };
                return conferenceCommandsService.Create(options);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public TelnyxList<ListConferenceResponse> List()
        {
            ListConferenceOptions options = new ListConferenceOptions
            {

            };
            var response = listConferenceService.List(options);
            return response;
        }

    }
}
