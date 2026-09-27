using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.PortingOrders.ActivationJobs;

namespace Telnyx.Sdk.Services.PortingOrders;

/// <inheritdoc/>
public sealed class ActivationJobService : IActivationJobService
{
    readonly Lazy<IActivationJobServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IActivationJobServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IActivationJobService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ActivationJobService(this._client.WithOptions(modifier)); }

    public ActivationJobService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ActivationJobServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ActivationJobRetrieveResponse> Retrieve(
        ActivationJobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActivationJobRetrieveResponse> Retrieve(
        string activationJobID,
        ActivationJobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            ActivationJobID = activationJobID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActivationJobUpdateResponse> Update(
        ActivationJobUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActivationJobUpdateResponse> Update(
        string activationJobID,
        ActivationJobUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ActivationJobID = activationJobID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ActivationJobListPage> List(
        ActivationJobListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ActivationJobListPage> List(
        string id,
        ActivationJobListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ActivationJobServiceWithRawResponse : IActivationJobServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IActivationJobServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ActivationJobServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ActivationJobServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActivationJobRetrieveResponse>> Retrieve(
        ActivationJobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ActivationJobID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ActivationJobID' cannot be null"
            );
        }

        HttpRequest<ActivationJobRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var activationJob = await response.Deserialize<ActivationJobRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                activationJob.Validate();
            }
            return activationJob;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActivationJobRetrieveResponse>> Retrieve(
        string activationJobID,
        ActivationJobRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            ActivationJobID = activationJobID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActivationJobUpdateResponse>> Update(
        ActivationJobUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ActivationJobID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ActivationJobID' cannot be null"
            );
        }

        HttpRequest<ActivationJobUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var activationJob = await response.Deserialize<ActivationJobUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                activationJob.Validate();
            }
            return activationJob;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActivationJobUpdateResponse>> Update(
        string activationJobID,
        ActivationJobUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ActivationJobID = activationJobID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ActivationJobListPage>> List(
        ActivationJobListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ActivationJobListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<ActivationJobListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ActivationJobListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ActivationJobListPage>> List(
        string id,
        ActivationJobListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }
}