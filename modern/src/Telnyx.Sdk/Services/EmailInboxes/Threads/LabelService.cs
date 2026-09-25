using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailInboxes.Threads.Labels;

namespace Telnyx.Sdk.Services.EmailInboxes.Threads;

/// <inheritdoc/>
public sealed class LabelService : ILabelService
{
    readonly Lazy<ILabelServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILabelServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ILabelService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new LabelService(this._client.WithOptions(modifier)); }

    public LabelService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new LabelServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<LabelCreateResponse> Create(
        LabelCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<LabelCreateResponse> Create(
        string threadID,
        LabelCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ThreadID = threadID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LabelDeleteAllResponse> DeleteAll(
        LabelDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.DeleteAll(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<LabelDeleteAllResponse> DeleteAll(
        string threadID,
        LabelDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteAll(parameters with{
            ThreadID = threadID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class LabelServiceWithRawResponse : ILabelServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILabelServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new LabelServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LabelServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<LabelCreateResponse>> Create(
        LabelCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ThreadID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ThreadID' cannot be null"
            );
        }

        HttpRequest<LabelCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var label = await response.Deserialize<LabelCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                label.Validate();
            }
            return label;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<LabelCreateResponse>> Create(
        string threadID,
        LabelCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ThreadID = threadID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LabelDeleteAllResponse>> DeleteAll(
        LabelDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ThreadID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ThreadID' cannot be null"
            );
        }

        HttpRequest<LabelDeleteAllParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<LabelDeleteAllResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<LabelDeleteAllResponse>> DeleteAll(
        string threadID,
        LabelDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteAll(parameters with{
            ThreadID = threadID
        }, cancellationToken);
    }
}