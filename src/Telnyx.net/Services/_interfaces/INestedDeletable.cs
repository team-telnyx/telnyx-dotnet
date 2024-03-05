namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Nested deletable generic.
    /// </summary>
    /// <typeparam name="T">Generic type.</typeparam>
    public interface INestedDeletable<T>
        where T : ITelnyxEntity, IHasId
    {
        /// <summary>
        /// Delete generic.
        /// </summary>
        /// <param name="parentId">Parent Id.</param>
        /// <param name="id">Id.</param>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>Generic T.</returns>
        T Delete(string parentId, string id, RequestOptions requestOptions = null);

        /// <summary>
        /// Delete generic async.
        /// </summary>
        /// <param name="parentId">Parent Id.</param>
        /// <param name="id">Id.</param>
        /// <param name="requestOptions">Request options.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Task of Generic T.</returns>
        Task<T> DeleteAsync(string parentId, string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
