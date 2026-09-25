using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.DialogflowConnections;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class DialogflowConnectionService : IDialogflowConnectionService
{
    readonly Lazy<IDialogflowConnectionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDialogflowConnectionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IDialogflowConnectionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DialogflowConnectionService(this._client.WithOptions(modifier));
    }

    public DialogflowConnectionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new DialogflowConnectionServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<DialogflowConnectionResponse> Create(
        DialogflowConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DialogflowConnectionResponse> Create(
        string connectionID,
        DialogflowConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DialogflowConnectionResponse> Retrieve(
        DialogflowConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DialogflowConnectionResponse> Retrieve(
        string connectionID,
        DialogflowConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DialogflowConnectionResponse> Update(
        DialogflowConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DialogflowConnectionResponse> Update(
        string connectionID,
        DialogflowConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        DialogflowConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string connectionID,
        DialogflowConnectionDeleteParams? parameters = null,
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
public sealed class DialogflowConnectionServiceWithRawResponse : IDialogflowConnectionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDialogflowConnectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DialogflowConnectionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DialogflowConnectionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<DialogflowConnectionResponse>> Create(
        DialogflowConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConnectionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConnectionID' cannot be null"
            );
        }

        HttpRequest<DialogflowConnectionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var dialogflowConnectionResponse = await response.Deserialize<DialogflowConnectionResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                dialogflowConnectionResponse.Validate();
            }
            return dialogflowConnectionResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DialogflowConnectionResponse>> Create(
        string connectionID,
        DialogflowConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DialogflowConnectionResponse>> Retrieve(
        DialogflowConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConnectionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConnectionID' cannot be null"
            );
        }

        HttpRequest<DialogflowConnectionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var dialogflowConnectionResponse = await response.Deserialize<DialogflowConnectionResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                dialogflowConnectionResponse.Validate();
            }
            return dialogflowConnectionResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DialogflowConnectionResponse>> Retrieve(
        string connectionID,
        DialogflowConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DialogflowConnectionResponse>> Update(
        DialogflowConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConnectionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConnectionID' cannot be null"
            );
        }

        HttpRequest<DialogflowConnectionUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var dialogflowConnectionResponse = await response.Deserialize<DialogflowConnectionResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                dialogflowConnectionResponse.Validate();
            }
            return dialogflowConnectionResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DialogflowConnectionResponse>> Update(
        string connectionID,
        DialogflowConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        DialogflowConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConnectionID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ConnectionID' cannot be null"
            );
        }

        HttpRequest<DialogflowConnectionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string connectionID,
        DialogflowConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ConnectionID = connectionID
        }, cancellationToken);
    }
}