using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.BundlePricing.BillingBundles;

namespace Telnyx.Sdk.Services.BundlePricing;

/// <inheritdoc/>
public sealed class BillingBundleService : IBillingBundleService
{
    readonly Lazy<IBillingBundleServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBillingBundleServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IBillingBundleService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new BillingBundleService(this._client.WithOptions(modifier)); }

    public BillingBundleService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new BillingBundleServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<BillingBundleRetrieveResponse> Retrieve(
        BillingBundleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<BillingBundleRetrieveResponse> Retrieve(
        string bundleID,
        BillingBundleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            BundleID = bundleID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BillingBundleListPage> List(
        BillingBundleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BillingBundleServiceWithRawResponse : IBillingBundleServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBillingBundleServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BillingBundleServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BillingBundleServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<BillingBundleRetrieveResponse>> Retrieve(
        BillingBundleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BundleID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BundleID' cannot be null"
            );
        }

        HttpRequest<BillingBundleRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var billingBundle = await response.Deserialize<BillingBundleRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                billingBundle.Validate();
            }
            return billingBundle;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<BillingBundleRetrieveResponse>> Retrieve(
        string bundleID,
        BillingBundleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            BundleID = bundleID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BillingBundleListPage>> List(
        BillingBundleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BillingBundleListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<BillingBundleListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new BillingBundleListPage(this, parameters, page);
        });
    }
}