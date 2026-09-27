using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Porting;
using Porting = Telnyx.Sdk.Services.Porting;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class PortingService : IPortingService
{
    readonly Lazy<IPortingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPortingServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPortingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new PortingService(this._client.WithOptions(modifier)); }

    public PortingService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PortingServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _events =new(() => new Porting::EventService(client)) ;
        _reports =new(() => new Porting::ReportService(client)) ;
        _loaConfigurations =new(
            () => new Porting::LoaConfigurationService(client)
        ) ;
    }

    readonly Lazy<Porting::IEventService> _events;
    public Porting::IEventService Events { get { return _events.Value; } }

    readonly Lazy<Porting::IReportService> _reports;
    public Porting::IReportService Reports { get { return _reports.Value; } }

    readonly Lazy<Porting::ILoaConfigurationService> _loaConfigurations;
    public Porting::ILoaConfigurationService LoaConfigurations {
        get { return _loaConfigurations.Value; }
    }

    /// <inheritdoc/>
    public async Task<PortingListUkCarriersResponse> ListUkCarriers(
        PortingListUkCarriersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListUkCarriers(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PortingServiceWithRawResponse : IPortingServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPortingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PortingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PortingServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _events =new(() => new Porting::EventServiceWithRawResponse(client)) ;
        _reports =new(() => new Porting::ReportServiceWithRawResponse(client)) ;
        _loaConfigurations =new(
            () => new Porting::LoaConfigurationServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<Porting::IEventServiceWithRawResponse> _events;
    public Porting::IEventServiceWithRawResponse Events {
        get { return _events.Value; }
    }

    readonly Lazy<Porting::IReportServiceWithRawResponse> _reports;
    public Porting::IReportServiceWithRawResponse Reports {
        get { return _reports.Value; }
    }

    readonly Lazy<Porting::ILoaConfigurationServiceWithRawResponse> _loaConfigurations;
    public Porting::ILoaConfigurationServiceWithRawResponse LoaConfigurations {
        get { return _loaConfigurations.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PortingListUkCarriersResponse>> ListUkCarriers(
        PortingListUkCarriersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PortingListUkCarriersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<PortingListUkCarriersResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}