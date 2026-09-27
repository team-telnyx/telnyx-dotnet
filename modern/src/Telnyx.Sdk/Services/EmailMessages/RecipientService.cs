using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailMessages.Recipients;

namespace Telnyx.Sdk.Services.EmailMessages;

/// <inheritdoc/>
public sealed class RecipientService : IRecipientService
{
    readonly Lazy<IRecipientServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRecipientServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRecipientService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new RecipientService(this._client.WithOptions(modifier)); }

    public RecipientService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RecipientServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<RecipientRetrieveResponse> Retrieve(
        RecipientRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RecipientRetrieveResponse> Retrieve(
        string recipientID,
        RecipientRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            RecipientID = recipientID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RecipientListPage> List(
        RecipientListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<RecipientListPage> List(
        string emailID,
        RecipientListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            EmailID = emailID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class RecipientServiceWithRawResponse : IRecipientServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRecipientServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RecipientServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RecipientServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<RecipientRetrieveResponse>> Retrieve(
        RecipientRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RecipientID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.RecipientID' cannot be null"
            );
        }

        HttpRequest<RecipientRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var recipient = await response.Deserialize<RecipientRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                recipient.Validate();
            }
            return recipient;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RecipientRetrieveResponse>> Retrieve(
        string recipientID,
        RecipientRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            RecipientID = recipientID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RecipientListPage>> List(
        RecipientListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EmailID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EmailID' cannot be null"
            );
        }

        HttpRequest<RecipientListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<RecipientListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new RecipientListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<RecipientListPage>> List(
        string emailID,
        RecipientListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            EmailID = emailID
        }, cancellationToken);
    }
}