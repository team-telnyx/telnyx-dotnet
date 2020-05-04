namespace Telnyx.Example
{
    public class ConferenceCommandsExample
    {
        private readonly ConferenceCommandsService conferenceCommandsService = new ConferenceCommandsService();

        public void SetCallControlId(string callControlId)
        {
            conferenceCommandsService.CallControlId = callControlId;
        }

        public CreateConferenceResponse Create()
        {
            CreateConferenceOptions options = new CreateConferenceOptions
            { 
                CallControlId = conferenceCommandsService.CallControlId
            };
            return conferenceCommandsService.Create(options);
        }

    }
}
