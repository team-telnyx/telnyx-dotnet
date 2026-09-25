using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Dir.PhoneNumbers;

namespace Telnyx.Sdk.Services.Dir;

/// <inheritdoc/>
public sealed class PhoneNumberService : IPhoneNumberService
{
    readonly Lazy<IPhoneNumberServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPhoneNumberServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPhoneNumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new PhoneNumberService(this._client.WithOptions(modifier)); }

    public PhoneNumberService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PhoneNumberServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberListPage> List(
        PhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberListPage> List(
        string dirID,
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberAddResponse> Add(
        PhoneNumberAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Add(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberAddResponse> Add(
        string dirID,
        PhoneNumberAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberRemoveResponse> Remove(
        PhoneNumberRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Remove(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PhoneNumberRemoveResponse> Remove(
        string dirID,
        PhoneNumberRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with{
            DirID = dirID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PhoneNumberServiceWithRawResponse : IPhoneNumberServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhoneNumberServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PhoneNumberServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberListPage>> List(
        PhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DirID' cannot be null"
            );
        }

        HttpRequest<PhoneNumberListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PhoneNumberListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new PhoneNumberListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberListPage>> List(
        string dirID,
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberAddResponse>> Add(
        PhoneNumberAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DirID' cannot be null"
            );
        }

        HttpRequest<PhoneNumberAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<PhoneNumberAddResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberAddResponse>> Add(
        string dirID,
        PhoneNumberAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberRemoveResponse>> Remove(
        PhoneNumberRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DirID' cannot be null"
            );
        }

        HttpRequest<PhoneNumberRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var phoneNumber = await response.Deserialize<PhoneNumberRemoveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                phoneNumber.Validate();
            }
            return phoneNumber;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberRemoveResponse>> Remove(
        string dirID,
        PhoneNumberRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with{
            DirID = dirID
        }, cancellationToken);
    }
}