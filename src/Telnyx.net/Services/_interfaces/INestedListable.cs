namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    /// <summary>
    /// INestedListable.
    /// </summary>
    /// <typeparam name="T">ITelnyxEntity.</typeparam>
    /// <typeparam name="O">ListOptions.</typeparam>
    public interface INestedListable<T, O>
        where T : ITelnyxEntity, IHasId
        where O : ListOptions
    {
        /// <summary>
        /// List.
        /// </summary>
        /// <param name="parentId">parentId.</param>
        /// <param name="listOptions">listOptions.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>TelnyxList of ITelnyxEntity.</returns>
        TelnyxList<T> List(string parentId, O listOptions = null, RequestOptions requestOptions = null);

        /// <summary>
        /// ListAsync.
        /// </summary>
        /// <param name="parentId">parentId.</param>
        /// <param name="listOptions">listOptions.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>TelnyxList of ITelnyxEntity.</returns>
        Task<TelnyxList<T>> ListAsync(string parentId, O listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));

        ///// <summary>
        ///// ListAutoPaging
        ///// </summary>
        ///// <param name="parentId">parentId</param>
        ///// <param name="listOptions">listOptions</param>
        ///// <param name="requestOptions">requestOptions</param>
        ///// <returns>IEnumerable of ITelnyxEntity</returns>
        //IEnumerable<T> ListAutoPaging(string parentId, O listOptions = null, RequestOptions requestOptions = null);
    }
}
