using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.InfringementClaims;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class InfringementClaimService : IInfringementClaimService
{
    readonly Lazy<IInfringementClaimServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInfringementClaimServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IInfringementClaimService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new InfringementClaimService(this._client.WithOptions(modifier)); }

    public InfringementClaimService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new InfringementClaimServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<InfringementClaimWrapped> Retrieve(
        InfringementClaimRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<InfringementClaimWrapped> Retrieve(
        string claimID,
        InfringementClaimRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ClaimID = claimID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InfringementClaimWrapped> Contest(
        InfringementClaimContestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Contest(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<InfringementClaimWrapped> Contest(
        string claimID,
        InfringementClaimContestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Contest(parameters with{
            ClaimID = claimID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class InfringementClaimServiceWithRawResponse : IInfringementClaimServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInfringementClaimServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InfringementClaimServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InfringementClaimServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<InfringementClaimWrapped>> Retrieve(
        InfringementClaimRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ClaimID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ClaimID' cannot be null"
            );
        }

        HttpRequest<InfringementClaimRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var infringementClaimWrapped = await response.Deserialize<InfringementClaimWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                infringementClaimWrapped.Validate();
            }
            return infringementClaimWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<InfringementClaimWrapped>> Retrieve(
        string claimID,
        InfringementClaimRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ClaimID = claimID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InfringementClaimWrapped>> Contest(
        InfringementClaimContestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ClaimID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ClaimID' cannot be null"
            );
        }

        HttpRequest<InfringementClaimContestParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var infringementClaimWrapped = await response.Deserialize<InfringementClaimWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                infringementClaimWrapped.Validate();
            }
            return infringementClaimWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<InfringementClaimWrapped>> Contest(
        string claimID,
        InfringementClaimContestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Contest(parameters with{
            ClaimID = claimID
        }, cancellationToken);
    }
}