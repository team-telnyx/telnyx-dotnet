namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// IDeletable
    /// </summary>
    /// <typeparam name="T">ITelnyxEntity</typeparam>
    public interface IDeletable<T>
        where T : ITelnyxEntity, IHasId
    {
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <returns>ITelnyxEntity</returns>
        T Delete(string id, RequestOptions requestOptions = null);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>ITelnyxEntity</returns>
        Task<T> DeleteAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
