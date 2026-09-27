using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.NumberOrderPhoneNumbers;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class NumberOrderPhoneNumberService : INumberOrderPhoneNumberService
{
    readonly Lazy<INumberOrderPhoneNumberServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INumberOrderPhoneNumberServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public INumberOrderPhoneNumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NumberOrderPhoneNumberService(this._client.WithOptions(modifier));
    }

    public NumberOrderPhoneNumberService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new NumberOrderPhoneNumberServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<NumberOrderPhoneNumberRetrieveResponse> Retrieve(
        NumberOrderPhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NumberOrderPhoneNumberRetrieveResponse> Retrieve(
        string numberOrderPhoneNumberID,
        NumberOrderPhoneNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            NumberOrderPhoneNumberID = numberOrderPhoneNumberID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NumberOrderPhoneNumberListResponse> List(
        NumberOrderPhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NumberOrderPhoneNumberUpdateRequirementGroupResponse> UpdateRequirementGroup(
        NumberOrderPhoneNumberUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.UpdateRequirementGroup(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NumberOrderPhoneNumberUpdateRequirementGroupResponse> UpdateRequirementGroup(
        string id,
        NumberOrderPhoneNumberUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateRequirementGroup(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NumberOrderPhoneNumberUpdateRequirementsResponse> UpdateRequirements(
        NumberOrderPhoneNumberUpdateRequirementsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.UpdateRequirements(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NumberOrderPhoneNumberUpdateRequirementsResponse> UpdateRequirements(
        string numberOrderPhoneNumberID,
        NumberOrderPhoneNumberUpdateRequirementsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateRequirements(parameters with{
            NumberOrderPhoneNumberID = numberOrderPhoneNumberID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class NumberOrderPhoneNumberServiceWithRawResponse : INumberOrderPhoneNumberServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public INumberOrderPhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NumberOrderPhoneNumberServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NumberOrderPhoneNumberServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberOrderPhoneNumberRetrieveResponse>> Retrieve(
        NumberOrderPhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.NumberOrderPhoneNumberID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.NumberOrderPhoneNumberID' cannot be null"
            );
        }

        HttpRequest<NumberOrderPhoneNumberRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var numberOrderPhoneNumber = await response.Deserialize<NumberOrderPhoneNumberRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                numberOrderPhoneNumber.Validate();
            }
            return numberOrderPhoneNumber;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NumberOrderPhoneNumberRetrieveResponse>> Retrieve(
        string numberOrderPhoneNumberID,
        NumberOrderPhoneNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            NumberOrderPhoneNumberID = numberOrderPhoneNumberID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberOrderPhoneNumberListResponse>> List(
        NumberOrderPhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NumberOrderPhoneNumberListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var numberOrderPhoneNumbers = await response.Deserialize<NumberOrderPhoneNumberListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                numberOrderPhoneNumbers.Validate();
            }
            return numberOrderPhoneNumbers;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberOrderPhoneNumberUpdateRequirementGroupResponse>> UpdateRequirementGroup(
        NumberOrderPhoneNumberUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<NumberOrderPhoneNumberUpdateRequirementGroupParams> request = new(

        )
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<NumberOrderPhoneNumberUpdateRequirementGroupResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NumberOrderPhoneNumberUpdateRequirementGroupResponse>> UpdateRequirementGroup(
        string id,
        NumberOrderPhoneNumberUpdateRequirementGroupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateRequirementGroup(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberOrderPhoneNumberUpdateRequirementsResponse>> UpdateRequirements(
        NumberOrderPhoneNumberUpdateRequirementsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.NumberOrderPhoneNumberID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.NumberOrderPhoneNumberID' cannot be null"
            );
        }

        HttpRequest<NumberOrderPhoneNumberUpdateRequirementsParams> request = new(

        )
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<NumberOrderPhoneNumberUpdateRequirementsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NumberOrderPhoneNumberUpdateRequirementsResponse>> UpdateRequirements(
        string numberOrderPhoneNumberID,
        NumberOrderPhoneNumberUpdateRequirementsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateRequirements(parameters with{
            NumberOrderPhoneNumberID = numberOrderPhoneNumberID
        }, cancellationToken);
    }
}