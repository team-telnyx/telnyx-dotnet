namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// ISingletonRetrievable
    /// </summary>
    /// <typeparam name="T">ITelnyxEntity</typeparam>
    public interface ISingletonRetrievable<T>
        where T : ITelnyxEntity
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="requestOptions">requestOptions</param>
        /// <returns>ITelnyxEntity</returns>
        T Get(RequestOptions requestOptions = null);

        /// <summary>
        /// GetAsync
        /// </summary>
        /// <param name="requestOptions">requestOptions</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>ITelnyxEntity</returns>
        Task<T> GetAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
