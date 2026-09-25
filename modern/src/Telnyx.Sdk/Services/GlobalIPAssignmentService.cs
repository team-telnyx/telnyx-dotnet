using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.GlobalIPAssignments;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class GlobalIPAssignmentService : IGlobalIPAssignmentService
{
    readonly Lazy<IGlobalIPAssignmentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGlobalIPAssignmentServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IGlobalIPAssignmentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GlobalIPAssignmentService(this._client.WithOptions(modifier));
    }

    public GlobalIPAssignmentService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new GlobalIPAssignmentServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<GlobalIPAssignmentCreateResponse> Create(
        GlobalIPAssignmentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<GlobalIPAssignmentRetrieveResponse> Retrieve(
        GlobalIPAssignmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<GlobalIPAssignmentRetrieveResponse> Retrieve(
        string id,
        GlobalIPAssignmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<GlobalIPAssignmentUpdateResponse> Update(
        GlobalIPAssignmentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<GlobalIPAssignmentUpdateResponse> Update(
        string globalIPAssignmentID,
        GlobalIPAssignmentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            GlobalIPAssignmentID = globalIPAssignmentID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<GlobalIPAssignmentListPage> List(
        GlobalIPAssignmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<GlobalIPAssignmentDeleteResponse> Delete(
        GlobalIPAssignmentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<GlobalIPAssignmentDeleteResponse> Delete(
        string id,
        GlobalIPAssignmentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class GlobalIPAssignmentServiceWithRawResponse : IGlobalIPAssignmentServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGlobalIPAssignmentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GlobalIPAssignmentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GlobalIPAssignmentServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<GlobalIPAssignmentCreateResponse>> Create(
        GlobalIPAssignmentCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<GlobalIPAssignmentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var globalIPAssignment = await response.Deserialize<GlobalIPAssignmentCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                globalIPAssignment.Validate();
            }
            return globalIPAssignment;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GlobalIPAssignmentRetrieveResponse>> Retrieve(
        GlobalIPAssignmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<GlobalIPAssignmentRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var globalIPAssignment = await response.Deserialize<GlobalIPAssignmentRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                globalIPAssignment.Validate();
            }
            return globalIPAssignment;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<GlobalIPAssignmentRetrieveResponse>> Retrieve(
        string id,
        GlobalIPAssignmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GlobalIPAssignmentUpdateResponse>> Update(
        GlobalIPAssignmentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.GlobalIPAssignmentID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.GlobalIPAssignmentID' cannot be null"
            );
        }

        HttpRequest<GlobalIPAssignmentUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var globalIPAssignment = await response.Deserialize<GlobalIPAssignmentUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                globalIPAssignment.Validate();
            }
            return globalIPAssignment;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<GlobalIPAssignmentUpdateResponse>> Update(
        string globalIPAssignmentID,
        GlobalIPAssignmentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            GlobalIPAssignmentID = globalIPAssignmentID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GlobalIPAssignmentListPage>> List(
        GlobalIPAssignmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<GlobalIPAssignmentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<GlobalIPAssignmentListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new GlobalIPAssignmentListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GlobalIPAssignmentDeleteResponse>> Delete(
        GlobalIPAssignmentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<GlobalIPAssignmentDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var globalIPAssignment = await response.Deserialize<GlobalIPAssignmentDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                globalIPAssignment.Validate();
            }
            return globalIPAssignment;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<GlobalIPAssignmentDeleteResponse>> Delete(
        string id,
        GlobalIPAssignmentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}