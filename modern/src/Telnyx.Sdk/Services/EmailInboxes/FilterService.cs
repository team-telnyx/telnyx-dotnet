using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailInboxes.Filters;

namespace Telnyx.Sdk.Services.EmailInboxes;

/// <inheritdoc/>
public sealed class FilterService : IFilterService
{
    readonly Lazy<IFilterServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFilterServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IFilterService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new FilterService(this._client.WithOptions(modifier)); }

    public FilterService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new FilterServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<FilterListResponse> List(
        FilterListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FilterListResponse> List(
        string inboxID,
        FilterListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            InboxID = inboxID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FilterAddResponse> Add(
        FilterAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Add(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FilterAddResponse> Add(
        string inboxID,
        FilterAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with{
            InboxID = inboxID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FilterDeleteAllResponse> DeleteAll(
        FilterDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.DeleteAll(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FilterDeleteAllResponse> DeleteAll(
        string inboxID,
        FilterDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteAll(parameters with{
            InboxID = inboxID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FilterReplaceResponse> Replace(
        FilterReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Replace(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<FilterReplaceResponse> Replace(
        string inboxID,
        FilterReplaceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Replace(parameters with{
            InboxID = inboxID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class FilterServiceWithRawResponse : IFilterServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFilterServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new FilterServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FilterServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<FilterListResponse>> List(
        FilterListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboxID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.InboxID' cannot be null"
            );
        }

        HttpRequest<FilterListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var filters = await response.Deserialize<FilterListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                filters.Validate();
            }
            return filters;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FilterListResponse>> List(
        string inboxID,
        FilterListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            InboxID = inboxID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FilterAddResponse>> Add(
        FilterAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboxID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.InboxID' cannot be null"
            );
        }

        HttpRequest<FilterAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<FilterAddResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FilterAddResponse>> Add(
        string inboxID,
        FilterAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with{
            InboxID = inboxID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FilterDeleteAllResponse>> DeleteAll(
        FilterDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboxID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.InboxID' cannot be null"
            );
        }

        HttpRequest<FilterDeleteAllParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<FilterDeleteAllResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FilterDeleteAllResponse>> DeleteAll(
        string inboxID,
        FilterDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteAll(parameters with{
            InboxID = inboxID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FilterReplaceResponse>> Replace(
        FilterReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InboxID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.InboxID' cannot be null"
            );
        }

        HttpRequest<FilterReplaceParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<FilterReplaceResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<FilterReplaceResponse>> Replace(
        string inboxID,
        FilterReplaceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Replace(parameters with{
            InboxID = inboxID
        }, cancellationToken);
    }
}