using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.MessagingProfiles;
using MessagingProfiles = Telnyx.Sdk.Services.MessagingProfiles;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class MessagingProfileService : IMessagingProfileService
{
    readonly Lazy<IMessagingProfileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMessagingProfileServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IMessagingProfileService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MessagingProfileService(this._client.WithOptions(modifier)); }

    public MessagingProfileService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MessagingProfileServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _autorespConfigs =new(
            () => new MessagingProfiles::AutorespConfigService(client)
        ) ;
        _actions =new(() => new MessagingProfiles::ActionService(client)) ;
    }

    readonly Lazy<MessagingProfiles::IAutorespConfigService> _autorespConfigs;
    public MessagingProfiles::IAutorespConfigService AutorespConfigs {
        get { return _autorespConfigs.Value; }
    }

    readonly Lazy<MessagingProfiles::IActionService> _actions;
    public MessagingProfiles::IActionService Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<MessagingProfileCreateResponse> Create(
        MessagingProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MessagingProfileRetrieveResponse> Retrieve(
        MessagingProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessagingProfileRetrieveResponse> Retrieve(
        string messagingProfileID,
        MessagingProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            MessagingProfileID = messagingProfileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessagingProfileUpdateResponse> Update(
        MessagingProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessagingProfileUpdateResponse> Update(
        string messagingProfileID,
        MessagingProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            MessagingProfileID = messagingProfileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessagingProfileListPage> List(
        MessagingProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MessagingProfileDeleteResponse> Delete(
        MessagingProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessagingProfileDeleteResponse> Delete(
        string messagingProfileID,
        MessagingProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            MessagingProfileID = messagingProfileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessagingProfileListAlphanumericSenderIdsPage> ListAlphanumericSenderIds(
        MessagingProfileListAlphanumericSenderIdsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListAlphanumericSenderIds(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessagingProfileListAlphanumericSenderIdsPage> ListAlphanumericSenderIds(
        string id,
        MessagingProfileListAlphanumericSenderIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAlphanumericSenderIds(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessagingProfileListPhoneNumbersPage> ListPhoneNumbers(
        MessagingProfileListPhoneNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListPhoneNumbers(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessagingProfileListPhoneNumbersPage> ListPhoneNumbers(
        string messagingProfileID,
        MessagingProfileListPhoneNumbersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListPhoneNumbers(parameters with{
            MessagingProfileID = messagingProfileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessagingProfileListShortCodesPage> ListShortCodes(
        MessagingProfileListShortCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListShortCodes(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessagingProfileListShortCodesPage> ListShortCodes(
        string messagingProfileID,
        MessagingProfileListShortCodesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListShortCodes(parameters with{
            MessagingProfileID = messagingProfileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessagingProfileRetrieveMetricsResponse> RetrieveMetrics(
        MessagingProfileRetrieveMetricsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveMetrics(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<MessagingProfileRetrieveMetricsResponse> RetrieveMetrics(
        string id,
        MessagingProfileRetrieveMetricsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveMetrics(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MessagingProfileServiceWithRawResponse : IMessagingProfileServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMessagingProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MessagingProfileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MessagingProfileServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _autorespConfigs =new(
            () => new MessagingProfiles::AutorespConfigServiceWithRawResponse(
                client
            )
        ) ;
        _actions =new(
            () => new MessagingProfiles::ActionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<MessagingProfiles::IAutorespConfigServiceWithRawResponse> _autorespConfigs;
    public MessagingProfiles::IAutorespConfigServiceWithRawResponse AutorespConfigs {
        get { return _autorespConfigs.Value; }
    }

    readonly Lazy<MessagingProfiles::IActionServiceWithRawResponse> _actions;
    public MessagingProfiles::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingProfileCreateResponse>> Create(
        MessagingProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MessagingProfileCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messagingProfile = await response.Deserialize<MessagingProfileCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messagingProfile.Validate();
            }
            return messagingProfile;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingProfileRetrieveResponse>> Retrieve(
        MessagingProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessagingProfileID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MessagingProfileID' cannot be null"
            );
        }

        HttpRequest<MessagingProfileRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messagingProfile = await response.Deserialize<MessagingProfileRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messagingProfile.Validate();
            }
            return messagingProfile;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessagingProfileRetrieveResponse>> Retrieve(
        string messagingProfileID,
        MessagingProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            MessagingProfileID = messagingProfileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingProfileUpdateResponse>> Update(
        MessagingProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessagingProfileID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MessagingProfileID' cannot be null"
            );
        }

        HttpRequest<MessagingProfileUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messagingProfile = await response.Deserialize<MessagingProfileUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messagingProfile.Validate();
            }
            return messagingProfile;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessagingProfileUpdateResponse>> Update(
        string messagingProfileID,
        MessagingProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            MessagingProfileID = messagingProfileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingProfileListPage>> List(
        MessagingProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MessagingProfileListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MessagingProfileListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MessagingProfileListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingProfileDeleteResponse>> Delete(
        MessagingProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessagingProfileID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MessagingProfileID' cannot be null"
            );
        }

        HttpRequest<MessagingProfileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var messagingProfile = await response.Deserialize<MessagingProfileDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                messagingProfile.Validate();
            }
            return messagingProfile;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessagingProfileDeleteResponse>> Delete(
        string messagingProfileID,
        MessagingProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            MessagingProfileID = messagingProfileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingProfileListAlphanumericSenderIdsPage>> ListAlphanumericSenderIds(
        MessagingProfileListAlphanumericSenderIdsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MessagingProfileListAlphanumericSenderIdsParams> request = new(

        )
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MessagingProfileListAlphanumericSenderIdsPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MessagingProfileListAlphanumericSenderIdsPage(this,
            parameters,
            page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessagingProfileListAlphanumericSenderIdsPage>> ListAlphanumericSenderIds(
        string id,
        MessagingProfileListAlphanumericSenderIdsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAlphanumericSenderIds(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingProfileListPhoneNumbersPage>> ListPhoneNumbers(
        MessagingProfileListPhoneNumbersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessagingProfileID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MessagingProfileID' cannot be null"
            );
        }

        HttpRequest<MessagingProfileListPhoneNumbersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MessagingProfileListPhoneNumbersPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MessagingProfileListPhoneNumbersPage(this,
            parameters,
            page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessagingProfileListPhoneNumbersPage>> ListPhoneNumbers(
        string messagingProfileID,
        MessagingProfileListPhoneNumbersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListPhoneNumbers(parameters with{
            MessagingProfileID = messagingProfileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingProfileListShortCodesPage>> ListShortCodes(
        MessagingProfileListShortCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessagingProfileID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.MessagingProfileID' cannot be null"
            );
        }

        HttpRequest<MessagingProfileListShortCodesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MessagingProfileListShortCodesPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MessagingProfileListShortCodesPage(this,
            parameters,
            page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessagingProfileListShortCodesPage>> ListShortCodes(
        string messagingProfileID,
        MessagingProfileListShortCodesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListShortCodes(parameters with{
            MessagingProfileID = messagingProfileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessagingProfileRetrieveMetricsResponse>> RetrieveMetrics(
        MessagingProfileRetrieveMetricsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<MessagingProfileRetrieveMetricsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<MessagingProfileRetrieveMetricsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<MessagingProfileRetrieveMetricsResponse>> RetrieveMetrics(
        string id,
        MessagingProfileRetrieveMetricsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveMetrics(parameters with{
            ID = id
        }, cancellationToken);
    }
}