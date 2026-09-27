using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Legacy.Reporting.BatchDetailRecords.SpeechToText;

namespace Telnyx.Sdk.Services.Legacy.Reporting.BatchDetailRecords;

/// <inheritdoc/>
public sealed class SpeechToTextService : ISpeechToTextService
{
    readonly Lazy<ISpeechToTextServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISpeechToTextServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ISpeechToTextService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new SpeechToTextService(this._client.WithOptions(modifier)); }

    public SpeechToTextService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new SpeechToTextServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<SpeechToTextCreateResponse> Create(
        SpeechToTextCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SpeechToTextRetrieveResponse> Retrieve(
        SpeechToTextRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SpeechToTextRetrieveResponse> Retrieve(
        string id,
        SpeechToTextRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SpeechToTextListResponse> List(
        SpeechToTextListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SpeechToTextDeleteResponse> Delete(
        SpeechToTextDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<SpeechToTextDeleteResponse> Delete(
        string id,
        SpeechToTextDeleteParams? parameters = null,
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
public sealed class SpeechToTextServiceWithRawResponse : ISpeechToTextServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISpeechToTextServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SpeechToTextServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SpeechToTextServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<SpeechToTextCreateResponse>> Create(
        SpeechToTextCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SpeechToTextCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var speechToText = await response.Deserialize<SpeechToTextCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                speechToText.Validate();
            }
            return speechToText;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SpeechToTextRetrieveResponse>> Retrieve(
        SpeechToTextRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SpeechToTextRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var speechToText = await response.Deserialize<SpeechToTextRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                speechToText.Validate();
            }
            return speechToText;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SpeechToTextRetrieveResponse>> Retrieve(
        string id,
        SpeechToTextRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SpeechToTextListResponse>> List(
        SpeechToTextListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SpeechToTextListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var speechToTexts = await response.Deserialize<SpeechToTextListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                speechToTexts.Validate();
            }
            return speechToTexts;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SpeechToTextDeleteResponse>> Delete(
        SpeechToTextDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<SpeechToTextDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var speechToText = await response.Deserialize<SpeechToTextDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                speechToText.Validate();
            }
            return speechToText;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<SpeechToTextDeleteResponse>> Delete(
        string id,
        SpeechToTextDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }
}