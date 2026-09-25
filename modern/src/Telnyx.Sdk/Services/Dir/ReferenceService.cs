using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Dir.References;

namespace Telnyx.Sdk.Services.Dir;

/// <inheritdoc/>
public sealed class ReferenceService : IReferenceService
{
    readonly Lazy<IReferenceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IReferenceServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IReferenceService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ReferenceService(this._client.WithOptions(modifier)); }

    public ReferenceService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ReferenceServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ReferenceList> Create(
        ReferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ReferenceList> Create(
        string dirID,
        ReferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ReferenceUpdateResponse> Update(
        ReferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ReferenceUpdateResponse> Update(
        long slot,
        ReferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            Slot = slot
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ReferenceList> List(
        ReferenceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ReferenceList> List(
        string dirID,
        ReferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            DirID = dirID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ReferenceServiceWithRawResponse : IReferenceServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IReferenceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ReferenceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ReferenceServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReferenceList>> Create(
        ReferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DirID' cannot be null"
            );
        }

        HttpRequest<ReferenceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var referenceList = await response.Deserialize<ReferenceList>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                referenceList.Validate();
            }
            return referenceList;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ReferenceList>> Create(
        string dirID,
        ReferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReferenceUpdateResponse>> Update(
        ReferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Slot == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Slot' cannot be null"
            );
        }

        HttpRequest<ReferenceUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var reference = await response.Deserialize<ReferenceUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                reference.Validate();
            }
            return reference;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ReferenceUpdateResponse>> Update(
        long slot,
        ReferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            Slot = slot
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReferenceList>> List(
        ReferenceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DirID' cannot be null"
            );
        }

        HttpRequest<ReferenceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var referenceList = await response.Deserialize<ReferenceList>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                referenceList.Validate();
            }
            return referenceList;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ReferenceList>> List(
        string dirID,
        ReferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            DirID = dirID
        }, cancellationToken);
    }
}