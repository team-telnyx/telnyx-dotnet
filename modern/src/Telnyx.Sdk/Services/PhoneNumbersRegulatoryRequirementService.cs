using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PhoneNumbersRegulatoryRequirements;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class PhoneNumbersRegulatoryRequirementService : IPhoneNumbersRegulatoryRequirementService
{
    readonly Lazy<IPhoneNumbersRegulatoryRequirementServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPhoneNumbersRegulatoryRequirementServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPhoneNumbersRegulatoryRequirementService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhoneNumbersRegulatoryRequirementService(this._client.WithOptions(modifier));
    }

    public PhoneNumbersRegulatoryRequirementService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PhoneNumbersRegulatoryRequirementServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<PhoneNumbersRegulatoryRequirementRetrieveResponse> Retrieve(
        PhoneNumbersRegulatoryRequirementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PhoneNumbersRegulatoryRequirementServiceWithRawResponse : IPhoneNumbersRegulatoryRequirementServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPhoneNumbersRegulatoryRequirementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhoneNumbersRegulatoryRequirementServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PhoneNumbersRegulatoryRequirementServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumbersRegulatoryRequirementRetrieveResponse>> Retrieve(
        PhoneNumbersRegulatoryRequirementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PhoneNumbersRegulatoryRequirementRetrieveParams> request = new(

        )
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var phoneNumbersRegulatoryRequirement = await response.Deserialize<PhoneNumbersRegulatoryRequirementRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                phoneNumbersRegulatoryRequirement.Validate();
            }
            return phoneNumbersRegulatoryRequirement;
        });
    }
}