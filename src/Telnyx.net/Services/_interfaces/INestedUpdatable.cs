namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// INestedUpdatable
    /// </summary>
    /// <typeparam name="T">ITelnyxEntity</typeparam>
    /// <typeparam name="O">BaseOptions</typeparam>
    public interface INestedUpdatable<T, O>
        where T : ITelnyxEntity, IHasId
        where O : BaseOptions
    {
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="id">id</param>
        /// <param name="updateOptions">updateOptions</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <returns>ITelnyxEntity</returns>
        T Update(string parentId, string id, O updateOptions, RequestOptions requestOptions = null);

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="id">id</param>
        /// <param name="updateOptions">updateOptions</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>ITelnyxEntity</returns>
        Task<T> UpdateAsync(string parentId, string id, O updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
