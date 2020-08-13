namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// IBulkUpdatable.
    /// </summary>
    /// <typeparam name="T">ITelnyxEntity.</typeparam>
    /// <typeparam name="O">BaseOptions.</typeparam>
    public interface IBulkUpdatable<T, O>
        where T : ITelnyxEntity
        where O : BaseOptions
    {
        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="updateOptions">updateOptions.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>ITelnyxEntity.</returns>
        T Update(O updateOptions, RequestOptions requestOptions = null);

        /// <summary>
        /// UpdateAsync.
        /// </summary>
        /// <param name="updateOptions">updateOptions.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>ITelnyxEntity.</returns>
        Task<T> UpdateAsync(O updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
