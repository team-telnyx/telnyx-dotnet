using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Requirements;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class RequirementService : IRequirementService
{
    readonly Lazy<IRequirementServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRequirementServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRequirementService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new RequirementService(this._client.WithOptions(modifier)); }

    public RequirementService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RequirementServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<RequirementRetrieveResponse> Retrieve(
        RequirementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RequirementRetrieveResponse> Retrieve(
        string id,
        RequirementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RequirementListPage> List(
        RequirementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RequirementServiceWithRawResponse : IRequirementServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRequirementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RequirementServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RequirementServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<RequirementRetrieveResponse>> Retrieve(
        RequirementRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<RequirementRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var requirement = await response.Deserialize<RequirementRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                requirement.Validate();
            }
            return requirement;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RequirementRetrieveResponse>> Retrieve(
        string id,
        RequirementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RequirementListPage>> List(
        RequirementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RequirementListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<RequirementListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new RequirementListPage(this, parameters, page);
        });
    }
}