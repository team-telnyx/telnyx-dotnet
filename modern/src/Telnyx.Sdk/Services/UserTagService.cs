using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.UserTags;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class UserTagService : IUserTagService
{
    readonly Lazy<IUserTagServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUserTagServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IUserTagService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new UserTagService(this._client.WithOptions(modifier)); }

    public UserTagService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new UserTagServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<UserTagListResponse> List(
        UserTagListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class UserTagServiceWithRawResponse : IUserTagServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUserTagServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new UserTagServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UserTagServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserTagListResponse>> List(
        UserTagListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UserTagListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var userTags = await response.Deserialize<UserTagListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                userTags.Validate();
            }
            return userTags;
        });
    }
}