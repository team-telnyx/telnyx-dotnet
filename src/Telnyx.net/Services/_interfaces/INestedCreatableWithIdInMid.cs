namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// INestedCreatableWithIdInMid
    /// </summary>
    /// <typeparam name="T">ITelnyxEntity</typeparam>
    /// <typeparam name="O">BaseOptions</typeparam>
    public interface INestedCreatableWithIdInMid<T, O>
        where T : ITelnyxEntity
        where O : BaseOptions
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="createOptions">createOptions</param>
        /// <param name="postFix">postFix</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <returns>ITelnyxEntity</returns>
        T Create(string parentId, O createOptions, string postFix, RequestOptions requestOptions = null);

        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="createOptions">createOptions</param>
        /// <param name="postFix">postFix</param>
        /// <param name="requestOptions">requestOptions</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>ITelnyxEntity</returns>
        Task<T> CreateAsync(string parentId, O createOptions, string postFix, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
