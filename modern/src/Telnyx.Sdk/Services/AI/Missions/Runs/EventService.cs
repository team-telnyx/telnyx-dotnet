using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Missions;
using Telnyx.Sdk.Models.AI.Missions.Runs.Events;

namespace Telnyx.Sdk.Services.AI.Missions.Runs;

/// <inheritdoc/>
public sealed class EventService : IEventService
{
    readonly Lazy<IEventServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEventServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IEventService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new EventService(this._client.WithOptions(modifier)); }

    public EventService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new EventServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<EventListPage> List(
        EventListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EventListPage> List(
        string runID,
        EventListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EventResponse> GetEventDetails(
        EventGetEventDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetEventDetails(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EventResponse> GetEventDetails(
        string eventID,
        EventGetEventDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetEventDetails(parameters with{
            EventID = eventID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EventResponse> Log(
        EventLogParams parameters, CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Log(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EventResponse> Log(
        string runID,
        EventLogParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Log(parameters with{
            RunID = runID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class EventServiceWithRawResponse : IEventServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEventServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EventServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EventServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventListPage>> List(
        EventListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RunID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RunID' cannot be null"
            );
        }

        HttpRequest<EventListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<EventsListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new EventListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EventListPage>> List(
        string runID,
        EventListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with{
            RunID = runID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventResponse>> GetEventDetails(
        EventGetEventDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EventID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EventID' cannot be null"
            );
        }

        HttpRequest<EventGetEventDetailsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var eventResponse = await response.Deserialize<EventResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                eventResponse.Validate();
            }
            return eventResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EventResponse>> GetEventDetails(
        string eventID,
        EventGetEventDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetEventDetails(parameters with{
            EventID = eventID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventResponse>> Log(
        EventLogParams parameters, CancellationToken cancellationToken = default
    )
    {
        if (parameters.RunID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RunID' cannot be null"
            );
        }

        HttpRequest<EventLogParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var eventResponse = await response.Deserialize<EventResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                eventResponse.Validate();
            }
            return eventResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EventResponse>> Log(
        string runID,
        EventLogParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Log(parameters with{
            RunID = runID
        }, cancellationToken);
    }
}