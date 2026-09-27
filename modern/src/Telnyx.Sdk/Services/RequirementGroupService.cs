using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.RequirementGroups;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class RequirementGroupService : IRequirementGroupService
{
    readonly Lazy<IRequirementGroupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRequirementGroupServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRequirementGroupService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new RequirementGroupService(this._client.WithOptions(modifier)); }

    public RequirementGroupService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RequirementGroupServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<RequirementGroup> Create(
        RequirementGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RequirementGroup> Retrieve(
        RequirementGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RequirementGroup> Retrieve(
        string id,
        RequirementGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RequirementGroup> Update(
        RequirementGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RequirementGroup> Update(
        string id,
        RequirementGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<RequirementGroup>> List(
        RequirementGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RequirementGroup> Delete(
        RequirementGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RequirementGroup> Delete(
        string id,
        RequirementGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RequirementGroup> SubmitForApproval(
        RequirementGroupSubmitForApprovalParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.SubmitForApproval(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RequirementGroup> SubmitForApproval(
        string id,
        RequirementGroupSubmitForApprovalParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.SubmitForApproval(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class RequirementGroupServiceWithRawResponse : IRequirementGroupServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRequirementGroupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RequirementGroupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RequirementGroupServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<RequirementGroup>> Create(
        RequirementGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RequirementGroupCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var requirementGroup = await response.Deserialize<RequirementGroup>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                requirementGroup.Validate();
            }
            return requirementGroup;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RequirementGroup>> Retrieve(
        RequirementGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<RequirementGroupRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var requirementGroup = await response.Deserialize<RequirementGroup>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                requirementGroup.Validate();
            }
            return requirementGroup;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RequirementGroup>> Retrieve(
        string id,
        RequirementGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RequirementGroup>> Update(
        RequirementGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<RequirementGroupUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var requirementGroup = await response.Deserialize<RequirementGroup>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                requirementGroup.Validate();
            }
            return requirementGroup;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RequirementGroup>> Update(
        string id,
        RequirementGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<RequirementGroup>>> List(
        RequirementGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RequirementGroupListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var requirementGroups = await response.Deserialize<List<RequirementGroup>>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                foreach (var item in requirementGroups)
                {
                    item.Validate();
                }
            }
            return requirementGroups;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RequirementGroup>> Delete(
        RequirementGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<RequirementGroupDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var requirementGroup = await response.Deserialize<RequirementGroup>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                requirementGroup.Validate();
            }
            return requirementGroup;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RequirementGroup>> Delete(
        string id,
        RequirementGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RequirementGroup>> SubmitForApproval(
        RequirementGroupSubmitForApprovalParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<RequirementGroupSubmitForApprovalParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var requirementGroup = await response.Deserialize<RequirementGroup>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                requirementGroup.Validate();
            }
            return requirementGroup;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RequirementGroup>> SubmitForApproval(
        string id,
        RequirementGroupSubmitForApprovalParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.SubmitForApproval(parameters with{
            ID = id
        }, cancellationToken);
    }
}