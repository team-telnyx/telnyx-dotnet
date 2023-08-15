namespace Telnyx.net.Services.PhoneNumbers.NumberConfigurations
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.PhoneNumbers.NumberConfigurations;

    public class NumberConfigurationMessagingService : Service<PhoneNumberMessaging>
    {
        public NumberConfigurationMessagingService()
            : base(null)
        {
        }

        public NumberConfigurationMessagingService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/phone_numbers";

        public override string PostPath { get; set; } = "messaging";

        public async Task<TelnyxList<PhoneNumberMessaging>> ListMessagingSettingsAsync(ListOptions opts = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(this.PostPath, opts, reqOpts, cancellationToken: ct);
        }

        public TelnyxList<PhoneNumberMessaging> ListMessagingSettings(ListOptions opts = null, RequestOptions reqOpts = null)
        {
            return this.ListEntities(this.PostPath, opts, reqOpts);
        }

        public async Task<PhoneNumberMessaging> RetrievePhoneNumberMessagingettingsAsync(string id, BaseOptions opts = null, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, opts, reqOpts, postPath: this.PostPath, parentToken: "data", cancellationToken: ct);
        }

        public PhoneNumberMessaging RetrievePhoneNumberMessagingSettings(string id, BaseOptions opts = null, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, opts, reqOpts, postPath: this.PostPath, parentToken: "data");
        }

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="updateOptions">Update Options.</param>
        /// <param name="requestOptions">Request Options.</param>
        /// <returns>Number Order.</returns>
        public PhoneNumberMessaging UpdateMessagingSettings(string id, MessagingSettingUpdateOptions updateOptions, RequestOptions requestOptions = null)
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
        /// <returns>PhoneNumberMessaging.</returns>
        public async Task<PhoneNumberMessaging> UpdateMessagingSettingsAsync(string id, MessagingSettingUpdateOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.UpdateEntityAsync(id, updateOptions, requestOptions, parentToken: "data", cancellationToken);
        }
    }
}
