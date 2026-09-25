using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Whatsapp.PhoneNumbers.ConversationalComponents;

namespace Telnyx.Sdk.Services.Whatsapp.PhoneNumbers;

/// <inheritdoc/>
public sealed class ConversationalComponentService : IConversationalComponentService
{
    readonly Lazy<IConversationalComponentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IConversationalComponentServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IConversationalComponentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ConversationalComponentService(this._client.WithOptions(modifier));
    }

    public ConversationalComponentService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ConversationalComponentServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ConversationalComponentListResponse> List(
        ConversationalComponentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ConversationalComponentListResponse> List(
        string phoneNumber,
        ConversationalComponentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ConversationalComponentPatchAllResponse> PatchAll(
        ConversationalComponentPatchAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.PatchAll(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ConversationalComponentPatchAllResponse> PatchAll(
        string phoneNumber,
        ConversationalComponentPatchAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.PatchAll(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ConversationalComponentServiceWithRawResponse : IConversationalComponentServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IConversationalComponentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ConversationalComponentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ConversationalComponentServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConversationalComponentListResponse>> List(
        ConversationalComponentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<ConversationalComponentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var conversationalComponents = await response.Deserialize<ConversationalComponentListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                conversationalComponents.Validate();
            }
            return conversationalComponents;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ConversationalComponentListResponse>> List(
        string phoneNumber,
        ConversationalComponentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConversationalComponentPatchAllResponse>> PatchAll(
        ConversationalComponentPatchAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<ConversationalComponentPatchAllParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ConversationalComponentPatchAllResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ConversationalComponentPatchAllResponse>> PatchAll(
        string phoneNumber,
        ConversationalComponentPatchAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.PatchAll(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }
}