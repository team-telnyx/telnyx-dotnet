namespace Telnyx
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Number Reservation Service
    /// </summary>
    public class NumberReservationsService : Service<NumberReservation>,
        ICreatable<NumberReservation, NumberReservation>,
        IListable<NumberReservation, NumberReservationsListOptions>,
        IRetrievable<NumberReservation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumberReservationsService"/> class.
        /// </summary>
        public NumberReservationsService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberReservationsService"/> class.
        /// </summary>
        /// <param name="apiKey">API key</param>
        public NumberReservationsService(string apiKey)
            : base(apiKey)
        {
        }

        /// <inheritdoc/>
        public override string BasePath => "/number_reservations";

        /// <inheritdoc/>
        public NumberReservation Create(NumberReservation createOptions, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(createOptions, requestOptions);
        }

        /// <inheritdoc/>
        public Task<NumberReservation> CreateAsync(NumberReservation createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(createOptions, requestOptions, cancellationToken);
        }

        /// <inheritdoc/>
        public NumberReservation Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, null, requestOptions);
        }

        /// <inheritdoc/>
        public Task<NumberReservation> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityAsync(id, null, requestOptions, cancellationToken);
        }

        /// <inheritdoc/>
        public TelnyxList<NumberReservation> List(NumberReservationsListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        /// <inheritdoc/>
        public Task<TelnyxList<NumberReservation>> ListAsync(NumberReservationsListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.ListEntitiesAsync(listOptions, requestOptions, cancellationToken);
        }

        /// <inheritdoc/>
        public IEnumerable<NumberReservation> ListAutoPaging(NumberReservationsListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListAutoPaging(listOptions, requestOptions);
        }
    }
}
