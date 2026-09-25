using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AccessIPRanges;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class AccessIPRangeService : IAccessIPRangeService
{
    readonly Lazy<IAccessIPRangeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccessIPRangeServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAccessIPRangeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new AccessIPRangeService(this._client.WithOptions(modifier)); }

    public AccessIPRangeService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AccessIPRangeServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<AccessIPRange> Create(
        AccessIPRangeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AccessIPRangeListPage> List(
        AccessIPRangeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AccessIPRange> Delete(
        AccessIPRangeDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AccessIPRange> Delete(
        string accessIPRangeID,
        AccessIPRangeDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            AccessIPRangeID = accessIPRangeID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AccessIPRangeServiceWithRawResponse : IAccessIPRangeServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccessIPRangeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AccessIPRangeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AccessIPRangeServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccessIPRange>> Create(
        AccessIPRangeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AccessIPRangeCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var accessIPRange = await response.Deserialize<AccessIPRange>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                accessIPRange.Validate();
            }
            return accessIPRange;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccessIPRangeListPage>> List(
        AccessIPRangeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AccessIPRangeListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<AccessIPRangeListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new AccessIPRangeListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccessIPRange>> Delete(
        AccessIPRangeDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AccessIPRangeID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AccessIPRangeID' cannot be null"
            );
        }

        HttpRequest<AccessIPRangeDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var accessIPRange = await response.Deserialize<AccessIPRange>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                accessIPRange.Validate();
            }
            return accessIPRange;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AccessIPRange>> Delete(
        string accessIPRangeID,
        AccessIPRangeDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            AccessIPRangeID = accessIPRangeID
        }, cancellationToken);
    }
}