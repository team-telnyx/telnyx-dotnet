using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.ExternalConnections;
using ExternalConnections = Telnyx.Sdk.Services.ExternalConnections;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class ExternalConnectionService : IExternalConnectionService
{
    readonly Lazy<IExternalConnectionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExternalConnectionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IExternalConnectionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ExternalConnectionService(this._client.WithOptions(modifier));
    }

    public ExternalConnectionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ExternalConnectionServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _logMessages =new(
            () => new ExternalConnections::LogMessageService(client)
        ) ;
        _civicAddresses =new(
            () => new ExternalConnections::CivicAddressService(client)
        ) ;
        _phoneNumbers =new(
            () => new ExternalConnections::PhoneNumberService(client)
        ) ;
        _releases =new(() => new ExternalConnections::ReleaseService(client)) ;
        _uploads =new(() => new ExternalConnections::UploadService(client)) ;
    }

    readonly Lazy<ExternalConnections::ILogMessageService> _logMessages;
    public ExternalConnections::ILogMessageService LogMessages {
        get { return _logMessages.Value; }
    }

    readonly Lazy<ExternalConnections::ICivicAddressService> _civicAddresses;
    public ExternalConnections::ICivicAddressService CivicAddresses {
        get { return _civicAddresses.Value; }
    }

    readonly Lazy<ExternalConnections::IPhoneNumberService> _phoneNumbers;
    public ExternalConnections::IPhoneNumberService PhoneNumbers {
        get { return _phoneNumbers.Value; }
    }

    readonly Lazy<ExternalConnections::IReleaseService> _releases;
    public ExternalConnections::IReleaseService Releases {
        get { return _releases.Value; }
    }

    readonly Lazy<ExternalConnections::IUploadService> _uploads;
    public ExternalConnections::IUploadService Uploads {
        get { return _uploads.Value; }
    }

    /// <inheritdoc/>
    public async Task<ExternalConnectionCreateResponse> Create(
        ExternalConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ExternalConnectionRetrieveResponse> Retrieve(
        ExternalConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ExternalConnectionRetrieveResponse> Retrieve(
        string id,
        ExternalConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExternalConnectionUpdateResponse> Update(
        ExternalConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ExternalConnectionUpdateResponse> Update(
        string id,
        ExternalConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExternalConnectionListPage> List(
        ExternalConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ExternalConnectionDeleteResponse> Delete(
        ExternalConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ExternalConnectionDeleteResponse> Delete(
        string id,
        ExternalConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExternalConnectionUpdateLocationResponse> UpdateLocation(
        ExternalConnectionUpdateLocationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.UpdateLocation(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ExternalConnectionUpdateLocationResponse> UpdateLocation(
        string locationID,
        ExternalConnectionUpdateLocationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateLocation(parameters with{
            LocationID = locationID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ExternalConnectionServiceWithRawResponse : IExternalConnectionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExternalConnectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ExternalConnectionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExternalConnectionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _logMessages =new(
            () => new ExternalConnections::LogMessageServiceWithRawResponse(
                client
            )
        ) ;
        _civicAddresses =new(
            () => new ExternalConnections::CivicAddressServiceWithRawResponse(
                client
            )
        ) ;
        _phoneNumbers =new(
            () => new ExternalConnections::PhoneNumberServiceWithRawResponse(
                client
            )
        ) ;
        _releases =new(
            () => new ExternalConnections::ReleaseServiceWithRawResponse(client)
        ) ;
        _uploads =new(
            () => new ExternalConnections::UploadServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<ExternalConnections::ILogMessageServiceWithRawResponse> _logMessages;
    public ExternalConnections::ILogMessageServiceWithRawResponse LogMessages {
        get { return _logMessages.Value; }
    }

    readonly Lazy<ExternalConnections::ICivicAddressServiceWithRawResponse> _civicAddresses;
    public ExternalConnections::ICivicAddressServiceWithRawResponse CivicAddresses {
        get { return _civicAddresses.Value; }
    }

    readonly Lazy<ExternalConnections::IPhoneNumberServiceWithRawResponse> _phoneNumbers;
    public ExternalConnections::IPhoneNumberServiceWithRawResponse PhoneNumbers {
        get { return _phoneNumbers.Value; }
    }

    readonly Lazy<ExternalConnections::IReleaseServiceWithRawResponse> _releases;
    public ExternalConnections::IReleaseServiceWithRawResponse Releases {
        get { return _releases.Value; }
    }

    readonly Lazy<ExternalConnections::IUploadServiceWithRawResponse> _uploads;
    public ExternalConnections::IUploadServiceWithRawResponse Uploads {
        get { return _uploads.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalConnectionCreateResponse>> Create(
        ExternalConnectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExternalConnectionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var externalConnection = await response.Deserialize<ExternalConnectionCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                externalConnection.Validate();
            }
            return externalConnection;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalConnectionRetrieveResponse>> Retrieve(
        ExternalConnectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ExternalConnectionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var externalConnection = await response.Deserialize<ExternalConnectionRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                externalConnection.Validate();
            }
            return externalConnection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ExternalConnectionRetrieveResponse>> Retrieve(
        string id,
        ExternalConnectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalConnectionUpdateResponse>> Update(
        ExternalConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ExternalConnectionUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var externalConnection = await response.Deserialize<ExternalConnectionUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                externalConnection.Validate();
            }
            return externalConnection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ExternalConnectionUpdateResponse>> Update(
        string id,
        ExternalConnectionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalConnectionListPage>> List(
        ExternalConnectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExternalConnectionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<ExternalConnectionListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ExternalConnectionListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalConnectionDeleteResponse>> Delete(
        ExternalConnectionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<ExternalConnectionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var externalConnection = await response.Deserialize<ExternalConnectionDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                externalConnection.Validate();
            }
            return externalConnection;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ExternalConnectionDeleteResponse>> Delete(
        string id,
        ExternalConnectionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalConnectionUpdateLocationResponse>> UpdateLocation(
        ExternalConnectionUpdateLocationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LocationID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.LocationID' cannot be null"
            );
        }

        HttpRequest<ExternalConnectionUpdateLocationParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ExternalConnectionUpdateLocationResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ExternalConnectionUpdateLocationResponse>> UpdateLocation(
        string locationID,
        ExternalConnectionUpdateLocationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateLocation(parameters with{
            LocationID = locationID
        }, cancellationToken);
    }
}