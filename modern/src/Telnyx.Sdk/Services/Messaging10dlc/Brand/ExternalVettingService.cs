using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Messaging10dlc.Brand.ExternalVetting;

namespace Telnyx.Sdk.Services.Messaging10dlc.Brand;

/// <inheritdoc/>
public sealed class ExternalVettingService : IExternalVettingService
{
    readonly Lazy<IExternalVettingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExternalVettingServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IExternalVettingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ExternalVettingService(this._client.WithOptions(modifier)); }

    public ExternalVettingService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ExternalVettingServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<List<ExternalVettingExternalVetting>> List(
        ExternalVettingListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<List<ExternalVettingExternalVetting>> List(
        string brandID,
        ExternalVettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExternalVettingExternalVetting> Imports(
        ExternalVettingImportsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Imports(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ExternalVettingExternalVetting> Imports(
        string brandID,
        ExternalVettingImportsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Imports(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExternalVettingExternalVetting> Order(
        ExternalVettingOrderParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Order(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ExternalVettingExternalVetting> Order(
        string brandID,
        ExternalVettingOrderParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Order(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ExternalVettingServiceWithRawResponse : IExternalVettingServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExternalVettingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ExternalVettingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExternalVettingServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<ExternalVettingExternalVetting>>> List(
        ExternalVettingListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BrandID' cannot be null"
            );
        }

        HttpRequest<ExternalVettingListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var externalVettings = await response.Deserialize<List<ExternalVettingExternalVetting>>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                foreach (var item in externalVettings)
                {
                    item.Validate();
                }
            }
            return externalVettings;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<List<ExternalVettingExternalVetting>>> List(
        string brandID,
        ExternalVettingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalVettingExternalVetting>> Imports(
        ExternalVettingImportsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BrandID' cannot be null"
            );
        }

        HttpRequest<ExternalVettingImportsParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var externalVetting = await response.Deserialize<ExternalVettingExternalVetting>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                externalVetting.Validate();
            }
            return externalVetting;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ExternalVettingExternalVetting>> Imports(
        string brandID,
        ExternalVettingImportsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Imports(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalVettingExternalVetting>> Order(
        ExternalVettingOrderParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BrandID' cannot be null"
            );
        }

        HttpRequest<ExternalVettingOrderParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var externalVetting = await response.Deserialize<ExternalVettingExternalVetting>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                externalVetting.Validate();
            }
            return externalVetting;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ExternalVettingExternalVetting>> Order(
        string brandID,
        ExternalVettingOrderParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Order(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }
}