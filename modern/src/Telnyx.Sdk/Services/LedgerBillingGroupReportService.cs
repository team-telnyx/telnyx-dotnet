using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.LedgerBillingGroupReports;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class LedgerBillingGroupReportService : ILedgerBillingGroupReportService
{
    readonly Lazy<ILedgerBillingGroupReportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILedgerBillingGroupReportServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ILedgerBillingGroupReportService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new LedgerBillingGroupReportService(this._client.WithOptions(modifier));
    }

    public LedgerBillingGroupReportService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new LedgerBillingGroupReportServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<LedgerBillingGroupReportCreateResponse> Create(
        LedgerBillingGroupReportCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<LedgerBillingGroupReportRetrieveResponse> Retrieve(
        LedgerBillingGroupReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<LedgerBillingGroupReportRetrieveResponse> Retrieve(
        string id,
        LedgerBillingGroupReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class LedgerBillingGroupReportServiceWithRawResponse : ILedgerBillingGroupReportServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILedgerBillingGroupReportServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new LedgerBillingGroupReportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LedgerBillingGroupReportServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<LedgerBillingGroupReportCreateResponse>> Create(
        LedgerBillingGroupReportCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<LedgerBillingGroupReportCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var ledgerBillingGroupReport = await response.Deserialize<LedgerBillingGroupReportCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                ledgerBillingGroupReport.Validate();
            }
            return ledgerBillingGroupReport;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LedgerBillingGroupReportRetrieveResponse>> Retrieve(
        LedgerBillingGroupReportRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<LedgerBillingGroupReportRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var ledgerBillingGroupReport = await response.Deserialize<LedgerBillingGroupReportRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                ledgerBillingGroupReport.Validate();
            }
            return ledgerBillingGroupReport;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<LedgerBillingGroupReportRetrieveResponse>> Retrieve(
        string id,
        LedgerBillingGroupReportRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }
}