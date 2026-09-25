using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Porting.LoaConfigurations;

namespace Telnyx.Sdk.Services.Porting;

/// <inheritdoc/>
public sealed class LoaConfigurationService : ILoaConfigurationService
{
    readonly Lazy<ILoaConfigurationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILoaConfigurationServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ILoaConfigurationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new LoaConfigurationService(this._client.WithOptions(modifier)); }

    public LoaConfigurationService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new LoaConfigurationServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<LoaConfigurationCreateResponse> Create(
        LoaConfigurationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<LoaConfigurationRetrieveResponse> Retrieve(
        LoaConfigurationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<LoaConfigurationRetrieveResponse> Retrieve(
        string id,
        LoaConfigurationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LoaConfigurationUpdateResponse> Update(
        LoaConfigurationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<LoaConfigurationUpdateResponse> Update(
        string id,
        LoaConfigurationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LoaConfigurationListPage> List(
        LoaConfigurationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        LoaConfigurationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string id,
        LoaConfigurationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            ID = id
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Preview(
        LoaConfigurationPreviewParams parameters,
        CancellationToken cancellationToken = default
    )
    { return this.WithRawResponse.Preview(parameters, cancellationToken); }

    /// <inheritdoc/>
    public Task<HttpResponse> Preview0(
        LoaConfigurationPreview0Params parameters,
        CancellationToken cancellationToken = default
    )
    { return this.WithRawResponse.Preview0(parameters, cancellationToken); }

    /// <inheritdoc/>
    public Task<HttpResponse> Preview1(
        LoaConfigurationPreview1Params parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Preview1(parameters, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Preview1(
        string id,
        LoaConfigurationPreview1Params? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Preview1(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class LoaConfigurationServiceWithRawResponse : ILoaConfigurationServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILoaConfigurationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new LoaConfigurationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LoaConfigurationServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<LoaConfigurationCreateResponse>> Create(
        LoaConfigurationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<LoaConfigurationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var loaConfiguration = await response.Deserialize<LoaConfigurationCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                loaConfiguration.Validate();
            }
            return loaConfiguration;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LoaConfigurationRetrieveResponse>> Retrieve(
        LoaConfigurationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<LoaConfigurationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var loaConfiguration = await response.Deserialize<LoaConfigurationRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                loaConfiguration.Validate();
            }
            return loaConfiguration;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<LoaConfigurationRetrieveResponse>> Retrieve(
        string id,
        LoaConfigurationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LoaConfigurationUpdateResponse>> Update(
        LoaConfigurationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<LoaConfigurationUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var loaConfiguration = await response.Deserialize<LoaConfigurationUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                loaConfiguration.Validate();
            }
            return loaConfiguration;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<LoaConfigurationUpdateResponse>> Update(
        string id,
        LoaConfigurationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LoaConfigurationListPage>> List(
        LoaConfigurationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<LoaConfigurationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<LoaConfigurationListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new LoaConfigurationListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        LoaConfigurationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<LoaConfigurationDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        LoaConfigurationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Preview(
        LoaConfigurationPreviewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<LoaConfigurationPreviewParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Preview0(
        LoaConfigurationPreview0Params parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<LoaConfigurationPreview0Params> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Preview1(
        LoaConfigurationPreview1Params parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<LoaConfigurationPreview1Params> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Preview1(
        string id,
        LoaConfigurationPreview1Params? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Preview1(parameters with{
            ID = id
        }, cancellationToken);
    }
}