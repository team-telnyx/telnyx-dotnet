namespace Telnyx.net.Services.HostedNumbers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities.HostedNumbers;

    public class HostedNumberService : Service<HostedNumber>
    {
        public HostedNumberService()
        {
        }

        public HostedNumberService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/messaging_hosted_numbers";

        /// <summary>
        /// Delete a messaging hosted number.
        /// </summary>
        /// <param name="id">Identifies the type of resource.</param>
        /// <param name="requestOptions">Additional options (optional).</param>
        /// <param name="ct">Cancellation Token (optional).</param>
        /// <returns>Successful response with details about a messaging hosted number.</returns>
        public async Task<HostedNumber> DeleteHostedNumberAsync(string id, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.DeleteEntityAsync(id, requestOptions, string.Empty, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a messaging hosted number.
        /// </summary>
        /// <param name="id">Identifies the type of resource.</param>
        /// <param name="requestOptions">Additional options (optional).</param>
        /// <returns>Successful response with details about a messaging hosted number.</returns>
        public HostedNumber DeleteHostedNumber(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, requestOptions);
        }
    }
}
