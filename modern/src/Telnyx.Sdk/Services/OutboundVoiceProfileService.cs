using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.OutboundVoiceProfiles;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class OutboundVoiceProfileService : IOutboundVoiceProfileService
{
    readonly Lazy<IOutboundVoiceProfileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOutboundVoiceProfileServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IOutboundVoiceProfileService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new OutboundVoiceProfileService(this._client.WithOptions(modifier));
    }

    public OutboundVoiceProfileService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new OutboundVoiceProfileServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<OutboundVoiceProfileCreateResponse> Create(
        OutboundVoiceProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<OutboundVoiceProfileRetrieveResponse> Retrieve(
        OutboundVoiceProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<OutboundVoiceProfileRetrieveResponse> Retrieve(
        string id,
        OutboundVoiceProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<OutboundVoiceProfileUpdateResponse> Update(
        OutboundVoiceProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<OutboundVoiceProfileUpdateResponse> Update(
        string id,
        OutboundVoiceProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<OutboundVoiceProfileListPage> List(
        OutboundVoiceProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<OutboundVoiceProfileDeleteResponse> Delete(
        OutboundVoiceProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<OutboundVoiceProfileDeleteResponse> Delete(
        string id,
        OutboundVoiceProfileDeleteParams? parameters = null,
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
public sealed class OutboundVoiceProfileServiceWithRawResponse : IOutboundVoiceProfileServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOutboundVoiceProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new OutboundVoiceProfileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OutboundVoiceProfileServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<OutboundVoiceProfileCreateResponse>> Create(
        OutboundVoiceProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<OutboundVoiceProfileCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var outboundVoiceProfile = await response.Deserialize<OutboundVoiceProfileCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                outboundVoiceProfile.Validate();
            }
            return outboundVoiceProfile;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OutboundVoiceProfileRetrieveResponse>> Retrieve(
        OutboundVoiceProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<OutboundVoiceProfileRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var outboundVoiceProfile = await response.Deserialize<OutboundVoiceProfileRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                outboundVoiceProfile.Validate();
            }
            return outboundVoiceProfile;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<OutboundVoiceProfileRetrieveResponse>> Retrieve(
        string id,
        OutboundVoiceProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OutboundVoiceProfileUpdateResponse>> Update(
        OutboundVoiceProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<OutboundVoiceProfileUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var outboundVoiceProfile = await response.Deserialize<OutboundVoiceProfileUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                outboundVoiceProfile.Validate();
            }
            return outboundVoiceProfile;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<OutboundVoiceProfileUpdateResponse>> Update(
        string id,
        OutboundVoiceProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OutboundVoiceProfileListPage>> List(
        OutboundVoiceProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<OutboundVoiceProfileListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<OutboundVoiceProfileListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new OutboundVoiceProfileListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OutboundVoiceProfileDeleteResponse>> Delete(
        OutboundVoiceProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<OutboundVoiceProfileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var outboundVoiceProfile = await response.Deserialize<OutboundVoiceProfileDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                outboundVoiceProfile.Validate();
            }
            return outboundVoiceProfile;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<OutboundVoiceProfileDeleteResponse>> Delete(
        string id,
        OutboundVoiceProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}