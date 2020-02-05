namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// IRetrievable
    /// </summary>
    /// <typeparam name="T">ITelnyxEntity</typeparam>
    public interface IRetrievable<T>
        where T : ITelnyxEntity, IHasId
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <returns>ITelnyxEntity</returns>
        T Get(string id, RequestOptions requestOptions = null);

        /// <summary>
        /// GetAsync
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>ITelnyxEntity</returns>
        Task<T> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
