using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Compute.Funcs.Export;

namespace Telnyx.Sdk.Services.Compute.Funcs;

/// <inheritdoc/>
public sealed class ExportService : IExportService
{
    readonly Lazy<IExportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExportServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IExportService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ExportService(this._client.WithOptions(modifier)); }

    public ExportService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ExportServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<FuncLogExportConfigResponse> Create(
        ExportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FuncLogExportConfigResponse> Create(
        string id,
        ExportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FuncLogExportConfigResponse> List(
        ExportListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FuncLogExportConfigResponse> List(
        string id,
        ExportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task DeleteAll(
        ExportDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.DeleteAll(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task DeleteAll(
        string id,
        ExportDeleteAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.DeleteAll(parameters with{
            ID = id
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ExportServiceWithRawResponse : IExportServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ExportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExportServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<FuncLogExportConfigResponse>> Create(
        ExportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ExportCreateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var funcLogExportConfigResponse = await response.Deserialize<FuncLogExportConfigResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                funcLogExportConfigResponse.Validate();
            }
            return funcLogExportConfigResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FuncLogExportConfigResponse>> Create(
        string id,
        ExportCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FuncLogExportConfigResponse>> List(
        ExportListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ExportListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var funcLogExportConfigResponse = await response.Deserialize<FuncLogExportConfigResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                funcLogExportConfigResponse.Validate();
            }
            return funcLogExportConfigResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FuncLogExportConfigResponse>> List(
        string id,
        ExportListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteAll(
        ExportDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ExportDeleteAllParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> DeleteAll(
        string id,
        ExportDeleteAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DeleteAll(parameters with{
            ID = id
        }, cancellationToken);
    }
}