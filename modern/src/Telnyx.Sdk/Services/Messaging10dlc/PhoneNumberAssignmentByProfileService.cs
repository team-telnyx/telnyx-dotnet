using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Messaging10dlc.PhoneNumberAssignmentByProfile;

namespace Telnyx.Sdk.Services.Messaging10dlc;

/// <inheritdoc/>
public sealed class PhoneNumberAssignmentByProfileService : IPhoneNumberAssignmentByProfileService
{
    readonly Lazy<IPhoneNumberAssignmentByProfileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPhoneNumberAssignmentByProfileServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPhoneNumberAssignmentByProfileService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhoneNumberAssignmentByProfileService(this._client.WithOptions(modifier));
    }

    public PhoneNumberAssignmentByProfileService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PhoneNumberAssignmentByProfileServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberAssignmentByProfileAssignResponse> Assign(
        PhoneNumberAssignmentByProfileAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Assign(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse> ListPhoneNumberStatus(
        PhoneNumberAssignmentByProfileListPhoneNumberStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListPhoneNumberStatus(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse> ListPhoneNumberStatus(
        string taskID,
        PhoneNumberAssignmentByProfileListPhoneNumberStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListPhoneNumberStatus(parameters with{
            TaskID = taskID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse> RetrievePhoneNumberStatus(
        PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrievePhoneNumberStatus(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse> RetrievePhoneNumberStatus(
        string taskID,
        PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrievePhoneNumberStatus(parameters with{
            TaskID = taskID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberAssignmentByProfileRetrieveStatusResponse> RetrieveStatus(
        PhoneNumberAssignmentByProfileRetrieveStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveStatus(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberAssignmentByProfileRetrieveStatusResponse> RetrieveStatus(
        string taskID,
        PhoneNumberAssignmentByProfileRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveStatus(parameters with{
            TaskID = taskID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PhoneNumberAssignmentByProfileServiceWithRawResponse : IPhoneNumberAssignmentByProfileServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPhoneNumberAssignmentByProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhoneNumberAssignmentByProfileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PhoneNumberAssignmentByProfileServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberAssignmentByProfileAssignResponse>> Assign(
        PhoneNumberAssignmentByProfileAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PhoneNumberAssignmentByProfileAssignParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<PhoneNumberAssignmentByProfileAssignResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse>> ListPhoneNumberStatus(
        PhoneNumberAssignmentByProfileListPhoneNumberStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TaskID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.TaskID' cannot be null"
            );
        }

        HttpRequest<PhoneNumberAssignmentByProfileListPhoneNumberStatusParams> request = new(

        )
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberAssignmentByProfileListPhoneNumberStatusResponse>> ListPhoneNumberStatus(
        string taskID,
        PhoneNumberAssignmentByProfileListPhoneNumberStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListPhoneNumberStatus(parameters with{
            TaskID = taskID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse>> RetrievePhoneNumberStatus(
        PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TaskID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.TaskID' cannot be null"
            );
        }

        HttpRequest<PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusParams> request = new(

        )
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusResponse>> RetrievePhoneNumberStatus(
        string taskID,
        PhoneNumberAssignmentByProfileRetrievePhoneNumberStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrievePhoneNumberStatus(parameters with{
            TaskID = taskID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberAssignmentByProfileRetrieveStatusResponse>> RetrieveStatus(
        PhoneNumberAssignmentByProfileRetrieveStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TaskID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.TaskID' cannot be null"
            );
        }

        HttpRequest<PhoneNumberAssignmentByProfileRetrieveStatusParams> request = new(

        )
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<PhoneNumberAssignmentByProfileRetrieveStatusResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberAssignmentByProfileRetrieveStatusResponse>> RetrieveStatus(
        string taskID,
        PhoneNumberAssignmentByProfileRetrieveStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveStatus(parameters with{
            TaskID = taskID
        }, cancellationToken);
    }
}