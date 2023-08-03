namespace Telnyx
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;

    /// <summary>
    /// Number Reservation Service.
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
        /// <param name="apiKey">API key.</param>
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
        public async Task<NumberReservation> CreateAsync(NumberReservation createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(createOptions, requestOptions, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public NumberReservation Get(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, null, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<NumberReservation> GetAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.GetEntityAsync(id, null, requestOptions, string.Empty, cancellationToken);
        }

        /// <inheritdoc/>
        public TelnyxList<NumberReservation> List(NumberReservationsListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(listOptions, requestOptions);
        }

        /// <inheritdoc/>
        public async Task<TelnyxList<NumberReservation>> ListAsync(NumberReservationsListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.ListEntitiesAsync(listOptions, requestOptions, string.Empty, cancellationToken);
        }

        /// <inheritdoc/>
        public IEnumerable<NumberReservation> ListAutoPaging(NumberReservationsListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListAutoPaging(listOptions, requestOptions);
        }

        public virtual NumberReservation ExtendANumberReservationRequest(string id, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, "/actions/extend", null, requestOptions, string.Empty);
        }

        public async Task<NumberReservation> ExtendANumberReservationRequestAsync(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(id, "/actions/extend", null, requestOptions, string.Empty, cancellationToken);
        }
    }
}
