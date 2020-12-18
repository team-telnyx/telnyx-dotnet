namespace Telnyx
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// ICreatable.
    /// </summary>
    /// <typeparam name="T">ITelnyxEntity.</typeparam>
    /// <typeparam name="O">BaseOptions.</typeparam>
    public interface ICreatable<T, O>
        where T : ITelnyxEntity
        where O : BaseOptions
    {
        /// <summary>
        /// Create.
        /// </summary>
        /// <param name="createOptions">createOptions.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <returns>ITelnyxEntity.</returns>
        T Create(O createOptions, RequestOptions requestOptions = null);

        /// <summary>
        /// CreateAsync.
        /// </summary>
        /// <param name="createOptions">createOptions.</param>
        /// <param name="requestOptions">requestOptions.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>ITelnyxEntity.</returns>
        Task<T> CreateAsync(O createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
