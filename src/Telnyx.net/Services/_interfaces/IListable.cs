namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    /// <summary>
    /// IListable.
    /// </summary>
    /// <typeparam name="T">ITelnyxEntity.</typeparam>
    /// <typeparam name="O">ListOptions.</typeparam>
    public interface IListable<T, O>
        where T : ITelnyxEntity, IHasId
        where O : ListOptions
    {
        /// <summary>
        /// List.
        /// </summary>
        /// <param name="listOptions">listOptions.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>TelnyxList of ITelnyxEntity.</returns>
        TelnyxList<T> List(O listOptions = null, RequestOptions requestOptions = null);

        /// <summary>
        /// ListAsync.
        /// </summary>
        /// <param name="listOptions">listOptions.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>TelnyxList of ITelnyxEntity.</returns>
        Task<TelnyxList<T>> ListAsync(O listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));

        ///// <summary>
        ///// ListAutoPaging
        ///// </summary>
        ///// <param name="listOptions">listOptions</param>
        ///// <param name="requestOptions">requestOptions</param>
        ///// <returns>IEnumerable of ITelnyxEntity</returns>
        //IEnumerable<T> ListAutoPaging(O listOptions = null, RequestOptions requestOptions = null);
    }
}
