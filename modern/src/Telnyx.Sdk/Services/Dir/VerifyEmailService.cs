using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Dir.VerifyEmail;

namespace Telnyx.Sdk.Services.Dir;

/// <inheritdoc/>
public sealed class VerifyEmailService : IVerifyEmailService
{
    readonly Lazy<IVerifyEmailServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVerifyEmailServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IVerifyEmailService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new VerifyEmailService(this._client.WithOptions(modifier)); }

    public VerifyEmailService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new VerifyEmailServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<EmailVerificationStatusWrapped> Create(
        VerifyEmailCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailVerificationStatusWrapped> Create(
        string dirID,
        VerifyEmailCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailVerificationStatusWrapped> List(
        VerifyEmailListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailVerificationStatusWrapped> List(
        string dirID,
        VerifyEmailListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailVerificationStatusWrapped> Confirm(
        VerifyEmailConfirmParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Confirm(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EmailVerificationStatusWrapped> Confirm(
        string dirID,
        VerifyEmailConfirmParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Confirm(parameters with{
            DirID = dirID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class VerifyEmailServiceWithRawResponse : IVerifyEmailServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVerifyEmailServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new VerifyEmailServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VerifyEmailServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailVerificationStatusWrapped>> Create(
        VerifyEmailCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DirID' cannot be null"
            );
        }

        HttpRequest<VerifyEmailCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailVerificationStatusWrapped = await response.Deserialize<EmailVerificationStatusWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailVerificationStatusWrapped.Validate();
            }
            return emailVerificationStatusWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailVerificationStatusWrapped>> Create(
        string dirID,
        VerifyEmailCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailVerificationStatusWrapped>> List(
        VerifyEmailListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DirID' cannot be null"
            );
        }

        HttpRequest<VerifyEmailListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailVerificationStatusWrapped = await response.Deserialize<EmailVerificationStatusWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailVerificationStatusWrapped.Validate();
            }
            return emailVerificationStatusWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailVerificationStatusWrapped>> List(
        string dirID,
        VerifyEmailListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailVerificationStatusWrapped>> Confirm(
        VerifyEmailConfirmParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DirID' cannot be null"
            );
        }

        HttpRequest<VerifyEmailConfirmParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var emailVerificationStatusWrapped = await response.Deserialize<EmailVerificationStatusWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                emailVerificationStatusWrapped.Validate();
            }
            return emailVerificationStatusWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EmailVerificationStatusWrapped>> Confirm(
        string dirID,
        VerifyEmailConfirmParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Confirm(parameters with{
            DirID = dirID
        }, cancellationToken);
    }
}