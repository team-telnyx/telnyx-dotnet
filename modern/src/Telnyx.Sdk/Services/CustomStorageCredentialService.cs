using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.CustomStorageCredentials;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class CustomStorageCredentialService : ICustomStorageCredentialService
{
    readonly Lazy<ICustomStorageCredentialServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICustomStorageCredentialServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICustomStorageCredentialService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CustomStorageCredentialService(this._client.WithOptions(modifier));
    }

    public CustomStorageCredentialService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CustomStorageCredentialServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<CredentialsResponse> Create(
        CustomStorageCredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CredentialsResponse> Create(
        string connectionID,
        CustomStorageCredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CredentialsResponse> Retrieve(
        CustomStorageCredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CredentialsResponse> Retrieve(
        string connectionID,
        CustomStorageCredentialRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CredentialsResponse> Update(
        CustomStorageCredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CredentialsResponse> Update(
        string connectionID,
        CustomStorageCredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        CustomStorageCredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string connectionID,
        CustomStorageCredentialDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            ConnectionID = connectionID
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CustomStorageCredentialServiceWithRawResponse : ICustomStorageCredentialServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICustomStorageCredentialServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CustomStorageCredentialServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CustomStorageCredentialServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<CredentialsResponse>> Create(
        CustomStorageCredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConnectionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConnectionID' cannot be null"
            );
        }

        HttpRequest<CustomStorageCredentialCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var credentialsResponse = await response.Deserialize<CredentialsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                credentialsResponse.Validate();
            }
            return credentialsResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CredentialsResponse>> Create(
        string connectionID,
        CustomStorageCredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CredentialsResponse>> Retrieve(
        CustomStorageCredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConnectionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConnectionID' cannot be null"
            );
        }

        HttpRequest<CustomStorageCredentialRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var credentialsResponse = await response.Deserialize<CredentialsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                credentialsResponse.Validate();
            }
            return credentialsResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CredentialsResponse>> Retrieve(
        string connectionID,
        CustomStorageCredentialRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CredentialsResponse>> Update(
        CustomStorageCredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConnectionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConnectionID' cannot be null"
            );
        }

        HttpRequest<CustomStorageCredentialUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var credentialsResponse = await response.Deserialize<CredentialsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                credentialsResponse.Validate();
            }
            return credentialsResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CredentialsResponse>> Update(
        string connectionID,
        CustomStorageCredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        CustomStorageCredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConnectionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConnectionID' cannot be null"
            );
        }

        HttpRequest<CustomStorageCredentialDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string connectionID,
        CustomStorageCredentialDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }
}