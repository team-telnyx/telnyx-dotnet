using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.SubNumberOrdersReport;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class SubNumberOrdersReportService : ISubNumberOrdersReportService
{
    readonly Lazy<ISubNumberOrdersReportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISubNumberOrdersReportServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISubNumberOrdersReportService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SubNumberOrdersReportService(this._client.WithOptions(modifier));
    }

    public SubNumberOrdersReportService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SubNumberOrdersReportServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<SubNumberOrdersReportCreateResponse> Create(
        SubNumberOrdersReportCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SubNumberOrdersReportRetrieveResponse> Retrieve(
        SubNumberOrdersReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SubNumberOrdersReportRetrieveResponse> Retrieve(
        string reportID,
        SubNumberOrdersReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ReportID = reportID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BinaryContent> Download(
        SubNumberOrdersReportDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Download(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<BinaryContent> Download(
        string reportID,
        SubNumberOrdersReportDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Download(parameters with{
            ReportID = reportID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SubNumberOrdersReportServiceWithRawResponse : ISubNumberOrdersReportServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISubNumberOrdersReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SubNumberOrdersReportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SubNumberOrdersReportServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubNumberOrdersReportCreateResponse>> Create(
        SubNumberOrdersReportCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SubNumberOrdersReportCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var subNumberOrdersReport = await response.Deserialize<SubNumberOrdersReportCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                subNumberOrdersReport.Validate();
            }
            return subNumberOrdersReport;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubNumberOrdersReportRetrieveResponse>> Retrieve(
        SubNumberOrdersReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ReportID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ReportID' cannot be null"
            );
        }

        HttpRequest<SubNumberOrdersReportRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var subNumberOrdersReport = await response.Deserialize<SubNumberOrdersReportRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                subNumberOrdersReport.Validate();
            }
            return subNumberOrdersReport;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SubNumberOrdersReportRetrieveResponse>> Retrieve(
        string reportID,
        SubNumberOrdersReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ReportID = reportID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BinaryContent>> Download(
        SubNumberOrdersReportDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ReportID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ReportID' cannot be null"
            );
        }

        HttpRequest<SubNumberOrdersReportDownloadParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<BinaryContent>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<BinaryContent>> Download(
        string reportID,
        SubNumberOrdersReportDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Download(parameters with{
            ReportID = reportID
        }, cancellationToken);
    }
}