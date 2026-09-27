using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Enterprises.Reputation.Remediation;

namespace Telnyx.Sdk.Services.Enterprises.Reputation;

/// <inheritdoc/>
public sealed class RemediationService : IRemediationService
{
    readonly Lazy<IRemediationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRemediationServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRemediationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new RemediationService(this._client.WithOptions(modifier)); }

    public RemediationService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RemediationServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<RemediationRequestWrapped> Create(
        RemediationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RemediationRequestWrapped> Create(
        string enterpriseID,
        RemediationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RemediationRequestWrapped> Retrieve(
        RemediationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RemediationRequestWrapped> Retrieve(
        string remediationID,
        RemediationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            RemediationID = remediationID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RemediationListPage> List(
        RemediationListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RemediationListPage> List(
        string enterpriseID,
        RemediationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class RemediationServiceWithRawResponse : IRemediationServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRemediationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RemediationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RemediationServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<RemediationRequestWrapped>> Create(
        RemediationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnterpriseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EnterpriseID' cannot be null"
            );
        }

        HttpRequest<RemediationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var remediationRequestWrapped = await response.Deserialize<RemediationRequestWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                remediationRequestWrapped.Validate();
            }
            return remediationRequestWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RemediationRequestWrapped>> Create(
        string enterpriseID,
        RemediationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RemediationRequestWrapped>> Retrieve(
        RemediationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RemediationID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RemediationID' cannot be null"
            );
        }

        HttpRequest<RemediationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var remediationRequestWrapped = await response.Deserialize<RemediationRequestWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                remediationRequestWrapped.Validate();
            }
            return remediationRequestWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RemediationRequestWrapped>> Retrieve(
        string remediationID,
        RemediationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            RemediationID = remediationID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RemediationListPage>> List(
        RemediationListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnterpriseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EnterpriseID' cannot be null"
            );
        }

        HttpRequest<RemediationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<RemediationListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new RemediationListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RemediationListPage>> List(
        string enterpriseID,
        RemediationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }
}