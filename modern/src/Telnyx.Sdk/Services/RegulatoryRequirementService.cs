using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.RegulatoryRequirements;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class RegulatoryRequirementService : IRegulatoryRequirementService
{
    readonly Lazy<IRegulatoryRequirementServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRegulatoryRequirementServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IRegulatoryRequirementService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RegulatoryRequirementService(this._client.WithOptions(modifier));
    }

    public RegulatoryRequirementService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new RegulatoryRequirementServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<RegulatoryRequirementRetrieveResponse> Retrieve(
        RegulatoryRequirementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RegulatoryRequirementServiceWithRawResponse : IRegulatoryRequirementServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRegulatoryRequirementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RegulatoryRequirementServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RegulatoryRequirementServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<RegulatoryRequirementRetrieveResponse>> Retrieve(
        RegulatoryRequirementRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RegulatoryRequirementRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var regulatoryRequirement = await response.Deserialize<RegulatoryRequirementRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                regulatoryRequirement.Validate();
            }
            return regulatoryRequirement;
        });
    }
}