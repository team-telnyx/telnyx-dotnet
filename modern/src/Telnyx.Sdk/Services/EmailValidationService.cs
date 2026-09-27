using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailValidations;
using Telnyx.Sdk.Services.EmailValidations;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class EmailValidationService : IEmailValidationService
{
    readonly Lazy<IEmailValidationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEmailValidationServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IEmailValidationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new EmailValidationService(this._client.WithOptions(modifier)); }

    public EmailValidationService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new EmailValidationServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _batch =new(() => new BatchService(client)) ;
    }

    readonly Lazy<IBatchService> _batch;
    public IBatchService Batch { get { return _batch.Value; } }

    /// <inheritdoc/>
    public async Task<EmailValidationCreateResponse> Create(
        EmailValidationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class EmailValidationServiceWithRawResponse : IEmailValidationServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEmailValidationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EmailValidationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EmailValidationServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _batch =new(() => new BatchServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IBatchServiceWithRawResponse> _batch;
    public IBatchServiceWithRawResponse Batch { get { return _batch.Value; } }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailValidationCreateResponse>> Create(
        EmailValidationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EmailValidationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailValidation = await response.Deserialize<EmailValidationCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailValidation.Validate();
            }
            return emailValidation;
        });
    }
}