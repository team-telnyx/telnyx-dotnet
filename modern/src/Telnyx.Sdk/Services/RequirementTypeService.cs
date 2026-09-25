using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.RequirementTypes;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class RequirementTypeService : IRequirementTypeService
{
    readonly Lazy<IRequirementTypeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRequirementTypeServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRequirementTypeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new RequirementTypeService(this._client.WithOptions(modifier)); }

    public RequirementTypeService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RequirementTypeServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<RequirementTypeRetrieveResponse> Retrieve(
        RequirementTypeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RequirementTypeRetrieveResponse> Retrieve(
        string id,
        RequirementTypeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RequirementTypeListResponse> List(
        RequirementTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RequirementTypeServiceWithRawResponse : IRequirementTypeServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRequirementTypeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RequirementTypeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RequirementTypeServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<RequirementTypeRetrieveResponse>> Retrieve(
        RequirementTypeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<RequirementTypeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var requirementType = await response.Deserialize<RequirementTypeRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                requirementType.Validate();
            }
            return requirementType;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RequirementTypeRetrieveResponse>> Retrieve(
        string id,
        RequirementTypeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RequirementTypeListResponse>> List(
        RequirementTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RequirementTypeListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var requirementTypes = await response.Deserialize<RequirementTypeListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                requirementTypes.Validate();
            }
            return requirementTypes;
        });
    }
}