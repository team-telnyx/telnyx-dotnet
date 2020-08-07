namespace Telnyx.net.Services._interfaces
{
    using System.Threading;
    using System.Threading.Tasks;

    interface IRetrievableWithIdInMid<T>
        where T : ITelnyxEntity, IHasId
    {
        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>ITelnyxEntity.</returns>
        T Get(string id, BaseOptions baseOptions, RequestOptions requestOptions = null, string postFix = null);

        /// <summary>
        /// GetAsync.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>ITelnyxEntity.</returns>
        Task<T> GetAsync(string id, BaseOptions baseOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken), string postFix = null);
    }
}
