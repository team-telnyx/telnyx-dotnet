namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// INestedRetrievable.
    /// </summary>
    /// <typeparam name="T">ITelnyxEntity.</typeparam>
    public interface INestedRetrievable<T>
        where T : ITelnyxEntity, IHasId
    {
        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="parentId">parentId.</param>
        /// <param name="id">id.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>ITelnyxEntity.</returns>
        T Get(string parentId, string id, RequestOptions requestOptions = null);

        /// <summary>
        /// GetAsync.
        /// </summary>
        /// <param name="parentId">parentId.</param>
        /// <param name="id">id.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>ITelnyxEntity.</returns>
        Task<T> GetAsync(string parentId, string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
