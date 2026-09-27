using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Rcs.Agents.TestDevices;

namespace Telnyx.Sdk.Services.Rcs.Agents;

/// <inheritdoc/>
public sealed class TestDeviceService : ITestDeviceService
{
    readonly Lazy<ITestDeviceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITestDeviceServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ITestDeviceService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new TestDeviceService(this._client.WithOptions(modifier)); }

    public TestDeviceService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new TestDeviceServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<TestDeviceResponse> Create(
        TestDeviceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TestDeviceResponse> Create(
        string id,
        TestDeviceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<TestDeviceResponse>> List(
        TestDeviceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<List<TestDeviceResponse>> List(
        string id,
        TestDeviceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        TestDeviceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string testDeviceID,
        TestDeviceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with{
            TestDeviceID = testDeviceID
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TestDeviceServiceWithRawResponse : ITestDeviceServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITestDeviceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TestDeviceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TestDeviceServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<TestDeviceResponse>> Create(
        TestDeviceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<TestDeviceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var testDeviceResponse = await response.Deserialize<TestDeviceResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                testDeviceResponse.Validate();
            }
            return testDeviceResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TestDeviceResponse>> Create(
        string id,
        TestDeviceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<TestDeviceResponse>>> List(
        TestDeviceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<TestDeviceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var testDeviceResponses = await response.Deserialize<List<TestDeviceResponse>>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                foreach (var item in testDeviceResponses)
                {
                    item.Validate();
                }
            }
            return testDeviceResponses;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<List<TestDeviceResponse>>> List(
        string id,
        TestDeviceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        TestDeviceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TestDeviceID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.TestDeviceID' cannot be null"
            );
        }

        HttpRequest<TestDeviceDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string testDeviceID,
        TestDeviceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            TestDeviceID = testDeviceID
        }, cancellationToken);
    }
}