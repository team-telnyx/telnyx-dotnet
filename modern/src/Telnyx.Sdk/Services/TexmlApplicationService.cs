using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.TexmlApplications;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class TexmlApplicationService : ITexmlApplicationService
{
    readonly Lazy<ITexmlApplicationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITexmlApplicationServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ITexmlApplicationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new TexmlApplicationService(this._client.WithOptions(modifier)); }

    public TexmlApplicationService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new TexmlApplicationServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<TexmlApplicationCreateResponse> Create(
        TexmlApplicationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TexmlApplicationRetrieveResponse> Retrieve(
        TexmlApplicationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TexmlApplicationRetrieveResponse> Retrieve(
        string id,
        TexmlApplicationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TexmlApplicationUpdateResponse> Update(
        TexmlApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TexmlApplicationUpdateResponse> Update(
        string id,
        TexmlApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TexmlApplicationListPage> List(
        TexmlApplicationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TexmlApplicationDeleteResponse> Delete(
        TexmlApplicationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TexmlApplicationDeleteResponse> Delete(
        string id,
        TexmlApplicationDeleteParams? parameters = null,
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
public sealed class TexmlApplicationServiceWithRawResponse : ITexmlApplicationServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITexmlApplicationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TexmlApplicationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TexmlApplicationServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<TexmlApplicationCreateResponse>> Create(
        TexmlApplicationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TexmlApplicationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var texmlApplication = await response.Deserialize<TexmlApplicationCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                texmlApplication.Validate();
            }
            return texmlApplication;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TexmlApplicationRetrieveResponse>> Retrieve(
        TexmlApplicationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<TexmlApplicationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var texmlApplication = await response.Deserialize<TexmlApplicationRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                texmlApplication.Validate();
            }
            return texmlApplication;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TexmlApplicationRetrieveResponse>> Retrieve(
        string id,
        TexmlApplicationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TexmlApplicationUpdateResponse>> Update(
        TexmlApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<TexmlApplicationUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var texmlApplication = await response.Deserialize<TexmlApplicationUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                texmlApplication.Validate();
            }
            return texmlApplication;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TexmlApplicationUpdateResponse>> Update(
        string id,
        TexmlApplicationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TexmlApplicationListPage>> List(
        TexmlApplicationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TexmlApplicationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<TexmlApplicationListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new TexmlApplicationListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TexmlApplicationDeleteResponse>> Delete(
        TexmlApplicationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<TexmlApplicationDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var texmlApplication = await response.Deserialize<TexmlApplicationDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                texmlApplication.Validate();
            }
            return texmlApplication;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TexmlApplicationDeleteResponse>> Delete(
        string id,
        TexmlApplicationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}