namespace Telnyx.net.Services.PhoneNumbers.NumberConfigurations
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.PhoneNumbers.NumberConfigurations;

    public class NumberConfigurationVoiceService : Service<PhoneNumberVoiceSettings>
    {
        public NumberConfigurationVoiceService()
            : base(null)
        {
        }

        public NumberConfigurationVoiceService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/phone_numbers";

        public override string PostPath { get; set; } = "voice";

        public async Task<PhoneNumberVoiceSettings> RetrievePhoneNumberVoiceSettingsAsync(string id, BaseOptions opts = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, opts, reqOpts, postPath: this.PostPath, parentToken: "data", cancellationToken: ct);
        }

        public PhoneNumberVoiceSettings RetrievePhoneNumberVoiceSettings(string id, BaseOptions opts = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, opts, reqOpts, postPath: this.PostPath, parentToken: "data");
        }

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="updateOptions">Update Options.</param>
        /// <param name="requestOptions">Request Options.</param>
        /// <returns>Phone Number Voice Settings.</returns>
        public PhoneNumberVoiceSettings UpdateVoiceSettings(string id, VoiceSettingUpdateOptions updateOptions, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(id, updateOptions, requestOptions, parentToken: "data");
        }

        /// <summary>
        /// Update Async.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="updateOptions">Update Options.</param>
        /// <param name="requestOptions">Request Options.</param>
        /// <param name="cancellationToken">Cancellation Token.</param>
        /// <returns>PhoneNumberVoiceSettings.</returns>
        public async Task<PhoneNumberVoiceSettings> UpdateVoiceSettingsAsync(string id, VoiceSettingUpdateOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.UpdateEntityAsync(id, updateOptions, requestOptions, parentToken: "data", cancellationToken);
        }

        public async Task<TelnyxList<PhoneNumberVoiceSettings>> ListPhoneNumberVoiceAsync(VoiceSettingsListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(this.PostPath, options, reqOpts, cancellationToken: ct);
        }

        public TelnyxList<PhoneNumberVoiceSettings> ListPhoneNumberVoice(VoiceSettingsListOptions options, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return this.ListEntities(this.PostPath, options, reqOpts);
        }

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="updateOptions">Update Options.</param>
        /// <param name="requestOptions">Request Options.</param>
        /// <returns>Number Order.</returns>
        public virtual PhoneNumberVoiceSettings EnableEmergencySettings(string id, EmergencyOptions updateOptions, RequestOptions requestOptions = null)
        {
            this.PostPath = "actions/enable_emergency";
            return this.CreateEntity(id, this.PostPath, updateOptions, requestOptions, parentToken: "data");
        }

        /// <summary>
        /// Update Async.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="updateOptions">Update Options.</param>
        /// <param name="requestOptions">Request Options.</param>
        /// <param name="cancellationToken">Cancellation Token.</param>
        /// <returns>Number Order.</returns>
        public async virtual Task<PhoneNumberVoiceSettings> EnableEmergencySettingsAsync(string id, EmergencyOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            this.PostPath = "actions/enable_emergency";
            return await this.CreateEntityAsync(id, this.PostPath, updateOptions, requestOptions, parentToken: "data", cancellationToken);
        }
    }
}
