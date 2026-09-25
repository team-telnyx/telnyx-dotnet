using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.CustomerServiceRecords;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class CustomerServiceRecordService : ICustomerServiceRecordService
{
    readonly Lazy<ICustomerServiceRecordServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICustomerServiceRecordServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ICustomerServiceRecordService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CustomerServiceRecordService(this._client.WithOptions(modifier));
    }

    public CustomerServiceRecordService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CustomerServiceRecordServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
    }

    /// <inheritdoc/>
    public async Task<CustomerServiceRecordCreateResponse> Create(
        CustomerServiceRecordCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CustomerServiceRecordRetrieveResponse> Retrieve(
        CustomerServiceRecordRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CustomerServiceRecordRetrieveResponse> Retrieve(
        string customerServiceRecordID,
        CustomerServiceRecordRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            CustomerServiceRecordID = customerServiceRecordID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomerServiceRecordListPage> List(
        CustomerServiceRecordListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CustomerServiceRecordVerifyPhoneNumberCoverageResponse> VerifyPhoneNumberCoverage(
        CustomerServiceRecordVerifyPhoneNumberCoverageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.VerifyPhoneNumberCoverage(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CustomerServiceRecordServiceWithRawResponse : ICustomerServiceRecordServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICustomerServiceRecordServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CustomerServiceRecordServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CustomerServiceRecordServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerServiceRecordCreateResponse>> Create(
        CustomerServiceRecordCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CustomerServiceRecordCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var customerServiceRecord = await response.Deserialize<CustomerServiceRecordCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                customerServiceRecord.Validate();
            }
            return customerServiceRecord;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerServiceRecordRetrieveResponse>> Retrieve(
        CustomerServiceRecordRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerServiceRecordID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.CustomerServiceRecordID' cannot be null"
            );
        }

        HttpRequest<CustomerServiceRecordRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var customerServiceRecord = await response.Deserialize<CustomerServiceRecordRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                customerServiceRecord.Validate();
            }
            return customerServiceRecord;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CustomerServiceRecordRetrieveResponse>> Retrieve(
        string customerServiceRecordID,
        CustomerServiceRecordRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            CustomerServiceRecordID = customerServiceRecordID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerServiceRecordListPage>> List(
        CustomerServiceRecordListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CustomerServiceRecordListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<CustomerServiceRecordListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new CustomerServiceRecordListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerServiceRecordVerifyPhoneNumberCoverageResponse>> VerifyPhoneNumberCoverage(
        CustomerServiceRecordVerifyPhoneNumberCoverageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CustomerServiceRecordVerifyPhoneNumberCoverageParams> request = new(

        )
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<CustomerServiceRecordVerifyPhoneNumberCoverageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}