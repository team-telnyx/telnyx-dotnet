namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// IUpdatable
    /// </summary>
    /// <typeparam name="T">ITelnyxEntity</typeparam>
    /// <typeparam name="O">BaseOptions</typeparam>
    public interface IUpdatable<T, O>
        where T : ITelnyxEntity, IHasId
        where O : BaseOptions
    {
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="updateOptions">updateOptions</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <returns>ITelnyxEntity</returns>
        T Update(string id, O updateOptions, RequestOptions requestOptions = null);

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="updateOptions">updateOptions</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>ITelnyxEntity</returns>
        Task<T> UpdateAsync(string id, O updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
