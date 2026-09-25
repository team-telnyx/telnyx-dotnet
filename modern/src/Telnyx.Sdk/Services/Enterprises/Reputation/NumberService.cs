using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Enterprises.Reputation.Numbers;

namespace Telnyx.Sdk.Services.Enterprises.Reputation;

/// <inheritdoc/>
public sealed class NumberService : INumberService
{
    readonly Lazy<INumberServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INumberServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public INumberService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new NumberService(this._client.WithOptions(modifier)); }

    public NumberService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new NumberServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ReputationPhoneNumberWithReputation> Retrieve(
        NumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ReputationPhoneNumberWithReputation> Retrieve(
        string phoneNumber,
        NumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NumberListPage> List(
        NumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NumberListPage> List(
        string enterpriseID,
        NumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ReputationPhoneNumberList> Associate(
        NumberAssociateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Associate(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ReputationPhoneNumberList> Associate(
        string enterpriseID,
        NumberAssociateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Associate(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Disassociate(
        NumberDisassociateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Disassociate(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Disassociate(
        string phoneNumber,
        NumberDisassociateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Disassociate(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NumberRefreshResponse> Refresh(
        NumberRefreshParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Refresh(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<NumberRefreshResponse> Refresh(
        string enterpriseID,
        NumberRefreshParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Refresh(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class NumberServiceWithRawResponse : INumberServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public INumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NumberServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NumberServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReputationPhoneNumberWithReputation>> Retrieve(
        NumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<NumberRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var reputationPhoneNumberWithReputation = await response.Deserialize<ReputationPhoneNumberWithReputation>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                reputationPhoneNumberWithReputation.Validate();
            }
            return reputationPhoneNumberWithReputation;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ReputationPhoneNumberWithReputation>> Retrieve(
        string phoneNumber,
        NumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberListPage>> List(
        NumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnterpriseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EnterpriseID' cannot be null"
            );
        }

        HttpRequest<NumberListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<ReputationPhoneNumberList>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new NumberListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NumberListPage>> List(
        string enterpriseID,
        NumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReputationPhoneNumberList>> Associate(
        NumberAssociateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnterpriseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EnterpriseID' cannot be null"
            );
        }

        HttpRequest<NumberAssociateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var reputationPhoneNumberList = await response.Deserialize<ReputationPhoneNumberList>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                reputationPhoneNumberList.Validate();
            }
            return reputationPhoneNumberList;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ReputationPhoneNumberList>> Associate(
        string enterpriseID,
        NumberAssociateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Associate(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Disassociate(
        NumberDisassociateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PhoneNumber' cannot be null"
            );
        }

        HttpRequest<NumberDisassociateParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Disassociate(
        string phoneNumber,
        NumberDisassociateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Disassociate(parameters with{
            PhoneNumber = phoneNumber
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NumberRefreshResponse>> Refresh(
        NumberRefreshParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnterpriseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EnterpriseID' cannot be null"
            );
        }

        HttpRequest<NumberRefreshParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<NumberRefreshResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<NumberRefreshResponse>> Refresh(
        string enterpriseID,
        NumberRefreshParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Refresh(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }
}