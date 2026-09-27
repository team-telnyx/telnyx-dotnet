using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Memory.Namespaces;
using Telnyx.Sdk.Services.AI.Memory.Namespaces;

namespace Telnyx.Sdk.Services.AI.Memory;

/// <inheritdoc/>
public sealed class NamespaceService : INamespaceService
{
    readonly Lazy<INamespaceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INamespaceServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public INamespaceService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new NamespaceService(this._client.WithOptions(modifier)); }

    public NamespaceService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new NamespaceServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _profiles =new(() => new ProfileService(client)) ;
        _settings =new(() => new SettingService(client)) ;
    }

    readonly Lazy<IProfileService> _profiles;
    public IProfileService Profiles { get { return _profiles.Value; } }

    readonly Lazy<ISettingService> _settings;
    public ISettingService Settings { get { return _settings.Value; } }

    /// <inheritdoc/>
    public async Task<NamespaceRetrieveResponse> Retrieve(
        NamespaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NamespaceRetrieveResponse> Retrieve(
        string operationID,
        NamespaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            OperationID = operationID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class NamespaceServiceWithRawResponse : INamespaceServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public INamespaceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NamespaceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NamespaceServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _profiles =new(() => new ProfileServiceWithRawResponse(client)) ;
        _settings =new(() => new SettingServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IProfileServiceWithRawResponse> _profiles;
    public IProfileServiceWithRawResponse Profiles {
        get { return _profiles.Value; }
    }

    readonly Lazy<ISettingServiceWithRawResponse> _settings;
    public ISettingServiceWithRawResponse Settings {
        get { return _settings.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NamespaceRetrieveResponse>> Retrieve(
        NamespaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.OperationID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.OperationID' cannot be null"
            );
        }

        HttpRequest<NamespaceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<NamespaceRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NamespaceRetrieveResponse>> Retrieve(
        string operationID,
        NamespaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            OperationID = operationID
        }, cancellationToken);
    }
}