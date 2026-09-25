using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Actions.Register;

namespace Telnyx.Sdk.Services.Actions;

/// <inheritdoc/>
public sealed class RegisterService : IRegisterService
{
    readonly Lazy<IRegisterServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRegisterServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRegisterService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new RegisterService(this._client.WithOptions(modifier)); }

    public RegisterService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RegisterServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<RegisterCreateResponse> Create(
        RegisterCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RegisterServiceWithRawResponse : IRegisterServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRegisterServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RegisterServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RegisterServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<RegisterCreateResponse>> Create(
        RegisterCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RegisterCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var register = await response.Deserialize<RegisterCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                register.Validate();
            }
            return register;
        });
    }
}