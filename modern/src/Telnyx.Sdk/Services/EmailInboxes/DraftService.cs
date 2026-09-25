using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailInboxes.Drafts;

namespace Telnyx.Sdk.Services.EmailInboxes;

/// <inheritdoc/>
public sealed class DraftService : IDraftService
{
    readonly Lazy<IDraftServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDraftServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IDraftService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new DraftService(this._client.WithOptions(modifier)); }

    public DraftService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new DraftServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<EmailDraftResponse> Create(
        DraftCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailDraftResponse> Create(
        string inboxID,
        DraftCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            InboxID = inboxID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailDraftResponse> Retrieve(
        DraftRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailDraftResponse> Retrieve(
        string draftID,
        DraftRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            DraftID = draftID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailDraftResponse> Update(
        DraftUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailDraftResponse> Update(
        string draftID,
        DraftUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            DraftID = draftID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DraftListPage> List(
        DraftListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DraftListPage> List(
        string inboxID,
        DraftListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            InboxID = inboxID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        DraftDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string draftID,
        DraftDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with{
            DraftID = draftID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EmailDraftResponse> Patch(
        DraftPatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Patch(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailDraftResponse> Patch(
        string draftID,
        DraftPatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Patch(parameters with{
            DraftID = draftID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailMessageResponse> Send(
        DraftSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Send(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailMessageResponse> Send(
        string draftID,
        DraftSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Send(parameters with{
            DraftID = draftID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DraftServiceWithRawResponse : IDraftServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDraftServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DraftServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DraftServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailDraftResponse>> Create(
        DraftCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboxID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.InboxID' cannot be null"
            );
        }

        HttpRequest<DraftCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailDraftResponse = await response.Deserialize<EmailDraftResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailDraftResponse.Validate();
            }
            return emailDraftResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailDraftResponse>> Create(
        string inboxID,
        DraftCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            InboxID = inboxID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailDraftResponse>> Retrieve(
        DraftRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DraftID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DraftID' cannot be null"
            );
        }

        HttpRequest<DraftRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailDraftResponse = await response.Deserialize<EmailDraftResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailDraftResponse.Validate();
            }
            return emailDraftResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailDraftResponse>> Retrieve(
        string draftID,
        DraftRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            DraftID = draftID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailDraftResponse>> Update(
        DraftUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DraftID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DraftID' cannot be null"
            );
        }

        HttpRequest<DraftUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailDraftResponse = await response.Deserialize<EmailDraftResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailDraftResponse.Validate();
            }
            return emailDraftResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailDraftResponse>> Update(
        string draftID,
        DraftUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            DraftID = draftID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DraftListPage>> List(
        DraftListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboxID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.InboxID' cannot be null"
            );
        }

        HttpRequest<DraftListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<DraftListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new DraftListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DraftListPage>> List(
        string inboxID,
        DraftListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            InboxID = inboxID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        DraftDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DraftID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DraftID' cannot be null"
            );
        }

        HttpRequest<DraftDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string draftID,
        DraftDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            DraftID = draftID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailDraftResponse>> Patch(
        DraftPatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DraftID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DraftID' cannot be null"
            );
        }

        HttpRequest<DraftPatchParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailDraftResponse = await response.Deserialize<EmailDraftResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailDraftResponse.Validate();
            }
            return emailDraftResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailDraftResponse>> Patch(
        string draftID,
        DraftPatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Patch(parameters with{
            DraftID = draftID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailMessageResponse>> Send(
        DraftSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DraftID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DraftID' cannot be null"
            );
        }

        HttpRequest<DraftSendParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailMessageResponse = await response.Deserialize<EmailMessageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailMessageResponse.Validate();
            }
            return emailMessageResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailMessageResponse>> Send(
        string draftID,
        DraftSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Send(parameters with{
            DraftID = draftID
        }, cancellationToken);
    }
}