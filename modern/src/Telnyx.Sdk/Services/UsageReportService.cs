using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.UsageReports;

namespace Telnyx.Sdk.Services;

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
    }

    /// <inheritdoc/>
    public async Task<UsageReportListPage> List(
        UsageReportListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<UsageReportGetOptionsResponse> GetOptions(
        UsageReportGetOptionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetOptions(parameters, cancellationToken).ConfigureAwait(false);
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
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<UsageReportListPage>> List(
        UsageReportListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UsageReportListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<UsageReportListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new UsageReportListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UsageReportGetOptionsResponse>> GetOptions(
        UsageReportGetOptionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UsageReportGetOptionsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<UsageReportGetOptionsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}