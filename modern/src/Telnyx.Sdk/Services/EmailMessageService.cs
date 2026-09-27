using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailInboxes.Drafts;
using Telnyx.Sdk.Models.EmailMessages;
using Telnyx.Sdk.Services.EmailMessages;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class EmailMessageService : IEmailMessageService
{
    readonly Lazy<IEmailMessageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEmailMessageServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IEmailMessageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new EmailMessageService(this._client.WithOptions(modifier)); }

    public EmailMessageService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new EmailMessageServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _recipients =new(() => new RecipientService(client)) ;
    }

    readonly Lazy<IRecipientService> _recipients;
    public IRecipientService Recipients { get { return _recipients.Value; } }

    /// <inheritdoc/>
    public async Task<EmailMessageResponse> Create(
        EmailMessageCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EmailMessageDetailResponse> Retrieve(
        EmailMessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailMessageDetailResponse> Retrieve(
        string id,
        EmailMessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailMessageListPage> List(
        EmailMessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        EmailMessageDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string id,
        EmailMessageDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            ID = id
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EmailMessageBatchResponse> Batch(
        EmailMessageBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Batch(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task DeleteAll(
        EmailMessageDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    { return this.WithRawResponse.DeleteAll(parameters, cancellationToken); }

    /// <inheritdoc/>
    public async Task<EmailMessageResponse> DeleteSchedule(
        EmailMessageDeleteScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.DeleteSchedule(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailMessageResponse> DeleteSchedule(
        string emailID,
        EmailMessageDeleteScheduleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DeleteSchedule(parameters with{
            EmailID = emailID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailMessageRetrieveEventsPage> RetrieveEvents(
        EmailMessageRetrieveEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveEvents(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailMessageRetrieveEventsPage> RetrieveEvents(
        string emailID,
        EmailMessageRetrieveEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveEvents(parameters with{
            EmailID = emailID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailMessageDetailResponse> UpdateSchedule(
        EmailMessageUpdateScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.UpdateSchedule(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailMessageDetailResponse> UpdateSchedule(
        string emailID,
        EmailMessageUpdateScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateSchedule(parameters with{
            EmailID = emailID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class EmailMessageServiceWithRawResponse : IEmailMessageServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEmailMessageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EmailMessageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EmailMessageServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _recipients =new(() => new RecipientServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IRecipientServiceWithRawResponse> _recipients;
    public IRecipientServiceWithRawResponse Recipients {
        get { return _recipients.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailMessageResponse>> Create(
        EmailMessageCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EmailMessageCreateParams> request = new()
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
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailMessageDetailResponse>> Retrieve(
        EmailMessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailMessageRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailMessageDetailResponse = await response.Deserialize<EmailMessageDetailResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailMessageDetailResponse.Validate();
            }
            return emailMessageDetailResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailMessageDetailResponse>> Retrieve(
        string id,
        EmailMessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailMessageListPage>> List(
        EmailMessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EmailMessageListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<EmailMessageListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new EmailMessageListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        EmailMessageDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<EmailMessageDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        EmailMessageDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailMessageBatchResponse>> Batch(
        EmailMessageBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EmailMessageBatchParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<EmailMessageBatchResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteAll(
        EmailMessageDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EmailMessageDeleteAllParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailMessageResponse>> DeleteSchedule(
        EmailMessageDeleteScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EmailID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EmailID' cannot be null"
            );
        }

        HttpRequest<EmailMessageDeleteScheduleParams> request = new()
        {
            Method = HttpMethod.Delete,
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
    public Task<HttpResponse<EmailMessageResponse>> DeleteSchedule(
        string emailID,
        EmailMessageDeleteScheduleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DeleteSchedule(parameters with{
            EmailID = emailID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailMessageRetrieveEventsPage>> RetrieveEvents(
        EmailMessageRetrieveEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EmailID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EmailID' cannot be null"
            );
        }

        HttpRequest<EmailMessageRetrieveEventsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<EmailMessageRetrieveEventsPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new EmailMessageRetrieveEventsPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailMessageRetrieveEventsPage>> RetrieveEvents(
        string emailID,
        EmailMessageRetrieveEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveEvents(parameters with{
            EmailID = emailID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailMessageDetailResponse>> UpdateSchedule(
        EmailMessageUpdateScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EmailID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EmailID' cannot be null"
            );
        }

        HttpRequest<EmailMessageUpdateScheduleParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailMessageDetailResponse = await response.Deserialize<EmailMessageDetailResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailMessageDetailResponse.Validate();
            }
            return emailMessageDetailResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailMessageDetailResponse>> UpdateSchedule(
        string emailID,
        EmailMessageUpdateScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateSchedule(parameters with{
            EmailID = emailID
        }, cancellationToken);
    }
}