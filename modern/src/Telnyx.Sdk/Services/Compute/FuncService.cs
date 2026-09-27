using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Compute.Funcs;
using Telnyx.Sdk.Services.Compute.Funcs;

namespace Telnyx.Sdk.Services.Compute;

/// <inheritdoc/>
public sealed class FuncService : IFuncService
{
    readonly Lazy<IFuncServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFuncServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IFuncService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new FuncService(this._client.WithOptions(modifier)); }

    public FuncService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new FuncServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _export =new(() => new ExportService(client)) ;
    }

    readonly Lazy<IExportService> _export;
    public IExportService Export { get { return _export.Value; } }

    /// <inheritdoc/>
    public async Task<FuncRetrieveLogsResponse> RetrieveLogs(
        FuncRetrieveLogsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveLogs(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FuncRetrieveLogsResponse> RetrieveLogs(
        string id,
        FuncRetrieveLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveLogs(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FuncRetrieveMetricAggregatesPage> RetrieveMetricAggregates(
        FuncRetrieveMetricAggregatesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveMetricAggregates(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FuncRetrieveMetricAggregatesPage> RetrieveMetricAggregates(
        string id,
        FuncRetrieveMetricAggregatesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveMetricAggregates(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FuncRetrieveRevisionsPage> RetrieveRevisions(
        FuncRetrieveRevisionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveRevisions(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FuncRetrieveRevisionsPage> RetrieveRevisions(
        string id,
        FuncRetrieveRevisionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveRevisions(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FuncRetrieveShipInspectionResponse> RetrieveShipInspection(
        FuncRetrieveShipInspectionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveShipInspection(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FuncRetrieveShipInspectionResponse> RetrieveShipInspection(
        string id,
        FuncRetrieveShipInspectionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveShipInspection(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class FuncServiceWithRawResponse : IFuncServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFuncServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new FuncServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FuncServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _export =new(() => new ExportServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IExportServiceWithRawResponse> _export;
    public IExportServiceWithRawResponse Export {
        get { return _export.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FuncRetrieveLogsResponse>> RetrieveLogs(
        FuncRetrieveLogsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<FuncRetrieveLogsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<FuncRetrieveLogsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FuncRetrieveLogsResponse>> RetrieveLogs(
        string id,
        FuncRetrieveLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveLogs(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FuncRetrieveMetricAggregatesPage>> RetrieveMetricAggregates(
        FuncRetrieveMetricAggregatesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<FuncRetrieveMetricAggregatesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<FuncRetrieveMetricAggregatesPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new FuncRetrieveMetricAggregatesPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FuncRetrieveMetricAggregatesPage>> RetrieveMetricAggregates(
        string id,
        FuncRetrieveMetricAggregatesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveMetricAggregates(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FuncRetrieveRevisionsPage>> RetrieveRevisions(
        FuncRetrieveRevisionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<FuncRetrieveRevisionsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<FuncRetrieveRevisionsPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new FuncRetrieveRevisionsPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FuncRetrieveRevisionsPage>> RetrieveRevisions(
        string id,
        FuncRetrieveRevisionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveRevisions(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FuncRetrieveShipInspectionResponse>> RetrieveShipInspection(
        FuncRetrieveShipInspectionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<FuncRetrieveShipInspectionParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<FuncRetrieveShipInspectionResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FuncRetrieveShipInspectionResponse>> RetrieveShipInspection(
        string id,
        FuncRetrieveShipInspectionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveShipInspection(parameters with{
            ID = id
        }, cancellationToken);
    }
}