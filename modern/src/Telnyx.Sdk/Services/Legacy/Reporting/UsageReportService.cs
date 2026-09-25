using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Legacy.Reporting.UsageReports;
using UsageReports = Telnyx.Sdk.Services.Legacy.Reporting.UsageReports;

namespace Telnyx.Sdk.Services.Legacy.Reporting;

/// <inheritdoc/>
public sealed class UsageReportService : IUsageReportService
{
    readonly Lazy<IUsageReportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUsageReportServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IUsageReportService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new UsageReportService(this._client.WithOptions(modifier)); }

    public UsageReportService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new UsageReportServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _messaging =new(() => new UsageReports::MessagingService(client)) ;
        _numberLookup =new(
            () => new UsageReports::NumberLookupService(client)
        ) ;
        _voice =new(() => new UsageReports::VoiceService(client)) ;
    }

    readonly Lazy<UsageReports::IMessagingService> _messaging;
    public UsageReports::IMessagingService Messaging {
        get { return _messaging.Value; }
    }

    readonly Lazy<UsageReports::INumberLookupService> _numberLookup;
    public UsageReports::INumberLookupService NumberLookup {
        get { return _numberLookup.Value; }
    }

    readonly Lazy<UsageReports::IVoiceService> _voice;
    public UsageReports::IVoiceService Voice { get { return _voice.Value; } }

    /// <inheritdoc/>
    public async Task<UsageReportRetrieveSpeechToTextResponse> RetrieveSpeechToText(
        UsageReportRetrieveSpeechToTextParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveSpeechToText(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class UsageReportServiceWithRawResponse : IUsageReportServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUsageReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new UsageReportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UsageReportServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _messaging =new(
            () => new UsageReports::MessagingServiceWithRawResponse(client)
        ) ;
        _numberLookup =new(
            () => new UsageReports::NumberLookupServiceWithRawResponse(client)
        ) ;
        _voice =new(
            () => new UsageReports::VoiceServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<UsageReports::IMessagingServiceWithRawResponse> _messaging;
    public UsageReports::IMessagingServiceWithRawResponse Messaging {
        get { return _messaging.Value; }
    }

    readonly Lazy<UsageReports::INumberLookupServiceWithRawResponse> _numberLookup;
    public UsageReports::INumberLookupServiceWithRawResponse NumberLookup {
        get { return _numberLookup.Value; }
    }

    readonly Lazy<UsageReports::IVoiceServiceWithRawResponse> _voice;
    public UsageReports::IVoiceServiceWithRawResponse Voice {
        get { return _voice.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UsageReportRetrieveSpeechToTextResponse>> RetrieveSpeechToText(
        UsageReportRetrieveSpeechToTextParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UsageReportRetrieveSpeechToTextParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<UsageReportRetrieveSpeechToTextResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}