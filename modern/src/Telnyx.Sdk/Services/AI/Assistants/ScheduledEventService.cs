using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Assistants.ScheduledEvents;

namespace Telnyx.Sdk.Services.AI.Assistants;

/// <inheritdoc/>
public sealed class ScheduledEventService : IScheduledEventService
{
    readonly Lazy<IScheduledEventServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IScheduledEventServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IScheduledEventService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ScheduledEventService(this._client.WithOptions(modifier)); }

    public ScheduledEventService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ScheduledEventServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ScheduledEventResponse> Create(
        ScheduledEventCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ScheduledEventResponse> Create(
        string assistantID,
        ScheduledEventCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ScheduledEventResponse> Retrieve(
        ScheduledEventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ScheduledEventResponse> Retrieve(
        string eventID,
        ScheduledEventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            EventID = eventID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ScheduledEventListPage> List(
        ScheduledEventListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ScheduledEventListPage> List(
        string assistantID,
        ScheduledEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        ScheduledEventDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string eventID,
        ScheduledEventDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with{
            EventID = eventID
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ScheduledEventServiceWithRawResponse : IScheduledEventServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IScheduledEventServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ScheduledEventServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ScheduledEventServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ScheduledEventResponse>> Create(
        ScheduledEventCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AssistantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AssistantID' cannot be null"
            );
        }

        HttpRequest<ScheduledEventCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var scheduledEventResponse = await response.Deserialize<ScheduledEventResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                scheduledEventResponse.Validate();
            }
            return scheduledEventResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ScheduledEventResponse>> Create(
        string assistantID,
        ScheduledEventCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ScheduledEventResponse>> Retrieve(
        ScheduledEventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EventID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EventID' cannot be null"
            );
        }

        HttpRequest<ScheduledEventRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var scheduledEventResponse = await response.Deserialize<ScheduledEventResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                scheduledEventResponse.Validate();
            }
            return scheduledEventResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ScheduledEventResponse>> Retrieve(
        string eventID,
        ScheduledEventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            EventID = eventID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ScheduledEventListPage>> List(
        ScheduledEventListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AssistantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AssistantID' cannot be null"
            );
        }

        HttpRequest<ScheduledEventListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<ScheduledEventListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ScheduledEventListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ScheduledEventListPage>> List(
        string assistantID,
        ScheduledEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        ScheduledEventDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EventID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EventID' cannot be null"
            );
        }

        HttpRequest<ScheduledEventDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string eventID,
        ScheduledEventDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            EventID = eventID
        }, cancellationToken);
    }
}