namespace Telnyx
{
    using System.Threading.Tasks;

    /// <summary>
    /// CreateConferenceService.
    /// </summary>
    public class ConferenceCommandsService
    {
        private readonly CreateConferenceService createConferenceService;

        public ConferenceCommandsService()
        {
            this.createConferenceService = new CreateConferenceService();
        }

        public string CallControlId { get; set; }

        public virtual CreateConferenceResponse Create(CreateConferenceOptions options)
        {
            return this.createConferenceService.Create(options);
        }

        public virtual Task<CreateConferenceResponse> CreateAsync(CreateConferenceOptions options)
        {
            return this.createConferenceService.CreateAsync(options);
        }
    }
}